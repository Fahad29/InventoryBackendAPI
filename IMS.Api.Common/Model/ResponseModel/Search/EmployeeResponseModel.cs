using static IMS.Api.Common.Enumerations.Eumeration;

namespace IMS.Api.Common.Model.ResponseModel.Search
{
    public class EmployeeResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserRoleEnum UserRoleId { get; set; }
        public string Mobile1 { get; set; }
        public string Gender { get; set; }
        public string ResidentialAddress { get; set; }
        public string CompanyName { get; set; }

    }
}
