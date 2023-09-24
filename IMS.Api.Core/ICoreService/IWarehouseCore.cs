using IMS.Api.Common.Model.Params;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.ResponseModel;

namespace IMS.Api.Core.ICoreService
{
    public interface IWarehouseCore
    {
        Task<APIResponse> Search(WareHouseSearchRequestModel model);
        Task<APIResponse> GetById(int Id);
        Task<APIResponse> TotalCount(WareHouseSearchRequestModel model);
        Task<APIResponse> Create(WareHouseCreateRequestModel model);
        Task<APIResponse> Update(WareHouseUpdateRequestModel model);
        Task<APIResponse> Delete(int Id);
    }
}
