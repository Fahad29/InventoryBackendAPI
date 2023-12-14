using IMS.Api.Common.Model.CommonModel;
using System.Text.Json.Serialization;

namespace IMS.Api.Common.Model.RequestModel.Search
{
    public class UserSearchRequestModel:BaseFilter
    {
        public string? Email {  get; set; }
        [JsonIgnore]
        public int CompanyId { get; set; }
    }
}
