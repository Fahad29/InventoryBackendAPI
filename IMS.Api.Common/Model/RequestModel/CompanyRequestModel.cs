﻿namespace IMS.Api.Common.Model.RequestModel
{
    public class CompanyRequestModel
    {
        public string? CompanyName { get; set; }
        public string? Address { get; set; }
        public string? Fax { get; set; }
        public string? LandLine { get; set; }
        public string? Mobile { get; set; }

        // User Params
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

    }
}
