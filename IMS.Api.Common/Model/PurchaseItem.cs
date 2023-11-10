namespace IMS.Api.Common.Model
{
    public class PurchaseItem
    {
        public string PurchaseItemId { get; set; }
        public string PurchaseOrderID { get; set; }
        public string ProductId { get; set; }
        public string Barcode { get; set; }
        public string ExpireDate { get; set; }
        public string Quantity { get; set; }
        public string UnitPrice { get; set; }
        public string TotalPrice { get; set; }
        public string DiscountId { get; set; }
        public string DiscountValue { get; set; }
        public string TaxPercent { get; set; }
        public string TaxAmount { get; set; }
        public string AmountWithTax { get; set; }
    }
}
