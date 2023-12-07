using IMS.Api.Common.Model.DataModel;

namespace IMS.Api.Common.Model.ResponseModel
{
    public class ProductResponseModel
    {
        public ProductResponseModel()
        {
            attachments = new List<AttachmentResponse>();
        }
        public long CompanyProductId { get; set; }
        public long ProductDetailId{ get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public decimal Price { get; set; } = 0.0M;
        public int QuantityId { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal Stock { get; set; }
        public string Quantity { get; set; }
        public string BarcodeValue { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<AttachmentResponse> attachments { get; set; }
    }
}