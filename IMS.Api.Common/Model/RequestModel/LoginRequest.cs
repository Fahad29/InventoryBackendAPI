using System.ComponentModel.DataAnnotations;

namespace IMS.Api.Common.Model
{
    public  class LoginRequest
    {
        [Required]
        public string Username { get; set; } = "Admin";
        [Required]
        public string Password { get; set; } = "12345";
        public bool RememberMe { get; set; }
    }
}
