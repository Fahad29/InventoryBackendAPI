using IMS.Api.Common.Constant;
using IMS.Api.Common.Enumerations;
using IMS.Api.Common.Extensions;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.DataModel;
using IMS.Api.Common.Model.Params;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.ResponseModel;
using IMS.Api.Common.Model.ResponseModel.Search;
using IMS.Api.Core.ICoreService;
using IMS.Api.Service.IRepository;
using Microsoft.AspNetCore.Http;
using System.Net;
using static IMS.Api.Common.Enumerations.Eumeration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace IMS.Api.Core.CoreService
{
    public class EmployeeCore : IEmployeeCore
    {
        IRepository<Employee> _iRepository;
        APIResponse _apiResponse;
        IAttachmentCore _attachmentCore;
        public EmployeeCore(IRepository<Employee> iRepository, APIResponse apiResponse, IAttachmentCore attachmentCore)
        {
            _iRepository = iRepository;
            _apiResponse = apiResponse;
            _attachmentCore = attachmentCore;
        }

        public async Task<APIResponse> Search(EmployeeSearchRequestModel model)
        {
            APIConfig.Log.Debug("CALLING API\" Employee Get all \"  STARTED");
            try
            {

                List<EmployeeResponseModel> employeeResponseModelList = _iRepository.Search<EmployeeResponseModel>(model, Constant.SpGetEmployee).ToList();
                if (employeeResponseModelList.Count > 0)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, employeeResponseModelList);

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

        public async Task<APIResponse> GetById(int EmployeeId)
        {
            APIConfig.Log.Debug("CALLING API\" Employee GetById \"  STARTED");
            try
            {
                Employee Employee = _iRepository.Search(new { Id = EmployeeId }, Constant.SpGetEmployee).FirstOrDefault();
                if (Employee != null)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, Employee);
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

        public async Task<APIResponse> Create(EmployeeCreateRequestModel model)
        {
            APIConfig.Log.Debug("CALLING API\" Employee create \"  STARTED");
            try
            {

                User user = new User()
                {
                    FirstName = model?.Name,
                    Email = model?.Email,
                    UserRoleId = model.UserRoleId,
                    CompanyId = APIConfig.CompanyId,
                    MobileNo = model?.Mobile1,
                    PasswordHash = model.Password != null ? model.Password.MD5Encrypt() : ExtensionMethod.GenPassword(),
                };

                user = _iRepository.Search<User>(user, Constant.SpCreateUser)?.FirstOrDefault();
                long ProfilePhotoId;
                Employee employee = model.MapTo<Employee>();
                employee.UserId = user.UserId;
                employee = _iRepository.CreateSP<Employee>(employee, Constant.SpCreateEmployee);
                if (employee != null && user != null && model.ProfilePhoto != null)
                    await _attachmentCore.UploadImages(new List<IFormFile>() { model.ProfilePhoto }, user.UserId, (long)employee?.Id, (int)AttachmentTypeEnum.ProfilePicture);

                #region Email Work

                #endregion

                return _apiResponse.ReturnResponse(HttpStatusCode.Created, employee);
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        public async Task<APIResponse> Update(EmployeeUpdateRequestModel model)
        {
            try
            {
                APIConfig.Log.Debug("CALLING API\" Employee update \"  STARTED");
                Employee employee = model.MapTo<Employee>();
                employee = _iRepository.CreateSP<Employee>(employee, Constant.SpUpdateEmployee);
                if (model.ProfilePhoto != null)
                    await _attachmentCore.UploadImages(new List<IFormFile>() { model.ProfilePhoto }, (long)employee.UserId, (long)employee?.Id, (int)AttachmentTypeEnum.ProfilePicture);

                return _apiResponse.ReturnResponse(HttpStatusCode.OK, Constant.UpdateRecord);
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> Delete(int EmployeeId)
        {
            APIConfig.Log.Debug("CALLING API\" Employee delete \"  STARTED");
            try
            {
                if (EmployeeId > 0)
                {

                    _iRepository.CreateSP<Employee>(new { Id = EmployeeId, UpdatedBy = APIConfig.UserId }, Constant.SpDeleteEmployee);
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

        public async Task<APIResponse> TotalCount(EmployeeSearchRequestModel model)
        {
            APIConfig.Log.Debug("CALLING API\" Employee TotalCount \"  STARTED");
            try
            {
                int? TotalCount = _iRepository.Search<int>(model, Constant.SpEmployeeTotalCount).FirstOrDefault();
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
    }
}
