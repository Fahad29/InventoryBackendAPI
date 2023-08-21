using IMS.Api.Common.Model;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Core.ICoreService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        readonly ICityCore _cityCore;
        public CityController(ICityCore cityCore)
        {
            _cityCore = cityCore;
        }

        [AllowAnonymous, HttpPost, Route("Search")]
        public async Task<IActionResult> GetAll(BaseFilter model)
        {
            try
            {
                APIResponse response = await _cityCore.Search(model);
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
        public async Task<IActionResult> Create(CityRequestModel model)
        {
            try
            {
                APIResponse response = await _cityCore.Create(model);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        [AllowAnonymous, HttpGet, Route("DropDown")]
        public async Task<IActionResult> DropDown()
        {
            try
            {
                APIResponse response = await _cityCore.DropDown();
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

}