using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Service.IRepository;

namespace IMS.Api.Service.Repository
{
    public class ConnectionFactory : IConnection
    {
        public ConnectionFactory()
        {

        }
        public string ConnectionString
        {
            get
            {
                return APIConfig.Configuration?.GetSection("ConnectionStrings")["DefaultConnection"];
            }
        }

    }
}
