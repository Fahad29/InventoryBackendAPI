using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.Params;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.ResponseModel;

namespace IMS.Api.Core.ICoreService
{
    public interface IDealCore
    {
        Task<APIResponse> Search(DealSearchRequestModel model);
        Task<APIResponse> GetById(int Id);
        Task<APIResponse> Create(List<DealCreateRequestModel> dealRequestList);
        Task<APIResponse> Update(DealUpdateRequestModel companyRequest);
        Task<APIResponse> Delete(int Id);
        Task<APIResponse> TotalCount(DealSearchRequestModel model);

    }
}
