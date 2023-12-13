using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.ResponseModel;

namespace IMS.Api.Core.ICoreService
{
    public interface IWarehouseCore
    {
        Task<APIResponse> Search(WarehouseSearchRequestModel model);
        Task<APIResponse> GetById(int Id);
        Task<APIResponse> Create(WarehouseCreateRequestModel model);
        Task<APIResponse> Update(WarehouseUpdateRequestModel model);
        Task<APIResponse> Delete(int Id);
    }
}
