﻿using Microsoft.Extensions.Configuration;

namespace IMS.Api.Common.Model.CommonModel
{

    public static class APIConfig
    {
        public static IConfiguration Configuration { get; set; }
        public static Serilog.ILogger Log { get; set; }
        public static Serilog.ILogger TransLog { get; set; }
        public static int UserId { get; set; }
        public static int CompanyId { get; set; }
        public static int TaxValue { get; set; } = 5;
        public static int RoleId { get; set; }
        public static string ContentRootPath { get; set; }

    }
}
