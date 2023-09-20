namespace IMS.Api.Common.Model.RequestModel
{
    public class RoleRightsRequest
    {
        public int ModuleId { get; set; }
        public int RoleId { get; set; }
        public bool AllowView { get; set; }
        public bool AllowCreate { get; set; }
        public bool AllowUpdate { get; set; }
        public bool AllowDelete { get; set; }
    }
}
