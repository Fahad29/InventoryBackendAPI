namespace IMS.Api.Common.Model.ResponseModel.Export
{
    public class OrderExportResponseModel
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CustomerName { get; set; }
        public string MobileNo { get; set; }
        public Decimal Amount { get; set; }
        public string OrderDate { get; set; }

    }
}
