namespace IMS.Api.Common.Model.ResponseModel
{
    public class PurchaseOrderResponseModel
    {
        public int PurchaseOrderID { get; set; }
        public string PurchaseCode { get; set; }
        public int VendorID { get; set; }
        public string VendorCompany { get; set; }
        public string ContactPerson { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int PaymentType { get; set; }
        public int PaymentStatus { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        public string Note { get; set; }
        public int NoOfItems { get; set; }

    }

}

