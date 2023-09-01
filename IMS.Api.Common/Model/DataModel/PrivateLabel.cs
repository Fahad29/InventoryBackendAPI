using IMS.Api.Common.Model.RequestModel;

namespace IMS.Api.Common.Model.DataModel
{
    public class PrivateLabel : BaseModel
    {
        public int Id { get; set; }
        public string CustomURL { get; set; }
        public string LoginLogo { get; set; }
        public string SidebarLogo { get; set; }
        public string FavLogo { get; set; }
        public string ThemesColor { get; set; }
        public string SidebarBackgroundColor { get; set; }
        public string MenuHighlightColor { get; set; }
        public string MenuTextColor { get; set; }
        public string HeaderBackgroundColor { get; set; }
        public string HeaderTextColor { get; set; }
        public string FromEmail { get; set; }
        public string SupportURL { get; set; }
    }
}
