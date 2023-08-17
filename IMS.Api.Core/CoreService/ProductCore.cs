using IMS.Api.Common.Constant;
using IMS.Api.Common.Extensions;
using IMS.Api.Common.Model;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.DataModel;
using IMS.Api.Common.Model.RequestModel;
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

        public async Task<APIResponse> GetAll()
        {
            APIConfig.Log.Debug("CALLING API\" Product Get all \"  STARTED");
            try
            {
                Object obj = new
                {

                };
                List<ProductDetail> products = _iRepository.Search(obj, Constant.SpGetProductDetail).ToList();
                if (products.Count > 0)
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, products);
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
                ProductDetail? product = _iRepository.Search<ProductDetail>(new { Id = productId }, Constant.SpGetProductDetail).FirstOrDefault();
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

        public async Task<APIResponse> Create(ProductRequestModel productRequest)
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

        public async Task<APIResponse> Update(ProductRequestModel productRequest)
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
                    _iRepository.ExecuteQuery<ProductDetail>(new { Id = productId}, Constant.SpDeleteProductDetail);
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
    }

}
