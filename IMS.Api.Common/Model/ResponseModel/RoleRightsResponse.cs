using System.ComponentModel.DataAnnotations;

namespace IMS.Api.Common.Model.ResponseModel
{
    public class RoleRightsResponse
    {
        [Key]
        public int RoleRightId { get; set; }
        public int RoleId { get; set; } = 0;
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public bool AllowView { get; set; }
        public bool AllowCreate { get; set; }
        public bool AllowUpdate { get; set; }
        public bool AllowDelete { get; set; }
    }
}
