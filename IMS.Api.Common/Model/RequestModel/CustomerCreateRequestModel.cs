

using IMS.Api.Common.Model.CommonModel;

namespace IMS.Api.Common.Model.RequestModel
{
   
    public class CustomerUpdateRequestModel 
    {
        public int Id { get; set; }
        public int CompanyId { get; set; } = APIConfig.CompanyId;
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string MobileNo { get; set; }
        public string IdentityCardNo { get; set; }
        public string City { get; set; }
        public int Country { get; set; }
        public string WebURL { get; set; }
    }
}
