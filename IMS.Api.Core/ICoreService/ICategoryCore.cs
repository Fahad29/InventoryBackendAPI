using IMS.Api.Common.Model;

namespace IMS.Api.Core.ICoreService
{
    public interface ICategoryCore
    {
        Task<APIResponse> GetAll();
        Task<APIResponse> Create(string Name);
        Task<APIResponse> Delete(int categoryId);
        Task<APIResponse> DropDown();
    }
}
