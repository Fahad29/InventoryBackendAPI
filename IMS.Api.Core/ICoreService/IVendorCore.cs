using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.ResponseModel;

namespace IMS.Api.Core.ICoreService
{
    public interface IVendorCore
    {
        Task<APIResponse> Search(VendorSearch model);
        Task<APIResponse> GetById(int vendorId);
        Task<APIResponse> Create(VendorRequestModel model);
        Task<APIResponse> Update(int vendorId, VendorRequestModel model);
        Task<APIResponse> Delete(int vendorId);
    }
}
