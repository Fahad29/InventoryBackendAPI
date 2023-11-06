using IMS.Api.Common.Model.CommonModel;

namespace IMS.Api.Common.Model.RequestModel.Search
{
    public class CustomerSearchRequestModel : BaseFilter
    {
        public int? CompanyId { get; set; } = APIConfig.CompanyId;
        public string? Name { get; set; }
        public string? CompanyName { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? MobileNo { get; set; }
        public string? IdentityCardNo { get; set; }
    }
}
