using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.Params;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.ResponseModel;
using IMS.Api.Core.ICoreService;
using IMS.Api.Service.IRepository;
using IMS.Api.Service.Repository;
using IMS.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseController
    {
        readonly IOrderCore _orderCore;
        readonly IOrderRepository _iOrderRepository;
        public OrderController(IOrderCore orderCore)
        {
            _orderCore = orderCore;
        }

        [HttpPost, Route("Search")]
        public async Task<IActionResult> Search(OrderSearchRequestModel model)
        {
            try
            {
                APIResponse response = await _orderCore.Search(model);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet, Route("GetById")]
        public async Task<IActionResult> GetById(int orderId)
        {
            try
            {
                APIResponse response = await _orderCore.GetById(orderId);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost, Route("Create")]
        public async Task<IActionResult> Create(OrderCreateRequestModel orderRequest)
        {
            try
            {
                APIResponse response = await _orderCore.Create(orderRequest);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPut, Route("Update")]
        public async Task<IActionResult> Update([FromForm] OrderUpdateRequestModel orderRequest)
        {
            try
            {
                APIResponse response = await _orderCore.Update(orderRequest);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpDelete, Route("Delete")]
        public async Task<IActionResult> Delete(int orderId)
        {
            try
            {
                APIResponse response = await _orderCore.Delete(orderId);
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
        public async Task<IActionResult> TotalCount(OrderSearchRequestModel model)
        {
            try
            {
                APIResponse response = await _orderCore.TotalCount(model);
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
