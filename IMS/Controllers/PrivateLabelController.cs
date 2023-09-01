using IMS.Api.Common.Model;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.Params;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.RequestModel.SearchModel;
using IMS.Api.Core.CoreService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oculus.Extensions;

namespace IMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrivateLabelController : BaseController
    {
        readonly IPrivateLabelCore _PrivateLabelCore;
        public PrivateLabelController(IPrivateLabelCore PrivateLabelCore, APIResponse apiResponse)
        {
            _PrivateLabelCore = PrivateLabelCore;
        }

        [AllowAnonymous, HttpPost, Route("Search")]
        public async Task<IActionResult> Search(PrivateLabelSearchRequestModel model)
        {
            try
            {
                APIResponse response = await _PrivateLabelCore.Search(model);
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
        public async Task<IActionResult> GetById(int PrivateLabelId)
        {
            try
            {
                APIResponse response = await _PrivateLabelCore.GetById(PrivateLabelId);
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
        public async Task<IActionResult> Create(PrivateLabelCreateRequestModel PrivateLabelRequest)
        {
            try
            {
                APIResponse response = await _PrivateLabelCore.Create(PrivateLabelRequest, new Params() { ContentRootPath = APIConfig.ContentRootPath, UserId = User.GetUserId() });
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
        public async Task<IActionResult> Update(PrivateLabelUpdateRequestModel PrivateLabelRequest)
        {
            try
            {
                APIResponse response = await _PrivateLabelCore.Update(PrivateLabelRequest, new Params() { ContentRootPath = APIConfig.ContentRootPath, UserId = User.GetUserId() });
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
        public async Task<IActionResult> Delete(int PrivateLabelId)
        {
            try
            {
                APIResponse response = await _PrivateLabelCore.Delete(PrivateLabelId, new Params() { ContentRootPath = AppConfig.ContentRootPath, UserId = User.GetUserId() });
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
