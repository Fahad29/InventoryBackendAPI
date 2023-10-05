using IMS.Api.Common.Model.DataModel;
using IMS.Api.Common.Model.RequestModel;

namespace IMS.Api.Service.IRepository
{

    public interface IOrderRepository
    {

        Task<Order> Create(OrderRequestModel model);
        Task<Order> Update(Order model);
    }
}
