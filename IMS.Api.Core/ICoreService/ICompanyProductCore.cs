using IMS.Api.Common.Model.Params;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.ResponseModel;

namespace IMS.Api.Core.ICoreService
{
    public interface ICompanyProductCore
    {
        Task<APIResponse> Search(CompanyProductSearchRequestModel model);
        Task<APIResponse> GetById(int productId);
        Task<APIResponse> Add(List<CompanyProductAddRequestModel> model);
        Task<APIResponse> Delete(int productId);
        Task<APIResponse> TotalCount(CompanyProductSearchRequestModel model);
    }
}
