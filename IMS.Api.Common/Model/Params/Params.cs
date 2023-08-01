using System.Diagnostics.CodeAnalysis;

namespace IMS.Api.Common.Model.Params
{
    public class Params
    {
        public string IpAddress { get; set; }
        public int UserId { get; set; }

        public string ContentRootPath { get; set; }

        public string WebRootPath { get; set; }

        public string WebApiRootPath
        {
            //get { return WebRootPath + @"\api\"; }
            get { return ContentRootPath; }
        }
    }
}
