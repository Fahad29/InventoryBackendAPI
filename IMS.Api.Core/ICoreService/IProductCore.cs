﻿using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.RequestModel.Search;
using IMS.Api.Common.Model.ResponseModel;

namespace IMS.Api.Core.ICoreService
{
    public interface IProductCore
    {
        Task<APIResponse> Search(ProductSearchRequestModel model);
        Task<APIResponse> GetById(long productId);
        Task<APIResponse> Create(ProductRequestModel productRequest);
        Task<APIResponse> Update(ProductUpdateRequestModel productRequest);
        Task<APIResponse> Delete(long productId, long UserId);
    }
}
