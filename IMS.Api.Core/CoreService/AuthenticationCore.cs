using IMS.Api.Common.Constant;
using IMS.Api.Common.Extensions;
using IMS.Api.Common.Helper;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.DataModel;
using IMS.Api.Common.Model.Params;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.ResponseModel;
using IMS.Api.Core.CoreService;
using IMS.Api.Service.IRepository;
using Microsoft.IdentityModel.Tokens;
using SendGrid.Helpers.Mail.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;
using System.Text;
using static IMS.Api.Common.Enumerations.Eumeration;
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
                            loginResponseModel.UserId = user?.UserId;
                            loginResponseModel.UserName = user?.FirstName + " " + user?.LastName;
                            loginResponseModel.Email = user?.Email;
                            loginResponseModel.IsActive = user?.IsActive;
                            loginResponseModel.UserRoleId = user?.UserRoleId;
                            loginResponseModel.CompanyId = user?.CompanyId;
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
                        user.UserRoleId = model?.UserRoleId != null ? model.UserRoleId : (int)UserRoleEnum.Company;
                        user.CompanyId = Convert.ToInt32(company?.CompanyId);
                        user.MobileNo = model?.PhoneNumber;
                        user.PasswordHash = model.Password != null ? model.Password.MD5Encrypt() : ExtensionMethod.GenPassword();

                        user = _iRepository.CreateSP<User>(user, Constant.SpCreateUser);
                    }
                    return _apiResponse.ReturnResponse(HttpStatusCode.Created, Constant.SuccessResponse);
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
            string Htmlcontent = string.Empty;
            User user = _iRepository.Search<User>(new { UserName = emailAddress }, Constant.SpGetUser)?.FirstOrDefault();
            if (user != null && emailAddress != null)
            {
                user.OTPExpire = DateTime.UtcNow;
                user.OTP = ExtensionMethod.Generate5DigitOTP().ToString();

                user = _iRepository.Search<User>(user, Constant.SpUpdateUser)?.FirstOrDefault();

                Htmlcontent = ExtensionMethod.CreateEmailBody(@params.ContentRootPath.MapPath(Constant.SendOTP));
                @params.ContentRootPath = @params.ContentRootPath.MapPath(Constant.SendOTP);

                using (MailMessage mm = new MailMessage(Constant.CompanyEmail, emailAddress))
                {
                    try
                    {
                        SendEmailView emailmodel = new SendEmailView();

                        mm.Subject = "OTP Verification Code";

                        string body = string.Empty;
                        body = ExtensionMethod.CreateEmailBody(@params.ContentRootPath);

                        Htmlcontent = Htmlcontent.Replace("{{phonenumber}}", Constant.ContactNumber);
                        Htmlcontent = Htmlcontent.Replace("{{supportemail}}", Constant.supportemail);
                        Htmlcontent = Htmlcontent.Replace("{{supporturl}}", Constant.supporturl);
                        Htmlcontent = Htmlcontent.Replace("{{CompanyName}}", Constant.CompanyName);
                        Htmlcontent = Htmlcontent.Replace("{{email}}", Constant.CompanyEmail);
                        Htmlcontent = Htmlcontent.Replace("{{Weblink}}", Constant.WebLink);
                        Htmlcontent = Htmlcontent.Replace("{{Websitelink}}", Constant.WebLink);
                        Htmlcontent = Htmlcontent.Replace("{{Logo}}", Constant.LogoUrl);
                        Htmlcontent = Htmlcontent.Replace("{{OTP}}", user?.OTP);

                        EmailProvider.CreateEmail(Constant.FromEmail, new List<string>() { emailAddress })
                        .CC()
                        .BCC()
                        .WithSubject(Constant.OTPSubject)
                        .WithHtmlContent(Htmlcontent)
                        .Send();
                    }
                    catch (Exception ex)
                    {
                        APIConfig.Log.Debug("Sending OTP Email Exception :" + ex.Message);
                    }

                }
                //return _apiResponse.ReturnResponse(HttpStatusCode.OK, Constant.OTPSendResponse);
                return _apiResponse.ReturnResponse(HttpStatusCode.OK, new { OTP = user.OTP, ExpiryTime = "1 Minute" });
            }
            else
            {
                return _apiResponse.ReturnResponse(HttpStatusCode.Unauthorized, Constant.UnAuthorized);
            }

        }

        public APIResponse VerifyOTP(OTPVerificationRequestModel model)
        {
            User user = _iRepository.Search<User>(new { UserName = model.EmailAddress }, Constant.SpGetUser)?.FirstOrDefault();
            if (user != null)
            {
                if (user?.OTPExpire?.AddMinutes(1) <= DateTime.UtcNow)
                {
                    if (user.OTP == model.OTP)
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
