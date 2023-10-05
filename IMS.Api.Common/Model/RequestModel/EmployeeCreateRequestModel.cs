using Microsoft.AspNetCore.Http;

namespace IMS.Api.Common.Model.RequestModel
{
    public class EmployeeCreateRequestModel : EmployeeUser
    {
        public string? Name { get; set; }
        public string? IdentityCardNo { get; set; }
        public int? Country { get; set; }
        public string? City { get; set; }
        public string? Gender { get; set; }
        public string? PostalCode { get; set; }
        public string? PermanentAddress { get; set; }
        public string? ResidentialAddress { get; set; }
        public string? Fax { get; set; }
        public string? Mobile1 { get; set; }
        public string? Mobile2 { get; set; }
        public DateTime? DateOfJoining { get; set; } = Convert.ToDateTime("1900-01-01");
        public IFormFile ProfilePhoto { get; set; }
    }
    public class EmployeeUpdateRequestModel{

        public int? Id { get; set; }

        public string? Name { get; set; }
        public string? IdentityCardNo { get; set; }
        public int? Country { get; set; }
        public string? City { get; set; }
        public string? Gender { get; set; }
        public string? PostalCode { get; set; }
        public string? PermanentAddress { get; set; }
        public string? ResidentialAddress { get; set; }
        public string? Fax { get; set; }
        public string? Mobile1 { get; set; }
        public string? Mobile2 { get; set; }
        public DateTime? DateOfJoining { get; set; } = Convert.ToDateTime("1900-01-01");
        public IFormFile ProfilePhoto { get; set; }
    }

    public partial class EmployeeUser
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int UserRoleId { get; set; }
      
    }

}
