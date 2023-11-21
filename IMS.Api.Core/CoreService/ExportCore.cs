using IMS.Api.Common.Constant;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.DataModel;
using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.ResponseModel;
using IMS.Api.Common.Model.ResponseModel.Export;
using IMS.Api.Core.ICoreService;
using IMS.Api.Service.IRepository;
using System.Net;

namespace IMS.Api.Core.CoreService
{
    public class ExportCore : IExportCore
    {
        IRepository<CustomerExportResponseModel> _iRepository;
        APIResponse _apiResponse;
        public ExportCore(IRepository<CustomerExportResponseModel> iRepository, APIResponse apiResponse)
        {
            _iRepository = iRepository;
            _apiResponse = apiResponse;
        }

        public async Task<APIResponse> Company(BaseFilter model)
        {
            APIConfig.Log.Debug("CALLING API\" Company Export \"  STARTED");
            try
            {

                List<CompanyExportResponseModel> companyExportResponseModel = _iRepository.Search<CompanyExportResponseModel>(model, Constant.SpGetCompanyExportDetails).ToList();
                if (companyExportResponseModel.Count > 0)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, companyExportResponseModel);

                }
                else
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, Constant.RecordNotFound);
                }


            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> Customer(CustomerSearchRequestModel model)
        {
            APIConfig.Log.Debug("CALLING API\" Customer Export \"  STARTED");
            try
            {

                List<CustomerExportResponseModel> customerExportResponseModel = _iRepository.Search<CustomerExportResponseModel>(model, Constant.SpGetCustomerExportDetails).ToList();
                if (customerExportResponseModel.Count > 0)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, customerExportResponseModel);

                }
                else
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, Constant.RecordNotFound);
                }


            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> Order(OrderSearchRequestModel model)
        {
            APIConfig.Log.Debug("CALLING API\" Order Export \"  STARTED");
            try
            {

                List<OrderExportResponseModel> orderExportResponseModel = _iRepository.Search<OrderExportResponseModel>(model, Constant.SpGetOrderExportDetails).ToList();
                if (orderExportResponseModel.Count > 0)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, orderExportResponseModel);

                }
                else
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, Constant.RecordNotFound);
                }


            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> CompanyProduct(CompanyProductSearchRequestModel model)
        {
            APIConfig.Log.Debug("CALLING API\" Company Product Export \"  STARTED");
            try
            {
                List<CompanyProductExportResponseModel> productExportResponseModel = _iRepository.Search<CompanyProductExportResponseModel>(model, Constant.SpGetCompanyProductExportDetails).ToList();
                if (productExportResponseModel.Count > 0)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, productExportResponseModel);

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

        public async Task<APIResponse> Transaction(TransactionSearchRequestModel model)
        {
            APIConfig.Log.Debug("CALLING API\" Transaction Export \"  STARTED");
            try
            {

                List<TransactionExportResponseModel> transactionExportResponseModel = _iRepository.Search<TransactionExportResponseModel>(model, Constant.SpGetTransactionExportDetails).ToList();
                if (transactionExportResponseModel.Count > 0)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, transactionExportResponseModel);

                }
                else
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, Constant.RecordNotFound);
                }


            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        public async Task<APIResponse> Vendor(VendorSearch model)
        {
            APIConfig.Log.Debug("******* Calling Transaction Export API ******* ");
            try
            {
                model.CompanyId = APIConfig.CompanyId;
                var result = await _iRepository.SearchMuiltiple<VendorResponse>(model, Constant.SpGetVendor);
                // Access the data from the result
                var respose = new
                {
                    vendorList = result.Item1,
                    totalCount = result.Item2
                };
                if (result.Item1.ToList().Count > 0)
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, respose);
                else
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, Constant.RecordNotFound);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<APIResponse> PurchaseTransaction(TransactionSearchRequestModel model)
        {
            APIConfig.Log.Debug("CALLING API\" Transaction Export \"  STARTED");
            try
            {
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, _apiResponse);
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}