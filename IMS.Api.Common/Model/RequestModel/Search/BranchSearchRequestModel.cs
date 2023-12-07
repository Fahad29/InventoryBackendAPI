using IMS.Api.Common.Model.CommonModel;

namespace IMS.Api.Common.Model.RequestModel.Search
{
    public class BranchSearchRequestModel : BaseFilter
    {
        public int? CompanyId { get; set; } = APIConfig.CompanyId;
    }
}
