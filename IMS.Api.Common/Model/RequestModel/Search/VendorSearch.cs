namespace IMS.Api.Common.Model.RequestModel.Search
{
    public class VendorSearch
    {
        public int VendorId { get; set; } = -1;
        public int CompanyId { get; set; } = -1;
        public string VendorCompany { get; set; } = string.Empty;
        public string PhoneNo { get; set; } = string.Empty;
        public string IdCardNo { get; set; } = string.Empty;
        public int? PageNo { get; set; } = 1;
        public int? RecordLimit { get; set; } = 100;
    }
}
