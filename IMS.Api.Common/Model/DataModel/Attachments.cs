using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Api.Common.Model.DataModel
{
    public class Attachment
    {
        public long AttachmentId { get; set; }
        public long RequestId { get; set; }
        public int AttachmentType { get; set; }
        public string Extension { get; set; }
        public string OrignalName { get; set; }
        public string AttachmentName { get; set; }
        public string AttachmentPath { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedBy { get; set; }
        public bool IsDeleted { get; set; }

    }
}
