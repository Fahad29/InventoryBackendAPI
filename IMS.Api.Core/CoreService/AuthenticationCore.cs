using IMS.Api.Common.Constant;
using IMS.Api.Common.Extensions;
using IMS.Api.Common.Model;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.DataModel;
using IMS.Api.Core.CoreService;
using IMS.Api.Service.IRepository;
using System.Net;

namespace IMS.Api.Core.ICoreService
{
    public class AuthenticationCore : IAuthenticationCore
    {
        APIResponse _apiResponse;
        readonly IRepository<CompanyRequestModel> _iRepository;
        public AuthenticationCore(APIResponse apiResponse, IRepository<CompanyRequestModel> iRepository)
        {
            this._iRepository = iRepository;
            this._apiResponse = apiResponse;
        }

        public async Task<APIResponse> Login(LoginRequest loginRequest)
        {
            try
            {
                return _apiResponse.ReturnResponse(HttpStatusCode.OK, _apiResponse);
            }
            catch (Exception ex)
            {
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        public async Task<APIResponse> Register(RegisterRequest model)
        {
            APIConfig.Log.Debug("CALLING API\" user create \"  STARTED");
            try
            {
                Company company = new Company();
                company.CompanyName = model.CompanyName;
                company =  _iRepository.CreateSP<Company>(company, Constant.SpCreateCompany);
                if (company?.CompanyId != null && company?.CompanyId > 0)
                {
                    User user = new User();
                    user.FirstName = model?.FirstName;
                    user.LastName = model?.Lastname;
                    user.Email = model?.Email;
                    user.CompanyId = Convert.ToInt32(company?.CompanyId);
                    user.MobileNo = model?.PhoneNumber;
                    user.PasswordHash = ExtensionMethod.GenPassword();

                    user = _iRepository.CreateSP<User>(user, Constant.SpCreateUser);
                }
                _apiResponse.StatusCode = HttpStatusCode.Created;

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex);
                _apiResponse.StatusCode =  HttpStatusCode.BadRequest;
            }
            APIConfig.Log.Debug("CALLING API\" user create \"  ENDED");
            return _apiResponse.ReturnResponse(_apiResponse.StatusCode, _apiResponse.Response);
        }
        public async Task<APIResponse> ForgotPassword(string Email)
        {
            try
            {
                return _apiResponse.ReturnResponse(HttpStatusCode.OK, _apiResponse);
            }
            catch (Exception ex)
            {
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
