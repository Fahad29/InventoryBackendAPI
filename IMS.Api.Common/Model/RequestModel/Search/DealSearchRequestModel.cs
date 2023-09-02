using IMS.Api.Common.Model.CommonModel;

namespace IMS.Api.Common.Model.RequestModel.Search
{
    public class DealSearchRequestModel : BaseFilter
    {
        public int? CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public string? BranchName { get; set; }
        public string? ProductName { get; set; }
    }
}
