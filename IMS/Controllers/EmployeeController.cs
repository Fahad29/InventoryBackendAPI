using IMS.Api.Common.Model.CommonModel;
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
    public class EmployeeController : BaseController
    {
        readonly IEmployeeCore _employeeCore;
        public EmployeeController(IEmployeeCore employeeCore)
        {
            _employeeCore = employeeCore;
        }

        [HttpPost, Route("Search")]
        public async Task<IActionResult> Search(BaseFilter model)
        {
            try
            {
                APIResponse response = await _employeeCore.Search(model);
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
        public async Task<IActionResult> GetById(int employeeId)
        {
            try
            {
                APIResponse response = await _employeeCore.GetById(employeeId);
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
        public async Task<IActionResult> Create(EmployeeCreateRequestModel employeeRequest)
        {
            try
            {
                APIResponse response = await _employeeCore.Create(employeeRequest);
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
        public async Task<IActionResult> Update(EmployeeUpdateRequestModel employeeRequest)
        {
            try
            {
                APIResponse response = await _employeeCore.Update(employeeRequest);
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
        public async Task<IActionResult> Delete(int employeeId)
        {
            try
            {
                APIResponse response = await _employeeCore.Delete(employeeId);
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
        public async Task<IActionResult> TotalCount(BaseFilter model)
        {
            try
            {
                APIResponse response = await _employeeCore.TotalCount(model);
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
