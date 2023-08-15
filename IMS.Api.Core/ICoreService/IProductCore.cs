using IMS.Api.Common.Model;
using IMS.Api.Common.Model.RequestModel;

namespace IMS.Api.Core.ICoreService
{
    public interface IProductCore
    {
        Task<APIResponse> GetAll();
        Task<APIResponse> GetById(int productId);
        Task<APIResponse> Create(ProductRequestModel productRequest);
        Task<APIResponse> Update(ProductRequestModel productRequest);
        Task<APIResponse> Delete(int productId);
    }
}
