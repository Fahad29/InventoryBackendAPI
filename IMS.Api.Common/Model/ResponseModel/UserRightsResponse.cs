namespace IMS.Api.Common.Model.ResponseModel
{
    public class UserRightsResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ModuleId { get; set; }
        public int RoleId { get; set; }
        public string ModuleName { get; set; }
        public bool AllowView { get; set; }
        public bool AllowCreate { get; set; }
        public bool AllowUpdate { get; set; }
        public bool AllowDelete { get; set; }
    }
}
