using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.ResponseModel;

namespace IMS.Api.Core.ICoreService
{
    public interface ITransactionCore
    {
        Task<APIResponse> Search(TransactionSearchRequestModel model);
        Task<APIResponse> GetById(int Id);
        Task<APIResponse> Delete(int Id);
        Task<APIResponse> TotalCount(TransactionSearchRequestModel model);

    }
}
