namespace IMS.Api.Common.Model.RequestModel
{
    public class AttachmentUploadRequestModel
    {
        public int RequestID { get; set; }
        public int AttachmentType { get; set; } = 3;
        public long CreatedBy { get; set; }
    }
}
