using IMS.Api.Common.Constant;
using IMS.Api.Common.Extensions;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.DataModel;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.ResponseModel;
using IMS.Api.Common.Model.ResponseModel.Search;
using IMS.Api.Core.ICoreService;
using IMS.Api.Service.IRepository;
using System.Net;

namespace IMS.Api.Core.CoreService
{
    public class ProductCore : IProductCore
    {
        IRepository<ProductDetail> _iRepository;
        APIResponse _apiResponse;
        public ProductCore(IRepository<ProductDetail> iRepository, APIResponse apiResponse)
        {
            _iRepository = iRepository;
            _apiResponse = apiResponse;
        }

        public async Task<APIResponse> Search(ProductSearchRequestModel model)
        {
            APIConfig.Log.Debug("CALLING API\" Product search \"  STARTED");
            try
            {
                List<ProductSearchResponseModel> productList = _iRepository.Search<ProductSearchResponseModel>(model, Constant.SpGetProductDetail).ToList();
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
            APIConfig.Log.Debug("CALLING API\" Product GetById \"  STARTED");
            try
            {
                ProductDetail? product = _iRepository.Search<ProductDetail>(new { Id = productId }, Constant.SpGetProductDetailById).FirstOrDefault();
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

        public async Task<APIResponse> Create(ProductCreateRequestModel productRequest)
        {
            APIConfig.Log.Debug("CALLING API\" ProductDetail create \"  STARTED");
            try
            {
                ProductDetail product = productRequest.MapTo<ProductDetail>();
                //product.CreatedBy = @params.UserId;
                product = _iRepository.CreateSP<ProductDetail>(product, Constant.SpCreateProductDetail);

                return _apiResponse.ReturnResponse(HttpStatusCode.Created, product);

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        public async Task<APIResponse> Update(ProductUpdateRequestModel productRequest)
        {
            try
            {
                APIConfig.Log.Debug("CALLING API\" ProductDetail update \"  STARTED");
                ProductDetail product = productRequest.MapTo<ProductDetail>();
                //company.UpdatedBy = @params.UserId;
                product = _iRepository.CreateSP<ProductDetail>(product, Constant.SpUpdateProductDetail);
                return _apiResponse.ReturnResponse(HttpStatusCode.OK, product);

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> Delete(int productId)
        {
            APIConfig.Log.Debug("CALLING API\" ProductDetail delete \"  STARTED");
            try
            {
                if (productId > 0)
                {

                    _iRepository.CreateSP<ProductDetail>(new { Id = productId}, Constant.SpDeleteProductDetail);
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, Constant.DeleteRecord);
                }
                else
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, null);
                }

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        public async Task<APIResponse> DropDown()
        {
            APIConfig.Log.Debug("CALLING API\" Product Drop Down \"  STARTED");
            try
            {
                List<DropdownResponse> dropDownList = _iRepository.Search<DropdownResponse>(null, Constant.SpGetProductDetail).ToList();
                if (dropDownList.Count > 0)
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, dropDownList);
                else
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, Constant.RecordNotFound);

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> TotalCount(int? CompanyId)
        {
            APIConfig.Log.Debug("CALLING API\" Product TotalCount \"  STARTED");
            try
            {
                int? TotalCount = _iRepository.Search<int>(new { CompanyId = CompanyId }, Constant.SpProductDetailTotalCount).FirstOrDefault();
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
