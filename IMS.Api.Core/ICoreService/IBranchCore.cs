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
        Task<APIResponse> Create(BranchCreateRequestModel model, Params @params);
        Task<APIResponse> Update(BranchUpdateRequestModel model, Params @params);
        Task<APIResponse> Delete(int BranchId, Params @params);
        Task<APIResponse> DropDown(int? CompanyId);
        Task<APIResponse> TotalCount(int? CompanyId);


    }
}
