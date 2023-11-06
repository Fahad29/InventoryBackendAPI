using System.ComponentModel.DataAnnotations;

namespace IMS.Api.Common.Model.RequestModel
{
    public class ResetPasswordRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
