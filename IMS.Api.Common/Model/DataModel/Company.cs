namespace IMS.Api.Common.Model.DataModel
{
    public class Company : BaseModel
    {
        public int CompanyId { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public int CountryId { get; set; }
        public string Address { get; set; }
        public string Fax { get; set; }
        public string LandLine { get; set; }
        public string Mobile { get; set; }
        public string PostalCode { get; set; }
    }
}
