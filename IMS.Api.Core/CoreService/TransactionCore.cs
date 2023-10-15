using IMS.Api.Common.Constant;
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
using System.Net;

namespace IMS.Api.Core.CoreService
{
    public class TransactionCore : ITransactionCore
    {
        IRepository<Transaction> _iRepository;
        APIResponse _apiResponse;
        public TransactionCore(IRepository<Transaction> iRepository, APIResponse apiResponse)
        {
            _iRepository = iRepository;
            _apiResponse = apiResponse;
        }

        public async Task<APIResponse> Search(TransactionSearchRequestModel model)
        {
            APIConfig.Log.Debug("CALLING API\" transaction Get all \"  STARTED");
            try
            {
                List<TransactionSearchResponseModel> transactionSearchResponseModel = _iRepository.Search<TransactionSearchResponseModel>(model, Constant.SpGetTransaction).ToList();
                if (transactionSearchResponseModel.Count > 0)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, transactionSearchResponseModel);
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

        public async Task<APIResponse> GetById(int TransactionId)
        {
            APIConfig.Log.Debug("CALLING API\" transaction GetById \"  STARTED");
            try
            {
                Transaction transaction = _iRepository.Search(new { Id = TransactionId }, Constant.SpGetTransactionById).FirstOrDefault();
                if (transaction != null)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, transaction);
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

        public async Task<APIResponse> Delete(int TransactionId)
        {
            APIConfig.Log.Debug("CALLING API\" transaction delete \"  STARTED");
            try
            {
                if (TransactionId > 0)
                {

                    _iRepository.CreateSP<Transaction>(new { Id = TransactionId, UpdatedBy = APIConfig.UserId }, Constant.SpDeleteTransaction);
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
        public async Task<APIResponse> TotalCount(TransactionSearchRequestModel model)
        {
            APIConfig.Log.Debug("CALLING API\" Transaction TotalCount \"  STARTED");
            try
            {
                int? TotalCount = _iRepository.Search<int>(model, Constant.SpGetTransactionTotalCount).FirstOrDefault();
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
