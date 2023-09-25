using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace IMS.Api.Common.Model.RequestModel
{
    public class ProductCreateRequestModel
    {

        [Required]
        public int BrandId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public int CompanyId { get; set; }
        [Required]
        public int ItemQuantityId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string BarcodeValue { get; set; }
        public string Description { get; set; }
        public List<IFormFile> ProductImages { get; set; }
    }

    public class ProductUpdateRequestModel : ProductCreateRequestModel
    {
        [Key]
        public int Id { get; set; }
      
    }

}
