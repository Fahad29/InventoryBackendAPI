using IMS.Api.Service.IRepository;
using IMS.Api.Service.Repository;
using System.Security.Claims;

namespace IMS
{
    public static class AddRepository
    {
        public static string ToUser(this ClaimsPrincipal claOMSPrincipal)
        {

            return string.Empty;
        }
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IConnection, ConnectionFactory>();
            return services;
        }
    }
}
