using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.DataModel;
using IMS.Api.Common.Model.ResponseModel;
using IMS.Api.Core.ICoreService;
using IMS.Api.Service.IRepository;
using System.Net;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Extensions;
using IMS.Api.Common.Constant;

namespace IMS.Api.Core.CoreService
{
    public class CountryCore : ICountryCore
    {
        IRepository<Country> _iRepository;
        APIResponse _apiResponse;
        public CountryCore(IRepository<Country> iRepository, APIResponse apiResponse)
        {
            _iRepository = iRepository;
            _apiResponse = apiResponse;
        }

        public async Task<APIResponse> Search(BaseFilter model)
        {
            APIConfig.Log.Debug("CALLING API\" Country Get all \"  STARTED");
            try
            {
                List<Country> categories = _iRepository.Search(model, Constant.SpGetCountry).ToList();

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

        public async Task<APIResponse> Create(CountryRequestModel model)
        {
            APIConfig.Log.Debug("CALLING API\" company create \"  STARTED");
            try
            {
                Country country = model.MapTo<Country>();
                country = _iRepository.CreateSP<Country>(country, Constant.SpCreateCountry);

                return _apiResponse.ReturnResponse(HttpStatusCode.Created, country);

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        public async Task<APIResponse> Delete(int countryId)
        {
            APIConfig.Log.Debug("CALLING API\" Country delete \"  STARTED");
            try
            {
                if (countryId > 0)
                {
                    _iRepository.CreateSP<Country>(new { Id = countryId }, Constant.SpDeleteCountry);
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, Constant.DeleteRecord);
                }
                else
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, "Invalid Country Selected");


            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> DropDown()
        {
            APIConfig.Log.Debug("CALLING API\" Country DropDown \"  STARTED");
            try
            {

                List<DropdownResponse> dropDownList = _iRepository.Search<DropdownResponse>(null, Constant.SpGetCountry).ToList();

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
