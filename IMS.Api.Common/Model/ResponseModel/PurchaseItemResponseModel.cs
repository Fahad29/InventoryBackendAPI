using IMS.Api.Common.Model;

namespace IMS.Api.Common.Model.ResponseModel
{
    public class PurchaseItemResponseModel
    {
        public int OrderId { get; set; }
        public string PurchaseCode { get; set; }
        public int CompanyId { get; set; }
        public string BrandName { get; set; }
        public string ProductName { get; set; }
        public string Barcode { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal Quantity { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
