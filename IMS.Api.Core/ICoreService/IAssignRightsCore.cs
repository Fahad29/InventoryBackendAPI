using IMS.Api.Common.Model;

namespace IMS.Api.Core.ICoreService
{
    public interface IAssignRightsCore
    {
        Task<APIResponse> GetRoleRights(int RoleId);
    }
}
