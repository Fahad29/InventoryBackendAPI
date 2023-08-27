using IMS.Api.Common.Constant;
using IMS.Api.Common.Extensions;
using IMS.Api.Common.Model;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.DataModel;
using IMS.Api.Common.Model.Params;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Core.CoreService;
using IMS.Api.Service.IRepository;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace IMS.Api.Core.ICoreService
{
    public class DealCore : IDealCore
    {
        IRepository<Deal> _iRepository;
        APIResponse _apiResponse;
        public DealCore(IRepository<Deal> iRepository, APIResponse apiResponse)
        {
            _iRepository = iRepository;
            _apiResponse = apiResponse;
        }

        public async Task<APIResponse> Search(BaseFilter model)
        {
            APIConfig.Log.Debug("CALLING API\" deal Get all \"  STARTED");
            try
            {

                List<Deal> deal = _iRepository.Search(model, Constant.SpGetDeal).ToList();
                if (deal.Count > 0)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, deal);

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

        public async Task<APIResponse> GetById(int DealId)
        {
            APIConfig.Log.Debug("CALLING API\" deal GetById \"  STARTED");
            try
            {
                Deal deal = _iRepository.Search(new { Id = DealId }, Constant.SpGetDeal).FirstOrDefault();
                if (deal != null)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, deal);
                }
                else
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent,Constant.RecordNotFound);
                }
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> Create(DealCreateRequestModel model, Params @params)
        {
            APIConfig.Log.Debug("CALLING API\" deal create \"  STARTED");
            try
            {
                Deal deal = model.MapTo<Deal>();
                deal.CreatedBy = @params.UserId;
                deal = _iRepository.CreateSP<Deal>(deal, Constant.SpCreateDeal);

                return _apiResponse.ReturnResponse(HttpStatusCode.Created, deal);
                
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
     
        }

        public async Task<APIResponse> Update(DealUpdateRequestModel model, Params @params)
        {
            try
            {
                APIConfig.Log.Debug("CALLING API\" deal update \"  STARTED");
                Deal deal = model.MapTo<Deal>();
                deal.UpdatedBy = @params.UserId;
                deal.UpdatedOn =DateTime.UtcNow;
                deal = _iRepository.CreateSP<Deal>(deal, Constant.SpUpdateDeal);
                return _apiResponse.ReturnResponse(HttpStatusCode.OK, deal);

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);

            }
            


        }

        public async Task<APIResponse> Delete(int DealId, Params @params)
        {
            APIConfig.Log.Debug("CALLING API\" deal delete \"  STARTED");
            try
            {
                if (DealId > 0)
                {

                    _iRepository.CreateSP<Deal>(new { Id = DealId, UpdatedBy = @params.UserId }, Constant.SpDeleteDeal);
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
