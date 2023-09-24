using IMS.Api.Common.Constant;
using IMS.Api.Common.Extensions;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.DataModel;
using IMS.Api.Common.Model.Params;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.ResponseModel;
using IMS.Api.Common.Model.ResponseModel.Search;
using IMS.Api.Core.ICoreService;
using IMS.Api.Service.IRepository;
using System.Net;

namespace IMS.Api.Core.CoreService
{
    public class CompanyProductCore : ICompanyProductCore
    {
        IRepository<CompanyProduct> _iRepository;
        APIResponse _apiResponse;
        public CompanyProductCore(IRepository<CompanyProduct> iRepository, APIResponse apiResponse)
        {
            _iRepository = iRepository;
            _apiResponse = apiResponse;
        }

        public async Task<APIResponse> Search(CompanyProductSearchRequestModel model)
        {
            APIConfig.Log.Debug("CALLING API\" CompanyProduct search \"  STARTED");
            try
            {
                List<CompanyProductSearchResponseModel> productList = _iRepository.Search<CompanyProductSearchResponseModel>(model, Constant.SpGetCompanyProduct).ToList();
                if (productList.Count > 0)
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, productList);
                else
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, Constant.RecordNotFound);

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> GetById(int productId)
        {
            APIConfig.Log.Debug("CALLING API\" CompanyProduct GetById \"  STARTED");
            try
            {
                CompanyProduct? product = _iRepository.Search<CompanyProduct>(new { Id = productId }, Constant.SpGetCompanyProductById).FirstOrDefault();
                if (product != null)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, product);
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

        public async Task<APIResponse> Add(List<CompanyProductAddRequestModel> model)
        {
            APIConfig.Log.Debug("CALLING API\" CompanyProduct Add \"  STARTED");
            try
            {
                foreach (var item in model)
                {
                    CompanyProduct product = item.MapTo<CompanyProduct>();
                    product = _iRepository.CreateSP<CompanyProduct>(product, Constant.SpCreateCompanyProduct);
                }
                

                return _apiResponse.ReturnResponse(HttpStatusCode.Created, Constant.SuccessResponse);

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        public async Task<APIResponse> Delete(int productId)
        {
            APIConfig.Log.Debug("CALLING API\" CompanyProduct delete \"  STARTED");
            try
            {
                if (productId > 0)
                {
                    _iRepository.CreateSP<CompanyProduct>(new { Id = productId}, Constant.SpDeleteCompanyProduct);
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, Constant.DeleteRecord);
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

        public async Task<APIResponse> TotalCount(CompanyProductSearchRequestModel model)
        {
            APIConfig.Log.Debug("CALLING API\" CompanyProduct TotalCount \"  STARTED");
            try
            {
                int? TotalCount = _iRepository.Search<int>(model, Constant.SpCompanyProductTotalCount).FirstOrDefault();
                if (TotalCount > 0)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, new { TotalCount = TotalCount });
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
