using IMS.Api.Common.Constant;
using IMS.Api.Common.Extensions;
using IMS.Api.Common.Model;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.DataModel;
using IMS.Api.Common.Model.Params;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.ResponseModel.DropDown;
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

        public async Task<APIResponse> Search(BaseFilter model)
        {
            APIConfig.Log.Debug("CALLING API\" Warehouse Get all \"  STARTED");
            try
            {

                List<WareHouse> Warehouse = _iRepository.Search(model, Constant.SpGetWarehouse).ToList();
                if (Warehouse.Count > 0)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, Warehouse);

                }
                else
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, null);
                }


            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> GetById(int WareHouseId)
        {
            APIConfig.Log.Debug("CALLING API\" Warehouse GetById \"  STARTED");
            try
            {
                WareHouse user = _iRepository.Search(new { WareHouseId = WareHouseId }, Constant.SpGetWarehouse).FirstOrDefault();
                if (user != null)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, user);
                }
                else
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, null);
                }
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> Create(WareHouseRequestModel model, Params @params)
        {
            APIConfig.Log.Debug("CALLING API\" Warehouse create \"  STARTED");
            try
            {
                WareHouse wareHouse = model.MapTo<WareHouse>();
                wareHouse.CreatedBy = @params.UserId;
                wareHouse = _iRepository.CreateSP<WareHouse>(wareHouse, Constant.SpCreateWarehouse);
                return _apiResponse.ReturnResponse(HttpStatusCode.Created, wareHouse);
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> Update(WareHouseRequestModel model, Params @params)
        {
            try
            {
                APIConfig.Log.Debug("CALLING API\" Warehouse update \"  STARTED");
                WareHouse wareHouse = model.MapTo<WareHouse>();
                wareHouse.UpdatedBy = @params.UserId;
                wareHouse = _iRepository.CreateSP<WareHouse>(wareHouse, Constant.SpUpdateWarehouse);
                return _apiResponse.ReturnResponse(HttpStatusCode.OK, wareHouse);

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> Delete(int WareHouseId, Params @params)
        {
            APIConfig.Log.Debug("CALLING API\" Warehouse delete \"  STARTED");
            try
            {
                if (WareHouseId > 0)
                {

                    _iRepository.CreateSP<Company>(new { Id = WareHouseId, UpdatedBy = @params.UserId }, Constant.SpDeleteCompanyWarehouse);
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
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        public async Task<APIResponse> DropDown()
        {
            APIConfig.Log.Debug("CALLING API\" Warehouse DropDown \"  STARTED");
            try
            {

                List<DropDown> dropDownList = _iRepository.Search<DropDown>(null, Constant.SpGetWarehouse).ToList();
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
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}

