namespace IMS.Api.Common.Model.DataModel
{
    public class OrderItem
    {
        public int? Id { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? DealId { get; set; }
        public int? Quantity { get; set; }
        public Decimal? Amount { get; set; }
        public Decimal? Discount { get; set; }
        public Decimal? TotalAmount { get; set; }
    }
}
