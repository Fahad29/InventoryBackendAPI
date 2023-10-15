namespace IMS.Api.Gateway.Model.Response
{
    public class TransactionResponseModel
    {
        public string OriginalTransactionId { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public bool Status { get; set; }
        public string StatusMessage { get; set; }


    }
}
