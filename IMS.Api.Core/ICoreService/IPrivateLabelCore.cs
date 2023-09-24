using IMS.Api.Common.Model.Params;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.ResponseModel;

namespace IMS.Api.Core.CoreService
{
    public interface IPrivateLabelCore
    {
        Task<APIResponse> Search(PrivateLabelSearchRequestModel model);
        Task<APIResponse> GetById(int Id);
        Task<APIResponse> Create(PrivateLabelCreateRequestModel companyRequest );
        Task<APIResponse> Update(PrivateLabelUpdateRequestModel companyRequest);
        Task<APIResponse> Delete(int Id);
        Task<APIResponse> TotalCount(PrivateLabelSearchRequestModel model);

    }
}
