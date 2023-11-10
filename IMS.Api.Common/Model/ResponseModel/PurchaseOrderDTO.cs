namespace IMS.Api.Common.Model.ResponseModel
{
    public class PurchaseOrderDTO
    {
        public string PurchaseOrderID { get; set; }
        public string VendorID { get; set; }
        public string DeliveryDate { get; set; }
        public string TotalAmount { get; set; }
        public string PaymentType { get; set; }
        public string PaymentStatus { get; set; }
        public string PaidAmount { get; set; }
        public string RemainingAmount { get; set; }
        public string Note { get; set; }
    }
}
