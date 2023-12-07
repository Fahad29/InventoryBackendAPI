using IMS.Api.Common.Model.CommonModel;
using System.Text.Json.Serialization;

namespace IMS.Api.Common.Model.RequestModel.Search
{
    public class ProductSearchRequestModel : BaseFilter
    {
        public int BrandID { get; set; } = 0;
        public int CategoryId { get; set; } = 0;
        public int QuantityId { get; set; } = 0;
        public string? Barcode { get; set; }
        [JsonIgnore]
        public int CompanyId { get; set; }

    }
}
