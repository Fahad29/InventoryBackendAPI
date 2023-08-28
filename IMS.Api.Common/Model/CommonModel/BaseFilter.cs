namespace IMS.Api.Common.Model.CommonModel
{
    public class BaseFilter
    {
       
        public int? Id { get; set; }
        public string? Name { get; set; }
        public DateTime? FromDate { get; set; } 
        public DateTime? ToDate { get; set; }
        public int? PageNo { get; set; } = 1;
        public int? RecordLimit { get; set; } = 100;
    }
}
