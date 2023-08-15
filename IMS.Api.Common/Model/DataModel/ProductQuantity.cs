using System.ComponentModel.DataAnnotations;

namespace IMS.Api.Common.Model.DataModel
{
    public class ProductQuantity
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
        public bool IsActive { get; set; }
    }
}
