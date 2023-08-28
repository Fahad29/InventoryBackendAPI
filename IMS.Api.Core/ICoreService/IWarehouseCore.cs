using IMS.Api.Common.Model;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.Params;
using IMS.Api.Common.Model.RequestModel;

namespace IMS.Api.Core.ICoreService
{
    public interface IWarehouseCore
    {
        Task<APIResponse> Search(BaseFilter model);
        Task<APIResponse> GetById(int Id);
        Task<APIResponse> TotalCount(int? CompanyId);
        Task<APIResponse> Create(WareHouseCreateRequestModel model, Params @params);
        Task<APIResponse> Update(WareHouseUpdateRequestModel model, Params @params);
        Task<APIResponse> Delete(int Id, Params @params);
        Task<APIResponse> DropDown(int? CompanyId);
    }
}
