namespace IMS.Api.Common.Model.ResponseModel
{
    public class LoginResponseModel
    {
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public bool? IsActive { get; set; }
        public int? UserRoleId { get; set; }


    }
}
