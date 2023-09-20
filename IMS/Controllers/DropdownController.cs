using IMS.Api.Common.Model;
using IMS.Api.Common.Model.ResponseModel;
using IMS.Api.Core.ICoreService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DropdownController : ControllerBase
    {
        readonly IDropdownCore _dropdownCore;
        public DropdownController(IDropdownCore dropdownCore)
        {
            _dropdownCore = dropdownCore;
        }

        [AllowAnonymous, HttpGet, Route("GetModules")]
        public async Task<IActionResult> GetModules()
        {
            try
            {
                APIResponse response = await _dropdownCore.GetModules();
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [AllowAnonymous, HttpGet, Route("GetDropdownByModuleId")]
        public async Task<IActionResult> GetDropdownByModuleId(int ModuleId)
        {
            try
            {
                APIResponse response = await _dropdownCore.GetDropdownByModuleId(ModuleId);
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
