using IMS.Api.Common.Model.Params;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.ResponseModel;

namespace IMS.Api.Core.CoreService
{
    public interface IAuthenticationCore
    {
        Task<APIResponse> Login(LoginRequest  loginRequest);
        Task<APIResponse> Register(RegisterRequest  registerRequest);
        Task<APIResponse> ForgotPassword(string emailAddress);
        APIResponse GetOTP(string emailAddress);
        APIResponse VerifyOTP(OTPVerificationRequestModel model);
    }
}
