using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.ResponseModel;

namespace IMS.Api.Core.ICoreService
{
    public interface IQuantityCore
    {
        Task<APIResponse> GetAll(QuantitySearch quantitySearch);
        Task<APIResponse> Create(QuantityRequestModel quantityRequest);
        Task<APIResponse> Delete(int QuantityId);
        Task<APIResponse> TotalCount();
    }
}
