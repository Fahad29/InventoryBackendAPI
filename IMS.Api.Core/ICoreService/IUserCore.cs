using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.ResponseModel;

namespace IMS.Api.Core.ICoreService
{
    public interface IUserCore
    {
        Task<APIResponse> Search(BaseFilter model);
        Task<APIResponse> GetById(int userId);
        Task<APIResponse> Create(UserRequest userRequest);
        Task<APIResponse> Update(UserRequest userRequest);
        Task<APIResponse> Delete(int CompanyId);
        Task<APIResponse> TotalCount(BaseFilter model);
    }
}
