using Newtonsoft.Json;

namespace IMS.Api.Common.Model.ResponseModel.Export
{
    public class CompanyProductExportResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Measureby { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        [JsonProperty(PropertyName = "Manufacture Date")]
        public string ManufactureDate { get; set; }
        [JsonProperty(PropertyName = "Expiry Date")]
        public string ExpiryDate { get; set; }
        [JsonProperty(PropertyName = "Inserted Date")]
        public string CreatedOn { get; set; }
        [JsonProperty(PropertyName = "Inserted By")]
        public string CreatedBy { get; set; }

    }
}
