using IMS.Api.Common.Constant;
using IMS.Api.Common.Extensions;
using IMS.Api.Common.Model;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.DataModel;
using IMS.Api.Common.Model.ResponseModel;
using IMS.Api.Core.CoreService;
using IMS.Api.Service.IRepository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;

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
                if (!string.IsNullOrEmpty(loginRequest.Username) && !string.IsNullOrEmpty(loginRequest.Password))
                {
                    loginRequest.Password = loginRequest.Password.MD5Encrypt();
                    User user = _iRepository.CreateSP<User>(loginRequest, Constant.SpGetUser);
                    if (user != null)
                    {
                        string expiry = APIConfig.Configuration?.GetSection("JWT")["ExpiryMinutes"].ToString();
                        if (user.IsActive)
                        {
                            loginResponseModel.Token = ExtensionMethod.GenerateJSONWebToken(user, expiry);
                            loginResponseModel.UserId = (int)user.UserId;
                            loginResponseModel.UserName = user.FirstName + " " + user.LastName;
                            loginResponseModel.Email = user.Email;
                            loginResponseModel.IsActive = user.IsActive;
                            _apiResponse.Response = loginResponseModel;
                        }

                        else
                        {
                            return _apiResponse.ReturnResponse(HttpStatusCode.Unauthorized, null);
                        }

                    }
                    else
                    {
                        return _apiResponse.ReturnResponse(HttpStatusCode.NotFound, null);
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
                _apiResponse.StatusCode = HttpStatusCode.Created;

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex);
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
            }
            APIConfig.Log.Debug("CALLING API\" user create \"  ENDED");
            return _apiResponse.ReturnResponse(_apiResponse.StatusCode, _apiResponse.Response);
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

    }
}
