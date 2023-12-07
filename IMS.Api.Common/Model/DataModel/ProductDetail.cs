using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.ResponseModel;
using System.ComponentModel.DataAnnotations;

namespace IMS.Api.Common.Model.DataModel
{
    public class ProductDetail : BaseModel
    {

        [Key]
        public long Id { get; set; }
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
        public string Description { get; set; }
        public int CompanyId { get; set; } = APIConfig.CompanyId;
    }
}
