namespace IMS.Api.Common.Model.ResponseModel.Export
{
    public class CompanyProductExportResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public int ItemQuantityId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime ExpiryDate { get; set; }

    }
}
