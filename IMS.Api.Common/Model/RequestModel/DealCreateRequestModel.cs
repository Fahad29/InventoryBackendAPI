namespace IMS.Api.Common.Model.RequestModel
{
    public  class DealCreateRequestModel
    {
      
        public string Name { get; set; }
        public int Quantity { get; set; } = 1;
        public int CompanyId { get; set; }
        public int BranchId { get; set; }
        public int ProductId { get; set; }
        public Decimal OffPercentAmount { get; set; }
        public Decimal OffPercent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? FreeProductId { get; set; }
    }
    public class DealUpdateRequestModel : DealCreateRequestModel
    {
        public int Id { get; set; }
    }
}
