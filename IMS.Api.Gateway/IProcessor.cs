using IMS.Api.Gateway.Model.Request;
using IMS.Api.Gateway.Model.Response;

namespace IMS.Api.Gateway
{
    public interface IProcessor
    {
        Task<TransactionResponseModel> Sale(TransactionRequestModel model );
        Task<TransactionResponseModel> ProfileSale(TransactionRequestModel model );
        Task<TransactionResponseModel> Void(TransactionRequestModel model );
        Task<TransactionResponseModel> Refund(TransactionRequestModel model );
        Task<TransactionResponseModel> ACHSale(TransactionRequestModel model);
        Task<TransactionResponseModel> ProfileACHSale(TransactionRequestModel model);
        Task<TransactionResponseModel> ACHVoid(TransactionRequestModel model);
        Task<TransactionResponseModel> ACHRefund(TransactionRequestModel model);
    }
}
