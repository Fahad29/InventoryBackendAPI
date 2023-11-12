using IMS.Api.Common.Model.ResponseModel;
using IMS.Api.Core.ICoreService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        readonly ICategoryCore _categoryCore;
        public CategoryController(ICategoryCore categoryCore)
        {
            _categoryCore = categoryCore;
        }

        [AllowAnonymous, HttpGet, Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                APIResponse response = await _categoryCore.GetAll();
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
        public async Task<IActionResult> Create(string Name)
        {
            try
            {
                APIResponse response = await _categoryCore.Create(Name);
                if (response?.Response != null)
                    return Ok(response);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

 
        [AllowAnonymous, HttpPost, Route("TotalCount")]
        public async Task<IActionResult> TotalCount()
        {
            try
            {
                APIResponse response = await _categoryCore.TotalCount();
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