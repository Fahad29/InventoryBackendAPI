﻿using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.Params;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.ResponseModel;
using IMS.Api.Core.CoreService;
using IMS.Api.Core.ICoreService;
using IMS.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly IProductCore _productCore;
        public ProductController(IProductCore productCore)
        {
            _productCore = productCore;
        }

        [AllowAnonymous, HttpPost, Route("Search")]
        public async Task<IActionResult> Search(ProductSearchRequestModel model)
        {
            try
            {
                APIResponse response = await _productCore.Search(model);
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
        public async Task<IActionResult> GetById(int productId)
        {
            try
            {
                APIResponse response = await _productCore.GetById(productId);
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
        public async Task<IActionResult> Create(ProductCreateRequestModel productRequest)
        {
            try
            {
                APIResponse response = await _productCore.Create(productRequest);
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
        public async Task<IActionResult> Update(ProductUpdateRequestModel productRequest)
        {
            try
            {
                APIResponse response = await _productCore.Update(productRequest);
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
        public async Task<IActionResult> Delete(int productId)
        {
            try
            {
                APIResponse response = await _productCore.Delete(productId);
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
        public async Task<IActionResult> TotalCount(ProductSearchRequestModel model)
        {
            try
            {
                APIResponse response = await _productCore.TotalCount(model);
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
