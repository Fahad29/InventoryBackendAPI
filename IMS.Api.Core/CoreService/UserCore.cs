using IMS.Api.Common.Constant;
using IMS.Api.Common.Extensions;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.DataModel;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.ResponseModel;
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

        public async Task<APIResponse> Search(BaseFilter model)
        {
            APIConfig.Log.Debug("CALLING API\" user Get all \"  STARTED");
            try
            {
                List<User> users = _iRepository.Search(model, Constant.SpGetUser).ToList();
                if (users.Count > 0)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, users);

                }
                else
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, Constant.RecordNotFound);
                }


            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> GetById(int Id)
        {
            APIConfig.Log.Debug("CALLING API\" user GetById \"  STARTED");
            try
            {
                User user = _iRepository.Search(new { Id = Id }, Constant.SpGetUser).FirstOrDefault();
                if (user != null)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, user);
                }
                else
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, Constant.RecordNotFound);
                }
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> Create(UserRequest model)
        {
            APIConfig.Log.Debug("CALLING API\" user create \"  STARTED");
            try
            {
                User user = model.MapTo<User>();
                //user.CreatedBy = @params.UserId;
                user = _iRepository.CreateSP<User>(user, Constant.SpCreateCompany);
                return _apiResponse.ReturnResponse(HttpStatusCode.Created, user);
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> Update(UserRequest model)
        {
            try
            {
                APIConfig.Log.Debug("CALLING API\" user update \"  STARTED");
                User user = model.MapTo<User>();
                //company.UpdatedBy = @params.UserId;
                user = _iRepository.CreateSP<User>(user, Constant.SpUpdateCompany);
                return _apiResponse.ReturnResponse(HttpStatusCode.OK, user);

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> Delete(int Id)
        {
            APIConfig.Log.Debug("CALLING API\" User delete \"  STARTED");
            try
            {
                if (Id > 0)
                {

                    _iRepository.CreateSP<User>(new { UserId  = Id }, Constant.SpDeleteUser);
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, Constant.DeleteRecord);
                }
                else
                {
                    return  _apiResponse.ReturnResponse(HttpStatusCode.NoContent, Constant.RecordNotFound);
                }

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        public async Task<APIResponse> TotalCount(BaseFilter model)
        {
            APIConfig.Log.Debug("CALLING API\" user TotalCount \"  STARTED");
            try
            {
                int? TotalCount = _iRepository.Search<int>(model, Constant.SpGetUserTotalCount).FirstOrDefault();
                if (TotalCount > 0)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, new { TotalCount = TotalCount });
                }
                else
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, Constant.RecordNotFound);
                }
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }


    }
}
