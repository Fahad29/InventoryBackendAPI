using static IMS.Api.Common.Enumerations.Eumeration;

namespace IMS.Api.Common.Model.DataModel
{
    public class Transaction : BaseModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public decimal Surcharge { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal RefundAmount { get; set; }
        public int ParentTransactionId { get; set; }
        public bool IsVoided { get; set; }
        public bool IsRefunded { get; set; }
        public string OriginalTransactionId { get; set; }
        public int TransactionType { get; set; }
        public int CardType { get; set; }
        public int ProcessorType { get; set; }
        public int PaymentType { get; set; }
        public string GatewayRequest { get; set; }
        public string GatewayResponse { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string Expiry { get; set; }
        public string CVV { get; set; }


    }
}
