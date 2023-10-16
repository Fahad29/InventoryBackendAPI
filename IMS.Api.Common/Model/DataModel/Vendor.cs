namespace IMS.Api.Common.Model.DataModel
{
    public class Vendor : BaseModel
    {
        public int VendorID { get; set; }
        public int CompanyId { get; set; }
        public string VendorCompany { get; set; }
        public string ContactPerson { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string IDCardNo { get; set; }
        public string Address { get; set; }
    }
}
