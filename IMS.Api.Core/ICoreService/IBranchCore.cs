using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.Params;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.ResponseModel;

namespace IMS.Api.Core.ICoreService
{
    public interface IBranchCore
    {
        Task<APIResponse> Search(BranchSearchRequestModel model);
        Task<APIResponse> GetById(int CompanyId);
        Task<APIResponse> Create(BranchCreateRequestModel model);
        Task<APIResponse> Update(BranchUpdateRequestModel model);
        Task<APIResponse> Delete(int BranchId);
        Task<APIResponse> TotalCount(BranchSearchRequestModel model);


    }
}
