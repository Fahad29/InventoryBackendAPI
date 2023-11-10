using Newtonsoft.Json;

namespace IMS.Api.Common.Model.ResponseModel.Export
{
    public class CustomerExportResponseModel
    {
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Company Name")]
        public string CompanyName { get; set; }

        [JsonProperty(PropertyName = "Mobile No")]
        public string MobileNo { get; set; }

        [JsonProperty(PropertyName = "ID Card No")]
        public string IdentityCardNo { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        [JsonProperty(PropertyName = "Boarding By")]
        public string BoardedBy{ get; set; }
        [JsonProperty(PropertyName = "Boarding Date")]
        public string BoardingDate{ get; set; }

    }
}
