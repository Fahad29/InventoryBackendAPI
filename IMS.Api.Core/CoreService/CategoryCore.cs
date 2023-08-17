using IMS.Api.Common.Constant;
using IMS.Api.Common.Model;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.DataModel;
using IMS.Api.Core.ICoreService;
using IMS.Api.Service.IRepository;
using System.Net;

namespace IMS.Api.Core.CoreService
{
    public class CategoryCore : ICategoryCore
    {
        IRepository<Category> _iRepository;
        APIResponse _apiResponse;
        public CategoryCore(IRepository<Category> iRepository, APIResponse apiResponse)
        {
            _iRepository = iRepository;
            _apiResponse = apiResponse;
        }

        public async Task<APIResponse> GetAll()
        {
            APIConfig.Log.Debug("CALLING API\" Category Get all \"  STARTED");
            try
            {
                Object obj = new
                {

                };
                List<Category> categories = _iRepository.Search(obj, Constant.SpGetAllProductCategories).ToList();

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

        public async Task<APIResponse> Create(string Name)
        {
            APIConfig.Log.Debug("CALLING API\" company create \"  STARTED");
            try
            {
                Category category = new Category();
                category.Name = Name;
                category = _iRepository.CreateSP<Category>(category, Constant.SpCreateProductCategory);

                return _apiResponse.ReturnResponse(HttpStatusCode.Created, category);

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        public async Task<APIResponse> Delete(int categoryId)
        {
            APIConfig.Log.Debug("CALLING API\" Category delete \"  STARTED");
            try
            {
                if (categoryId > 0)
                {
                    _iRepository.CreateSP<Category>(new { Id = categoryId }, Constant.SpDeleteProductCategory);
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, Constant.DeleteRecord);
                }
                else
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, "Invalid Category Selected");


            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
