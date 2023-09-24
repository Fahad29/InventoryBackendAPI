using Newtonsoft.Json.Serialization;
using System.Diagnostics.CodeAnalysis;

namespace IMS.Api.Common.Helper
{
    public class LowercaseContractResolver : DefaultContractResolver
    {
        [ExcludeFromCodeCoverage]
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToLower();
        }
    }
}
