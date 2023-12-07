using IMS.Api.Common.Model.CommonModel;

namespace IMS.Api.Common.Model.RequestModel.Search
{
    public class PurchaseSearch
    {
        public string VendorCompany { get; set; } = string.Empty;
        public int CompanyId { get; set; } = APIConfig.CompanyId;
        public string PurchaseCode { get; set; } = string.Empty;
        public int PageNo { get; set; } = 1;
        public int RecordLimit { get; set; } = 10;
    }
}
