namespace IMS.Api.Common.Model.CommonModel
{
    public class APIUser
    {
        public APIUser()
        {
            this.LastLogin = Convert.ToDateTime("01-01-1900");
        }

        public long UserID { get; set; }
        public int EntityID { get; set; }
        public long UserRoleID { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string SecondaryEmail { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string ManualEntryKey { get; set; }
        public string QrCodeSetupImageUrl { get; set; }
        public string UniqueKey { get; set; }
        public DateTime LastLogin { get; set; }
        public string RoleId { get; set; }


    }
}
