using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.DataModel;
using IMS.Api.Common.Model;
using IMS.Api.Core.ICoreService;
using IMS.Api.Service.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using IMS.Api.Common.Constant;
using IMS.Api.Common.Model.ResponseModel;

namespace IMS.Api.Core.CoreService
{
    public class DropdownCore : IDropdownCore
    {
        IRepository<DropdownResponse> _iRepository;
        APIResponse _apiResponse;
        public DropdownCore(IRepository<DropdownResponse> iRepository, APIResponse apiResponse)
        {
            _iRepository = iRepository;
            _apiResponse = apiResponse;
        }
        public async Task<APIResponse> GetModules()
        {
            APIConfig.Log.Debug("Getting Module Data From DropdownCore ");

            try
            {
                List<DropdownResponse> modules = _iRepository.Search(null, Constant.SpGetModules).ToList();
                if (modules.Count > 0)
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, modules);
                else
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, Constant.RecordNotFound);
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<APIResponse> GetDropdownByModuleId(int ModuleId)
        {
            APIConfig.Log.Debug("Getting Dropdown By Module Id Data From DropdownCore ");
            try
            {
                List<DropdownResponse> myDropdowns = _iRepository.Search(new { ModuleId = ModuleId }, Constant.SpGetDropdownbyModule).ToList();

                if (myDropdowns.Count > 0)
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, myDropdowns);
                else
                    return _apiResponse.ReturnResponse(HttpStatusCode.NoContent, Constant.RecordNotFound);
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
