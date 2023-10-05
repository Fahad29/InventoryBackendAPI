using IMS.Api.Common.Model.CommonModel;

namespace IMS.Api.Common.Model.RequestModel.Search
{
    public class ProductSearchRequestModel : BaseFilter
    {
        public string? Category { get; set; }
        public string? Brand { get; set; }
        public string? Name { get; set; }
    }
}
