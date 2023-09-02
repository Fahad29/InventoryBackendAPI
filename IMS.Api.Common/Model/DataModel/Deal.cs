namespace IMS.Api.Common.Model.DataModel
{
    public class Deal : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int CompanyId { get; set; }
        public int BranchId { get; set; }
        public int ProductId { get; set; }
        public Decimal OffPercentAmount { get; set; }
        public Decimal OffPercent { get; set; }
        public DateTime StartDate { get; set; } = Convert.ToDateTime("1900-01-01");
        public DateTime EndDate { get; set; } = Convert.ToDateTime("1900-01-01");
        public int? FreeProductId { get; set; }

    }
}
