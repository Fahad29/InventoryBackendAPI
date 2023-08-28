using IMS.Api.Common.Model;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.Params;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Core.CoreService;
using IMS.Api.Core.ICoreService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oculus.Extensions;

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
        public async Task<IActionResult> Search(BaseFilter model)
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
                throw;
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
                throw;
            }
        }

        [AllowAnonymous, HttpPost, Route("Create")]
        public async Task<IActionResult> Create(BranchRequestModel model)
        {
            try
            {
                APIResponse response = await _branchCore.Create(model, new Params() { ContentRootPath = AppConfig.ContentRootPath, UserId = User.GetUserId() });
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
        public async Task<IActionResult> Update(BranchRequestModel model)
        {
            try
            {
                APIResponse response = await _branchCore.Update(model, new Params() { ContentRootPath = AppConfig.ContentRootPath, UserId = User.GetUserId() });
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
        public async Task<IActionResult> Delete(int branchId)
        {
            try
            {
                APIResponse response = await _branchCore.Delete(branchId, new Params() { ContentRootPath = AppConfig.ContentRootPath, UserId = User.GetUserId() });
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [AllowAnonymous, HttpGet, Route("DropDown")]
        public async Task<IActionResult> DropDown(int? CompanyId)
        {
            try
            {
                APIResponse response = await _branchCore.DropDown(CompanyId);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [AllowAnonymous, HttpGet, Route("TotalCount")]
        public async Task<IActionResult> TotalCount(int? CompanyId)
        {
            try
            {
                APIResponse response = await _branchCore.TotalCount(CompanyId);
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
