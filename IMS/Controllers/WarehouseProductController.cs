using IMS.Api.Common.Model;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Core.ICoreService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseProductController : BaseController
    {
        readonly IWarehouseProduct _warehouseProduct;
        readonly int UserId;
        public WarehouseProductController(IWarehouseProduct warehouseProduct)
        {
            _warehouseProduct = warehouseProduct;
        }

        [AllowAnonymous, HttpGet, Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                APIResponse response = await _warehouseProduct.GetAll();
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
        public async Task<IActionResult> GetById(int warehouseProductId)
        {
            try
            {
                APIResponse response = await _warehouseProduct.GetById(warehouseProductId);
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
        public async Task<IActionResult> Create(WarehouseProductRequestModel warehouseProductRequest)
        {
            try
            {
                APIResponse response = await _warehouseProduct.Create(warehouseProductRequest, 1);
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
        public async Task<IActionResult> Update(WarehouseProductRequestModel warehouseProductRequest)
        {
            try
            {
                APIResponse response = await _warehouseProduct.Update(warehouseProductRequest, 1);
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
        public async Task<IActionResult> Delete(int warehouseProductId)
        {
            try
            {
                APIResponse response = await _warehouseProduct.Delete(warehouseProductId);
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
        public async Task<IActionResult> DropDown()
        {
            try
            {
                APIResponse response = await _warehouseProduct.DropDown();
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
