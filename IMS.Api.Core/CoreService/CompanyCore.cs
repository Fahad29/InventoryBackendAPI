using IMS.Api.Common.Constant;
using IMS.Api.Common.Extensions;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.DataModel;
using IMS.Api.Common.Model.Params;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.ResponseModel;
using IMS.Api.Core.ICoreService;
using IMS.Api.Service.IRepository;
using System.Net;

namespace IMS.Api.Core.CoreService
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
            APIConfig.Log.Debug("CALLING API\" Company Get all \"  STARTED");
            try
            {

                List<CompanyResponseModel> companies = _iRepository.Search<CompanyResponseModel>(model, Constant.SpGetCompany).ToList();
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
            APIConfig.Log.Debug("CALLING API\" Company GetById \"  STARTED");
            try
            {
                Company Company = _iRepository.Search(new { Id = CompanyId }, Constant.SpGetCompany).FirstOrDefault();
                if (Company != null)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, Company);
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

        public async Task<APIResponse> Create(CompanyRequestModel model)
        {
            APIConfig.Log.Debug("CALLING API\" Company create \"  STARTED");
            try
            {
                Company Company = model.MapTo<Company>();
                Company = _iRepository.CreateSP<Company>(Company, Constant.SpCreateCompany);

                return _apiResponse.ReturnResponse(HttpStatusCode.Created, Company);

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        public async Task<APIResponse> Update(CompanyUpdateRequestModel model)
        {
            try
            {
                APIConfig.Log.Debug("CALLING API\" Company update \"  STARTED");
                Company Company = model.MapTo<Company>();
                Company = _iRepository.CreateSP<Company>(Company, Constant.SpUpdateCompany);
                return _apiResponse.ReturnResponse(HttpStatusCode.OK, Company);

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);

            }



        }

        public async Task<APIResponse> Delete(int CompanyId)
        {
            APIConfig.Log.Debug("CALLING API\" Company delete \"  STARTED");
            try
            {
                if (CompanyId > 0)
                {

                    _iRepository.CreateSP<Company>(new { Id = CompanyId, UpdatedBy = APIConfig.UserId }, Constant.SpDeleteCompany);
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

        public async Task<APIResponse> TotalCount(BaseFilter model)
        {
            APIConfig.Log.Debug("CALLING API\" Company TotalCount \"  STARTED");
            try
            {
                int? TotalCount = _iRepository.Search<int>(model, Constant.SpCompanyTotalCount).FirstOrDefault();
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
