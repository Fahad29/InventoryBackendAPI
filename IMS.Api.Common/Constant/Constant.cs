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
        public const string DeleteRecord = "Record Deleted Successfully.";
        public const string UpdateRecord = "Record Updated Successfully.";
        public const string InValidRecordId = "In Valid Record Id.";

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

        #region Company
        public const string SpCreateCompany = "Usp_create_company";
        public const string SpUpdateCompany = "Usp_update_company";
        public const string SpGetCompany = "Usp_get_company";
        public const string SpCreateUser = "Usp_create_user";
        public const string SpUpdateUser = "Usp_update_user";
        #endregion

        #region Brand

        public const string SpGetAllBrands = "p_GetAll_Brands";
        public const string SpCreateBrand = "p_Create_Brand";
        public const string SpDeleteBrand = "p_Delete_Brand";

        #endregion

        #region Category
        public const string SpGetUser = "Usp_get_user";

        public const string SpGetAllCategories = "p_GetAll_Categories";
        public const string SpCreateCategory = "p_Create_Category";
        public const string SpDeleteCategory = "p_Delete_Category";

        #endregion

        #region Quality

        public const string SpGetAllQuantities = "p_GetAll_Quantities";
        public const string SpCreateQuantity = "p_Create_Quantity";
        public const string SpDeleteQuantity = "p_Delete_Quantity";

        #endregion

        #endregion

    }
}

