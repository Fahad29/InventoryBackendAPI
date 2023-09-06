using IMS.Api.Common.Model;

namespace IMS.Api.Core.ICoreService
{
    public interface IDropdownCore
    {
        Task<APIResponse> GetDropdownByModuleId(int ModuleId);
        Task<APIResponse> GetModules();
    }
}
