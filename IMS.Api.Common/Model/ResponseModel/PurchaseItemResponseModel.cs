using IMS.Api.Common.Model;

namespace IMS.Api.Common.Model.ResponseModel
{
    public class PurchaseItemResponseModel
    {
        public int PurchaseItemId { get; set; }
        public string Barcode { get; set; } = String.Empty;
        public DateOnly ExpiryDate { get; set; }
        public decimal Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
