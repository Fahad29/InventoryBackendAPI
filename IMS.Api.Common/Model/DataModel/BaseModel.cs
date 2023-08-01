namespace IMS.Api.Common.Model.DataModel
{
    public class BaseModel
    {
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
    }
}
