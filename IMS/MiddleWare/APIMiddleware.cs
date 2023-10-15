using IMS.Api.Common.Constant;
using IMS.Api.Common.Extensions;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.ResponseModel;
using IMS.Api.Core.CoreService;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace IMS.MiddleWare
{
    public class APIMiddleware
    {
        StringValues authKey;
        APIResponse apiResponse = null;
        private RequestDelegate next;
        public APIMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            string Path, endpoint = string.Empty;
            try
            {
                bool isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";
                httpContext.Request.EnableBuffering();

                Path = endpoint = httpContext?.Request?.Path.Value.ToLower();

                Path = Path.Substring(Path.LastIndexOf("/") + 1).ToLower();
                switch (Path)
                {

                    case "login":
                    case "register":
                    case "getotp":
                    case "verifyotp":


                        await LogRequestResponse(httpContext, Path);
                        break;
                    default:
                        {
                            if (httpContext.Request.Headers.TryGetValue("Authorization", out authKey))
                            {
                                APIUser Token = null;

                                if (authKey == "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9")
                                {
                                    await LogRequestResponse(httpContext, endpoint);
                                }
                                else
                                {
                                    var TokenData = ValidateJwtToken(authKey, httpContext);

                                    if (TokenData == Constant.SuccessResponse)
                                    {
                                        await LogRequestResponse(httpContext, endpoint);
                                    }

                                    else if (TokenData.ToLower().Contains(Constant.TokenExpireMsgs))
                                    {
                                        httpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                                        APIError e1 = new APIError(true, Constant.TokenExpireMsg, (int)HttpStatusCode.Forbidden);
                                        await httpContext.Response.WriteAsync(e1.ToJson()).ConfigureAwait(false);
                                    }
                                    else
                                    {
                                        await InvalidToken(httpContext);
                                    }
                                }
                            }
                            else
                            {
                                await AccessDenied(httpContext);
                            }

                            break;
                        }
                }
            }
            catch (Exception ex)
            {

                Log.Error($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);

            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.Headers.Add("access-control-allow-origin", "*");
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = "Internal Server Error from the custom middleware." + exception.Message.ToString()
            }.ToString()); ;
        }

        [ExcludeFromCodeCoverage]
        private async Task<bool> LogRequestResponse(HttpContext httpContext, string endpoint)
        {
            try
            {

                string request = await LogRequest(httpContext.Request, endpoint);
                string response = string.Empty;

                var originalResponseBody = httpContext.Response.Body;


                using (var responseBody = new MemoryStream())
                {

                    httpContext.Response.Body = responseBody;
                    await next.Invoke(httpContext).ConfigureAwait(true);
                    response = await LogResponse(httpContext.Response, endpoint);

                    await responseBody.CopyToAsync(originalResponseBody);


                }

                Log.Debug($"...endpoint is {endpoint.ToLower()}");
                switch (endpoint.ToLower())
                {

                }
            }
            catch (Exception ex)
            {
                return true;
            }
            return true;
        }

        [ExcludeFromCodeCoverage]
        private async Task<string> LogRequest(Microsoft.AspNetCore.Http.HttpRequest request, string endpoint)
        {
            try
            {
                var body = request.Body;

                //This line allows us to set the reader for the request back at the beginning of its stream.
                request.EnableBuffering();

                //We now need to read the request stream.  First, we create a new byte[] with the same length as the request stream...
                var buffer = new byte[Convert.ToInt32(request.ContentLength)];

                //...Then we copy the entire request stream into the new buffer.
                await request.Body.ReadAsync(buffer, 0, buffer.Length);

                //We convert the byte[] into a string using UTF8 encoding...
                var bodyAsText = System.Text.Encoding.UTF8.GetString(buffer);

                //..and finally, assign the read body back to the request body, which is allowed because of EnableRewind()
                request.Body = body;

                request.Body.Seek(0, System.IO.SeekOrigin.Begin);
                Log.Information($"{request.Scheme} {request.Host}{request.Path} {request.QueryString} {bodyAsText}");

                return bodyAsText;
            }
            catch (Exception)
            {
                return "";
            }
        }

        private async Task<string> LogResponse(HttpResponse response, string endpoint)
        {
            //We need to read the response stream from the beginning...
            response.Body.Seek(0, System.IO.SeekOrigin.Begin);

            //...and copy it into a string
            string text = await new System.IO.StreamReader(response.Body).ReadToEndAsync();
            text = text.ToLower();
            //We need to reset the reader for the response so that the client can read it.
            response.Body.Seek(0, System.IO.SeekOrigin.Begin);
            Log.Information($"{response.StatusCode}: {text}");

            return text;
        }

        public string ValidateJwtToken(string token, HttpContext httpcontext)
        {
            token = token?.Split(" ").Last();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(APIConfig.Configuration?.GetSection("JWT")["KEY"]);
            try
            {
                bool verified = new AuthenticationCore(apiResponse, null)
                    .IsTokenExpired(token);

                if (!verified)
                {
                    tokenHandler.ValidateToken(token, new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                        ClockSkew = TimeSpan.Zero
                    }, out SecurityToken validatedToken);

                    var TokenData = (JwtSecurityToken)validatedToken;

                    ClaimsIdentity identity = new ClaimsIdentity();
                    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, TokenData.Claims.FirstOrDefault(x => x.Type == "nameid").Value.ToString()));
                    identity.AddClaim(new Claim(ClaimTypes.Email, TokenData.Claims.FirstOrDefault(x => x.Type == "email").Value.ToString()));
                    identity.AddClaim(new Claim(ClaimTypes.GivenName, TokenData.Claims.FirstOrDefault(x => x.Type == "given_name").Value.ToString()));
                    identity.AddClaim(new Claim(ClaimTypes.Sid, TokenData.Claims.FirstOrDefault(x => x.Type.Contains("sid")).Value.ToString()));
                    identity.AddClaim(new Claim(ClaimTypes.Role, TokenData.Claims.FirstOrDefault(x => x.Type.Contains("role")).Value.ToString()));
                    identity.AddClaim(new Claim(ClaimTypes.PrimaryGroupSid, TokenData.Claims.FirstOrDefault(x => x.Type.Contains("primarygroupsid")).Value.ToString()));
                    identity.AddClaim(new Claim(ClaimTypes.Authentication, authKey));
                    httpcontext.User = new ClaimsPrincipal(identity);

                    int userId = 0;
                    int companyId = 0;
                    int roleId = 0;
                    int.TryParse(TokenData.Claims.FirstOrDefault(x => x.Type.Contains("sid")).Value.ToString(), out userId);
                    int.TryParse(TokenData.Claims.FirstOrDefault(x => x.Type.Contains("primarygroupsid")).Value.ToString(), out companyId);
                    int.TryParse(TokenData.Claims.FirstOrDefault(x => x.Type.Contains("role")).Value.ToString(), out roleId);
                    APIConfig.UserId = userId;
                    APIConfig.CompanyId = companyId;
                    APIConfig.RoleId = roleId;

                    return Constant.SuccessResponse;
                }
                else
                {
                    APIConfig.Log.Debug("ValidateJwtToken Else : Token: " + token + " Verified " + verified);
                    return Constant.TokenExpireMsgs;
                }
            }
            catch (SecurityTokenExpiredException tokenexpired)
            {
                APIConfig.Log.Debug("ValidateJwtToken Exception : " + tokenexpired.Message + " Stack Trace " + tokenexpired.StackTrace);
                return Constant.TokenExpireMsgs;
            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("ValidateJwtToken Exception : " + ex.Message + " Stack Trace " + ex.StackTrace);
                return Constant.TokenInvalidMsg;
            }
        }
        private async Task<bool> InvalidToken(HttpContext httpContext)
        {

            httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            APIResponse e1 = new APIResponse()
            {
                StatusCode = HttpStatusCode.BadRequest,
                StatusMessage = HttpStatusCode.BadRequest.ToString()
            };
            await httpContext.Response.WriteAsync(e1.ToJson()).ConfigureAwait(false);
            return true;
        }
        private async Task<bool> AccessDenied(HttpContext httpContext)
        {

            httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            APIError e1 = new APIError(true, "Access Denied", (int)HttpStatusCode.Unauthorized);
            await httpContext.Response.WriteAsync(e1.ToJson()).ConfigureAwait(false);
            return true;
        }



    }
    public static class APIMiddleApp
    {
        [ExcludeFromCodeCoverage]
        public static IApplicationBuilder APIKeyBuilder(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<APIMiddleware>();
        }
    }

}
