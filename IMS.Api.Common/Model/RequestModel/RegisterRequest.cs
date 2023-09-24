using System.ComponentModel.DataAnnotations;

namespace IMS.Api.Common.Model.RequestModel
{
    public class RegisterRequest
    {
        [Required, MaxLength(30)]
        public string FirstName { get; set; }
        [Required, MaxLength(30)]
        public string Lastname { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, MaxLength(15)]
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        [Required]
        public string CompanyName { get; set; }

    }
}
