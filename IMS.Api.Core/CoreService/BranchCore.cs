using IMS.Api.Common.Constant;
using IMS.Api.Common.Extensions;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.DataModel;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.ResponseModel;
using IMS.Api.Common.Model.ResponseModel.Search;
using IMS.Api.Core.ICoreService;
using IMS.Api.Service.IRepository;
using System.Net;

namespace IMS.Api.Core.CoreService
{
    public class BranchCore : IBranchCore
    {
        IRepository<Branch> _iRepository;
        APIResponse _apiResponse;

        public BranchCore(IRepository<Branch> iRepository, APIResponse apiResponse)
        {
            _iRepository = iRepository;
            _apiResponse = apiResponse;
        }
        public async Task<APIResponse> Search(BranchSearchRequestModel model)
        {
            APIConfig.Log.Debug("******* Calling Branch Search API *******");
            try
            {
                model.CompanyId = APIConfig.CompanyId;
                GridData response = await _iRepository.SearchMuiltiple(model, Constant.SpGetBranch);
                // Access the data from the result
                if (response.DataList.Count() > 0)
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, response);
                else
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, Constant.RecordNotFound);
            }
            catch
            {
                throw;
            }
        }
        public async Task<APIResponse> GetById(int BranchId)
        {
            APIConfig.Log.Debug("******* Calling Branch GetById API *******");
            try
            {
                BranchResponseModel response = _iRepository.Search<BranchResponseModel>(new { Id = BranchId, CompanyId = APIConfig.CompanyId }, Constant.SpGetBranchById).FirstOrDefault();
                if (response != null)
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, response);
                else
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, Constant.RecordNotFound);
            }
            catch
            {
                throw;
            }
        }
        public async Task<APIResponse> Create(BranchCreateRequestModel model)
        {
            APIConfig.Log.Debug("******* Calling Branch Create API *******");
            try
            {
                Branch branch = model.MapTo<Branch>();
                branch.CompanyId = APIConfig.CompanyId;
                branch.CreatedBy = APIConfig.UserId;
                branch.CreatedOn = DateTime.Now;
                BranchResponseModel response = _iRepository.CreateSP<BranchResponseModel>(branch, Constant.SpCreateBranch);
                return _apiResponse.ReturnResponse(HttpStatusCode.Created, response);
            }
            catch
            {
                throw;
            }
        }
        public async Task<APIResponse> Update(BranchUpdateRequestModel model)
        {
            try
            {
                APIConfig.Log.Debug("******* Calling Branch Update API *******");
                Branch branch = model.MapTo<Branch>();
                branch.CompanyId = APIConfig.CompanyId;
                branch.UpdatedBy = APIConfig.UserId;
                branch.UpdatedOn = DateTime.Now;
                BranchResponseModel response = _iRepository.CreateSP<BranchResponseModel>(branch, Constant.SpUpdateBranch);
                return _apiResponse.ReturnResponse(HttpStatusCode.OK, Constant.UpdateRecord);
            }
            catch
            {
                throw;
            }
        }
        public async Task<APIResponse> Delete(int BranchId)
        {
            APIConfig.Log.Debug("******* Calling Branch Delete API *******");
            try
            {
                if (BranchId > 0)
                {
                    _iRepository.Delete(new
                    {
                        Id = BranchId,
                        CompanyId = APIConfig.CompanyId,
                        UpdatedBy = APIConfig.UserId
                    }, Constant.SpDeleteCompanyBranch);
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, Constant.DeleteRecord);
                }
                else
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, Constant.InValidRecordId);
            }
            catch
            {
                throw;
            }
        }
    }
}
