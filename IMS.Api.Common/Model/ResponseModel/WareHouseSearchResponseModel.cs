﻿using IMS.Api.Common.Model.RequestModel;

namespace IMS.Api.Common.Model.ResponseModel
{
    public class WareHouseSearchResponseModel :WareHouseCreateRequestModel
    {
        public string? CompanyName { get; set; }
    }
}
