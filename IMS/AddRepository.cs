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

            services.AddScoped<IRepository<Company>, GenericRepository<Company>>();
            services.AddScoped<IRepository<CompanyRequestModel>, GenericRepository<CompanyRequestModel>>();
            services.AddScoped<ICompanyCore, CompanyCore>();

            services.AddScoped<IRepository<User>, GenericRepository<User>>();
            services.AddScoped<IUserCore, UserCore>();

            services.AddScoped<IAuthenticationCore, AuthenticationCore>();
            services.AddScoped<APIResponse>();


            services.AddScoped<IRepository<ProductDetail>, GenericRepository<ProductDetail>>();
            services.AddScoped<IProductCore, ProductCore>();

            services.AddScoped<IRepository<Brand>, GenericRepository<Brand>>();
            services.AddScoped<IBrandCore, BrandCore>();

            services.AddScoped<IRepository<Category>, GenericRepository<Category>>();
            services.AddScoped<ICategoryCore, CategoryCore>();

            services.AddScoped<IRepository<ProductQuantity>, GenericRepository<ProductQuantity>>();
            services.AddScoped<IQuantityCore, QuantityCore>();

            services.AddScoped<IRepository<WareHouse>, GenericRepository<WareHouse>>();
            services.AddScoped<IWarehouseCore, WarehouseCore>();

            services.AddScoped<IRepository<Branch>, GenericRepository<Branch>>();
            services.AddScoped<IBranchCore, BranchCore>();

            return services;
        }
    }
}
