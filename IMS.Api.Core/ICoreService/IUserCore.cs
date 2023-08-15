﻿using IMS.Api.Common.Model;
using IMS.Api.Common.Model.RequestModel;

namespace IMS.Api.Core.ICoreService
{
    public interface IUserCore
    {
        Task<APIResponse> GetAll();
        Task<APIResponse> GetById(int userId);
        Task<APIResponse> Create(UserRequest userRequest);
        Task<APIResponse> Update(UserRequest userRequest);
        Task<APIResponse> Delete(int CompanyId);
    }
}