using IMS.Api.Common.Model.CommonModel;

namespace IMS.Api.Common.Model.RequestModel.Search
{
    public class CompanyProductSearchRequestModel : BaseFilter
    {
        public int? CompanyId { get; set; } = APIConfig.CompanyId;
        public int? ProductId { get; set; }
        public string? Brand { get; set; }
        public string? Category { get; set; }
        public string? CompanyName { get; set; }
        public string? BarcodeValue { get; set; }
        
    }
}
