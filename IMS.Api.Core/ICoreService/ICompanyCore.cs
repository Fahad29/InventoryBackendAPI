using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.Params;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.ResponseModel;

namespace IMS.Api.Core.CoreService
{
    public interface ICompanyCore
    {
        Task<APIResponse> Search(BaseFilter model);
        Task<APIResponse> GetById(int Id);
        Task<APIResponse> Create(CompanyRequestModel companyRequest ,Params @params);
        Task<APIResponse> Update(CompanyUpdateRequestModel companyRequest, Params @params);
        Task<APIResponse> Delete(int CompanyId, Params @params);

    }
}
