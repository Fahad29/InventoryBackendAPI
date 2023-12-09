using System.ComponentModel.DataAnnotations;

namespace IMS.Api.Common.Model.RequestModel
{
    public class WarehouseCreateRequestModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        public string? Fax { get; set; }
        [Required]
        public string Address { get; set; }
    }
    public class WarehouseUpdateRequestModel : WarehouseCreateRequestModel
    {
        public int Id { get; set; }
    }
}
