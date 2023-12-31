﻿using IMS.Api.Common.Constant;
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
    public class CustomerCore : ICustomerCore
    {
        IRepository<Customer> _iRepository;
        APIResponse _apiResponse;
        public CustomerCore(IRepository<Customer> iRepository, APIResponse apiResponse)
        {
            _iRepository = iRepository;
            _apiResponse = apiResponse;
        }

        public async Task<APIResponse> Search(CustomerSearchRequestModel model)
        {
            APIConfig.Log.Debug("CALLING API\" customer Get all \"  STARTED");
            try
            {

                List<CustomerSearchResponseModel> customerSearchResponseModel = _iRepository.Search<CustomerSearchResponseModel>(model, Constant.SpGetCustomer).ToList();
                if (customerSearchResponseModel.Count > 0)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, customerSearchResponseModel);

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

        public async Task<APIResponse> GetById(int CustomerId)
        {
            APIConfig.Log.Debug("CALLING API\" customer GetById \"  STARTED");
            try
            {
                Customer customer = _iRepository.Search(new { Id = CustomerId }, Constant.SpGetCustomerById).FirstOrDefault();
                if (customer != null)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, customer);
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

        //public async Task<APIResponse> Create(CustomerCreateRequestModel model)
        //{
        //    APIConfig.Log.Debug("CALLING API\" customer create \"  STARTED");
        //    try
        //    {
        //        Customer customer = model.MapTo<Customer>();
        //        customer = _iRepository.CreateSP<Customer>(customer, Constant.SpCreateCustomer);

        //        return _apiResponse.ReturnResponse(HttpStatusCode.Created, customer);

        //    }
        //    catch (Exception ex)
        //    {
        //        APIConfig.Log.Debug("Exception: " + ex.Message);
        //        return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
        //    }

        //}

        public async Task<APIResponse> Update(CustomerUpdateRequestModel model)
        {
            try
            {
                APIConfig.Log.Debug("CALLING API\" customer update \"  STARTED");
                Customer customer = model.MapTo<Customer>();
                customer = _iRepository.CreateSP<Customer>(customer, Constant.SpUpdateCustomer);
                return _apiResponse.ReturnResponse(HttpStatusCode.OK, customer);

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> Delete(int CustomerId)
        {
            APIConfig.Log.Debug("CALLING API\" customer delete \"  STARTED");
            try
            {
                if (CustomerId > 0)
                {

                    _iRepository.CreateSP<Customer>(new { Id = CustomerId, UpdatedBy = APIConfig.UserId }, Constant.SpDeleteCustomer);
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
        public async Task<APIResponse> TotalCount(CustomerSearchRequestModel model)
        {
            APIConfig.Log.Debug("CALLING API\" Customer TotalCount \"  STARTED");
            try
            {
                int? TotalCount = _iRepository.Search<int>(model, Constant.SpGetCustomerTotalCount).FirstOrDefault();
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
