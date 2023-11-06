using IMS.Api.Common.Model.CommonModel;

namespace IMS.Api.Common
{
    public static class ApiUrls
    {
        public static readonly string BaseUrl = APIConfig.Configuration?.GetSection("BaseUrl")["Url"];
        public static readonly string WebBaseUrl = APIConfig.Configuration?.GetSection("WebBaseUrl")["Url"];
        
        public static readonly string ResetPassword = WebBaseUrl + "/resetpassword";

    }
}
