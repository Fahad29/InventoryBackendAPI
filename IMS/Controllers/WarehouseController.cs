﻿using IMS.Api.Common.Model.Params;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.ResponseModel;
using IMS.Api.Core.ICoreService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oculus.Extensions;

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
        public async Task<IActionResult> Search(WareHouseSearchRequestModel model)
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
                throw;
            }
        }

        [AllowAnonymous, HttpGet, Route("GetById")]
        public async Task<IActionResult> GetById(int warehouseId)
        {
            try
            {
                APIResponse response = await _warehouseCore.GetById(warehouseId);
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
                APIResponse response = await _warehouseCore.TotalCount(CompanyId);
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
        public async Task<IActionResult> Create(WareHouseCreateRequestModel model)
        {
            try
            {
                APIResponse response = await _warehouseCore.Create(model, new Params() { ContentRootPath = AppConfig.ContentRootPath, UserId = User.GetUserId() });
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
        public async Task<IActionResult> Update(WareHouseUpdateRequestModel model)
        {
            try
            {
                APIResponse response = await _warehouseCore.Update(model, new Params() { ContentRootPath = AppConfig.ContentRootPath, UserId = User.GetUserId() });
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
        public async Task<IActionResult> Delete(int warehouseId)
        {
            try
            {
                APIResponse response = await _warehouseCore.Delete(warehouseId, new Params() { ContentRootPath = AppConfig.ContentRootPath, UserId = User.GetUserId() });
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
                APIResponse response = await _warehouseCore.DropDown(CompanyId);
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
