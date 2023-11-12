using IMS.Api.Common.Model.ResponseModel;

namespace IMS.Api.Core.ICoreService
{
    public interface ICategoryCore
    {
        Task<APIResponse> GetAll();
        Task<APIResponse> Create(string Name);
        Task<APIResponse> TotalCount();
    }
}
