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

namespace IMS.Api.Core.ICoreService
{
    public class PrivateLabelCore : IPrivateLabelCore
    {
        IRepository<PrivateLabel> _iRepository;
        APIResponse _apiResponse;
        public PrivateLabelCore(IRepository<PrivateLabel> iRepository, APIResponse apiResponse)
        {
            _iRepository = iRepository;
            _apiResponse = apiResponse;
        }

        public async Task<APIResponse> Search(BaseFilter model)
        {
            APIConfig.Log.Debug("CALLING API\" privateLabel Get all \"  STARTED");
            try
            {

                List<PrivateLabel> privateLabel = _iRepository.Search(model, Constant.SpGetPrivateLabel).ToList();
                if (privateLabel.Count > 0)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, privateLabel);

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

        public async Task<APIResponse> GetById(int PrivateLabelId)
        {
            APIConfig.Log.Debug("CALLING API\" privateLabel GetById \"  STARTED");
            try
            {
                PrivateLabel privateLabel = _iRepository.Search(new { Id = PrivateLabelId }, Constant.SpGetPrivateLabel).FirstOrDefault();
                if (privateLabel != null)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, privateLabel);
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

        public async Task<APIResponse> Create(PrivateLabelCreateRequestModel model, Params @params)
        {
            APIConfig.Log.Debug("CALLING API\" privateLabel create \"  STARTED");
            try
            {
                PrivateLabel privateLabel = model.MapTo<PrivateLabel>();
                privateLabel.CreatedBy = @params.UserId;
                privateLabel = _iRepository.CreateSP<PrivateLabel>(privateLabel, Constant.SpCreatePrivateLabel);

                return _apiResponse.ReturnResponse(HttpStatusCode.Created, privateLabel);
                
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
     
        }

        public async Task<APIResponse> Update(PrivateLabelUpdateRequestModel model, Params @params)
        {
            try
            {
                APIConfig.Log.Debug("CALLING API\" privateLabel update \"  STARTED");
                PrivateLabel privateLabel = model.MapTo<PrivateLabel>();
                privateLabel.UpdatedBy = @params.UserId;
                privateLabel.UpdatedOn =DateTime.UtcNow;
                privateLabel = _iRepository.CreateSP<PrivateLabel>(privateLabel, Constant.SpUpdatePrivateLabel);
                return _apiResponse.ReturnResponse(HttpStatusCode.OK, privateLabel);

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);

            }
            


        }

        public async Task<APIResponse> Delete(int PrivateLabelId, Params @params)
        {
            APIConfig.Log.Debug("CALLING API\" privateLabel delete \"  STARTED");
            try
            {
                if (PrivateLabelId > 0)
                {

                    _iRepository.CreateSP<PrivateLabel>(new { Id = PrivateLabelId, UpdatedBy = @params.UserId }, Constant.SpDeletePrivateLabel);
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
