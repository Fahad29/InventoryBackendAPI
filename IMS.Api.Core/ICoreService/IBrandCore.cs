using IMS.Api.Common.Model;
using IMS.Api.Common.Model.Params;

namespace IMS.Api.Core.ICoreService
{
    public interface IBrandCore
    {
        Task<APIResponse> GetAll();
        Task<APIResponse> Create(string Name);
        Task<APIResponse> Delete(int brandId);
    }
}
