using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.ResponseModel;

namespace IMS.Api.Core.ICoreService
{
    public interface ICompanyCore
    {
        Task<APIResponse> Search(BaseFilter model);
        Task<APIResponse> GetById(int Id);
        Task<APIResponse> Create(CompanyRequestModel companyRequest);
        Task<APIResponse> Update(CompanyUpdateRequestModel companyRequest);
        Task<APIResponse> Delete(int CompanyId);
        Task<APIResponse> TotalCount(BaseFilter model);

    }
}
