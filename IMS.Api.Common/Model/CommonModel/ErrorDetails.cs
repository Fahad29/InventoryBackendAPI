using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace IMS.Api.Common.Model.CommonModel
{
    public class ErrorDetails
    {
        [ExcludeFromCodeCoverage]
        public int StatusCode { get; set; }
        [ExcludeFromCodeCoverage]
        public string Message { get; set; }
        [ExcludeFromCodeCoverage]
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
