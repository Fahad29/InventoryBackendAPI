

namespace IMS.Api.Common.Model.RequestModel
{
    public  class CustomerCreateRequestModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Fax { get; set; }
        public string LandLine { get; set; }
        public string Mobile { get; set; }
    }
    public class CustomerUpdateRequestModel : CustomerCreateRequestModel
    {
        public int CustomerId { get; set; }
    }
}
