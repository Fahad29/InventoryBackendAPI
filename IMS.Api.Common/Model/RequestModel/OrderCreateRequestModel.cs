using static IMS.Api.Common.Enumerations.Eumeration;

namespace IMS.Api.Common.Model.RequestModel
{
    public  class OrderCreateRequestModel : OrderTransactionRequest
    {

        #region Customer Params
        public string? CustomerName { get; set; }
        public string? CustomerMobileNo { get; set; }
        public string? WebURL { get; set; }
        #endregion

       
        public Decimal? SaleTax { get; set; }
        public Decimal Amount { get; set; }
        public Decimal Discount { get; set; }
        public Decimal TotalAmount { get; set; }


        public List<OrderItemCreateRequestModel> orderItemCreateRequestModelList { get; set; }
    }

    public class OrderUpdateRequestModel : OrderTransactionRequest
    {
        public Decimal? SaleTax { get; set; }
        public Decimal Amount { get; set; }
        public Decimal Discount { get; set; }
        public Decimal TotalAmount { get; set; }
        public List<OrderItemCreateRequestModel> orderItemCreateRequestModelList { get; set; }
    }

    public partial class OrderTransactionRequest
    {   
        public TransactionType TransactionType { get; set; }
        public PaymentType PaymentType { get; set; }
        public CardType CardType { get; set; }
        public ProcessorType ProcessorType { get; set; }
        public string? CardHolderName { get; set; }
        public string? CardNumber { get; set; }
        public string? Expiry { get; set; }
        public string? CVV { get; set; }
    }
}
