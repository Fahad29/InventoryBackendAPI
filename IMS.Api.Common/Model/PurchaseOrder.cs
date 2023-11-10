using static IMS.Api.Common.Enumerations.Eumeration;

namespace IMS.Api.Common.Model
{
    public class PurchaseOrder
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
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
    }
}
