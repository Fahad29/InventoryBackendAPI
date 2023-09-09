using IMS.Api.Common.Model;
using IMS.Api.Common.Model.DataModel;
using IMS.Api.Common.Model.RequestModel;

namespace IMS.Api.Core.ICoreService
{
    public interface IAssignRightsCore
    {
        Task<APIResponse> GetRoleRights(int RoleId);
        Task<APIResponse> ManageRoleRights(RoleRightsRequest roleRights);
        Task<APIResponse> GetUserRightsById(int User);
        Task<APIResponse> ManageUserRights(UserRightsRequest userRights);
    }
}
