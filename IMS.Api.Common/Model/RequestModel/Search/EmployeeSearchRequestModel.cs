using IMS.Api.Common.Model.CommonModel;

namespace IMS.Api.Common.Model.RequestModel.Search
{
    public class EmployeeSearchRequestModel : BaseFilter
    {
        public int? CompanyId { get; set; }
        public string? Name { get; set; }
        public string? PermanentAddress { get; set; }
        public string? Mobile1 { get; set; }
        public string? IdentityCardNo { get; set; }
    }
}
