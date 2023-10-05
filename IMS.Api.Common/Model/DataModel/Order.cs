namespace IMS.Api.Common.Model.DataModel
{
    public class Order : BaseModel
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int CustomerId { get; set; }
        public Decimal SaleTax { get; set; }
        public Decimal Amount { get; set; }
        public Decimal Discount { get; set; }
        public Decimal TotalAmount { get; set; }

    }
}
