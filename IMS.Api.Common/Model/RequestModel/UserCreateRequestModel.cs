namespace IMS.Api.Common.Model.RequestModel
{
    public class UserCreateRequestModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PasswordHash { get; set; }
        public string? Email { get; set; }
        public string? MobileNo { get; set; }
        public int UserRoleId { get; set; }
    }
    public class UserUpdateRequestModel : UserCreateRequestModel
    {
        public int UserId { get; set; }
        public bool IsActive { get; set; }
    }
}
