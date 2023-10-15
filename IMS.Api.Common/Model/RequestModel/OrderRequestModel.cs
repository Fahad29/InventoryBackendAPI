﻿using static IMS.Api.Common.Enumerations.Eumeration;

namespace IMS.Api.Common.Model.RequestModel
{
    public  class OrderRequestModel : TransactionRequest
    {

        #region Customer Params
        public string? CustomerName { get; set; }
        public string? CustomerGender { get; set; }
        public string? CustomerIdentityCardNo { get; set; }
        public int? CustomerCountry { get; set; }
        public string? CustomerCity { get; set; }
        public string? CustomerAddress1 { get; set; }
        public string? CustomerAddress2 { get; set; }
        public string? CustomerMobileNo { get; set; }
        public string? WebURL { get; set; }
        #endregion

       
        public Decimal? SaleTax { get; set; }
        public Decimal Amount { get; set; }
        public Decimal Discount { get; set; }
        public Decimal TotalAmount { get; set; }


        public List<OrderItemCreateRequestModel> orderItemCreateRequestModelList { get; set; }
    }


    public partial class TransactionRequest
    {   
        public TransactionType TransactionType { get; set; }
        public CardType CardType { get; set; }
        public ProcessorType ProcessorType { get; set; }
        public string OriginalTransactionId { get; set; }
        public string GatewayRequest { get; set; }
        public string GatewayResponse { get; set; }
        public decimal Surcharge { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string Expiry { get; set; }
        public string CVV { get; set; }

    }
}
