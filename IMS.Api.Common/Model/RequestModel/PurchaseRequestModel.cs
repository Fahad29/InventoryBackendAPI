using IMS.Api.Common.Model.CommonModel;
using System.ComponentModel.DataAnnotations;

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
        public string DeliveryDate { get; set; } = string.Empty;
        [Required]
        public decimal TotalAmount { get; set; }
        public int PaymentType { get; set; }
        public int PaymentStatus { get; set; }
        public decimal PaidAmount { get; set; }
        public string Note { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public int TaxValue { get; set; }
        public List<PurchaseItemRequestModel> PurchaseItemRequests { get; set; }
    }
    public class PurchaseItemRequestModel
    {
        public int PurchaseOrderId { get;set; }
        public string Barcode { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public decimal ItemPrice { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal TotalWithOutVAT { get; set; }
        public decimal VATAmount { get; set; }
        public decimal TotalWithVAT { get; set; }
    }
}
