using AutoMapper;
using IMS.Api.Common.Constant;
using IMS.Api.Common.Extensions;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.DataModel;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.ResponseModel;
using IMS.Api.Core.ICoreService;
using IMS.Api.Service.IRepository;
using System;
using System.Net;

namespace IMS.Api.Core.CoreService
{
    public class VendorCore : IVendorCore
    {
        IRepository<Vendor> _iRepository;
        APIResponse _apiResponse;


        public VendorCore(IRepository<Vendor> iRepository, APIResponse apiResponse)
        {
            _apiResponse = apiResponse;
            _iRepository = iRepository;
        }

        public async Task<APIResponse> Search(VendorSearch model)
        {
            APIConfig.Log.Debug("******* Calling Vendor Search API ******* ");
            try
            {
                List<Vendor> vendors = _iRepository.Search<Vendor>(model, Constant.SpGetVendor).ToList();

                if (vendors.Count > 0)
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, vendors);
                else
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, Constant.RecordNotFound);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<APIResponse> GetById(int VendorId)
        {
            APIConfig.Log.Debug("******* Calling Vendor Get By Id API ******* ");

            try
            {
                VendorSearch vendorSearch = new VendorSearch
                {
                    VendorId = VendorId,
                    CompanyId = APIConfig.CompanyId,
                };
                Vendor? vendor = _iRepository.Search<Vendor>(vendorSearch, Constant.SpGetVendor)?.FirstOrDefault();
                if (vendor != null)
                {
                    VendorResponse response = vendor.MapTo<VendorResponse>();
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, vendor);
                }
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

        public async Task<APIResponse> Create(VendorRequestModel model)
        {
            APIConfig.Log.Debug("******* Calling Vendor Create API ******* ");
            try
            {
                model.CompanyId = APIConfig.CompanyId;
                model.CurrentUserId = APIConfig.UserId;
                model.CurrentDate = DateTime.Now;
                Vendor vendor = _iRepository.CreateSP<Vendor>(model, Constant.SpCreateVendor);
                VendorResponse vendorResp = vendor.MapTo<VendorResponse>();
                return _apiResponse.ReturnResponse(HttpStatusCode.Created, vendorResp);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<APIResponse> Update(int vendorId, VendorRequestModel model)
        {
            APIConfig.Log.Debug("******* Calling Vendor Update API ******* ");

            try
            {
                model.VendorID = vendorId;
                model.CurrentUserId = APIConfig.UserId;
                model.CurrentDate = DateTime.Now;
                Vendor vendor = _iRepository.CreateSP<Vendor>(model, Constant.SpCreateVendor);
                VendorResponse vendorResp = vendor.MapTo<VendorResponse>();
                return _apiResponse.ReturnResponse(HttpStatusCode.Created, vendorResp);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<APIResponse> Delete(int vendorId)
        {
            APIConfig.Log.Debug("******* Calling Vendor Delete API ******* ");

            try
            {
                if (vendorId > 0)
                {

                    _iRepository.CreateSP<Vendor>(new { VendorId = vendorId, CurrentUserId = APIConfig.UserId, CurrentDate = DateTime.Now }, Constant.SpDeleteVendor);
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, Constant.DeleteRecord);
                }
                else
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, Constant.InValidRecordId);
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
