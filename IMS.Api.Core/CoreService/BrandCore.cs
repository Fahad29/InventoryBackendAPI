using IMS.Api.Common.Constant;
using IMS.Api.Common.Model;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.DataModel;
using IMS.Api.Core.ICoreService;
using IMS.Api.Service.IRepository;
using System.Net;

namespace IMS.Api.Core.CoreService
{
    public class BrandCore : IBrandCore
    {
        IRepository<Brand> _iRepository;
        APIResponse _apiResponse;
        public BrandCore(IRepository<Brand> iRepository, APIResponse apiResponse)
        {
            _iRepository = iRepository;
            _apiResponse = apiResponse;
        }

        public async Task<APIResponse> GetAll()
        {
            APIConfig.Log.Debug("CALLING API\" Brand Get all \"  STARTED");
            try
            {
                Object obj = new
                {

                };
                List<Brand> brands = _iRepository.Search(obj, Constant.SpGetCompany).ToList();
                if (brands.Count > 0)
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, brands);

                }
                else
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, null);
                }


            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> Create(string Name)
        {
            APIConfig.Log.Debug("CALLING API\" company create \"  STARTED");
            try
            {
                Brand brand = new Brand();
                brand.Name = Name;
                brand = _iRepository.CreateSP<Brand>(brand, Constant.SpCreateCompany);

                return _apiResponse.ReturnResponse(HttpStatusCode.Created, brand);

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        public async Task<APIResponse> Delete(int BrandId)
        {
            APIConfig.Log.Debug("CALLING API\" Brand delete \"  STARTED");
            try
            {
                Brand brand = new();
                if (brand == null)
                {
                    brand.Id = BrandId;
                    brand.IsActive = Constant.False;
                    brand = _iRepository.CreateSP<Brand>(brand, Constant.SpUpdateCompany);
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, brand);
                }
                else
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, null);
                }

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }

        }

    }
}
