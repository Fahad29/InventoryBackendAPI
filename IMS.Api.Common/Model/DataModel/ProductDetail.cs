using System.ComponentModel.DataAnnotations;

namespace IMS.Api.Common.Model.DataModel
{
    public class ProductDetail
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
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; }

    }
}
