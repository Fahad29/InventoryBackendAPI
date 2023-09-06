using IMS.Api.Common.Constant;
using IMS.Api.Common.Model;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.ResponseModel;
using IMS.Api.Core.ICoreService;
using IMS.Api.Service.IRepository;
using System.Net;

namespace IMS.Api.Core.CoreService
{
    public class AssignRightsCore : IAssignRightsCore
    {
        IRepository<DropdownResponse> _iRepository;
        APIResponse _apiResponse;
        public AssignRightsCore(IRepository<DropdownResponse> iRepository, APIResponse apiResponse)
        {
            _iRepository = iRepository;
            _apiResponse = apiResponse;
        }
        public async Task<APIResponse> GetRoleRights(int RoleId)
        {
            APIConfig.Log.Debug("Getting Module Data From DropdownCore ");

            try
            {
                List<RoleRightsResponse> modules = _iRepository.Search<RoleRightsResponse>(new { RoleId = RoleId }, Constant.SpGetRoleRights).ToList();
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
    }
}
