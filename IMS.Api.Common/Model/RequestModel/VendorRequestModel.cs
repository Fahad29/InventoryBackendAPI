using System.Text.Json.Serialization;

namespace IMS.Api.Common.Model.RequestModel
{
    public class VendorRequestModel
    {
        public int VendorID { get; set; } = -1;
        public string VendorCompany { get; set; }
        [JsonIgnore]
        public int CompanyId { get; set; }
        public string ContactPerson { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string IDCardNo { get; set; }
        public string Address { get; set; }
        [JsonIgnore]
        public long CurrentUserId { get; set; }
        [JsonIgnore]
        public DateTime CurrentDate { get; set; }
    }
}
