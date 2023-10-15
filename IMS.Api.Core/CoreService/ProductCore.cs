using IMS.Api.Common.Constant;
using IMS.Api.Common.Enumerations;
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
        IAttachmentCore _attachmentCore;
        APIResponse _apiResponse;
        public ProductCore(IRepository<ProductDetail> iRepository, APIResponse apiResponse, IAttachmentCore attachmentCore)
        {
            _iRepository = iRepository;
            _apiResponse = apiResponse;
            _attachmentCore = attachmentCore;
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
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, Constant.RecordNotFound);

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> GetById(long productId)
        {
            APIConfig.Log.Debug("CALLING API\" Product GetById \"  STARTED");
            try
            {
                ProductResponseModel? product = _iRepository.Search<ProductResponseModel>(new { Id = productId }, Constant.SpGetProductDetail).FirstOrDefault();

                if (product != null)
                {
                    List<AttachmentResponse> result = await _attachmentCore.GetAttachments((int)AttachmentTypeEnum.ProductImages, product.Id);
                    product.attachments = result;
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
                product = _iRepository.CreateSP<ProductDetail>(product, Constant.SpCreateProductDetail);
                if (product != null && productRequest.Attachments != null && productRequest.Attachments.Count > 0)
                {
                    _attachmentCore.UploadImages(productRequest.Attachments, APIConfig.UserId, product.Id, (int)AttachmentTypeEnum.ProductImages);
                }

                if (APIConfig.CompanyId > 0)
                {
                    CompanyProduct companyProduct = new CompanyProduct()
                    {
                        ProductId = Convert.ToInt32(product?.Id)
                    };
                    _iRepository.CreateSP<CompanyProduct>(companyProduct, Constant.SpCreateCompanyProduct);
                }

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
                product = _iRepository.CreateSP<ProductDetail>(product, Constant.SpCreateProductDetail);
                if (product != null && productRequest.Attachments != null && productRequest.Attachments.Count > 0)
                {
                    _attachmentCore.UploadImages(productRequest.Attachments, APIConfig.UserId, product.Id, (int)AttachmentTypeEnum.ProductImages);
                }
                return _apiResponse.ReturnResponse(HttpStatusCode.OK, product);

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> Delete(long productId, long UserId)
        {
            APIConfig.Log.Debug("CALLING API\" ProductDetail delete \"  STARTED");
            try
            {
                if (productId > 0)
                {

                    bool isDeleted = _iRepository.Delete(new { Id = productId }, Constant.SpDeleteProductBrand);
                    if (isDeleted)
                    {
                        await _attachmentCore.DeleteAttachments((int)AttachmentTypeEnum.ProductImages, productId, UserId);
                        return _apiResponse.ReturnResponse(HttpStatusCode.OK, Constant.DeleteRecord);
                    }
                    else
                        return _apiResponse.ReturnResponse(HttpStatusCode.OK, Constant.RecordNotFound);
                }
                else
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, Constant.InvalidRequest);
                }
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> TotalCount(ProductSearchRequestModel model)
        {
            APIConfig.Log.Debug("CALLING API\" Product TotalCount \"  STARTED");
            try
            {
                int? TotalCount = _iRepository.Search<int>(model, Constant.SpProductDetailTotalCount).FirstOrDefault();
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
