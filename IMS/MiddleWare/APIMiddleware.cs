using System.Diagnostics.CodeAnalysis;

namespace IMS.MiddleWare
{
    public class APIMiddleware
    {
        public APIMiddleware(RequestDelegate next)
        {

        }

        public async Task Invoke(HttpContext httpContext)
        {
            string Path, endpoint = string.Empty;
            try
            {
                bool isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";
                httpContext.Request.EnableBuffering();

                Path = endpoint = httpContext?.Request?.Path.Value.ToLower();

                Path = Path.Substring(Path.LastIndexOf("/") + 1).ToLower();
            }
            catch (Exception ex) { }
        }
    }
    public static class APIMiddleApp
    {
        [ExcludeFromCodeCoverage]
        public static IApplicationBuilder APIKeyBuilder(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<APIMiddleware>();
        }
    }

}
