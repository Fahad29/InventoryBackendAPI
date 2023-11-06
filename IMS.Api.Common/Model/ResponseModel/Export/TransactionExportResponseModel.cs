using Newtonsoft.Json;

namespace IMS.Api.Common.Model.ResponseModel.Export
{
    public class TransactionExportResponseModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }

        [JsonProperty(PropertyName = "Company Name")]
        public string CompanyName { get; set; }

        [JsonProperty(PropertyName = "Customer Name")]
        public string CustomerName { get; set; }
        [JsonProperty(PropertyName = "Mobile No")]
        public string MobileNo { get; set; }

        [JsonProperty(PropertyName = "ID Card No")]
        public string IdentityCardNo { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        [JsonProperty(PropertyName = "Payment Type")]
        public string PaymentType { get; set; }

        [JsonProperty(PropertyName = "Transaction Date")]
        public DateTime? TransactionDate { get; set; }

        [JsonProperty(PropertyName = "Order Created By")]
        public string OrderCreatedBy { get; set; }

        [JsonProperty(PropertyName = "Card Type")]
        public string CardType { get; set; }
        public string Amount { get; set; }
        public string Surcharge { get; set; }
        public string Discount { get; set; }
        public string TotalAmount { get; set; }
    
        

    }
}
