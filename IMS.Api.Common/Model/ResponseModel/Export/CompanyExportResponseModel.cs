using Newtonsoft.Json;

namespace IMS.Api.Common.Model.ResponseModel.Export
{
    public class CompanyExportResponseModel
    {
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "Company Name")]
        public string CompanyName { get; set; }
        [JsonProperty(PropertyName = "Company Code")]
        public string CompanyCode { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string Fax { get; set; }
        public string LandLine { get; set; }
        public string Mobile { get; set; }
        [JsonProperty(PropertyName = "Postal Code")]
        public string PostalCode { get; set; }
        [JsonProperty(PropertyName = "Boarding Date")]
        public string BoardingDate { get; set; }

    }
}
