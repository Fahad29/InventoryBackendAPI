namespace IMS.Api.Common.Model.RequestModel
{
    public  class DealCreateRequestModel
    {
      
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public int BranchId { get; set; }
        public List<int> ProductListwithdiscount { get; set; }
        public bool IsAllProduct { get; set; }
        public Decimal OffPercent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
    public class DealUpdateRequestModel : DealCreateRequestModel
    {
        public int Id { get; set; }
    }
}
