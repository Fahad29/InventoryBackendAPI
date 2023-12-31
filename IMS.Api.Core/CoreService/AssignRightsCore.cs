﻿using IMS.Api.Common.Constant;
using IMS.Api.Common.Model;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.DataModel;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.ResponseModel;
using IMS.Api.Core.ICoreService;
using IMS.Api.Service.IRepository;
using System.Net;

namespace IMS.Api.Core.CoreService
{
    public class AssignRightsCore : IAssignRightsCore
    {
        IRepository<DropdownResponse> _iRepository;
        APIResponse _apiResponse;
        public AssignRightsCore(IRepository<DropdownResponse> iRepository, APIResponse apiResponse)
        {
            _iRepository = iRepository;
            _apiResponse = apiResponse;
        }
        public async Task<APIResponse> GetRoleRights(int RoleId)
        {
            APIConfig.Log.Debug("Get Data From RoleRights Core ");

            try
            {
                List<RoleRightsResponse> modules = _iRepository.Search<RoleRightsResponse>(new { RoleId = RoleId }, Constant.SpGetRoleRights).ToList();
                if (modules.Count > 0)
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, modules);
                else
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, Constant.RecordNotFound);
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        public async Task<APIResponse> ManageRoleRights(RoleRightsRequest roleRights, long UserID)
        {
            APIConfig.Log.Debug("Insert ANd Update Data OF RoleRights Core");

            try
            {
                List<RoleRightsRequest> modules = _iRepository.Search<RoleRightsRequest>(roleRights, Constant.SpInsertUpdateRoleRights).ToList();
                if (modules.Count > 0)
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, modules);
                else
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, Constant.RecordNotFound);
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        public async Task<APIResponse> GetUserRightsById(int UserId)
        {
            APIConfig.Log.Debug("Get Data From UserRights Core ");

            try
            {
                List<UserRightsResponse> modules = _iRepository.Search<UserRightsResponse>(new { UserId = UserId }, Constant.SpGetUserRights).ToList();
                if (modules.Count > 0)
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, modules);
                else
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, Constant.RecordNotFound);
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        public async Task<APIResponse> ManageUserRights(UserRightsRequest userRights, long UserID)
        {
            APIConfig.Log.Debug("Insert And Update Data OF UserRights Core");

            try
            {
                userRights.CreatedUser = UserID;
                UserRightsResponse modules = _iRepository.CreateSP<UserRightsResponse>(userRights, Constant.SpInsertUpdateUserRights);
                if (modules != null)
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, modules);
                else
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, Constant.RecordNotFound);
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
