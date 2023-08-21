using IMS.Api.Common.Constant;
using IMS.Api.Common.Model;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.DataModel;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.ResponseModel;
using IMS.Api.Core.ICoreService;
using IMS.Api.Service.IRepository;
using System.Net;

namespace IMS.Api.Core.CoreService
{
    public class WarehouseProductCore : IWarehouseProduct
    {
        IRepository<WarehouseProduct> _iRepository;
        APIResponse _apiResponse;
        public WarehouseProductCore(IRepository<WarehouseProduct> iRepository, APIResponse apiResponse)
        {
            _iRepository = iRepository;
            _apiResponse = apiResponse;
        }

        public async Task<APIResponse> GetAll()
        {
            APIConfig.Log.Debug("CALLING API\" Brand Get all \"  STARTED");
            try
            {
                List<WarehouseProduct> warehouseProducts = _iRepository.Search(null, Constant.SpGetProductBrand).ToList();
                if (warehouseProducts.Count > 0)
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, warehouseProducts);
                else
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, Constant.RecordNotFound);
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> GetById(int warehouseProductId)
        {
            APIConfig.Log.Debug("CALLING API\" company GetById \"  STARTED");
            try
            {
                WarehouseProduct warehouseProduct = _iRepository.Search(new { Id = warehouseProductId }, Constant.SpGetCompany).FirstOrDefault();
                if (warehouseProduct != null)
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, warehouseProduct);
                else
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, Constant.RecordNotFound);
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> Create(WarehouseProductRequestModel warehouseProductRequest, int CurrentUserId)
        {
            APIConfig.Log.Debug("CALLING API\" company create \"  STARTED");
            try
            {
                WarehouseProduct warehouseProduct = new WarehouseProduct();
                warehouseProduct.CreatedBy = CurrentUserId;
                warehouseProduct.CreatedOn = DateTime.UtcNow;
                warehouseProduct = _iRepository.CreateSP<WarehouseProduct>(warehouseProduct, Constant.SpCreateProductBrand);
                return _apiResponse.ReturnResponse(HttpStatusCode.Created, warehouseProduct);
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        public async Task<APIResponse> Update(WarehouseProductRequestModel warehouseProductRequest, int CurrentUserId)
        {
            try
            {
                APIConfig.Log.Debug("CALLING API\" company update \"  STARTED");
                WarehouseProduct warehouseProduct = new WarehouseProduct();
                warehouseProduct.CreatedBy = CurrentUserId;
                warehouseProduct.CreatedOn = DateTime.UtcNow;
                warehouseProduct = _iRepository.CreateSP<WarehouseProduct>(warehouseProduct, Constant.SpUpdateCompany);
                return _apiResponse.ReturnResponse(HttpStatusCode.OK, warehouseProduct);

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> Delete(int warehouseProductId)
        {
            APIConfig.Log.Debug("CALLING API\" Brand delete \"  STARTED");
            try
            {
                if (warehouseProductId > 0)
                {
                    _iRepository.CreateSP<WarehouseProduct>(new { Id = warehouseProductId }, Constant.SpDeleteProductBrand);
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
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> DropDown()
        {
            APIConfig.Log.Debug("CALLING API\" Brand DropDown \"  STARTED");
            try
            {
                List<DropdownResponse> dropDownList = _iRepository.Search<DropdownResponse>(null, Constant.SpGetProductBrand).ToList();
                if (dropDownList.Count > 0)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, dropDownList);

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
    }
}
