using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Api.Common.Model.CommonModel
{
    public class APIError
    {
        [JsonProperty(PropertyName = "iserror")]
        private bool IsError { get; set; }
        [JsonProperty(PropertyName = "error")]
        private string ErrorMsg { get; set; }
        [JsonProperty(PropertyName = "errorcode")]
        private int ErrorCode { get; set; }
   

        public APIError(bool iserror, string msg, int errorcode)
        {
            this.IsError = iserror;
            this.ErrorMsg = StatusMessage = msg;
            this.ErrorCode = StatusCode = errorcode;
        }

        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }

    }
}
