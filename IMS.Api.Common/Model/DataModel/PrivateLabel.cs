namespace IMS.Api.Common.Model.DataModel
{
    public class PrivateLabel : BaseModel
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Logo { get; set; }
        public string BackgroundColor { get; set; }
        public string ForegroundColor { get; set; }
        public string Email { get; set; }
        public string SupportURL { get; set; }
        public string CustomURL { get; set; }
    }
}
