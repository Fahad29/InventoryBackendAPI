namespace IMS.Api.Common.Model.CommonModel
{
    public class BaseFilter
    {
        public BaseFilter() {

            this.FromDate = Convert.ToDateTime("01-01-1900");
            this.ToDate = Convert.ToDateTime("01-01-1900");
        }
        public int? Id { get; set; }
        public string? Name { get; set; }

        public DateTime? FromDate { get; set; } 
        public DateTime? ToDate { get; set; }
        public int? PageNo { get; set; } = 1;
        public int? RecordLimit { get; set; } = 100;
    }
}
