namespace IMS.Api.Common.Model.DataModel
{
    public class Customer : BaseModel
    {
        public int CustomerId { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Fax { get; set; }
        public string LandLine { get; set; }
        public string Mobile { get; set; }
    }
}
