using System.Diagnostics.CodeAnalysis;

namespace IMS.Api.Common.Model.RequestModel
{
    public  class PrivateLabelCreateRequestModel
    {
        public int? CompanyId { get; set; }
        public string? CustomURL { get; set; }
        public LogoImg? LoginLogo { get; set; }
        public LogoImg? SidebarLogo { get; set; }
        public LogoImg? FavLogo { get; set; }
        public string? ThemesColor { get; set; }
        public string? SidebarBackgroundColor { get; set; }
        public string? MenuHighlightColor { get; set; }
        public string? MenuTextColor { get; set; }
        public string? HeaderBackgroundColor { get; set; }
        public string? HeaderTextColor { get; set; }
        public string? FromEmail { get; set; }
        public string? SupportURL { get; set; }

    }
    public class PrivateLabelUpdateRequestModel : PrivateLabelCreateRequestModel
    {
        public int Id { get; set; }
    }

    public class LogoImg
    {
        public string filename { get; set; }
        public string filetype { get; set; }
        public string value { get; set; }
    }
}
