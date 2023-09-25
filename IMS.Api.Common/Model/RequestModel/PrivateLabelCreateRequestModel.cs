using Microsoft.AspNetCore.Http;
using System.Diagnostics.CodeAnalysis;

namespace IMS.Api.Common.Model.RequestModel
{
    public  class PrivateLabelCreateRequestModel
    {
        public int? CompanyId { get; set; }
        public string? CustomURL { get; set; }
        public IFormFile LoginLogo { get; set; }
        public IFormFile? SidebarLogo { get; set; }
        public IFormFile? FavLogo { get; set; }
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
}
