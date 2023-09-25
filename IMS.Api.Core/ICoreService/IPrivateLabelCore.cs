using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.ResponseModel;

namespace IMS.Api.Core.CoreService
{
    public interface IPrivateLabelCore
    {
        Task<APIResponse> Search(PrivateLabelSearchRequestModel model);
        Task<APIResponse> GetById(int Id);
        Task<APIResponse> Create(PrivateLabelCreateRequestModel companyRequest,long UserId );
        Task<APIResponse> Update(PrivateLabelUpdateRequestModel companyRequest, long UserId);
        Task<APIResponse> Delete(int Id);
        Task<APIResponse> TotalCount(PrivateLabelSearchRequestModel model);

    }
}
