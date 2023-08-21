using IMS.Api.Common.Constant;
using IMS.Api.Common.Extensions;
using IMS.Api.Common.Model;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.DataModel;
using IMS.Api.Common.Model.Params;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.ResponseModel;
using IMS.Api.Core.CoreService;
using IMS.Api.Service.IRepository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace IMS.Api.Core.ICoreService
{
    public class AuthenticationCore : IAuthenticationCore
    {
        APIResponse _apiResponse;
        readonly IRepository<Company> _iRepository;
        public AuthenticationCore(APIResponse apiResponse, IRepository<Company> iRepository)
        {
            this._iRepository = iRepository;
            this._apiResponse = apiResponse;
        }

        public async Task<APIResponse> Login(LoginRequest loginRequest)
        {
            try
            {
                LoginResponseModel loginResponseModel = new LoginResponseModel();
                if (!string.IsNullOrEmpty(loginRequest?.Username) && !string.IsNullOrEmpty(loginRequest?.Password))
                {
                    loginRequest.Password = loginRequest?.Password?.MD5Encrypt();
                    User user = _iRepository.CreateSP<User>(loginRequest, Constant.SpGetUser);
                    if (user != null)
                    {
                        string expiry = APIConfig.Configuration?.GetSection("JWT")["ExpiryMinutes"].ToString();
                        if (user.IsActive)
                        {
                            loginResponseModel.Token = ExtensionMethod.GenerateJSONWebToken(user, expiry);
                            loginResponseModel.UserId = Convert.ToInt32(user?.UserId);
                            loginResponseModel.UserName = user?.FirstName + " " + user?.LastName;
                            loginResponseModel.Email = user?.Email;
                            loginResponseModel.IsActive = Convert.ToBoolean(user?.IsActive);
                            _apiResponse.Response = loginResponseModel;
                        }

                        else
                        {
                            return _apiResponse.ReturnResponse(HttpStatusCode.Unauthorized, Constant.NotActive);
                        }

                    }
                    else
                    {
                        return _apiResponse.ReturnResponse(HttpStatusCode.Unauthorized, Constant.InvalidUser);
                    }

                }
                //model.Token = Extensions.ExtensionMethods.GenerateJSONWebToken(user, expiry);
                return _apiResponse.ReturnResponse(HttpStatusCode.OK, _apiResponse.Response);
            }
            catch (Exception ex)
            {
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        public async Task<APIResponse> Register(RegisterRequest model)
        {
            APIConfig.Log.Debug("CALLING API\" user create \"  STARTED");
            try
            {
                int? CompanyId = _iRepository.CreateSP<Company>(new { CompanyName = model.CompanyName }, Constant.SpGetCompany)?.CompanyId;
                if (CompanyId == null || CompanyId == 0)
                {
                    Company company = new Company();
                    company.CompanyName = model.CompanyName;
                    company = _iRepository.CreateSP<Company>(company, Constant.SpCreateCompany);
                    if (company?.CompanyId != null && company?.CompanyId > 0)
                    {
                        User user = new User();
                        user.FirstName = model?.FirstName;
                        user.LastName = model?.Lastname;
                        user.Email = model?.Email;
                        user.CompanyId = Convert.ToInt32(company?.CompanyId);
                        user.MobileNo = model?.PhoneNumber;
                        user.PasswordHash = model.Password != null ? model.Password.MD5Encrypt() : ExtensionMethod.GenPassword();

                        user = _iRepository.CreateSP<User>(user, Constant.SpCreateUser);
                    }
                    return _apiResponse.ReturnResponse(HttpStatusCode.Created, company);
                }
                else
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, "Company Already Exist!");
                }

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            APIConfig.Log.Debug("CALLING API\" user create \"  ENDED");
        }
        public async Task<APIResponse> ForgotPassword(string Email)
        {
            try
            {
                return _apiResponse.ReturnResponse(HttpStatusCode.OK, _apiResponse);
            }
            catch (Exception ex)
            {
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //public APIResponse Refreshtoken(string refreshtoken)
        //{
        //    String token = String.Empty;
        //    String expiry = String.Empty;
        //    int UserRoleID;
        //    User user = new User();

        //    if (!String.IsNullOrEmpty(refreshtoken))
        //    {
        //        if (refreshtoken.Contains("bearer"))
        //        {
        //            token = refreshtoken.Split(" ").Last();
        //        }
        //        else
        //        {
        //            token = refreshtoken;
        //        }
        //        if (!ValidateJWTBlackListed(token))
        //        {
        //            // if (CheckTokenIsExpired(token))
        //            {
        //                var tokenHandler = new JwtSecurityTokenHandler();
        //                var key = Encoding.ASCII.GetBytes(APIConfig.Configuration?.GetSection("JWT")["KEY"]);
        //                try
        //                {
        //                    var TokenData = tokenHandler.ReadJwtToken(token);

        //                    if (TokenData != null)
        //                    {
        //                        int.TryParse(TokenData.Claims.FirstOrDefault(x => x.Type.Contains("role")).Value.ToString(), out UserRoleID);
        //                        string email = TokenData.Claims.FirstOrDefault(x => x.Type == "email").Value.ToString();

        //                        user = _iRepository.Search<User>(new { Username = email, UserRoleId = UserRoleID }, Constant.SpGetAllUser).FirstOrDefault();

        //                        if (user != null)
        //                        {
        //                            expiry = APIConfig.Configuration?.GetSection("JWT")["ExpiryMinutes"].ToString();
        //                            _iRepository.Search<int>(new { Token = token }, Constant.SpCreateBlackListToken)?.FirstOrDefault();
        //                            token = ExtensionMethod.GenerateJSONWebToken(user, expiry);
        //                            _apiResponse.Response = new { token = token };
        //                        }
        //                        else
        //                        {
        //                            _apiResponse.StatusCode = 100;
        //                            _apiResponse.StatusMessage = Constant.InvalidToken;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        _apiResponse.StatusCode = ((int)ResponseCode.InvalidToken);
        //                        _apiResponse.StatusMessage = Constant.InvalidToken;
        //                    }
        //                }
        //                catch (Exception e)
        //                {
        //                    _apiResponse.StatusCode = ((int)ResponseCode.InvalidToken);
        //                    _apiResponse.StatusMessage = Constant.InvalidToken;
        //                }
        //            }

        //        }
        //        else
        //        {
        //            _apiResponse.StatusCode = ((int)ResponseCode.BlockedToken);
        //            _apiResponse.StatusMessage = Constant.BlockedToken;
        //        }
        //    }
        //    else
        //    {
        //        _apiResponse.StatusCode = ((int)ResponseCode.TokenRequired);
        //        _apiResponse.StatusMessage = Constant.TokenRequired;
        //    }

        //    return _apiResponse;
        //}

        public bool CheckTokenIsExpired(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(APIConfig.Configuration?.GetSection("JWT")["KEY"]);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                return false;
            }
        }

        public bool IsTokenExpired(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            var expiration = jwtToken.ValidTo;
            var now = DateTime.UtcNow;

            return expiration < now;
        }

        public APIResponse GetOTP(string emailAddress, Params @params)
        {
            User  user= _iRepository.Search<User>(new { UserName = emailAddress }, Constant.SpGetUser)?.FirstOrDefault();
            if (user  != null && emailAddress != null)
            {
                user.OTPExpire = DateTime.UtcNow;
                user.OTP = ExtensionMethod.Generate5DigitOTP().ToString();

                user =  _iRepository.Search<User>(user, Constant.SpUpdateUser)?.FirstOrDefault();

                @params.ContentRootPath = @params.ContentRootPath.MapPath(Constant.SendOTP);

                using (MailMessage mm = new MailMessage(Constant.CompanyEmail, emailAddress))
                {
                    mm.Subject = "OTP Verification Code";

                    string body = string.Empty;
                    body = ExtensionMethod.CreateEmailBody(@params.ContentRootPath);

                    body = body.Replace("{{phonenumber}}", Constant.ContactNumber);
                    body = body.Replace("{{supportemail}}", Constant.supportemail);
                    body = body.Replace("{{supporturl}}", Constant.supporturl);
                    body = body.Replace("{{CompanyName}}", Constant.CompanyName);
                    body = body.Replace("{{email}}", Constant.CompanyEmail);
                    body = body.Replace("{{Weblink}}", Constant.WebLink);
                    body = body.Replace("{{Websitelink}}", Constant.WebLink);
                    body = body.Replace("{{Logo}}", Constant.LogoUrl);
                    body = body.Replace("{{OTP}}", user?.OTP);

                    mm.Body = body;
                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = Constant.Host;
                    smtp.EnableSsl = true;

                    NetworkCredential NetworkCred = new NetworkCredential(Constant.SMTPuser, Constant.SMTPpassword);
                    smtp.UseDefaultCredentials = Convert.ToBoolean(Constant.EnableSSL);
                    smtp.Credentials = NetworkCred;
                    smtp.Port = int.Parse(Constant.Port);
                    smtp.Send(mm);

                }
                return _apiResponse.ReturnResponse(HttpStatusCode.OK, Constant.OTPSendResponse);
            }
            else
            {
                return _apiResponse.ReturnResponse(HttpStatusCode.Unauthorized, Constant.UnAuthorized);
            }
           
        }

        public APIResponse VerifyOTP(OTPVerificationRequestModel model)
        {
            User user  = _iRepository.Search<User>(new { UserName = model.EmailAddress }, Constant.SpGetUser)?.FirstOrDefault();
            if (user == null)
            {
                if(user?.OTPExpire?.AddMinutes(1) <= DateTime.UtcNow)
                {
                    if(user.OTP == model.OTP)
                    {
                        user.OTP = null;
                        user.OTPExpire = null;
                        _iRepository.Search(user, Constant.SpUpdateUser)?.FirstOrDefault();
                        return _apiResponse.ReturnResponse(HttpStatusCode.OK, Constant.OTPVerified);
                    }
                    else
                    {
                        return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, Constant.OTPNotCorrect);
                    }

                }
                else
                {
                    return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, Constant.OTPExpired);
                }
            }
            else
            {
                return _apiResponse.ReturnResponse(HttpStatusCode.Unauthorized, Constant.UnAuthorized);
            }
        }
    }
}
