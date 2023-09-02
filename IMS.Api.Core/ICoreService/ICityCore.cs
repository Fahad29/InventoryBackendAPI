using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.ResponseModel;

namespace IMS.Api.Core.ICoreService
{
    public interface ICityCore
    {
        Task<APIResponse> Search(BaseFilter model);
        Task<APIResponse> Create(CityRequestModel model);
        Task<APIResponse> Delete(int Id);
        Task<APIResponse> DropDown();
    }
}
