using IMS.Api.Common.Model.CommonModel;

namespace IMS.Api.Common.Model.RequestModel.Search
{
    public class VendorSearch : BaseFilter
    {
        public string PhoneNo { get; set; } = string.Empty;
        public string IDCardNo { get; set; } = string.Empty;
    }

}
