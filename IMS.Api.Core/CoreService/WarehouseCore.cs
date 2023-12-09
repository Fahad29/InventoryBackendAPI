using IMS.Api.Common.Constant;
using IMS.Api.Common.Extensions;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.DataModel;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.ResponseModel;
using IMS.Api.Core.ICoreService;
using IMS.Api.Service.IRepository;
using System.Net;

namespace IMS.Api.Core.CoreService
{
    public class WarehouseCore : IWarehouseCore
    {
        IRepository<WareHouse> _iRepository;
        APIResponse _apiResponse;
        public WarehouseCore(IRepository<WareHouse> iRepository, APIResponse apiResponse)
        {
            _iRepository = iRepository;
            _apiResponse = apiResponse;
        }

        public async Task<APIResponse> Search(WarehouseSearchRequestModel model)
        {
            APIConfig.Log.Debug("******* Calling Warehouse Search API ******* ");
            try
            {
                model.CompanyId = APIConfig.CompanyId;
                GridData response = await _iRepository.SearchMuiltiple(model, Constant.SpGetWarehouse);
                // Access the data from the result

                if (response.DataList.Count() > 0)
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, response);
                else
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, Constant.RecordNotFound);

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> GetById(int Id)
        {
            APIConfig.Log.Debug("CALLING API\" Warehouse GetById \"  STARTED");
            try
            {
                WarehouseResponse response = _iRepository.Search<WarehouseResponse>(new { Id = Id, CompanyId = APIConfig.CompanyId }, Constant.SpGetWarehouseById).FirstOrDefault();
                if (response != null)
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, response);
                else
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, Constant.RecordNotFound);
            }
            catch
            {
                throw;
            }
        }
        public async Task<APIResponse> Create(WarehouseCreateRequestModel model)
        {
            APIConfig.Log.Debug("CALLING API\" Warehouse create \"  STARTED");
            try
            {
                WareHouse warehouse = model.MapTo<WareHouse>();
                warehouse.CompanyId = APIConfig.CompanyId;
                warehouse.CreatedBy = APIConfig.UserId;
                warehouse.CreatedOn = DateTime.Now;
                WarehouseResponse response = _iRepository.CreateSP<WarehouseResponse>(warehouse, Constant.SpCreateWarehouse);
                return _apiResponse.ReturnResponse(HttpStatusCode.Created, response);
            }
            catch
            {
                throw;
            }
        }

        public async Task<APIResponse> Update(WarehouseUpdateRequestModel model)
        {
            try
            {
                APIConfig.Log.Debug("CALLING API\" Warehouse update \"  STARTED");
                WareHouse warehouse = model.MapTo<WareHouse>();
                warehouse.UpdatedBy = APIConfig.UserId;
                warehouse.UpdatedOn = DateTime.Now;
                warehouse = _iRepository.CreateSP<WareHouse>(warehouse, Constant.SpUpdateWarehouse);
                return _apiResponse.ReturnResponse(HttpStatusCode.OK, Constant.UpdateRecord);

            }
            catch
            {
                throw;
            }
        }

        public async Task<APIResponse> Delete(int WareHouseId)
        {
            APIConfig.Log.Debug("CALLING API\" Warehouse delete \"  STARTED");
            try
            {
                if (WareHouseId > 0)
                {

                    _iRepository.CreateSP<Company>(new { Id = WareHouseId, UpdatedBy = APIConfig.UserId }, Constant.SpDeleteCompanyWarehouse);
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, Constant.DeleteRecord);
                }
                else
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, Constant.InValidRecordId);
                }

            }
            catch
            {
                throw;
            }
        }

    }
}

