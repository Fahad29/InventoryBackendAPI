using IMS.Api.Common.Model.DataModel;
using IMS.Api.Service.IRepository;
using static Dapper.SqlMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Data.SqlClient;
using System.Data;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Extensions;
using IMS.Api.Common.Model.CommonModel;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace IMS.Api.Service.Repository
{
    public class OrderRepository : IOrderRepository
    {
        IConnection _connection;
        readonly string _connectionString;
        public OrderRepository(IConnection connection)
        {
            _connection = connection;
            _connectionString = _connection.ConnectionString.ToString();
        }

        public async Task<Order> Create(OrderRequestModel model)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        var customer = new Customer();
                        var order = new Order();
                        var transaction = new Transaction();

                        if (!string.IsNullOrEmpty(model.CustomerName) && !string.IsNullOrEmpty(model.CustomerMobileNo))
                        {
                            customer.Name = model.CustomerName;
                            customer.Gender = model.CustomerGender;
                            customer.Address1 = model.CustomerAddress1;
                            customer.Address2 = model.CustomerAddress2;
                            customer.MobileNo = model.CustomerMobileNo;
                            customer.IdentityCardNo = model.CustomerIdentityCardNo;
                            customer.City = model.CustomerCity;
                            customer.Country = Convert.ToInt32(model.CustomerCountry);
                            customer.WebURL = model.WebURL;

                            // Insert the customer and retrieve the ID
                            customer.Id = await conn.QuerySingleAsync<int>(
                                IMS.Api.Common.Constant.Constant.SpCreateCustomer,
                                customer,
                                commandType: CommandType.StoredProcedure,
                                transaction: trans
                            );
                        }

                        order.CompanyId = APIConfig.CompanyId;
                        order.CustomerId = customer.Id;
                        order.SaleTax = Convert.ToDecimal(model.SaleTax);
                        order.Amount = Convert.ToDecimal(model.Amount);
                        order.Discount = Convert.ToDecimal(model.Discount);
                        order.TotalAmount = order.Amount - order.SaleTax - order.Discount + Convert.ToDecimal(model.Surcharge);

                        // Insert the order and retrieve the ID
                        order.Id = await conn.QuerySingleAsync<int>(
                            IMS.Api.Common.Constant.Constant.SpCreateOrder,
                            order,
                            commandType: CommandType.StoredProcedure,
                            transaction: trans
                        );

                        transaction.Amount = model.Amount;
                        transaction.Surcharge = model.Surcharge;
                        transaction.TotalAmount = order.TotalAmount + Convert.ToDecimal(model.Surcharge);
                        transaction.RefundAmount = order.TotalAmount;
                        transaction.TransactionType = Convert.ToInt32(model.TransactionType);
                        transaction.CardType = Convert.ToInt32(model.CardType);
                        transaction.ProcessorType = Convert.ToInt32(model.ProcessorType);
                        transaction.OriginalTransactionId = model.OriginalTransactionId;
                        transaction.GatewayRequest = model.GatewayRequest;
                        transaction.GatewayResponse = model.GatewayResponse;
                        transaction.IsVoided = false;
                        transaction.IsRefunded = false;
                        transaction.OrderId = order.Id;

                        // Insert the transaction
                        await conn.ExecuteAsync(
                            IMS.Api.Common.Constant.Constant.SpCreateTransaction,
                            transaction,
                            commandType: CommandType.StoredProcedure,
                            transaction: trans
                        );

                        // Insert order items
                        if (model.orderItemCreateRequestModelList != null)
                        {
                            foreach (var item in model.orderItemCreateRequestModelList)
                            {
                                OrderItem orderItem = item.MapTo<OrderItem>();
                                orderItem.OrderId = order.Id;
                                orderItem.TotalAmount = item.Amount - item.Discount;

                                await conn.ExecuteAsync(
                                    IMS.Api.Common.Constant.Constant.SpCreateOrderItem,
                                    orderItem,
                                    commandType: CommandType.StoredProcedure,
                                    transaction: trans
                                );
                            }
                        }

                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        // An exception occurred, so roll back the transaction
                        trans.Rollback();
                        Console.WriteLine($"Transaction rolled back: {ex.Message}");
                        throw; // Re-throw the exception to handle it at a higher level
                    }
                }
            }

            return null; // You might want to return the created order here
        }


        public Task<Order> Update(Order model)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                return null;
            }
        }
    }
}
