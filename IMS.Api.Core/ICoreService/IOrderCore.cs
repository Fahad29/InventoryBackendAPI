using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.ResponseModel;

namespace IMS.Api.Core.ICoreService
{
    public interface IOrderCore
    {
        Task<APIResponse> Search(OrderSearchRequestModel model);
        Task<APIResponse> GetById(int Id);
        Task<APIResponse> GetItemsByOrderId(int OrderId);
        Task<APIResponse> Create(OrderCreateRequestModel companyRequest);
        Task<APIResponse> Update(OrderUpdateRequestModel companyRequest);
        Task<APIResponse> Delete(int OrderId);
        Task<APIResponse> TotalCount(OrderSearchRequestModel model);

    }
}
