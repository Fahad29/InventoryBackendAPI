namespace IMS.Api.Common.Model.RequestModel
{
    public class WarehouseProductRequestModel
    {
        public int Id { get; set; }
        public int WareHouseId { get; set; }
        public int ProductId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateOnly ManufacturerLabel { get; set; }
        public DateOnly ExpiryLabel { get; set; }
        public decimal Quantity { get; set; }
    }
}
