using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Service.IRepository;
using Microsoft.Extensions.Configuration;

namespace IMS.Api.Service.Repository
{
    public class ConnectionFactory : IConnection
    {
        readonly IConfiguration _configuration;
        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string ConnectionString
        {
            get
            {
                return _configuration.GetSection("ConnectionStrings")["DefaultConnection"];
            }

        }
    }
}
