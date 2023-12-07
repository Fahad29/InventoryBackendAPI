using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.Params;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.ResponseModel;

namespace IMS.Api.Core.ICoreService
{
    public  interface IExportCore
    {
        Task<APIResponse> Customer(CustomerSearchRequestModel model);
        Task<APIResponse> Order(OrderSearchRequestModel model);
        Task<APIResponse> CompanyProduct(CompanyProductSearchRequestModel model);
        Task<APIResponse> Company(BaseFilter model);
        Task<APIResponse> Transaction(TransactionSearchRequestModel model);
        Task<APIResponse> PurchaseTransaction(TransactionSearchRequestModel model);
        Task<APIResponse> Vendor(VendorSearch model);
    }
}
