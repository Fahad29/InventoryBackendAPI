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

        public async Task<APIResponse> Create(PrivateLabelCreateRequestModel model, Params @params)
        {
            APIConfig.Log.Debug("CALLING API\" privateLabel create \"  STARTED");
            try
            {
                string PLSidebarLogoDirPath = Constant.PLSidebarLogoDirPath;
                string PLLoginLogoDirPath = Constant.PLLoginLogoDirPath;
                string PLFavLogoDirPath = Constant.PLFavLogoDirPath;
                string logoFile = string.Empty;
                string FeviconFile = string.Empty;
                string splashScreenFile = string.Empty;
                string path = string.Empty;
                string ExactPath = string.Empty;
                PrivateLabel PLGManager = new PrivateLabel();
                List<string> AllowedExtension = new List<string>() { "image/jpeg", "image/jpg", "image/png", "images/gif", "image/x-icon", "image/svg+xml" };

                PrivateLabel privateLabel = new PrivateLabel();
               

                if (!string.IsNullOrEmpty(model?.SidebarLogo?.value))
                {
                    if (AllowedExtension.Contains(model?.SidebarLogo?.filetype?.ToLower()))
                    {
                        logoFile = "ComID_"+model.CompanyId.ToString() + Constant.FileTypeOfLogo + model.SidebarLogo.filename;
                        byte[] logoBytes = Convert.FromBase64String(model.SidebarLogo.value);

                        privateLabel.SidebarLogo = path = System.IO.Path.Combine(PLSidebarLogoDirPath, logoFile);

                        ExactPath = @params.ContentRootPath.MapPath(path);
                        System.IO.File.WriteAllBytes(ExactPath, logoBytes);
                    }
                    else
                    {
                        _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, Constant.ImageExtension);
                    }
                }
                if (!string.IsNullOrEmpty(model?.FavLogo?.value))
                {
                    if (AllowedExtension.Contains(model?.FavLogo?.filetype?.ToLower()))
                    {
                        logoFile = "ComID_" + model.CompanyId.ToString() + Constant.FileTypeOfLogo + model.FavLogo.filename;
                        byte[] logoBytes = Convert.FromBase64String(model.FavLogo.value);

                        privateLabel.FavLogo = path = System.IO.Path.Combine(PLFavLogoDirPath, logoFile);

                        ExactPath = @params.ContentRootPath.MapPath(path);
                        System.IO.File.WriteAllBytes(ExactPath, logoBytes);
                    }
                    else
                    {
                        _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, Constant.ImageExtension);
                    }
                }
                if (!string.IsNullOrEmpty(model?.LoginLogo?.value))
                {
                    if (AllowedExtension.Contains(model?.LoginLogo?.filetype?.ToLower()))
                    {
                        logoFile = "ComID_" + model.CompanyId.ToString() + Constant.FileTypeOfLogo + model.LoginLogo.filename;
                        byte[] logoBytes = Convert.FromBase64String(model.LoginLogo.value);

                        privateLabel.LoginLogo = path = System.IO.Path.Combine(PLLoginLogoDirPath, logoFile);

                        ExactPath = @params.ContentRootPath.MapPath(path);
                        System.IO.File.WriteAllBytes(ExactPath, logoBytes);
                    }
                    else
                    {
                        _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, Constant.ImageExtension);
                    }
                }

                privateLabel.CustomURL = model?.CustomURL;
                privateLabel.ThemesColor = model?.ThemesColor;
                privateLabel.SidebarBackgroundColor = model?.SidebarBackgroundColor;
                privateLabel.HeaderBackgroundColor = model?.HeaderBackgroundColor;
                privateLabel.HeaderTextColor = model?.HeaderTextColor;
                privateLabel.MenuHighlightColor = model?.MenuHighlightColor;
                privateLabel.MenuTextColor = model?.MenuTextColor;
                privateLabel.SupportURL = model?.SupportURL;
                privateLabel.FromEmail = model?.FromEmail;
                privateLabel.CreatedBy = @params.UserId;
                privateLabel = _iRepository.CreateSP<PrivateLabel>(privateLabel, Constant.SpCreatePrivateLabel);

                return _apiResponse.ReturnResponse(HttpStatusCode.Created, Constant.SuccessResponse);

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
                string PLSidebarLogoDirPath = Constant.PLSidebarLogoDirPath;
                string PLLoginLogoDirPath = Constant.PLLoginLogoDirPath;
                string PLFavLogoDirPath = Constant.PLFavLogoDirPath;
                string logoFile = string.Empty;
                string FeviconFile = string.Empty;
                string splashScreenFile = string.Empty;
                string path = string.Empty;
                string ExactPath = string.Empty;
                PrivateLabel PLGManager = new PrivateLabel();
                List<string> AllowedExtension = new List<string>() { "image/jpeg", "image/jpg", "image/png", "images/gif", "image/x-icon", "image/svg+xml" };

                PrivateLabel privateLabel = new PrivateLabel();


                if (!string.IsNullOrEmpty(model?.SidebarLogo?.value))
                {
                    if (AllowedExtension.Contains(model?.SidebarLogo?.filetype?.ToLower()))
                    {
                        logoFile = "ComID_" + model.CompanyId.ToString() + Constant.FileTypeOfLogo + model.SidebarLogo.filename;
                        byte[] logoBytes = Convert.FromBase64String(model.SidebarLogo.value);

                        privateLabel.SidebarLogo = path = System.IO.Path.Combine(PLSidebarLogoDirPath, logoFile);

                        ExactPath = @params.ContentRootPath.MapPath(path);
                        System.IO.File.WriteAllBytes(ExactPath, logoBytes);
                    }
                    else
                    {
                        _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, Constant.ImageExtension);
                    }
                }
                if (!string.IsNullOrEmpty(model?.FavLogo?.value))
                {
                    if (AllowedExtension.Contains(model?.FavLogo?.filetype?.ToLower()))
                    {
                        logoFile = "ComID_" + model.CompanyId.ToString() + Constant.FileTypeOfLogo + model.FavLogo.filename;
                        byte[] logoBytes = Convert.FromBase64String(model.FavLogo.value);

                        privateLabel.FavLogo = path = System.IO.Path.Combine(PLFavLogoDirPath, logoFile);

                        ExactPath = @params.ContentRootPath.MapPath(path);
                        System.IO.File.WriteAllBytes(ExactPath, logoBytes);
                    }
                    else
                    {
                        _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, Constant.ImageExtension);
                    }
                }
                if (!string.IsNullOrEmpty(model?.LoginLogo?.value))
                {
                    if (AllowedExtension.Contains(model?.LoginLogo?.filetype?.ToLower()))
                    {
                        logoFile = "ComID_" + model.CompanyId.ToString() + Constant.FileTypeOfLogo + model.LoginLogo.filename;
                        byte[] logoBytes = Convert.FromBase64String(model.LoginLogo.value);

                        privateLabel.LoginLogo = path = System.IO.Path.Combine(PLLoginLogoDirPath, logoFile);

                        ExactPath = @params.ContentRootPath.MapPath(path);
                        System.IO.File.WriteAllBytes(ExactPath, logoBytes);
                    }
                    else
                    {
                        _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, Constant.ImageExtension);
                    }
                }

                privateLabel.Id = model.Id;
                privateLabel.CustomURL = model?.CustomURL;
                privateLabel.ThemesColor = model?.ThemesColor;
                privateLabel.SidebarBackgroundColor = model?.SidebarBackgroundColor;
                privateLabel.HeaderBackgroundColor = model?.HeaderBackgroundColor;
                privateLabel.HeaderTextColor = model?.HeaderTextColor;
                privateLabel.MenuHighlightColor = model?.MenuHighlightColor;
                privateLabel.MenuTextColor = model?.MenuTextColor;
                privateLabel.SupportURL = model?.SupportURL;
                privateLabel.FromEmail = model?.FromEmail;
                privateLabel.UpdatedBy = @params.UserId;
                privateLabel = _iRepository.CreateSP<PrivateLabel>(privateLabel, Constant.SpUpdatePrivateLabel);
                return _apiResponse.ReturnResponse(HttpStatusCode.OK, Constant.UpdateRecord);

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

        public async Task<APIResponse> TotalCount(int? CompanyId)
        {
            APIConfig.Log.Debug("CALLING API\" PrivateLabel TotalCount \"  STARTED");
            try
            {
                int? TotalCount = _iRepository.Search<int>(new { CompanyId = CompanyId }, Constant.SpGetPrivateLabelTotalCount).FirstOrDefault();
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
