using IMS.Api.Common.Model;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.Params;
using IMS.Api.Common.Model.RequestModel;

namespace IMS.Api.Core.CoreService
{
    public interface IDealCore
    {
        Task<APIResponse> Search(BaseFilter model);
        Task<APIResponse> GetById(int Id);
        Task<APIResponse> Create(DealCreateRequestModel companyRequest ,Params @params);
        Task<APIResponse> Update(DealUpdateRequestModel companyRequest, Params @params);
        Task<APIResponse> Delete(int Id, Params @params);

    }
}
