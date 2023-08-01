using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace IMS.Controllers
{
    public class BaseController : ControllerBase
    {
       // public IUser CurrentUser;
        long _userid = 0;
        public long UserID { get { return _userid; } set { _userid = value; } }
    }
}
