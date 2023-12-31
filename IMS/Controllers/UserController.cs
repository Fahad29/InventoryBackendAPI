﻿using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.ResponseModel;
using IMS.Api.Core.CoreService;
using IMS.Api.Core.ICoreService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        readonly IUserCore _userCore;
        public UserController(IUserCore userCore, APIResponse apiResponse)
        {
            _userCore = userCore;
        }

        [AllowAnonymous, HttpPost, Route("Search")]
        public async Task<IActionResult> Search(UserSearchRequestModel model)
        {
            try
            {
                APIResponse response = await _userCore.Search(model);
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
        public async Task<IActionResult> GetById(int userId)
        {
            try
            {
                APIResponse response = await _userCore.GetById(userId);
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
        public async Task<IActionResult> Create(UserCreateRequestModel userRequest)
        {
            try
            {
                APIResponse response = await _userCore.Create(userRequest);
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
        public async Task<IActionResult> Update(UserUpdateRequestModel userRequest)
        {
            try
            {
                APIResponse response = await _userCore.Update(userRequest);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [AllowAnonymous, HttpPut, Route("StatusUpdate")]
        public async Task<IActionResult> StatusUpdate(UserStatusUpdateRequestModel model)
        {
            try
            {
                APIResponse response = await _userCore.StatusUpdate(model);
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
        public async Task<IActionResult> Delete(int userId)
        {
            try
            {
                APIResponse response = await _userCore.Delete(userId);
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
