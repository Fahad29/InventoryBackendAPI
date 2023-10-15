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
    public class VendorController : ControllerBase
    {

        readonly IVendorCore _vendorCore;
        public VendorController(IVendorCore endorCore)
        {
            _vendorCore = endorCore;
        }

        [AllowAnonymous, HttpPost, Route("Search")]
        public async Task<IActionResult> Search(BranchSearchRequestModel model)
        {
            try
            {
                APIResponse response = await _vendorCore.Search(model);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [AllowAnonymous, HttpGet, Route("GetById")]
        public async Task<IActionResult> GetById(int vendorId)
        {
            try
            {
                APIResponse response = await _vendorCore.GetById(vendorId);
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
        public async Task<IActionResult> Create(BranchCreateRequestModel model)
        {
            try
            {
                APIResponse response = await _vendorCore.Create(model);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [AllowAnonymous, HttpPut, Route("Update")]
        public async Task<IActionResult> Update(BranchUpdateRequestModel model)
        {
            try
            {
                APIResponse response = await _vendorCore.Update(model);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [AllowAnonymous, HttpDelete, Route("Delete")]
        public async Task<IActionResult> Delete(int vendorId)
        {
            try
            {
                APIResponse response = await _vendorCore.Delete(vendorId);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                return BadRequest(ex);
            }
        }
    }
}
