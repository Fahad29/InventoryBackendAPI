using IMS.Api.Common.Constant;
using IMS.Api.Common.Extensions;
using IMS.Api.Common.Model;
using IMS.Api.Common.Model.CommonModel;
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
        public CompanyCore(IRepository<CompanyRequestModel> iRepository, APIResponse apiResponse)
        {
            _iRepository = iRepository;
            _apiResponse = apiResponse;
        }

        public async Task<APIResponse> GetAll()
        {
            APIConfig.Log.Debug("CALLING API\" company Get all \"  STARTED");
            try
            {
                Object obj = new
                {

                };
                List<Company> companies = _iRepository.Search<Company>(obj, Constant.SpGetCompany).ToList();
                if(companies.Count > 0)
                {
                    _apiResponse.StatusCode = HttpStatusCode.OK;
                    _apiResponse.Response = companies;
                }
                else
                {
                    _apiResponse.StatusCode = HttpStatusCode.NoContent;
                }
                
                
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: "+ex);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
            }
            APIConfig.Log.Debug("CALLING API\" company Get all \"  ENDED");
            return _apiResponse.ReturnResponse(_apiResponse.StatusCode,_apiResponse.Response);
        }

        public async Task<APIResponse> GetById(int CompanyId)
        {
            APIConfig.Log.Debug("CALLING API\" company GetById \"  STARTED");
            try
            {
                Company company = _iRepository.Search<Company>(new { CompanyId = CompanyId }, Constant.SpGetCompany).FirstOrDefault();
                if(company != null) {
                    _apiResponse.StatusCode = HttpStatusCode.OK;
                    _apiResponse.Response = company;
                }
                else
                {
                    _apiResponse.StatusCode = HttpStatusCode.NoContent;
                }
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
            }
            APIConfig.Log.Debug("CALLING API\" company GetById \"  ENDED");
            return _apiResponse.ReturnResponse(_apiResponse.StatusCode, _apiResponse.Response);
        }

        public async Task<APIResponse> Create(CompanyRequestModel model, Params @params)
        {
            APIConfig.Log.Debug("CALLING API\" company create \"  STARTED");
            try
            {
                Company company = model.MapTo<Company>();
                company.CreatedBy = @params.UserId;
                company = _iRepository.CreateSP<Company>(company, Constant.SpCreateCompany);

                _apiResponse.StatusCode = HttpStatusCode.Created;
                _apiResponse.Response = company;
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
            }
            APIConfig.Log.Debug("CALLING API\" company create \"  ENDED");
            return _apiResponse.ReturnResponse(_apiResponse.StatusCode, _apiResponse.Response);
        }

        public async Task<APIResponse> Update(CompanyRequestModel model, Params @params)
        {
            APIConfig.Log.Debug("CALLING API\" company update \"  STARTED");
            try
            {
                Company company = model.MapTo<Company>();
                //company.UpdatedBy = @params.UserId;
                company = _iRepository.CreateSP<Company>(company, Constant.SpUpdateCompany);
                _apiResponse.StatusCode = HttpStatusCode.OK;
                _apiResponse.Response = company;
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
            }
            APIConfig.Log.Debug("CALLING API\" company update \"  ENDED");
            return _apiResponse.ReturnResponse(_apiResponse.StatusCode, _apiResponse.Response);
        }

        public async Task<APIResponse> Delete(int CompanyId, Params @params)
        {
            APIConfig.Log.Debug("CALLING API\" company delete \"  STARTED");
            try
            {
                Company company = _iRepository.CreateSP<Company>(new { CompanyId  = CompanyId }, Constant.SpGetCompany);
                if(company == null)
                {
                    company.IsActive = Constant.False;
                    //company.IsDeleted = Constant.True;
                    //company.UpdatedBy = @params.UserId;
                }
                company = _iRepository.CreateSP<Company>(company, Constant.SpUpdateCompany);
                _apiResponse.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
            }
            APIConfig.Log.Debug("CALLING API\" company delete \"  ENDED");
            return _apiResponse.ReturnResponse(_apiResponse.StatusCode, _apiResponse.Response);
        }


    }
}
