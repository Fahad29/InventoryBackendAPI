using Newtonsoft.Json;

namespace IMS.Api.Common.Model.ResponseModel.Export
{
    public class UserExportResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Company Name")]
        public string CompanyName { get; set; }
        public string Email { get; set; }

        [JsonProperty(PropertyName = "Mobile No")]
        public string MobileNo { get; set; }
        public string Designation { get; set; }
        [JsonProperty(PropertyName = "Status")]
        public string IsActive { get; set; }

        [JsonProperty(PropertyName = "Boarding Date")]
        public string BoardingDate{ get; set; }

    }
}
