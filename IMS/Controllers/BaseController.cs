using IMS.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers
{
    public class BaseController : ControllerBase
    {
        // public IUser CurrentUser;
        long _userid = 0;
        long _companyId = 0;
        public long UserID { get { return User.GetUserId(); } set { _userid = value; } }
        public long CompanyId { get { return User.GetUserCompanyId(); } set { _companyId = value; } }


    }
}
