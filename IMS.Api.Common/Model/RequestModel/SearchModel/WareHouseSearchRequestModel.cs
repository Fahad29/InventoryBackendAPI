using IMS.Api.Common.Model.CommonModel;

namespace IMS.Api.Common.Model.RequestModel
{
    public  class WareHouseSearchRequestModel : BaseFilter
    {
        public int? CompanyId { get; set; }
    }
}
