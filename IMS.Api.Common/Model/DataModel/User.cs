using IMS.Api.Common.Model.CommonModel;

namespace IMS.Api.Common.Model.DataModel
{
    public class User : BaseModel
    {
        public int UserId { get; set; }
        public int CompanyId { get; set; } = APIConfig.CompanyId;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public int UserRoleId { get; set; }
        public string IsEmailVerified { get; set; }
        public string OTP { get; set; }
        public DateTime? OTPExpire { get; set; }
        public string MobileNo { get; set; }
        public string IsMobileNoVerified { get; set; }

    }
}
