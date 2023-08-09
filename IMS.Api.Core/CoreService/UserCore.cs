using IMS.Api.Common.Constant;
using IMS.Api.Common.Extensions;
using IMS.Api.Common.Model;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.DataModel;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Core.ICoreService;
using IMS.Api.Service.IRepository;
using System.Net;

namespace IMS.Api.Core.CoreService
{
    public  class UserCore :IUserCore
    {
        IRepository<User> _iRepository;
        APIResponse _apiResponse;
        public UserCore(IRepository<User> iRepository, APIResponse apiResponse)
        {
            _iRepository = iRepository;
            _apiResponse = apiResponse;
        }

        public async Task<APIResponse> GetAll()
        {
            APIConfig.Log.Debug("CALLING API\" company Get all \"  STARTED");
            try
            {
                Object obj = new
                {

                };
                List<User> users = _iRepository.Search(obj, Constant.SpGetCompany).ToList();
                if (users.Count > 0)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, users);

                }
                else
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, null);
                }


            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> GetById(int CompanyId)
        {
            APIConfig.Log.Debug("CALLING API\" company GetById \"  STARTED");
            try
            {
                User user = _iRepository.Search(new { CompanyId = CompanyId }, Constant.SpGetCompany).FirstOrDefault();
                if (user != null)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, user);
                }
                else
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, null);
                }
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> Create(UserRequest model)
        {
            APIConfig.Log.Debug("CALLING API\" company create \"  STARTED");
            try
            {
                User user = model.MapTo<User>();
                //user.CreatedBy = @params.UserId;
                user = _iRepository.CreateSP<User>(user, Constant.SpCreateCompany);
                return _apiResponse.ReturnResponse(HttpStatusCode.Created, user);
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> Update(UserRequest model)
        {
            try
            {
                APIConfig.Log.Debug("CALLING API\" company update \"  STARTED");
                User user = model.MapTo<User>();
                //company.UpdatedBy = @params.UserId;
                user = _iRepository.CreateSP<User>(user, Constant.SpUpdateCompany);
                return _apiResponse.ReturnResponse(HttpStatusCode.OK, user);

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> Delete(int UserId)
        {
            APIConfig.Log.Debug("CALLING API\" company delete \"  STARTED");
            try
            {
                User user = _iRepository.CreateSP<User>(new { UsersId = UserId }, Constant.SpGetCompany);
                if (user == null)
                {
                    user.IsActive = false;
                    //company.IsDeleted = Constant.True;
                    //company.UpdatedBy = @params.UserId;
                    user = _iRepository.CreateSP<User>(user, Constant.SpUpdateCompany);
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, user);
                }
                else
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, null);
                }

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }

        }
    }
}
