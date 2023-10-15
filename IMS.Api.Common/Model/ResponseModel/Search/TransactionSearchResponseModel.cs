namespace IMS.Api.Common.Model.ResponseModel.Search
{
    public class TransactionSearchResponseModel
    {
        public int Id { get; set; }
        public string OrderId { get; set; }
        public string CompanyName { get; set; }
        public string CustomerName { get; set; }
        public string Amount { get; set; }
        public string Surcharge { get; set; }
        public string TotalAmount { get; set; }
        public DateTime? OrderDate { get; set; }


    }
}
