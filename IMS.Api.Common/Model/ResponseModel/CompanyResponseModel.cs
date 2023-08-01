using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Api.Common.Model.ResponseModel
{
    public class CompanyResponseModel
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Fax { get; set; }
        public string LandLine { get; set; }
        public string Mobile { get; set; }
    }
}
