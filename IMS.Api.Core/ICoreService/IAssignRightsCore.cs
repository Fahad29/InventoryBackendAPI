using IMS.Api.Common.Model.DataModel;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.ResponseModel;

namespace IMS.Api.Core.ICoreService
{
    public interface IAssignRightsCore
    {
        Task<APIResponse> GetRoleRights(int RoleId);
        Task<APIResponse> ManageRoleRights(RoleRightsRequest roleRights, long UserID);
        Task<APIResponse> GetUserRightsById(int UserId);
        Task<APIResponse> ManageUserRights(UserRightsRequest userRights,long UserID);
    }
}
