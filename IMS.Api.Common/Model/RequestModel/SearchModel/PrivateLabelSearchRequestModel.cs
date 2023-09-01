using IMS.Api.Common.Model.CommonModel;

namespace IMS.Api.Common.Model.RequestModel.SearchModel
{
    public class PrivateLabelSearchRequestModel : BaseFilter
    {
        public int? CompanyId { get; set; }
    }
}
