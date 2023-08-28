using IMS.Api.Common.Model;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.Params;
using IMS.Api.Common.Model.RequestModel;

namespace IMS.Api.Core.ICoreService
{
    public interface IBranchCore
    {
        Task<APIResponse> Search(BaseFilter model);
        Task<APIResponse> GetById(int CompanyId);
        Task<APIResponse> Create(BranchRequestModel model, Params @params);
        Task<APIResponse> Update(BranchRequestModel model, Params @params);
        Task<APIResponse> Delete(int BranchId, Params @params);
        Task<APIResponse> DropDown(int? CompanyId);
        Task<APIResponse> TotalCount(int? CompanyId);


    }
}
