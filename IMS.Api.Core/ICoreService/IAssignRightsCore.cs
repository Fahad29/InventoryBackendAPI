using IMS.Api.Common.Model;
using IMS.Api.Common.Model.RequestModel;

namespace IMS.Api.Core.ICoreService
{
    public interface IAssignRightsCore
    {
        Task<APIResponse> GetRoleRights(int RoleId);
        Task<APIResponse> ManageRoleRights(RoleRightsRequest roleRights);
    }
}
