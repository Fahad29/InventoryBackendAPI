namespace IMS.Api.Common.Model.ResponseModel.Export
{
    public class OrderExportResponseModel
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CustomerName { get; set; }
        public string MobileNo { get; set; }
        public string Amount { get; set; }
        public string Surcharge { get; set; }
        public string Discount { get; set; }
        public string TotalAmount { get; set; }
        public string OrderDate { get; set; }

    }
}
