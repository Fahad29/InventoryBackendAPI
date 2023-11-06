using System.ComponentModel.DataAnnotations;

namespace IMS.Api.Common.Model.RequestModel
{
    public class ChangePasswordRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}
