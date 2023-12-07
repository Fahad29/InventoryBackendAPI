namespace IMS.Api.Common.Model.RequestModel.Search
{
    public class QuantitySearch
    {
        public decimal Quantity { get; set; } = 0;
        public string Unit { get; set; }=String.Empty;
        public int? PageNo { get; set; } = 1;
        public int? RecordLimit { get; set; } = 10;

    }
}
