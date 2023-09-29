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
using Microsoft.AspNetCore.Http;
using System.Net;

namespace IMS.Api.Core.CoreService
{
    public class PrivateLabelCore : IPrivateLabelCore
    {
        IRepository<PrivateLabel> _iRepository;
        APIResponse _apiResponse;
        IAttachmentCore _attachmentCore;
        public PrivateLabelCore(IRepository<PrivateLabel> iRepository, APIResponse apiResponse, IAttachmentCore attachmentCore)
        {
            _iRepository = iRepository;
            _apiResponse = apiResponse;
            _attachmentCore = attachmentCore;
        }

        public async Task<APIResponse> Search(PrivateLabelSearchRequestModel model)
        {
            APIConfig.Log.Debug("CALLING API\" privateLabel Get all \"  STARTED");
            try
            {

                List<PrivateLableSearchResponseModel> privateLabel = _iRepository.Search<PrivateLableSearchResponseModel>(model, Constant.SpGetPrivateLabel).ToList();
                if (privateLabel.Count > 0)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, privateLabel);

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

        public async Task<APIResponse> GetById(int PrivateLabelId)
        {
            APIConfig.Log.Debug("CALLING API\" privateLabel GetById \"  STARTED");
            try
            {
                PrivateLabel privateLabel = _iRepository.Search(new { Id = PrivateLabelId }, Constant.SpGetPrivateLabelById).FirstOrDefault();
                if (privateLabel != null)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, privateLabel);
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

        public async Task<APIResponse> Create(PrivateLabelCreateRequestModel model, long UserId)
        {
            APIConfig.Log.Debug("CALLING API\" privateLabel create \"  STARTED");
            try
            {
                long favLogId, LoginLogoId, sidebarLogoId = 0;
                List<string> AllowedExtension = new List<string>() { "image/jpeg", "image/jpg", "image/png", "images/gif", "image/x-icon", "image/svg+xml" };
                PrivateLabel privateLabel = model.MapTo<PrivateLabel>();
                privateLabel = _iRepository.CreateSP<PrivateLabel>(privateLabel, Constant.SpCreatePrivateLabel);
                //fav Image
                if (model.FavLogo != null)
                    favLogId = await UploadPrivateabelImages(model.FavLogo, UserId, privateLabel.Id);
                //LoginLogo Image
                if (model.LoginLogo != null)
                    LoginLogoId = await UploadPrivateabelImages(model.LoginLogo, UserId, privateLabel.Id);
                //SidebarLogo Image
                if (model.SidebarLogo != null)
                    sidebarLogoId = await UploadPrivateabelImages(model.SidebarLogo, UserId, privateLabel.Id);

                return _apiResponse.ReturnResponse(HttpStatusCode.Created, Constant.SuccessResponse);

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        public async Task<APIResponse> Update(PrivateLabelUpdateRequestModel model, long UserId)
        {
            try
            {
                APIConfig.Log.Debug("CALLING API\" privateLabel update \"  STARTED");
                List<string> AllowedExtension = new List<string>() { "image/jpeg", "image/jpg", "image/png", "images/gif", "image/x-icon", "image/svg+xml" };
                PrivateLabel privateLabel = model.MapTo<PrivateLabel>();
                privateLabel = _iRepository.CreateSP<PrivateLabel>(privateLabel, Constant.SpUpdatePrivateLabel);
                // Fv Image
                UploadPrivateabelImages(model.FavLogo, UserId, privateLabel.Id);

                //privateLabel.Id = model.Id;
                //privateLabel.CustomURL = model?.CustomURL;
                //privateLabel.ThemesColor = model?.ThemesColor;
                //privateLabel.SidebarBackgroundColor = model?.SidebarBackgroundColor;
                //privateLabel.HeaderBackgroundColor = model?.HeaderBackgroundColor;
                //privateLabel.HeaderTextColor = model?.HeaderTextColor;
                //privateLabel.MenuHighlightColor = model?.MenuHighlightColor;
                //privateLabel.MenuTextColor = model?.MenuTextColor;
                //privateLabel.SupportURL = model?.SupportURL;
                //privateLabel.FromEmail = model?.FromEmail;
                //privateLabel.CompanyId = Convert.ToInt32(model?.CompanyId);

                return _apiResponse.ReturnResponse(HttpStatusCode.OK, Constant.UpdateRecord);

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);

            }



        }

        public async Task<APIResponse> Delete(int PrivateLabelId)
        {
            APIConfig.Log.Debug("CALLING API\" privateLabel delete \"  STARTED");
            try
            {
                if (PrivateLabelId > 0)
                {

                    _iRepository.CreateSP<PrivateLabel>(new { Id = PrivateLabelId, UpdatedBy = APIConfig.UserId }, Constant.SpDeletePrivateLabel);
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

        public async Task<APIResponse> TotalCount(PrivateLabelSearchRequestModel model)
        {
            APIConfig.Log.Debug("CALLING API\" PrivateLabel TotalCount \"  STARTED");
            try
            {
                int? TotalCount = _iRepository.Search<int>(model, Constant.SpGetPrivateLabelTotalCount).FirstOrDefault();
                if (TotalCount > 0)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, new { TotalCount });
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


        private async Task<long> UploadPrivateabelImages(IFormFile file, long UserId, long RequestId)
        {
            List<IFormFile> myFiles = new List<IFormFile>();
            myFiles.Add(file);
            List<AttachmentResponse> attachments = await _attachmentCore.UploadImages(myFiles, UserId, RequestId, (int)AttachmentTypeEnum.PrivateLabel);
            return attachments.FirstOrDefault().AttachmentId;
        }

    }
}
