using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.Params;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.ResponseModel;

namespace IMS.Api.Core.ICoreService
{
    public interface ICustomerCore
    {
        Task<APIResponse> Search(CustomerSearchRequestModel model);
        Task<APIResponse> GetById(int Id);
        Task<APIResponse> Create(CustomerCreateRequestModel companyRequest);
        Task<APIResponse> Update(CustomerUpdateRequestModel companyRequest);
        Task<APIResponse> Delete(int Id);

    }
}
