using IMS.Api.Common.Model;
using IMS.Api.Core.CoreService;
using IMS.Api.Service.IRepository;
using System.Net;

namespace IMS.Api.Core.ICoreService
{
    public class CompanyCore : ICompanyCore
    {
        IRepository<CompanyRequestModel> _iRepository;
        APIResponse _apiResponse;
        public CompanyCore(APIResponse apiResponse)
        {
            this._apiResponse = apiResponse;
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

        public async Task<APIResponse> Create(CompanyRequestModel companyRequest)
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

        public async Task<APIResponse> Update(CompanyRequestModel companyRequest)
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

        public async Task<APIResponse> Delete(int CompanyId)
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

//private IRepository<CompanyRequestModel> _iRepository;
//APIResponse apiResponse = new APIResponse();
////IRepository<CompanyRequestModel> iRepository
//public CompanyCore()
//{
//    //_iRepository = iRepository;
//}

//public APIResponse Create(CompanyRequestModel model, Params @params)
//{
//    Company company = model.MapTo<Company>();
//    company.CreatedBy = @params.UserId;
//    company = _iRepository.CreateSP<Company>(company, Constant.SpCreateCompany);

//    if (company?.CompanyId != null && company?.CompanyId > 0)
//    {

//        User user = new User();
//        user.FirstName = model?.FirstName;
//        user.LastName = model?.LastName;
//        user.Email = model?.Email;
//        user.CompanyId = Convert.ToInt32(company?.CompanyId);
//        user.MobileNo = model?.Mobile;
//        user.PasswordHash = string.IsNullOrEmpty(model?.Password?.MD5Encrypt()) ? ExtensionMethod.GenPassword() : model?.Password?.MD5Encrypt();

//        _iRepository.CreateSP(user, Constant.SpCreateUser);
//    }
//    apiResponse.Response = company;

//    return apiResponse;
//}

//public APIResponse Update(CompanyRequestModel model, Params @params)
//{
//    return apiResponse;
//}
//public APIResponse Delete(CompanyRequestModel model, Params @params)
//{
//    return apiResponse;
//}
//public APIResponse Get(int? Id)
//{
//    return apiResponse;
//}

//public APIResponse Search(CompanyRequestModel model)
//{
//    return apiResponse;
//}
//}
