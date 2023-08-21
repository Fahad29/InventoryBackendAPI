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
    public class CompanyCore : ICompanyCore
    {
        IRepository<Company> _iRepository;
        APIResponse _apiResponse;
        public CompanyCore(IRepository<Company> iRepository, APIResponse apiResponse)
        {
            _iRepository = iRepository;
            _apiResponse = apiResponse;
        }

        public async Task<APIResponse> Search(BaseFilter model)
        {
            APIConfig.Log.Debug("CALLING API\" company Get all \"  STARTED");
            try
            {

                List<Company> companies = _iRepository.Search(model, Constant.SpGetCompany).ToList();
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

        public async Task<APIResponse> GetById(int CompanyId)
        {
            APIConfig.Log.Debug("CALLING API\" company GetById \"  STARTED");
            try
            {
                Company company = _iRepository.Search(new { Id = CompanyId }, Constant.SpGetCompany).FirstOrDefault();
                if (company != null)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, company);
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

        public async Task<APIResponse> Create(CompanyRequestModel model, Params @params)
        {
            APIConfig.Log.Debug("CALLING API\" company create \"  STARTED");
            try
            {
                Company company = model.MapTo<Company>();
                company.CreatedBy = @params.UserId;
                company = _iRepository.CreateSP<Company>(company, Constant.SpCreateCompany);

                return _apiResponse.ReturnResponse(HttpStatusCode.Created, company);
                
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
     
        }

        public async Task<APIResponse> Update(CompanyUpdateRequestModel model, Params @params)
        {
            try
            {
                APIConfig.Log.Debug("CALLING API\" company update \"  STARTED");
                Company company = model.MapTo<Company>();
                company.UpdatedBy = @params.UserId;
                company.UpdatedOn =DateTime.UtcNow;
                company = _iRepository.CreateSP<Company>(company, Constant.SpUpdateCompany);
                return _apiResponse.ReturnResponse(HttpStatusCode.OK, company);

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);

            }
            


        }

        public async Task<APIResponse> Delete(int CompanyId, Params @params)
        {
            APIConfig.Log.Debug("CALLING API\" company delete \"  STARTED");
            try
            {
                if (CompanyId > 0)
                {

                    _iRepository.CreateSP<Company>(new { Id = CompanyId, UpdatedBy = @params.UserId }, Constant.SpDeleteCompany);
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
