using static IMS.Api.Common.Enumerations.Eumeration;

namespace IMS.Api.Common.Model.ResponseModel.Search
{
    public class TransactionSearchResponseModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string CompanyName { get; set; }
        public string CustomerName { get; set; }
        public string Amount { get; set; }
        public string Surcharge { get; set; }
        public string TotalAmount { get; set; }
        public PaymentType PaymentType { get; set; }
        public CardType CardType { get; set; }
        public DateTime? TransactionDate { get; set; }


    }
}
