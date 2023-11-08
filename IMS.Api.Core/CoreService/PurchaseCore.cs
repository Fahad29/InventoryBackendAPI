using IMS.Api.Common.Constant;
using IMS.Api.Common.Helper;
using IMS.Api.Common.Model;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.DataModel;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.ResponseModel;
using IMS.Api.Core.ICoreService;
using IMS.Api.Service.IRepository;
using System.Data;
using System.Net;

namespace IMS.Api.Core.CoreService
{
    public class PurchaseCore : IPurchaseCore
    {
        IRepository<PurchaseOrder> _iRepository;
        APIResponse _apiResponse;
        public PurchaseCore(IRepository<PurchaseOrder> iRepository, APIResponse apiResponse)
        {
            _apiResponse = apiResponse;
            _iRepository = iRepository;
        }

        public async Task<APIResponse> Search(PurchaseSearch searchModel)
        {
            APIConfig.Log.Debug("******* Calling Purchase Search API ******* ");
            try
            {
                List<PurchaseOrderDTO> vendors = _iRepository.Search<PurchaseOrderDTO>(searchModel, Constant.SpGetAllPurchaseOrder).ToList();
                if (vendors.Count > 0)
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, vendors);
                else
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, Constant.RecordNotFound);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<APIResponse> GetById(int PurchaseOrderId)
        {
            APIConfig.Log.Debug("******* Calling Vendor Get By Id API ******* ");

            try
            {
                PurchaseOrderDTO vendors = await _iRepository.GetById<PurchaseOrderDTO>(PurchaseOrderId, Constant.SpGetPurchaseOrderById);
                return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, Constant.RecordNotFound);
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        public async Task<APIResponse> Create(PurchaseRequestModel model)
        {
            APIConfig.Log.Debug("******* Calling Purchase Create API ******* ");
            try
            {
                await _iRepository.PurchaseTransactionsCreate(model);
                return _apiResponse.ReturnResponse(HttpStatusCode.Created, null);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<APIResponse> Delete(int vendorId)
        {
            APIConfig.Log.Debug("******* Calling Vendor Delete API ******* ");

            try
            {
                if (vendorId > 0)
                {

                    _iRepository.CreateSP<Vendor>(new { VendorId = vendorId, CurrentUserId = APIConfig.UserId, CurrentDate = DateTime.Now }, Constant.SpDeletePurchaseOrderById);
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, Constant.DeleteRecord);
                }
                else
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, Constant.InValidRecordId);
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
