using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.Params;
using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.ResponseModel;
using IMS.Api.Core.CoreService;
using IMS.Api.Core.ICoreService;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace IMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExportController : Controller
    {
        readonly IExportCore _exportCore;
        public ExportController(IExportCore exportCore)
        {
            _exportCore = exportCore;
        }
      
        [HttpPost]
        [Route("Transaction")]
        public async Task<IActionResult> Transaction(TransactionSearchRequestModel model)
        {
            try
            {
                APIResponse response = await _exportCore.Transaction(model);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("Company")]
        public async Task<IActionResult> Company(BaseFilter model)
        {
            try
            {
                APIResponse response = await _exportCore.Company(model);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("Customer")]
        public async Task<IActionResult> Customer(CustomerSearchRequestModel model)
        {
            try
            {
                APIResponse response = await _exportCore.Customer(model);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("Order")]
        public async Task<IActionResult> Order(OrderSearchRequestModel model)
        {
            try
            {
                APIResponse response = await _exportCore.Order(model);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("CompanyProduct")]
        public async Task<IActionResult> CompanyProduct(CompanyProductSearchRequestModel model)
        {
            try
            {
                APIResponse response = await _exportCore.CompanyProduct(model);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("Vendor")]
        public async Task<IActionResult> Vendor(VendorSearch model)
        {
            try
            {
                APIResponse response = await _exportCore.Vendor(model);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("User")]
        public async Task<IActionResult> User(UserSearchRequestModel model)
        {
            try
            {
                APIResponse response = await _exportCore.User(model);
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
