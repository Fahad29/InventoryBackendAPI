using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.ResponseModel;
using IMS.Api.Core.ICoreService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [AllowAnonymous, HttpPost, Route("ManageRoleRights")]
        public async Task<IActionResult> ManageRoleRights(RoleRightsRequest roleRights)
        {
            try
            {
                APIResponse response = await _assignRightsCore.ManageRoleRights(roleRights);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [AllowAnonymous, HttpGet, Route("GetUserRightsById")]
        public async Task<IActionResult> GetUserRightsById(int UserId)
        {
            try
            {
                APIResponse response = await _assignRightsCore.GetUserRightsById(UserId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [AllowAnonymous, HttpPost, Route("ManageUserRights")]
        public async Task<IActionResult> ManageUserRights(UserRightsRequest userRights)
        {
            try
            {
                userRights.CreatedUser = UserID;
                userRights.CreatedOn = DateTime.UtcNow;
                APIResponse response = await _assignRightsCore.ManageUserRights(userRights);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
