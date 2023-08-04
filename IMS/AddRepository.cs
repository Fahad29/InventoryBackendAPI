using IMS.Api.Common.Model.DataModel;
using IMS.Api.Common.Model;
using IMS.Api.Service.IRepository;
using IMS.Api.Service.Repository;
using System.Security.Claims;
using IMS.Api.Core.CoreService;
using IMS.Api.Core.ICoreService;

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
            services.AddScoped<IRepository<CompanyRequestModel>, GenericRepository<CompanyRequestModel>>();
            services.AddScoped<ICompanyCore, CompanyCore>();
            services.AddScoped<APIResponse>();
            services.AddScoped<IRepository<User>, GenericRepository<User>>();
            return services;
        }
    }
}
