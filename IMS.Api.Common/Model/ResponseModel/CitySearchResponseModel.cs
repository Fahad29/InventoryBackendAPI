﻿using IMS.Api.Common.Model.RequestModel;

namespace IMS.Api.Common.Model.ResponseModel
{
    public class CitySearchResponseModel : CityRequestModel
    {
        public string? CountryName { get; set; }
    }
}