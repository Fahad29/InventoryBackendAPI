using System.ComponentModel.DataAnnotations;

namespace IMS.Api.Common.Model.RequestModel
{
    public class QuantityRequestModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
    }
}
