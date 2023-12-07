using IMS.Api.Common.Model.CommonModel;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IMS.Api.Common.Model.RequestModel
{
    public class ProductRequestModel
    {
        [Required]
        public int BrandId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int ItemQuantityId { get; set; }
        [Required]
        public string BarcodeValue { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        [JsonIgnore]
        public int CompanyId { get; set; } = APIConfig.CompanyId;
        public List<IFormFile> Attachments { get; set; }
    }
    public class ProductUpdateRequestModel : ProductRequestModel
    {
        public int Id { get; set; }
    }
}