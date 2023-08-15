namespace IMS.Api.Common.Model.DataModel
{
    public class WareHouse : BaseModel
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string Address { get; set; }

    }
}
