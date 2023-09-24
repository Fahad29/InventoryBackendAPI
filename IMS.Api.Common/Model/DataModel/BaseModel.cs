using IMS.Api.Common.Model.CommonModel;

namespace IMS.Api.Common.Model.DataModel
{
    public class BaseModel
    {
        public int CreatedBy { get; set; } = APIConfig.UserId;
        public DateTime? CreatedOn { get; set; } = DateTime.Now;
        public int UpdatedBy { get; set; } = APIConfig.UserId;
        public DateTime? UpdatedOn { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
    }
}
