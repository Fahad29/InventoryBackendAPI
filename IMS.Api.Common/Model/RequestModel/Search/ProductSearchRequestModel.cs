using IMS.Api.Common.Model.CommonModel;

namespace IMS.Api.Common.Model.RequestModel
{
    public class ProductSearchRequestModel : BaseFilter
    {
        public int? CompanyId { get; set; }
        public string? Category { get; set; }
        public string? Brand { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
