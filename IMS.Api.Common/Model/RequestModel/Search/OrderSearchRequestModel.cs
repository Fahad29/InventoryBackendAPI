using IMS.Api.Common.Model.CommonModel;

namespace IMS.Api.Common.Model.RequestModel.Search
{
    public class OrderSearchRequestModel : BaseFilter
    {
        public int? CompanyId { get; set; }
        public string? CustomerName { get; set; }
        public string? CompanyName { get; set; }
        public string? CustomerAddress1 { get; set; }
        public string? CustomerAddress2 { get; set; }
        public string? CustomerMobileNo { get; set; }
        public string? CustomerIdentityCardNo { get; set; }
    }
}
