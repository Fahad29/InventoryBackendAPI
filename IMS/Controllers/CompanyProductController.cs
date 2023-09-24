using IMS.Api.Common.Model.Params;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.ResponseModel;
using IMS.Api.Core.ICoreService;
using IMS.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyProductController : ControllerBase
    {
        readonly ICompanyProductCore _companyProductCore;
        public CompanyProductController(ICompanyProductCore companyProductCore)
        {
            _companyProductCore = companyProductCore;
        }

        [AllowAnonymous, HttpPost, Route("Search")]
        public async Task<IActionResult> Search(CompanyProductSearchRequestModel model)
        {
            try
            {
                APIResponse response = await _companyProductCore.Search(model);
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
        public async Task<IActionResult> GetById(int companyProductId)
        {
            try
            {
                APIResponse response = await _companyProductCore.GetById(companyProductId);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [AllowAnonymous, HttpPost, Route("Add")]
        public async Task<IActionResult> Add(List<CompanyProductAddRequestModel> companyProductRequest)
        {
            try
            {
                APIResponse response = await _companyProductCore.Add(companyProductRequest);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [AllowAnonymous, HttpDelete, Route("Delete")]
        public async Task<IActionResult> Delete(int companyProductId)
        {
            try
            {
                APIResponse response = await _companyProductCore.Delete(companyProductId);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [AllowAnonymous, HttpPost, Route("TotalCount")]
        public async Task<IActionResult> TotalCount(CompanyProductSearchRequestModel model)
        {
            try
            {
                APIResponse response = await _companyProductCore.TotalCount(model);
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
