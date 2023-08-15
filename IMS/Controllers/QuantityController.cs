using IMS.Api.Common.Model;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Core.ICoreService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuantityController : ControllerBase
    {

        readonly IQuantityCore _quantityCore;
        public QuantityController(IQuantityCore quantityCore)
        {
            _quantityCore = quantityCore;
        }

        [AllowAnonymous, HttpGet, Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                APIResponse response = await _quantityCore.GetAll();
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
        public async Task<IActionResult> Create(QuantityRequestModel quantityRequest)
        {
            try
            {
                APIResponse response = await _quantityCore.Create(quantityRequest);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [AllowAnonymous, HttpDelete, Route("Delete")]
        public async Task<IActionResult> Delete(int QuantityId)
        {
            try
            {
                APIResponse response = await _quantityCore.Delete(QuantityId);
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
