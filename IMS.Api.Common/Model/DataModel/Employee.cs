using Microsoft.AspNetCore.Http;

namespace IMS.Api.Common.Model.DataModel
{
    public class Employee : BaseModel
    {
        public int? Id { get; set; }
        public int? CompanyId { get; set; }
        public int? UserId { get; set; }
        public string? Name { get; set; }
        public string? IdentityCardNo { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? PermanentAddress { get; set; }
        public string? ResidentialAddress { get; set; }
        public string? Fax { get; set; }
        public string? Mobile1 { get; set; }
        public string? Mobile2 { get; set; }
        public DateTime? DateOfJoining { get; set; } = Convert.ToDateTime("1900-01-01");


    }
}
