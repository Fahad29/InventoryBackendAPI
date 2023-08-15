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
        public int Name { get; set; }
        public int Description { get; set; }
    }
}
