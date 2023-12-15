namespace IMS.Api.Common.Model.RequestModel
{
    public class BranchCreateRequestModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Fax { get; set; }
        public string? Address { get; set; }
    }
    public class BranchUpdateRequestModel : BranchCreateRequestModel
    {
        public int? Id { get; set; }
    }
}
