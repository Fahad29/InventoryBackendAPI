using IMS.Api.Common.Model.CommonModel;
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
    public class BranchController : ControllerBase
    {
        readonly IBranchCore _branchCore;
        public BranchController(IBranchCore branchCore)
        {
            _branchCore = branchCore;
        }

        [AllowAnonymous, HttpPost, Route("Search")]
        public async Task<IActionResult> Search(BranchSearchRequestModel model)
        {
            try
            {
                APIResponse response = await _branchCore.Search(model);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Branch Controller Exception: " + ex);
                return BadRequest(ex);
            }
        }

        [AllowAnonymous, HttpGet, Route("GetById")]
        public async Task<IActionResult> GetById(int branchId)
        {
            try
            {
                APIResponse response = await _branchCore.GetById(branchId);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Branch Controller Exception: " + ex);
                return BadRequest(ex);
            }
        }

        [AllowAnonymous, HttpPost, Route("Create")]
        public async Task<IActionResult> Create(BranchCreateRequestModel model)
        {
            try
            {
                APIResponse response = await _branchCore.Create(model);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Branch Controller Exception: " + ex);
                return BadRequest(ex);
            }
        }

        [AllowAnonymous, HttpPut, Route("Update")]
        public async Task<IActionResult> Update(BranchUpdateRequestModel model)
        {
            try
            {
                APIResponse response = await _branchCore.Update(model);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Branch Controller Exception: " + ex);
                return BadRequest(ex);
            }
        }

        [AllowAnonymous, HttpDelete, Route("Delete")]
        public async Task<IActionResult> Delete(int branchId)
        {
            try
            {
                APIResponse response = await _branchCore.Delete(branchId);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Branch Controller Exception: " + ex);
                return BadRequest(ex);
            }
        }
    }
}
