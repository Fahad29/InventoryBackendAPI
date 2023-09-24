using IMS.Api.Common.Constant;
using IMS.Api.Common.Extensions;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.DataModel;
using IMS.Api.Common.Model.Params;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.ResponseModel;
using IMS.Api.Common.Model.ResponseModel.Search;
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

        public async Task<APIResponse> Search(DealSearchRequestModel model)
        {
            APIConfig.Log.Debug("CALLING API\" deal Get all \"  STARTED");
            try
            {

                List<DealSearchResponseModel> deal = _iRepository.Search<DealSearchResponseModel>(model, Constant.SpGetDeal).ToList();
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
                Deal deal = _iRepository.Search(new { Id = DealId }, Constant.SpGetDealById).FirstOrDefault();
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

        public async Task<APIResponse> Create(List<DealCreateRequestModel>  model)
        {
            APIConfig.Log.Debug("CALLING API\" deal create \"  STARTED");
            try
            {
                List<Deal> dealList = new List<Deal>();
                foreach(var item in model)
                {
                    Deal deal =  item.MapTo<Deal>();
                    _iRepository.CreateSP(deal, Constant.SpCreateDeal);
                    dealList.Add(deal);
                }
                //_iRepository.InsertInBulk<Deal>(dealList,"Deal",null);

                return _apiResponse.ReturnResponse(HttpStatusCode.Created, Constant.SuccessResponse);
                
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
     
        }

        public async Task<APIResponse> Update(DealUpdateRequestModel model)
        {
            try
            {
                APIConfig.Log.Debug("CALLING API\" deal update \"  STARTED");
                Deal deal = model.MapTo<Deal>();
                _iRepository.CreateSP(deal, Constant.SpUpdateDeal);
                return _apiResponse.ReturnResponse(HttpStatusCode.OK, Constant.UpdateRecord);

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);

            }
            


        }

        public async Task<APIResponse> Delete(int DealId)
        {
            APIConfig.Log.Debug("CALLING API\" deal delete \"  STARTED");
            try
            {
                if (DealId > 0)
                {

                    _iRepository.CreateSP<Deal>(new { Id = DealId, UpdatedBy = APIConfig.UserId }, Constant.SpDeleteDeal);
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

        public async Task<APIResponse> TotalCount(DealSearchRequestModel model)
        {
            APIConfig.Log.Debug("CALLING API\" Deal TotalCount \"  STARTED");
            try
            {
                int? TotalCount = _iRepository.Search<int>(new { CompanyId = model }, Constant.SpGetDealTotalCount).FirstOrDefault();
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
