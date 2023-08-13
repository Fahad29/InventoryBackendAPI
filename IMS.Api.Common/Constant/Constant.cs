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


        #endregion

        #region Brand

        public const string SpCreateBrand = "p_Create_Brand";
        public const string SpDeleteBrand = "p_Delete_Brand";
        public const string SpGetAllBrands = "p_GetAll_Brands";

        #endregion

    }
}
