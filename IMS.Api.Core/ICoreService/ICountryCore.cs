using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.ResponseModel;

namespace IMS.Api.Core.ICoreService
{
    public interface ICountryCore
    {
        Task<APIResponse> Search(BaseFilter model);
        Task<APIResponse> Create(CountryRequestModel model);
        Task<APIResponse> Delete(int Id);
    }
}
