using IMS.Api.Common.Constant;
using IMS.Api.Common.Extensions;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.DataModel;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.ResponseModel;
using IMS.Api.Core.ICoreService;
using IMS.Api.Service.IRepository;
using System.Net;

namespace IMS.Api.Core.CoreService
{
    public class UserCore : IUserCore
    {
        IRepository<User> _iRepository;
        APIResponse _apiResponse;
        public UserCore(IRepository<User> iRepository, APIResponse apiResponse)
        {
            _iRepository = iRepository;
            _apiResponse = apiResponse;
        }

        public async Task<APIResponse> Search(UserSearchRequestModel model)
        {
            APIConfig.Log.Debug("CALLING API\" user Get all \"  STARTED");
            try
            {
                model.CompanyId = APIConfig.CompanyId;
                GridData response = await _iRepository.SearchMuiltiple(model, Constant.SpGetUser);
                // Access the data from the result

                if (response.DataList.Count() > 0)
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, response);
                else
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, Constant.RecordNotFound);



            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        public async Task<APIResponse> GetById(int Id)
        {
            APIConfig.Log.Debug("CALLING API\" user GetById \"  STARTED");
            try
            {
                User user = _iRepository.Search(new { Id = Id }, Constant.SpGetUserById).FirstOrDefault();
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
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        public async Task<APIResponse> Create(UserCreateRequestModel model)
        {
            APIConfig.Log.Debug("CALLING API\" user create \"  STARTED");
            try
            {
                int? Id = _iRepository.CreateSP<User>(new { UserName = model?.Email }, Constant.SpUserLogin)?.UserId;
                if (Id > 0 || Id != null)
                {
                    _apiResponse.StatusCode = HttpStatusCode.Conflict;
                    return _apiResponse.ReturnResponse(HttpStatusCode.Conflict, Constant.EmailALreadyInUse);
                }
                else
                {
                    User user = model.MapTo<User>();
                    user.PasswordHash = model?.PasswordHash?.MD5Encrypt();
                    UserResponseModel userResponseModel = _iRepository.CreateSP<UserResponseModel>(user, Constant.SpCreateUser);
                    return _apiResponse.ReturnResponse(HttpStatusCode.Created, userResponseModel);
                }

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        public async Task<APIResponse> Update(UserUpdateRequestModel model)
        {
            try
            {
                APIConfig.Log.Debug("CALLING API\" user update \"  STARTED");
                int? Id = _iRepository.CreateSP<User>(new { Id = model?.UserId }, Constant.SpUserLogin)?.UserId;
                if (Id > 0)
                {
                    User user = model.MapTo<User>();
                    UserResponseModel userResponseModel = _iRepository.CreateSP<UserResponseModel>(user, Constant.SpUpdateUser);
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, userResponseModel);
                }
                else
                {
                    _apiResponse.StatusCode = HttpStatusCode.NotFound;
                    return _apiResponse.ReturnResponse(HttpStatusCode.NotFound, Constant.RecordNotFound);
                }

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        public async Task<APIResponse> StatusUpdate(UserStatusUpdateRequestModel model)
        {
            try
            {
                APIConfig.Log.Debug("CALLING API\" user status update \"  STARTED");
                int? Id = _iRepository.CreateSP<User>(new { Id = model?.UserId }, Constant.SpUserLogin)?.UserId;
                if (Id > 0)
                {
                    UserResponseModel userResponseModel = _iRepository.CreateSP<UserResponseModel>(model, Constant.SpUserStatusUpdate);
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, userResponseModel);
                }
                else
                {
                    _apiResponse.StatusCode = HttpStatusCode.NotFound;
                    return _apiResponse.ReturnResponse(HttpStatusCode.NotFound, Constant.RecordNotFound);
                }

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        public async Task<APIResponse> Delete(int Id)
        {
            APIConfig.Log.Debug("CALLING API\" User delete \"  STARTED");
            try
            {
                if (Id > 0)
                {

                    _iRepository.CreateSP<User>(new { UserId = Id, UpdatedBy = APIConfig.UserId }, Constant.SpDeleteUser);
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, Constant.DeleteRecord);
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
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }
        

    }
}
