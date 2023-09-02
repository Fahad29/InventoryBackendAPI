using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.ResponseModel;

namespace IMS.Api.Core.ICoreService
{
    public interface IBrandCore
    {
        Task<APIResponse> GetAll();
        Task<APIResponse> Create(string Name);
        Task<APIResponse> Delete(int brandId);
        Task<APIResponse> DropDown();
    }
}
