using Microsoft.Extensions.Primitives;
using System.Security.Claims;
using static IMS.Api.Common.Enumerations.Eumeration;

namespace Oculus.Extensions
{
    public static class ExtenstionMethods
    {



        /// <summary>
        /// User EntityId 
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        public static int? GetId(this ClaimsPrincipal principal)
        {
            return int.Parse(principal.FindFirstValue(ClaimTypes.NameIdentifier));
        }
        /// <summary>
        /// This Current User UserID 
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        public static int GetUserId(this ClaimsPrincipal principal)
        {
            int userId = 0;
            int.TryParse(principal.FindFirstValue(ClaimTypes.Sid), out userId);
            return userId;
        }

        public static string GetUserAuth(this ClaimsPrincipal principal)
        {
            string auth = "";
            auth = principal.FindFirstValue(ClaimTypes.Authentication);
            return auth;
        }


        public static UserRoleEnum GetUserRole(this ClaimsPrincipal principal)
        {
            return (UserRoleEnum)int.Parse(principal.FindFirstValue(ClaimTypes.Role));
        }

  
        public static string GetUserName(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue(ClaimTypes.Name);
        }
        public static string GetUserEmail(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue(ClaimTypes.Email);
        }
  
        public static bool GetHeader(this HttpContext httpContext,string Key,out string Value)
        {
            StringValues sv;
            bool b = httpContext.Request.Headers.TryGetValue(Key, out sv);
            Value = sv;
            return b; 
        }

    }


    
}
