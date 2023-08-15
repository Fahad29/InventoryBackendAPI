﻿using IMS.Api.Common.Model;
using IMS.Api.Common.Model.Params;

namespace IMS.Api.Core.CoreService
{
    public interface ICompanyCore
    {
        Task<APIResponse> GetAll();
        Task<APIResponse> GetById(int CompanyId);
        Task<APIResponse> Create(CompanyRequestModel companyRequest ,Params @params);
        Task<APIResponse> Update(CompanyRequestModel companyRequest, Params @params);
        Task<APIResponse> Delete(int CompanyId, Params @params);

    }
}