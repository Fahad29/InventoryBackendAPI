using IMS.Api.Common.Constant;
using IMS.Api.Common.Model;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.DataModel;
using IMS.Api.Core.ICoreService;
using IMS.Api.Service.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
                List<Category> categories = _iRepository.Search(obj, Constant.SpGetCompany).ToList();

                if (categories.Count > 0)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, categories);

                }
                else
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, null);
                }


            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex);
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
                category = _iRepository.CreateSP<Category>(category, Constant.SpCreateCompany);

                return _apiResponse.ReturnResponse(HttpStatusCode.Created, category);

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex);
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
                    Category category = new();
                    category.Id = categoryId;
                    category.IsActive = Constant.False;
                    category = _iRepository.CreateSP<Category>(category, Constant.SpUpdateCompany);
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, string.Empty);
                }
                else
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, string.Empty);
                }

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
