using IMS.Api.Common.Constant;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.ResponseModel;
using IMS.Api.Core.ICoreService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : BaseController
    {
        readonly IWarehouseCore _warehouseCore;
        public WarehouseController(IWarehouseCore warehouseCore)
        {
            _warehouseCore = warehouseCore;
        }

        [AllowAnonymous, HttpPost, Route("Search")]
        public async Task<IActionResult> Search(WarehouseSearchRequestModel model)
        {
            try
            {
                APIResponse response = await _warehouseCore.Search(model);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Warehouse Controller Exception: " + ex);
                return BadRequest(ex);
            }
        }

        [AllowAnonymous, HttpGet, Route("GetById")]
        public async Task<IActionResult> GetById(int warehouseId)
        {
            try
            {
                if (warehouseId > 0)
                {
                    APIResponse response = await _warehouseCore.GetById(warehouseId);
                    if (response?.Response != null)
                        return Ok(response);
                }

                return BadRequest(Constant.InValidRecordId);
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Warehouse Controller Exception: " + ex);
                return BadRequest(ex);
            }
        }

        [AllowAnonymous, HttpPost, Route("Create")]
        public async Task<IActionResult> Create(WarehouseCreateRequestModel model)
        {
            try
            {
                APIResponse response = await _warehouseCore.Create(model);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Warehouse Controller Exception: " + ex);
                return BadRequest(ex);
            }
        }

        [AllowAnonymous, HttpPut, Route("Update")]
        public async Task<IActionResult> Update(WarehouseUpdateRequestModel model)
        {
            try
            {
                if (model.Id > 0)
                {
                    APIResponse response = await _warehouseCore.Update(model);
                    if (response?.Response != null)
                        return Ok(response);
                }

                return BadRequest(Constant.InValidRecordId);
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Warehouse Controller Exception: " + ex);
                return BadRequest(ex);
            }
        }

        [AllowAnonymous, HttpDelete, Route("Delete")]
        public async Task<IActionResult> Delete(int warehouseId)
        {
            try
            {
                if (warehouseId > 0)
                {
                    APIResponse response = await _warehouseCore.Delete(warehouseId);
                    if (response?.Response != null)
                        return Ok(response);
                }
                return BadRequest(Constant.InValidRecordId);
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Warehouse Controller Exception: " + ex);
                return BadRequest(ex);
            }
        }

    }
}
