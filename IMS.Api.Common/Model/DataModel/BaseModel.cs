namespace IMS.Api.Common.Model.DataModel
{
    public class BaseModel
    {
        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; } = DateTime.UtcNow;
        public int UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
    }
}
