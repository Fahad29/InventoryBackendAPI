using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.ResponseModel;
using IMS.Api.Common.Model;
using IMS.Api.Core.ICoreService;
using IMS.Api.Service.IRepository;
using System.Net;
using IMS.Api.Common.Extensions;
using IMS.Api.Common.Constant;

namespace IMS.Api.Core.CoreService
{
    public class CityCore : ICityCore
    {
        IRepository<City> _iRepository;
        APIResponse _apiResponse;
        public CityCore(IRepository<City> iRepository, APIResponse apiResponse)
        {
            _iRepository = iRepository;
            _apiResponse = apiResponse;
        }

        public async Task<APIResponse> Search(BaseFilter model)
        {
            APIConfig.Log.Debug("CALLING API\" City Get all \"  STARTED");
            try
            {
                List<City> categories = _iRepository.Search(model, Constant.SpGetCity).ToList();

                if (categories.Count > 0)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, categories);

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

        public async Task<APIResponse> Create(CityRequestModel model)
        {
            APIConfig.Log.Debug("CALLING API\" company create \"  STARTED");
            try
            {
                City city = model.MapTo<City>();
                city = _iRepository.CreateSP<City>(city, Constant.SpCreateCity);

                return _apiResponse.ReturnResponse(HttpStatusCode.Created, city);

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        public async Task<APIResponse> Delete(int cityId)
        {
            APIConfig.Log.Debug("CALLING API\" City delete \"  STARTED");
            try
            {
                if (cityId > 0)
                {
                    _iRepository.CreateSP<City>(new { Id = cityId }, Constant.SpDeleteCity);
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, Constant.DeleteRecord);
                }
                else
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, "Invalid City Selected");


            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> DropDown()
        {
            APIConfig.Log.Debug("CALLING API\" City DropDown \"  STARTED");
            try
            {

                List<DropdownResponse> dropDownList = _iRepository.Search<DropdownResponse>(null, Constant.SpGetCity).ToList();

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
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
