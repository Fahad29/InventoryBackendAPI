using System.Diagnostics.CodeAnalysis;

namespace IMS.Api.Common.Model.CommonModel
{
    public class SendEmailView
    {
        public List<string> SendTo { get; set; }
        public string SendFrom { get; set; }
        [ExcludeFromCodeCoverage]
        public List<string> Bcc { get; set; }
        [ExcludeFromCodeCoverage]
        public List<string> Cc { get; set; }
        [ExcludeFromCodeCoverage]
        public string Subject { get; set; }
        public string HtmlBodyContent { get; set; }
        [ExcludeFromCodeCoverage]
        public string BodyContent { get; set; }
        public string MerchantName { get; set; }
        public int ResellerId { get; set; }
        public int PartnerId { get; set; }
        public int MerchantId { get; set; }
    }
}