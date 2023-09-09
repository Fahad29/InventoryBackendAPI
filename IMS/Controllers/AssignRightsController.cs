﻿using IMS.Api.Common.Model.RequestModel.SearchModel;
using IMS.Api.Common.Model;
using IMS.Api.Core.ICoreService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IMS.Api.Core.CoreService;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.DataModel;

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
        [AllowAnonymous, HttpPost, Route("ManageRoleRights")]
        public async Task<IActionResult> ManageRoleRights(RoleRightsRequest roleRights)
        {
            try
            {
                APIResponse response = await _assignRightsCore.ManageRoleRights(roleRights);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [AllowAnonymous, HttpGet, Route("GetUserRightsById")]
        public async Task<IActionResult> GetUserRightsById(int UserId)
        {
            try
            {
                APIResponse response = await _assignRightsCore.GetUserRightsById(UserId);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw;
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
