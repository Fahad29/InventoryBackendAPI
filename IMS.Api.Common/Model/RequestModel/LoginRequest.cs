﻿using System.ComponentModel.DataAnnotations;

namespace IMS.Api.Common.Model
{
    public  class LoginRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
