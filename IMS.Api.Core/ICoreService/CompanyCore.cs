using IMS.Api.Common.Constant;
using IMS.Api.Common.Extensions;
using IMS.Api.Common.Model;
using IMS.Api.Common.Model.DataModel;
using IMS.Api.Common.Model.Params;
using IMS.Api.Core.CoreService;
using IMS.Api.Service.IRepository;
using System.Net;

namespace IMS.Api.Core.ICoreService
{
    public class CompanyCore : ICompanyCore<CompanyRequestModel>
    {
        IRepository<CompanyRequestModel> _iRepository;
        APIResponse _apiResponse;
        public CompanyCore(IRepository<CompanyRequestModel> iRepository,APIResponse apiResponse)
        {
            _iRepository = iRepository;
            _apiResponse = apiResponse;
        }

        public async Task<APIResponse> GetAll()
        {
            try
            {
                return _apiResponse.ReturnResponse(HttpStatusCode.OK, _apiResponse);
                //return apiResponse.ReturnResponse(HttpStatusCode.BadRequest, "Invalid Credentials");
            }
            catch (Exception ex)
            {
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> GetById(int CompanyId)
        {
            try
            {
                return _apiResponse.ReturnResponse(HttpStatusCode.OK, _apiResponse);
                //return apiResponse.ReturnResponse(HttpStatusCode.BadRequest, "Invalid Credentials");
            }
            catch (Exception ex)
            {
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> Create(CompanyRequestModel model, Params @params)
        {
            try
            {
                Company company = model.MapTo<Company>();
                company.CreatedBy = @params.UserId;
                Company companyResponseModel = _iRepository.CreateSP<Company>(company, Constant.SpCreateCompany);

                if (companyResponseModel?.CompanyId != null && companyResponseModel?.CompanyId > 0)
                {
                    User user = new User();
                    user.FirstName = model?.FirstName;
                    user.LastName = model?.LastName;
                    user.Email = model?.Email;
                    user.CompanyId = Convert.ToInt32(companyResponseModel?.CompanyId);
                    user.MobileNo = model?.Mobile;
                    user.PasswordHash = string.IsNullOrEmpty(model?.Password?.MD5Encrypt()) ? ExtensionMethod.GenPassword() : model?.Password?.MD5Encrypt();

                    _iRepository.CreateSP(user, Constant.SpCreateUser);
                }
                //_apiResponse.Response = companyResponseModel;
                return _apiResponse.ReturnResponse(HttpStatusCode.Created, _apiResponse);
            }
            catch (Exception ex)
            {
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> Update(CompanyRequestModel companyRequest, Params @params)
        {
            try
            {
                return _apiResponse.ReturnResponse(HttpStatusCode.OK, _apiResponse);
                //return apiResponse.ReturnResponse(HttpStatusCode.BadRequest, "Invalid Credentials");
            }
            catch (Exception ex)
            {
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> Delete(int CompanyId, Params @params)
        {
            try
            {
                return _apiResponse.ReturnResponse(HttpStatusCode.OK, _apiResponse);
                //return apiResponse.ReturnResponse(HttpStatusCode.BadRequest, "Invalid Credentials");
            }
            catch (Exception ex)
            {
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

      
    }
}
