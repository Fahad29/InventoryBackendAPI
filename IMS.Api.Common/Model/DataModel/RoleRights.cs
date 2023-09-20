using System.ComponentModel.DataAnnotations;

namespace IMS.Api.Common.Model.DataModel
{
    public class RoleRights : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public int RoleId { get; set; }
        public bool AllowView { get; set; }
        public bool AllowCreate { get; set; }
        public bool AllowUpdate { get; set; }
        public bool AllowDelete { get; set; }
    }
}
