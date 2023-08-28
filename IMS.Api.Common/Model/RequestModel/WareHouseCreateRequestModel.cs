namespace IMS.Api.Common.Model.RequestModel
{
    public class WareHouseCreateRequestModel
    {
        
        public int? CompanyId { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Fax { get; set; }
        public string? Address { get; set; }
    }
    public class WareHouseUpdateRequestModel : WareHouseCreateRequestModel
    {
        public int? Id { get; set; }
    }
}
