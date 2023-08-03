using IMS.Api.Common.Model;

namespace IMS.Api.Core.CoreService
{
    public interface IAuthenticationCore
    {
        Task<APIResponse> Login(LoginRequest  loginRequest);
        Task<APIResponse> Register(RegisterRequest  registerRequest);
        Task<APIResponse> ForgotPassword(string emailAddress);
    }
}
