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
                List<ProductDetail> companies = _iRepository.Search(obj, Constant.SpGetCompany).ToList();
                if (companies.Count > 0)
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, companies);
                else
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, null);

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
                ProductDetail product = _iRepository.Search(new { ProductId = productId }, Constant.SpGetCompany).FirstOrDefault();
                if (product != null)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, product);
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

        public async Task<APIResponse> Create(ProductRequestModel productRequest)
        {
            APIConfig.Log.Debug("CALLING API\" ProductDetail create \"  STARTED");
            try
            {
                ProductDetail product = productRequest.MapTo<ProductDetail>();
                //product.CreatedBy = @params.UserId;
                product = _iRepository.CreateSP<ProductDetail>(product, Constant.SpCreateCompany);

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
                product = _iRepository.CreateSP<ProductDetail>(product, Constant.SpUpdateCompany);
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
                    ProductDetail product = new();
                    product.IsDeleted = Constant.False;
                    product = _iRepository.CreateSP<ProductDetail>(product, Constant.SpUpdateCompany);
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, product);
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
