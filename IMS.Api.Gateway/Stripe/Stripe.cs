using IMS.Api.Gateway.Model.Request;
using IMS.Api.Gateway.Model.Response;

namespace IMS.Api.Gateway.Stripe
{
    public class Stripe : IProcessor
    {
        public Stripe(string Config) {
        
        }
        public Task<TransactionResponseModel> ACHRefund(TransactionRequestModel model)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionResponseModel> ACHSale(TransactionRequestModel model)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionResponseModel> ACHVoid(TransactionRequestModel model)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionResponseModel> ProfileACHSale(TransactionRequestModel model)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionResponseModel> ProfileSale(TransactionRequestModel model)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionResponseModel> Refund(TransactionRequestModel model)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionResponseModel> Sale(TransactionRequestModel model)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionResponseModel> Void(TransactionRequestModel model)
        {
            throw new NotImplementedException();
        }
    }
}
