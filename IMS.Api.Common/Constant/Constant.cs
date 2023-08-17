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

        #region Branch
        public const string SpGetBranch = "Usp_Get_CompanyBranches";
        public const string SpCreateBranch = "Usp_Create_CompanyBranches";
        public const string SpUpdateBranch = "Usp_Update_CompanyBranches";
        public const string SpDeleteCompanyBranch = "Usp_Delete_CompanyBranches";
        #endregion

        #region Warehouse
        public const string SpGetWarehouse = "Usp_Get_CompanyWarehouse";
        public const string SpCreateWarehouse = "Usp_Create_CompanyWarehouse";
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
        public const string SpCreateProductDeal = "Usp_create_productdeal";
        public const string SpUpdateProductDeal = "Usp_update_productdeal";
        public const string SpGetProductDeal = "Usp_get_productdeal";
        public const string SpDeleteProductDeal = "Usp_Delete_ProductDeal";
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
        public const string SpDeleteRole = "Usp_Delete_Role";
        #endregion

        #region UserRole
        public const string SpCreateUserRole = "Usp_create_userrole";
        public const string SpUpdateUserRole = "Usp_update_userrole";
        public const string SpGetUserRole = "Usp_get_userrole";
        public const string SpDeleteUserRole = "Usp_Delete_UserRole";
        #endregion

        #endregion

    }
}

