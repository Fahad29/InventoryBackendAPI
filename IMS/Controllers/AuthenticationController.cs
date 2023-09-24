using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.Params;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.ResponseModel;
using IMS.Api.Core.CoreService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        readonly IAuthenticationCore _authenticationCore;
        public AuthenticationController(IAuthenticationCore authenticationCore)
        {
            _authenticationCore = authenticationCore;
        }

        [AllowAnonymous, HttpPost, Route("Login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            try
            {
                APIResponse response = await _authenticationCore.Login(loginRequest);
                    if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
       
        [AllowAnonymous, HttpPost, Route("Register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            try
            {
                APIResponse response = await _authenticationCore.Register(registerRequest);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
       
        [AllowAnonymous, HttpGet, Route("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(string emailAddress)
        {
            try
            {
                APIResponse response = await _authenticationCore.ForgotPassword(emailAddress);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [AllowAnonymous, HttpGet, Route("GetOTP")]
        public IActionResult GetOTP(string emailAddress)
        {
            try
            {
                APIResponse response = _authenticationCore.GetOTP(emailAddress);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [AllowAnonymous, HttpPost, Route("VerifyOTP")]
        public IActionResult VerifyOTP(OTPVerificationRequestModel model)
        {
            try
            {
                APIResponse response = _authenticationCore.VerifyOTP(model);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
