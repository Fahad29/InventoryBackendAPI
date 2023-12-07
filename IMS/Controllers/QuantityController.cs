using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.ResponseModel;
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

        [AllowAnonymous, HttpPost, Route("Search")]
        public async Task<IActionResult> GetAll(QuantitySearch quantitySearch)
        {
            try
            {
                APIResponse response = await _quantityCore.GetAll(quantitySearch);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
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
                return BadRequest(ex);
            }
        }

        [AllowAnonymous, HttpPost, Route("TotalCount")]
        public async Task<IActionResult> TotalCount()
        {
            try
            {
                APIResponse response = await _quantityCore.TotalCount();
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
