using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.ResponseModel;
using IMS.Api.Core.ICoreService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        readonly ICountryCore _countryCore;
        public CountryController(ICountryCore countryCore)
        {
            _countryCore = countryCore;
        }

        [AllowAnonymous, HttpPost, Route("Search")]
        public async Task<IActionResult> Search(BaseFilter model)
        {
            try
            {
                APIResponse response = await _countryCore.Search(model);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [AllowAnonymous, HttpPost, Route("Create")]
        public async Task<IActionResult> Create(CountryRequestModel model)
        {
            try
            {
                APIResponse response = await _countryCore.Create(model);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return null;
            }
        }



    }

}