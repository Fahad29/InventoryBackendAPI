namespace IMS.Api.Common.Model.ResponseModel.Search
{
    public class DealSearchResponseModel 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Decimal OffPercentAmount { get; set; }
        public Decimal OffPercent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string FreeProductName { get; set; }
        public string ProductName { get; set; }
        public string CompanyName { get; set; }
        public string BranchName { get; set; }

    }
}
