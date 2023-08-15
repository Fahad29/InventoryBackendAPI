using IMS.Api.Common.Model;
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
    }
}
