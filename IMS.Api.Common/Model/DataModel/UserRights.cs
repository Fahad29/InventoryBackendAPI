using System.ComponentModel.DataAnnotations;

namespace IMS.Api.Common.Model.DataModel
{
    public class UserRights : BaseModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ModuleId { get; set; }
        [Required]
        public int RoleId { get; set; }
        public string ModuleName { get; set; }

        public bool AllowView { get; set; }
        public bool AllowCreate { get; set; }
        public bool AllowUpdate { get; set; }
        public bool AllowDelete { get; set; }
    }
}