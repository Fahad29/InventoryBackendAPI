using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.ResponseModel;

namespace IMS.Api.Core.ICoreService
{
    public interface IPurchaseCore
    {
        Task<APIResponse> Search(PurchaseSearch searchModel);
        Task<APIResponse> GetById(int purchaseOrerId);
        Task<APIResponse> Create(PurchaseRequestModel model);
        Task<APIResponse> Delete(int vendorId);
    }
}
