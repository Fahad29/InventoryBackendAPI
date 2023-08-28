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
        public const string OTPSendResponse = "Please Check Inbox.";
        public const string UnAuthorized = "Unauthorized Access.";
        public const string OTPExpired = "Your OTP has been expired";
        public const string OTPNotCorrect = "OTP Not Correct";
        public const string OTPVerified = "OTP Verified";

        public const string RecordNotFound = "Record Not Found";

        public const string TokenExpireMsgs = "the token is expired.";
        public const string TokenInvalidMsg = "the token is invalid.";
        public const string TokenRequired = "Token Required";
        public const string TokenExpireMsg = "Token Expired";
        
        public const string InvalidUser = "Invalid Email and Password";
        public const string NotActive = "User Not Active";
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
        public const string SpDeleteCompany= "Usp_Delete_Company";
        #endregion

        #region Customer
        public const string SpCreateCustomer = "Usp_create_Customer";
        public const string SpUpdateCustomer = "Usp_update_Customer";
        public const string SpGetCustomer = "Usp_get_Customer";
        public const string SpDeleteCustomer = "Usp_Delete_Customer";
        #endregion

        #region PrivateLabel
        public const string SpCreatePrivateLabel = "Usp_create_PrivateLabel";
        public const string SpUpdatePrivateLabel = "Usp_update_PrivateLabel";
        public const string SpGetPrivateLabel = "Usp_get_PrivateLabel";
        public const string SpDeletePrivateLabel = "Usp_Delete_PrivateLabel";
        #endregion

        #region Branch
        public const string SpGetBranchById = "Usp_Get_CompanyBranchById";
        public const string SpGetBranchTotalCount = "Usp_Get_CompanyBranchTotalCount";
        public const string SpGetBranch = "Usp_Get_CompanyBranches";
        public const string SpCreateBranch = "Usp_Create_CompanyBranches";
        public const string SpUpdateBranch = "Usp_Update_CompanyBranches";
        public const string SpDeleteCompanyBranch = "Usp_Delete_CompanyBranch";
        #endregion

        #region Warehouse
        public const string SpGetWarehouseById = "Usp_Get_CompanyWarehouseById";
        public const string SpGetWarehouseTotalCount = "Usp_Get_CompanyWarehouseTotalCount";
        public const string SpGetWarehouse = "Usp_Get_CompanyWarehouse";
        public const string SpCreateWarehouse = "Usp_Create_Company_Warehouse";
        public const string SpUpdateWarehouse = "Usp_Update_CompanyWarehouse";
        public const string SpDeleteCompanyWarehouse = "Usp_Delete_CompanyWarehouse";
        #endregion

        #region User
        public const string SpCreateUser = "Usp_create_user";
        public const string SpUpdateUser = "Usp_update_user";
        public const string SpGetUser = "Usp_get_user";
        public const string SpDeleteUser = "Usp_Delete_user";
        #endregion

        #region Product SPs
        #region Brand
        public const string SpGetProductBrand = "Usp_Get_ProductBrand";
        public const string SpCreateProductBrand = "Usp_Create_ProductBrand";
        public const string SpUpdateProductBrand = "Usp_Update_ProductBrand";
        public const string SpDeleteProductBrand = "Usp_Delete_ProductBrand";


        #endregion

        #region Deals
        public const string SpGetDealById = "Usp_Get_CompanyDealById";
        public const string SpGetDealTotalCount = "Usp_Get_CompanyDealTotalCount";
        public const string SpCreateDeal = "Usp_create_Deal";
        public const string SpUpdateDeal = "Usp_update_Deal";
        public const string SpGetDeal = "Usp_get_Deal";
        public const string SpDeleteDeal = "Usp_Delete_Deal";
        #endregion

        #region Detail
        public const string SpCreateProductDetail = "Usp_create_productDetail";
        public const string SpUpdateProductDetail = "Usp_update_productDetail";
        public const string SpGetProductDetail = "Usp_Get_productDetail";
        public const string SpDeleteProductDetail = "Usp_Delete_ProductDetail";
        #endregion

        #region Category


        public const string SpGetAllProductCategories = "Usp_Get_ProductCategory";
        public const string SpCreateProductCategory = "Usp_Create_ProductCategory";
        public const string SpUpdateProductCategory = "Usp_Update_ProductCategory";
        public const string SpDeleteProductCategory = "Usp_Delete_ProductCategory";

        #endregion

        #region Quality
        public const string SpGetAllQuantities = "Usp_Get_ProductQuantity";
        public const string SpCreateQuantity = "Usp_Create_ProductQuantity";
        public const string SpUpdateQuantity = "Usp_Update_ProductQuantity";
        public const string SpDeleteQuantity = "USp_Delete_ProductQuantity";
        #endregion
        #endregion

        #region Country
        public const string SpCreateCountry = "Usp_create_country";
        public const string SpUpdateCountry = "Usp_update_country";
        public const string SpGetCountry = "Usp_get_country";
        public const string SpDeleteCountry = "Usp_Delete_Country";
        #endregion

        #region City
        public const string SpCreateCity = "Usp_create_city";
        public const string SpUpdateCity = "Usp_update_city";
        public const string SpGetCity = "Usp_get_city";
        public const string SpDeleteCity = "Usp_Delete_City";
        #endregion

        #region Role
        public const string SpCreateRole = "Usp_create_Role";
        public const string SpUpdateRole = "Usp_update_Role";
        public const string SpGetRole = "Usp_get_Role";
        #endregion

        #region UserRole
        public const string SpCreateUserRole = "Usp_create_userrole";
        public const string SpUpdateUserRole = "Usp_update_userrole";
        public const string SpGetUserRole = "Usp_get_userrole";
        #endregion

        #endregion


        #region Email Constant


        public const string ContactNumber = "03001200000";
        public const string supportemail = "support@IMS.com";
        public const string supporturl = "https://www.support.zakhaer.com";
        public const string CompanyEmail = "zakhaer2022@gmail.com";
        public const string CompanyName = "IMS";
        public const string Port = "587";
        public const bool   EnableSSL = true;
        public const string SMTPuser = "zakhaer2022@gmail.com";
        public const string SMTPpassword = "zxdmxfzvarsvaycd";
        public const string Host = "smtp.gmail.com";
        public const string WebLink = "https://www.dashboard.IMS.com/";
        public const string LogoUrl = "https://www.IMS.com/images/Logo/logo.jpg";
        public const string ImageExtension = "Please Upload image of type .jpg,.png.";
        #endregion


        #region  Email Templates 
        public const string SendOTP = "\\Content\\EmailTemplates\\SendOTP.html";
        #endregion
    }
}

