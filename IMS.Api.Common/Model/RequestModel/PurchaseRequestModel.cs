using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IMS.Api.Common.Model.RequestModel
{
    public class PurchaseRequestModel 
    {
        public PurchaseRequestModel()
        {
            PurchaseItemRequests = new List<PurchaseItemRequestModel>();
        }
        [Required]
        public int VendorId { get; set; }
        [Required]
        public DateTime DeliveryDate { get; set; } = DateTime.Now.Date;
        [Required]
        public decimal TotalAmount { get; set; }
        public int PaymentType { get; set; }
        public int PaymentStatus { get; set; }
        public decimal PaidAmount { get; set; }
        public string? Note { get; set; }
        [JsonIgnore]
        public int UserId { get; set; }
        [JsonIgnore]
        public int CompanyId { get; set; }
        [JsonIgnore]
        public int TaxValue { get; set; }
        public List<PurchaseItemRequestModel> PurchaseItemRequests { get; set; }
    }
    public class PurchaseItemRequestModel
    {
        [JsonIgnore]
        public int PurchaseOrderId { get;set; }
        public string Barcode { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal Discount { get; set; } = 0.0M;
        public decimal TotalPrice { get; set; }
        public DateTime ExpiryDate { get; set; } = DateTime.Now.Date;
    }
}   
