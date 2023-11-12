using Newtonsoft.Json;

namespace IMS.Api.Common.Model.ResponseModel.Export
{
    public class OrderExportResponseModel
    {
        public int Id { get; set; }
        [JsonProperty(PropertyName = "Company Name")]
        public string? CompanyName { get; set; }
        [JsonProperty(PropertyName = "Customer Name")]
        public string? CustomerName { get; set; }
        [JsonProperty(PropertyName = "Mobile No")]
        public string? MobileNo { get; set; }
        [JsonProperty(PropertyName = "No Of Items")]
        public int? NoOfItems { get; set; }
        public decimal Amount { get; set; }
        public decimal Surcharge { get; set; }
        [JsonProperty(PropertyName = "Sales Tax")]
        public decimal SalesTax { get; set; }
        public decimal Discount { get; set; }
        [JsonProperty(PropertyName = "Total Amount")]
        public decimal TotalAmount { get; set; }
        [JsonProperty(PropertyName = "Order Date")]
        public string OrderDate { get; set; }

    }
}
