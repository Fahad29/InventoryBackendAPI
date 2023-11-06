namespace IMS.Api.Common.Model.RequestModel
{
    public class VendorRequestModel
    {
        public int VendorID { get; set; } = -1;
        public string VendorCompany { get; set; }
        public int CompanyId { get; set; }
        public string ContactPerson { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string IDCardNo { get; set; }
        public string Address { get; set; }
        public long CurrentUserId { get; set; }
        public DateTime CurrentDate { get; set; }
    }
}
