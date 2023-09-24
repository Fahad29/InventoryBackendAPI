using IMS.Api.Common.Model.CommonModel;
using System.Buffers.Text;

namespace IMS.Api.Common.Model.DataModel
{
    public class CompanyProduct : BaseModel
    {
        public int Id { get; set; }
        public int CompanyId { get; set; } = APIConfig.CompanyId;
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string BarCode { get; set; }
        public Decimal Price { get; set; }
        public DateTime ManufactureDate { get; set; } = Convert.ToDateTime("1900-01-01");
        public DateTime ExpiryDate { get; set; } = Convert.ToDateTime("1900-01-01");
    }
}
