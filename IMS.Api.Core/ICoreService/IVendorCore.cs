using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.ResponseModel;

namespace IMS.Api.Core.ICoreService
{
    public interface IVendorCore
    {
        Task<APIResponse> Search(BranchSearchRequestModel model);
        Task<APIResponse> GetById(int vendorId);
        Task<APIResponse> Create(BranchCreateRequestModel model);
        Task<APIResponse> Update(BranchCreateRequestModel model);
        Task<APIResponse> Delete(int vendorId);
    }
}
