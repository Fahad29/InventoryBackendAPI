using IMS.Api.Common.Constant;
using IMS.Api.Common.Extensions;
using IMS.Api.Common.Model;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.DataModel;
using IMS.Api.Common.Model.Params;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.RequestModel.SearchModel;
using IMS.Api.Common.Model.ResponseModel;
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

        public async Task<APIResponse> Create(BranchCreateRequestModel model, Params @params)
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
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> Update(BranchUpdateRequestModel model, Params @params)
        {
            try
            {
                APIConfig.Log.Debug("CALLING API\" branches update \"  STARTED");
                Branch branch = model.MapTo<Branch>();
                branch.UpdatedBy = @params.UserId;
                branch = _iRepository.CreateSP<Branch>(branch, Constant.SpUpdateBranch);
                return _apiResponse.ReturnResponse(HttpStatusCode.OK, Constant.UpdateRecord);

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> Delete(int BranchId, Params @params)
        {
            APIConfig.Log.Debug("CALLING API\" branches delete \"  STARTED");
            try
            {
                if (BranchId > 0)
                {

                    _iRepository.CreateSP<Company>(new { Id = BranchId, UpdatedBy = @params.UserId }, Constant.SpDeleteCompanyBranch);
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
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }

        }
        
        public async Task<APIResponse> Search(BranchSearchRequestModel model)
        {
            APIConfig.Log.Debug("CALLING API\" branches Get all \"  STARTED");
            try
            {

                List<BranchSearchResponseModel> branches = _iRepository.Search<BranchSearchResponseModel>(model, Constant.SpGetBranch).ToList();
                if (branches.Count > 0)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, branches);

                }
                else
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, Constant.RecordNotFound);
                }


            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> GetById(int BranchId)
        {
            APIConfig.Log.Debug("CALLING API\" branches GetById \"  STARTED");
            try
            {
                Branch user = _iRepository.Search(new { Id = BranchId }, Constant.SpGetBranchById).FirstOrDefault();
                if (user != null)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, user);
                }
                else
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, Constant.RecordNotFound);
                }
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> TotalCount(int? CompanyId)
        {
            APIConfig.Log.Debug("CALLING API\" Branch TotalCount \"  STARTED");
            try
            {
                int? TotalCount = _iRepository.Search<int>(new { CompanyId = CompanyId }, Constant.SpGetBranchTotalCount).FirstOrDefault();
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

        public async Task<APIResponse> DropDown(int? CompanyId)
        {
            APIConfig.Log.Debug("CALLING API\" Branch DropDown \"  STARTED");
            try
            {

                List<DropdownResponse> dropDownList = _iRepository.Search<DropdownResponse>(new { CompanyId = CompanyId }, Constant.SpGetBranch).ToList();
                if (dropDownList.Count > 0)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, dropDownList);

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
