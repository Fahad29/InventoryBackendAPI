namespace IMS.Api.Common.Model.RequestModel
{
    public  class PrivateLabelCreateRequestModel
    {
        public int CompanyId { get; set; }
        public string Logo { get; set; }
        public string BackgroundColor { get; set; }
        public string ForegroundColor { get; set; }
        public string Email { get; set; }
        public string SupportURL { get; set; }
        public string CustomURL { get; set; }
    }
    public class PrivateLabelUpdateRequestModel : PrivateLabelCreateRequestModel
    {
        public int Id { get; set; }
    }
}
