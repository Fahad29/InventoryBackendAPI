using IMS.Api.Common.Model;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.Params;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Core.CoreService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oculus.Extensions;

namespace IMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseController
    {
        readonly ICustomerCore _CustomerCore;
        public CustomerController(ICustomerCore CustomerCore, APIResponse apiResponse)
        {
            _CustomerCore = CustomerCore;
        }

        [AllowAnonymous, HttpPost, Route("Search")]
        public async Task<IActionResult> Search(BaseFilter model)
        {
            try
            {
                APIResponse response = await _CustomerCore.Search(model);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [AllowAnonymous, HttpGet, Route("GetById")]
        public async Task<IActionResult> GetById(int CustomerId)
        {
            try
            {
                APIResponse response = await _CustomerCore.GetById(CustomerId);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [AllowAnonymous, HttpPost, Route("Create")]
        public async Task<IActionResult> Create(CustomerCreateRequestModel CustomerRequest)
        {
            try
            {
                APIResponse response = await _CustomerCore.Create(CustomerRequest, new Params() { ContentRootPath = AppConfig.ContentRootPath, UserId = User.GetUserId() });
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [AllowAnonymous, HttpPut, Route("Update")]
        public async Task<IActionResult> Update(CustomerUpdateRequestModel CustomerRequest)
        {
            try
            {
                APIResponse response = await _CustomerCore.Update(CustomerRequest, new Params() { ContentRootPath = AppConfig.ContentRootPath, UserId = User.GetUserId() });
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [AllowAnonymous, HttpDelete, Route("Delete")]
        public async Task<IActionResult> Delete(int CustomerId)
        {
            try
            {
                APIResponse response = await _CustomerCore.Delete(CustomerId, new Params() { ContentRootPath = AppConfig.ContentRootPath, UserId = User.GetUserId() });
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
