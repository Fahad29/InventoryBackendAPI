using IMS.Api.Common.Constant;
using IMS.Api.Common.Model;
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
                //_iRepository.ExecuteQuery<>()
                return _apiResponse.ReturnResponse(HttpStatusCode.OK, _apiResponse);
                //return apiResponse.ReturnResponse(HttpStatusCode.BadRequest, "Invalid Credentials");
            }
            catch (Exception ex)
            {
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        public async Task<APIResponse> Register(RegisterRequest registerRequest)
        {
            try
            {
                 _iRepository.CreateSP<RegisterRequest>(registerRequest, Constant.SpCreateCompany);
                return _apiResponse.ReturnResponse(HttpStatusCode.OK, _apiResponse);
                //return apiResponse.ReturnResponse(HttpStatusCode.BadRequest, "Invalid Credentials");
            }
            catch (Exception ex)
            {
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        public async Task<APIResponse> ForgotPassword(string Email)
        {
            try
            {
                return _apiResponse.ReturnResponse(HttpStatusCode.OK, _apiResponse);
                //return apiResponse.ReturnResponse(HttpStatusCode.BadRequest, "Invalid Credentials");
            }
            catch (Exception ex)
            {
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
