using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.ResponseModel;

namespace IMS.Api.Core.ICoreService
{
    public interface IProductCore
    {
        Task<APIResponse> Search(ProductSearchRequestModel model);
        Task<APIResponse> GetById(int productId);
        Task<APIResponse> Create(ProductCreateRequestModel productRequest);
        Task<APIResponse> Update(ProductUpdateRequestModel productRequest);
        Task<APIResponse> Delete(int productId);
        Task<APIResponse> TotalCount(int? CompanyId);
        Task<APIResponse> DropDown();
    }
}
