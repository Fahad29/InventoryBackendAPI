using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.ResponseModel;
using IMS.Api.Core.CoreService;
using IMS.Api.Core.ICoreService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IMS.Api.Common.Constant;

namespace IMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        readonly IPurchaseCore _purchaseCore;
        public PurchaseController(IPurchaseCore purchaseCore)
        {
            _purchaseCore = purchaseCore;
        }

        [AllowAnonymous, HttpPost, Route("Search")]
        public async Task<IActionResult> Search(PurchaseSearch searchModel)
        {
            try
            {
                APIResponse response = await _purchaseCore.Search(searchModel);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return BadRequest(ex);
            }
        }

        [AllowAnonymous, HttpGet, Route("GetById")]
        public async Task<IActionResult> GetById(int purchaseOrerId)
        {
            try
            {
                APIResponse response = await _purchaseCore.GetById(purchaseOrerId);
               
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return BadRequest(ex);
            }
        }

        [AllowAnonymous, HttpPost, Route("Create")]
        public async Task<IActionResult> Create(PurchaseRequestModel model)
        {
            try
            {
                APIResponse response = await _purchaseCore.Create(model);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return BadRequest(ex);
            }
        }

        [AllowAnonymous, HttpDelete, Route("Delete")]
        public async Task<IActionResult> Delete(int purchaseOrerId)
        {
            try
            {
                APIResponse response = await _purchaseCore.Delete(purchaseOrerId);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return BadRequest(ex);
            }
        }
    }
}
