using IMS.Api.Common.Constant;
using IMS.Api.Common.Extensions;
using IMS.Api.Common.Model;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.DataModel;
using IMS.Api.Common.Model.Params;
using IMS.Api.Common.Model.RequestModel;
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

        public async Task<APIResponse> GetAll(BaseFilter model)
        {
            APIConfig.Log.Debug("CALLING API\" branches Get all \"  STARTED");
            try
            {

                List<Branch> branches = _iRepository.Search(model, Constant.SpGetBranch).ToList();
                if (branches.Count > 0)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, branches);

                }
                else
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, null);
                }


            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> GetById(int BranchId)
        {
            APIConfig.Log.Debug("CALLING API\" branches GetById \"  STARTED");
            try
            {
                Branch user = _iRepository.Search(new { BranchId = BranchId }, Constant.SpGetBranch).FirstOrDefault();
                if (user != null)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, user);
                }
                else
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, null);
                }
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> Create(BranchRequestModel model,Params @params)
        {
            APIConfig.Log.Debug("CALLING API\" branches create \"  STARTED");
            try
            {
                Branch branch = model.MapTo<Branch>();
                branch.CreatedBy = @params.UserId;
                branch = _iRepository.CreateSP<Branch>(branch, Constant.SpCreateBranch);
                return _apiResponse.ReturnResponse(HttpStatusCode.Created, branch);
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> Update(BranchRequestModel model, Params @params)
        {
            try
            {
                APIConfig.Log.Debug("CALLING API\" branches update \"  STARTED");
                Branch branch = model.MapTo<Branch>();
                branch.UpdatedBy = @params.UserId;
                branch = _iRepository.CreateSP<Branch>(branch, Constant.SpUpdateBranch);
                return _apiResponse.ReturnResponse(HttpStatusCode.OK, branch);

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> Delete(int BranchId, Params @params)
        {
            APIConfig.Log.Debug("CALLING API\" branches delete \"  STARTED");
            try
            {
                Branch branch = _iRepository.CreateSP<Branch>(new { BranchId = BranchId }, Constant.SpGetBranch);
                if (branch == null)
                {
                    branch.IsActive = false;
                    branch.IsDeleted = Constant.True;
                    branch.UpdatedBy = @params.UserId;
                    branch = _iRepository.CreateSP<Branch>(branch, Constant.SpUpdateBranch);
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, branch);
                }
                else
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, null);
                }

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }

        }
    }
}
