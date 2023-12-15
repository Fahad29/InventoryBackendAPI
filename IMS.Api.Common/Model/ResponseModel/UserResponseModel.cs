using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.DataModel;

namespace IMS.Api.Common.Model.ResponseModel
{
    public class UserResponseModel 
    {
        public int UserId { get; set; }
        public int CompanyId { get; set; } = APIConfig.CompanyId;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int UserRoleId { get; set; }
        public string MobileNo { get; set; }

    }
}
