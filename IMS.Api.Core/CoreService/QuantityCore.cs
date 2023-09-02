using IMS.Api.Common.Constant;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.DataModel;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.ResponseModel;
using IMS.Api.Core.ICoreService;
using IMS.Api.Service.IRepository;
using System.Net;

namespace IMS.Api.Core.CoreService
{
    public class QuantityCore : IQuantityCore
    {
        IRepository<ProductQuantity> _iRepository;
        APIResponse _apiResponse;
        public QuantityCore(IRepository<ProductQuantity> iRepository, APIResponse apiResponse)
        {
            _iRepository = iRepository;
            _apiResponse = apiResponse;
        }

        public async Task<APIResponse> GetAll()
        {
            APIConfig.Log.Debug("CALLING API\" ItemQuantity Get all \"  STARTED");
            try
            {
                Object obj = new
                {

                };
                List<ProductQuantity> itemQuantities = _iRepository.Search(obj, Constant.SpGetAllQuantities).ToList();
                if (itemQuantities.Count > 0)
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, itemQuantities);
                else
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, Constant.RecordNotFound);
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> Create(QuantityRequestModel quantityRequest)
        {
            APIConfig.Log.Debug("CALLING API\" company create \"  STARTED");
            try
            {
                ProductQuantity itemQty = new ProductQuantity();
                itemQty.CategoryId = quantityRequest.CategoryId;
                itemQty.Quantity = quantityRequest.Quantity;
                itemQty.Unit = quantityRequest.Unit;
                itemQty = _iRepository.CreateSP<ProductQuantity>(itemQty, Constant.SpCreateQuantity);
                return _apiResponse.ReturnResponse(HttpStatusCode.Created, itemQty);

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        public async Task<APIResponse> Delete(int QuantityId)
        {
            APIConfig.Log.Debug("CALLING API\" Brand delete \"  STARTED");
            try
            {
                if (QuantityId > 0)
                {
                    _iRepository.CreateSP<ProductQuantity>(new { Id = QuantityId }, Constant.SpDeleteQuantity);
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, Constant.DeleteRecord);
                }
                else
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, Constant.InValidRecordId);


            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }

        }
        


    }
}
