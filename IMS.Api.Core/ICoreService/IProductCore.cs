using IMS.Api.Common.Model;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.RequestModel;

namespace IMS.Api.Core.ICoreService
{
    public interface IProductCore
    {
        Task<APIResponse> Search(BaseFilter model);
        Task<APIResponse> GetById(int productId);
        Task<APIResponse> Create(ProductRequestModel productRequest);
        Task<APIResponse> Update(ProductRequestModel productRequest);
        Task<APIResponse> Delete(int productId);
        Task<APIResponse> DropDown();
    }
}
