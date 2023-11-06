using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.ResponseModel;

namespace IMS.Api.Core.ICoreService
{
    public interface IAuthenticationCore
    {
        Task<APIResponse> Login(LoginRequest loginRequest);
        Task<APIResponse> Register(RegisterRequest registerRequest);
        Task<APIResponse> ForgotPassword(string emailAddress);
        Task<APIResponse> ResetPassword(ResetPasswordRequest model);
        APIResponse GetOTP(string emailAddress);
        APIResponse VerifyOTP(OTPVerificationRequestModel model);
        Task<APIResponse> ChangePassword(ChangePasswordRequest model);
    }
}
