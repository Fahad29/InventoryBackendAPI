using IMS.Api.Common.Model;
using IMS.Api.Core.CoreService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        readonly ICompanyCore _companyCore;
        public CompanyController(ICompanyCore companyCore)
        {
            _companyCore = companyCore;
        }

        [AllowAnonymous, HttpGet, Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                APIResponse response = await _companyCore.GetAll();
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
        public async Task<IActionResult> GetById(int companyId)
        {
            try
            {
                APIResponse response = await _companyCore.GetById(companyId);
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
        public async Task<IActionResult> Create(CompanyRequestModel companyRequest)
        {
            try
            {
                APIResponse response = await _companyCore.Create(companyRequest);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [AllowAnonymous, HttpPut, Route("Update")]
        public async Task<IActionResult> Update(CompanyRequestModel companyRequest)
        {
            try
            {
                APIResponse response = await _companyCore.Update(companyRequest);
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
        public async Task<IActionResult> Delete(int companyId)
        {
            try
            {
                APIResponse response = await _companyCore.Delete(companyId);
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
