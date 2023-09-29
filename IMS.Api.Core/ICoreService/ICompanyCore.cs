﻿using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.Params;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.ResponseModel;

namespace IMS.Api.Core.CoreService
{
    public interface IEmployeeCore
    {
        Task<APIResponse> Search(BaseFilter model);
        Task<APIResponse> GetById(int Id);
        Task<APIResponse> Create(EmployeeCreateRequestModel companyRequest );
        Task<APIResponse> Update(EmployeeUpdateRequestModel companyRequest);
        Task<APIResponse> Delete(int EmployeeId);
        Task<APIResponse> TotalCount(BaseFilter model);

    }
}
