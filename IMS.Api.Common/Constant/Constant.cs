namespace IMS.Api.Common.Constant
{
    public class Constant
    {

        #region Contant Variable
        public const bool True = true;
        public const bool False = false;
        #endregion
        #region Response Message
        public const string SuccessResponse = "Success";
        public const string RecordNotFound = "Record Not Found";

        public const string TokenExpireMsgs = "the token is expired.";
        public const string TokenInvalidMsg = "the token is invalid.";
        public const string TokenRequired = "Token Required";
        public const string TokenExpireMsg = "Token Expired";
        #endregion

        #region Store Procedure

        #region Authentication
        public const string SpRegisterUser = "sp_Register_User";
        public const string SpLoginUser = "sp_Login_User";
        public const string SpForgetPassword = "sp_ForgetPassword";
        public const string SpResendOTP = "sp_ReSendOTP";
        #endregion

        public const string SpCreateCompany = "Usp_create_company";
        public const string SpUpdateCompany = "Usp_update_company";
        public const string SpGetCompany = "Usp_get_company";
        public const string SpCreateUser = "Usp_create_user";
        public const string SpUpdateUser = "Usp_update_user";
        public const string SpGetUser = "Usp_get_user";


        #endregion

    }
}
