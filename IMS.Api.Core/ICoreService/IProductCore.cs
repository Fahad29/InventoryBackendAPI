using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.ResponseModel;

namespace IMS.Api.Core.ICoreService
{
    public interface IProductCore
    {
        Task<APIResponse> Search(ProductSearchRequestModel model);
        Task<APIResponse> GetById(long productId);
        Task<APIResponse> Create(ProductRequestModel productRequest, long UserId, long CompanyId);
        Task<APIResponse> Update(ProductUpdateRequestModel productRequest, long UserId, long CompanyId);
        Task<APIResponse> Delete(long productId, long UserId);
        Task<APIResponse> TotalCount(ProductSearchRequestModel model);
    }
}
