using IMS.Api.Common.Constant;
using IMS.Api.Common.Enumerations;
using IMS.Api.Common.Extensions;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.DataModel;
using IMS.Api.Common.Model.Params;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.ResponseModel;
using IMS.Api.Common.Model.ResponseModel.Search;
using IMS.Api.Core.ICoreService;
using IMS.Api.Gateway;
using IMS.Api.Gateway.Model.Request;
using IMS.Api.Gateway.Model.Response;
using IMS.Api.Service.IRepository;
using Microsoft.AspNetCore.Http;
using System.Net;
using static IMS.Api.Common.Enumerations.Eumeration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace IMS.Api.Core.CoreService
{
    public class OrderCore : IOrderCore
    {
        IRepository<Order> _iRepository;
        IOrderRepository _iOrderRepository;
        APIResponse _apiResponse;
        IAttachmentCore _attachmentCore;
        public OrderCore(IRepository<Order> iRepository, APIResponse apiResponse, IAttachmentCore attachmentCore, IOrderRepository iOrderRepository)
        {
            _iOrderRepository = iOrderRepository;
            _iRepository = iRepository;
            _apiResponse = apiResponse;
            _attachmentCore = attachmentCore;
        }

        public async Task<APIResponse> Search(OrderSearchRequestModel model)
        {
            APIConfig.Log.Debug("CALLING API\" Order Get all \"  STARTED");
            try
            {

                List<OrderSearchResponseModel> orderSearchResponseModel = _iRepository.Search<OrderSearchResponseModel>(model, Constant.SpGetOrder).ToList();
                if (orderSearchResponseModel.Count > 0)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, orderSearchResponseModel);

                }
                else
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, Constant.RecordNotFound);
                }


            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> GetById(int OrderId)
        {
            APIConfig.Log.Debug("CALLING API\" Order GetById \"  STARTED");
            try
            {
                Order Order = _iRepository.Search(new { Id = OrderId }, Constant.SpGetOrder).FirstOrDefault();
                if (Order != null)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, Order);
                }
                else
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, Constant.RecordNotFound);
                }
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> GetItemsByOrderId(int OrderId)
        {
            APIConfig.Log.Debug("CALLING API\" Order Items GetByOrderId \"  STARTED");
            try
            {
                List<OrderItem> OrderItems = _iRepository.Search<OrderItem>(new { OrderId = OrderId }, Constant.SpGetOrderItems).ToList();
                if (OrderItems.Count > 0)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, OrderItems);
                }
                else
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, Constant.RecordNotFound);
                }
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> Create(OrderCreateRequestModel model)
        {
            APIConfig.Log.Debug("CALLING API\" Order create \"  STARTED");
            try
            {
                OrderRequestModel orderRequestModel = model.MapTo<OrderRequestModel>();
                #region Transaction on Gateway 
                if (model.ProcessorType > 0)
                {
                    TransactionRequestModel transactionRequestModel = new TransactionRequestModel();
                    ProcessorConfiguration configuration = _iRepository.Search<ProcessorConfiguration>(new { CompanyId = APIConfig.CompanyId }, Constant.SpGetProcessorConfiguration).FirstOrDefault();
                    IProcessor processor = Gateway.GatewayFactory.GetProcessor(configuration);
                    TransactionResponseModel transactionResponseModel = processor.Sale(transactionRequestModel).Result;
                    orderRequestModel.GatewayRequest = transactionResponseModel?.Request;
                    orderRequestModel.GatewayResponse = transactionResponseModel?.Response;
                    orderRequestModel.OriginalTransactionId = transactionResponseModel?.OriginalTransactionId;
                    orderRequestModel.OriginalTransactionId = transactionResponseModel?.OriginalTransactionId;
                    orderRequestModel.CardNumber = orderRequestModel?.CardNumber?.GenerateFirstSixandLastFourDigits();
                }
                #endregion

                Order order = await _iOrderRepository.Create(orderRequestModel);
                if (order.Id > 0)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.Created, Constant.SuccessResponse);
                }
                else
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, Constant.RecordNotFound );
                }
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        public async Task<APIResponse> Update(OrderUpdateRequestModel model)
        {
            try
            {
                APIConfig.Log.Debug("CALLING API\" Order update \"  STARTED");
                Order order = model.MapTo<Order>();
                order = _iRepository.CreateSP<Order>(order, Constant.SpUpdateOrder);

                return _apiResponse.ReturnResponse(HttpStatusCode.OK, Constant.UpdateRecord);
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        public async Task<APIResponse> Delete(int OrderId)
        {
            APIConfig.Log.Debug("CALLING API\" Order delete \"  STARTED");
            try
            {
                if (OrderId > 0)
                {

                    _iRepository.CreateSP<Order>(new { Id = OrderId, UpdatedBy = APIConfig.UserId }, Constant.SpDeleteOrder);
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, Constant.DeleteRecord);
                }
                else
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, Constant.InValidRecordId);
                }

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        public async Task<APIResponse> TotalCount(OrderSearchRequestModel model)
        {
            APIConfig.Log.Debug("CALLING API\" Order TotalCount \"  STARTED");
            try
            {
                int? TotalCount = _iRepository.Search<int>(model, Constant.SpGetOrderTotalCount).FirstOrDefault();
                if (TotalCount > 0)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, new { TotalCount });
                }
                else
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, Constant.RecordNotFound);
                }
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
