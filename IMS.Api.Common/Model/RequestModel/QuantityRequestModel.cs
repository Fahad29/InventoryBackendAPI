using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IMS.Api.Common.Model.RequestModel
{
    public class QuantityRequestModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        [Required]
        public decimal Quantity { get; set; }
        [Required]
        public string Unit { get; set; }
    }
}
