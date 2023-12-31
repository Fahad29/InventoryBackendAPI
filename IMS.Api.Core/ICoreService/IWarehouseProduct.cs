﻿using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.ResponseModel;

namespace IMS.Api.Core.ICoreService
{
    public interface IWarehouseProduct
    {
        Task<APIResponse> GetAll();
        Task<APIResponse> GetById(int warehouseProductId);
        Task<APIResponse> Create(WarehouseProductRequestModel warehouseProductRequest, int CurrentUserId);
        Task<APIResponse> Update(WarehouseProductRequestModel warehouseProductRequest, int CurrentUserId);
        Task<APIResponse> Delete(int warehouseProductId);
    }
}
