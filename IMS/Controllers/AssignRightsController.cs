using IMS.Api.Common.Model.RequestModel.SearchModel;
using IMS.Api.Common.Model;
using IMS.Api.Core.ICoreService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IMS.Api.Core.CoreService;

namespace IMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignRightsController : BaseController
    {
        readonly IAssignRightsCore _assignRightsCore;
        public AssignRightsController(IAssignRightsCore assignRightsCore)
        {
            _assignRightsCore = assignRightsCore;
        }

        [AllowAnonymous, HttpGet, Route("GetRoleRightsById")]
        public async Task<IActionResult> GetRoleRightsById(int RoleID)
        {
            try
            {
                APIResponse response = await _assignRightsCore.GetRoleRights(RoleID);
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
