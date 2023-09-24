namespace IMS.Api.Common.Model.ResponseModel
{
    public class AttachmentResponse
    {
        public long AttachmentId { get; set; }
        public long RequestId { get; set; }
        public int AttachmentTypeId { get; set; }
        public string AttachmentType { get; set; }
        public string Extension { get; set; }
        public string OrignalName { get; set; }
        public string AttachmentName { get; set; }
        public string AttachmentPath { get; set; }
    }
}
