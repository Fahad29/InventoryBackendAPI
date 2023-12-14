using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.ResponseModel;

namespace IMS.Api.Core.ICoreService
{
    public interface IUserCore
    {
        Task<APIResponse> Search(UserSearchRequestModel model);
        Task<APIResponse> GetById(int Id);
        Task<APIResponse> Create(UserCreateRequestModel userRequest);
        Task<APIResponse> Update(UserUpdateRequestModel userRequest);
        Task<APIResponse> Delete(int Id);
    }
}
