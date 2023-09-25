using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

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
        public List<IFormFile> Attachments { get; set; }
    }

}
