﻿using IMS.Api.Common.Constant;
using IMS.Api.Common.Extensions;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.DataModel;
using IMS.Api.Common.Model.Params;
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

        public async Task<APIResponse> Search(WareHouseSearchRequestModel model)
        {
            APIConfig.Log.Debug("CALLING API\" Warehouse Get all \"  STARTED");
            try
            {

                List<WareHouseSearchResponseModel> Warehouse = _iRepository.Search<WareHouseSearchResponseModel>(model, Constant.SpGetWarehouse).ToList();
                if (Warehouse.Count > 0)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, Warehouse);

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

        public async Task<APIResponse> GetById(int Id)
        {
            APIConfig.Log.Debug("CALLING API\" Warehouse GetById \"  STARTED");
            try
            {
                WareHouse wareHouse = _iRepository.Search(new { Id = Id }, Constant.SpGetWarehouseById).FirstOrDefault();
                if (wareHouse != null)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, wareHouse);
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

        public async Task<APIResponse> TotalCount(WareHouseSearchRequestModel model)
        {
            APIConfig.Log.Debug("CALLING API\" Warehouse TotalCount \"  STARTED");
            try
            {
                int? TotalCount  = _iRepository.Search<int>(model, Constant.SpGetWarehouseTotalCount).FirstOrDefault();
                if (TotalCount > 0)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, new {TotalCount = TotalCount});
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

        public async Task<APIResponse> Create(WareHouseCreateRequestModel model)
        {
            APIConfig.Log.Debug("CALLING API\" Warehouse create \"  STARTED");
            try
            {
                WareHouse wareHouse = model.MapTo<WareHouse>();
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

        public async Task<APIResponse> Update(WareHouseUpdateRequestModel model)
        {
            try
            {
                APIConfig.Log.Debug("CALLING API\" Warehouse update \"  STARTED");
                WareHouse wareHouse = model.MapTo<WareHouse>();
                wareHouse = _iRepository.CreateSP<WareHouse>(wareHouse, Constant.SpUpdateWarehouse);
                return _apiResponse.ReturnResponse(HttpStatusCode.OK, Constant.UpdateRecord);

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
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
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        
    }
}

