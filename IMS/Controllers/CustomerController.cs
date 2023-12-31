﻿using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.Params;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.ResponseModel;
using IMS.Api.Core.CoreService;
using IMS.Api.Core.ICoreService;
using IMS.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseController
    {
        readonly ICustomerCore _customerCore;
        public CustomerController(ICustomerCore customerCore, APIResponse apiResponse)
        {
            _customerCore = customerCore;
        }

        [ HttpPost, Route("Search")]
        public async Task<IActionResult> Search(CustomerSearchRequestModel model)
        {
            try
            {
                APIResponse response = await _customerCore.Search(model);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [ HttpGet, Route("GetById")]
        public async Task<IActionResult> GetById(int CustomerId)
        {
            try
            {
                APIResponse response = await _customerCore.GetById(CustomerId);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [ HttpPut, Route("Update")]
        public async Task<IActionResult> Update(CustomerUpdateRequestModel CustomerRequest)
        {
            try
            {
                APIResponse response = await _customerCore.Update(CustomerRequest);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [ HttpDelete, Route("Delete")]
        public async Task<IActionResult> Delete(int CustomerId)
        {
            try
            {
                APIResponse response = await _customerCore.Delete(CustomerId);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
        [HttpPost, Route("TotalCount")]
        public async Task<IActionResult> TotalCount(CustomerSearchRequestModel model)
        {
            try
            {
                APIResponse response = await _customerCore.TotalCount(model);
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
