using IMS.Api.Common.Model;

namespace IMS.Api.Core.CoreService
{
    public interface ICompanyCore
    {
        Task<APIResponse> GetAll();
        Task<APIResponse> GetById(int CompanyId);
        Task<APIResponse> Create(CompanyRequestModel companyRequest);
        Task<APIResponse> Update(CompanyRequestModel companyRequest);
        Task<APIResponse> Delete(int CompanyId);

    }
}
