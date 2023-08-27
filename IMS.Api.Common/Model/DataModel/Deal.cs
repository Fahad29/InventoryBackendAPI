namespace IMS.Api.Common.Model.DataModel
{
    public class Deal : BaseModel
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int BranchId { get; set; }
        public object ProductListwithdiscount { get; set; }
        public bool IsAllProduct { get; set; }
        public Decimal OffPercent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
