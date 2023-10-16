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
            APIConfig.Log.Debug("CALLING API\" Company Get all \"  STARTED");
            try
            {

                List<VendorResponse> companies = _iRepository.Search<VendorResponse>(model, Constant.SpGetCompany).ToList();
                if (companies.Count > 0)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, companies);

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

        public async Task<APIResponse> GetById(int vendorId)
        {
            APIConfig.Log.Debug("CALLING API\" Company GetById \"  STARTED");
            try
            {
                Vendor vendor = _iRepository.Search(new { vendorId = vendorId }, Constant.SpGetCompany).FirstOrDefault();
                VendorResponse response = vendor.MapTo<VendorResponse>();
                if (vendor != null)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, vendor);
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

        public async Task<APIResponse> Create(VendorRequestModel model)
        {
            APIConfig.Log.Debug("CALLING API\" Company create \"  STARTED");
            try
            {
                Vendor vendor = model.MapTo<Vendor>();
                vendor.CompanyId = APIConfig.CompanyId;
                vendor.CreatedBy = APIConfig.UserId;
                vendor.CreatedOn = DateTime.Now;
                vendor = _iRepository.CreateSP<Vendor>(vendor, Constant.SpCreateCompany);
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
            APIConfig.Log.Debug("CALLING API\" Company create \"  STARTED");
            try
            {
                Vendor vendor = model.MapTo<Vendor>();
                vendor.VendorID = vendorId;
                vendor.CompanyId = APIConfig.CompanyId;
                vendor.UpdatedBy = APIConfig.UserId;
                vendor.UpdatedOn = DateTime.Now;
                vendor = _iRepository.CreateSP<Vendor>(vendor, Constant.SpCreateCompany);
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
            APIConfig.Log.Debug("CALLING API\" Company delete \"  STARTED");
            try
            {
                if (vendorId > 0)
                {

                    _iRepository.CreateSP<Company>(new { vendorId = vendorId, UpdatedBy = APIConfig.UserId }, Constant.SpDeleteCompany);
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
