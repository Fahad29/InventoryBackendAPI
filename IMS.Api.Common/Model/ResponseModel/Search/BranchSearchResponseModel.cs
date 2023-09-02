using IMS.Api.Common.Model.RequestModel;

namespace IMS.Api.Common.Model.ResponseModel.Search
{
    public class BranchSearchResponseModel : BranchCreateRequestModel
    {
        public string? CompanyName { get; set; }
        public string? CountryName { get; set; }
        public string? CityName { get; set; }

    }
}
