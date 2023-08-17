using System.ComponentModel.DataAnnotations;

namespace IMS.Api.Common.Model.RequestModel
{
    public class ProductRequestModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int BrandId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int ItemQuantityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
