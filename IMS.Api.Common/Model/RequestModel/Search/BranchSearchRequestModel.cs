using System.Text.Json.Serialization;

namespace IMS.Api.Common.Model.RequestModel.Search
{
    public class BranchSearchRequestModel
    {
        [JsonIgnore]
        public int CompanyId { get; set; } = -1;
        public string? Name { get; set; }
        public string? PhoneNo { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public int PageNo { get; set; } = 1;
        public int RecordLimit { get; set; } = 10;
    }
}
