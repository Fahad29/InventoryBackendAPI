namespace IMS.Api.Common.Constant
{
    public class Constant
    {

        #region Contant Variable
        public const bool True = true;
        public const bool False = false;
        public const string RootPath = "Content/";
        public const string FileTypeOfLogo = "Logo";

        public const string PLSidebarLogoDirPath = "~/Content/Logos/SidebarLogo/";
        public const string PLFavLogoDirPath = "~/Content/Logos/FavLogo/";
        public const string PLLoginLogoDirPath = "~/Content/Logos/LoginLogo/";
        public const string OTPSubject = "OTP Verification Code";
        #endregion
        #region Email Subjects
        public const string ResetPasswordSubject = "Password Reset";
        #endregion
        #region Response Message
        public const string SuccessResponse = "Success";
        public const string FailResponse = "Failed";
        public const string DeleteRecord = "Record Deleted Successfully.";
        public const string UpdateRecord = "Record Updated Successfully.";
        public const string InValidRecordId = "In Valid Record Id.";
        public const string OTPSendResponse = "Please Check Inbox.";
        public const string UnAuthorized = "Unauthorized Access.";
        public const string OTPExpired = "Your OTP has been expired";
        public const string OTPNotCorrect = "OTP Not Correct";
        public const string OTPVerified = "OTP Verified";
        
        public const string ResetPasswordEmail = "Reset password email has been sent.";
        public const string WrongPassword = "Please Enter New Password, This password match your old Password";
        public const string PasswordChanged = "Password Changed Successfully";
        public const string PasswordReset = "Password Reset Successfully";
        public const string LinkExpired = "This link has been expired";

        public const string RecordNotFound = "Record Not Found";
        public const string InvalidRequest = "Invalid Request";

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
        public const string SpDeleteCompany = "Usp_Delete_Company";
        public const string SpCompanyTotalCount = "Usp_Get_CompanyTotalCount";
        public const string SpGetCompanyExportDetails = "Usp_get_CompanyExportDetails";
        #endregion

        #region Employee
        public const string SpCreateEmployee = "Usp_create_Employee";
        public const string SpUpdateEmployee = "Usp_update_Employee";
        public const string SpGetEmployee = "Usp_get_Employee";
        public const string SpDeleteEmployee = "Usp_Delete_Employee";
        public const string SpEmployeeTotalCount = "Usp_Get_EmployeeTotalCount";
        #endregion

        #region Customer
        public const string SpCreateCustomer = "Usp_create_Customer";
        public const string SpUpdateCustomer = "Usp_update_Customer";
        public const string SpGetCustomer = "Usp_get_Customer";
        public const string SpGetCustomerById = "Usp_get_CustomerById";
        public const string SpDeleteCustomer = "Usp_Delete_Customer";
        public const string SpGetCustomerTotalCount = "Usp_Get_CustomerTotalCount";
        public const string SpGetCustomerExportDetails = "Usp_get_CustomerExportDetails";
        #endregion

        #region Order
        public const string SpCreateOrder = "Usp_create_Order";
        public const string SpUpdateOrder = "Usp_update_Order";
        public const string SpGetOrder = "Usp_get_Order";
        public const string SpGetOrderById = "Usp_getOrderById";
        public const string SpDeleteOrder = "Usp_Delete_Order";
        public const string SpGetOrderTotalCount = "Usp_Get_OrderTotalCount";
        public const string SpGetOrderItems = "Usp_get_OrderItems";
        public const string SpGetOrderExportDetails = "Usp_get_OrderExportDetails";
        #endregion

        #region OrderItem
        public const string SpCreateOrderItem = "Usp_create_OrderItem";
        public const string SpUpdateOrderItem = "Usp_update_OrderItem";
        public const string SpGetOrderItem = "Usp_get_OrderItem";
        public const string SpGetOrderItemById = "Usp_getOrderItemById";
        public const string SpDeleteOrderItem = "Usp_Delete_OrderItem";
        public const string SpGetOrderItemTotalCount = "Usp_Get_OrderItemTotalCount";
        #endregion

        #region Transaction
        public const string SpCreateTransaction = "Usp_create_Transaction";
        public const string SpUpdateTransaction = "Usp_update_Transaction";
        public const string SpGetTransaction = "Usp_get_Transaction";
        public const string SpGetTransactionById = "Usp_get_TransactionById";
        public const string SpDeleteTransaction = "Usp_Delete_Transaction";
        public const string SpGetTransactionTotalCount = "Usp_Get_TransactionTotalCount";
        public const string SpGetTransactionExportDetails = "Usp_get_TransactionExportDetails";
        #endregion

        #region PrivateLabel
        public const string SpCreatePrivateLabel = "Usp_create_PrivateLabel";
        public const string SpUpdatePrivateLabel = "Usp_update_PrivateLabel";
        public const string SpGetPrivateLabel = "Usp_get_PrivateLabel";
        public const string SpGetPrivateLabelById = "Usp_get_PrivateLabelById";
        public const string SpDeletePrivateLabel = "Usp_Delete_PrivateLabel";
        public const string SpGetPrivateLabelTotalCount = "Usp_Get_PrivateLabelTotalCount";
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
        public const string SpGetUserTotalCount = "Usp_Get_UserTotalCount";
        #endregion

        #region Product SPs
        #region Brand
        public const string SpGetProductBrand = "Usp_Get_ProductBrand";
        public const string SpCreateProductBrand = "Usp_Create_ProductBrand";
        public const string SpUpdateProductBrand = "Usp_Update_ProductBrand";
        public const string SpDeleteProductBrand = "Usp_Delete_ProductBrand";
        #endregion

        #region Deals
        public const string SpGetDealById = "Usp_Get_DealById";
        public const string SpGetDealTotalCount = "Usp_Get_DealTotalCount";
        public const string SpCreateDeal = "Usp_create_Deal";
        public const string SpUpdateDeal = "Usp_update_Deal";
        public const string SpGetDeal = "Usp_get_Deal";
        public const string SpDeleteDeal = "Usp_Delete_Deal";
        #endregion

        #region ProdcutDetail
        public const string SpCreateProductDetail = "Usp_create_productDetail";
        public const string SpUpdateProductDetail = "Usp_update_productDetail";
        public const string SpGetProductDetail = "Usp_Get_productDetail";
        public const string SpGetProductDetailById = "Usp_Get_productDetailById";
        public const string SpDeleteProductDetail = "Usp_Delete_ProductDetail";
        public const string SpProductDetailTotalCount = "Usp_Get_productDetailTotalCount";
        #endregion

        #region CompanyProdcut
        public const string SpCreateCompanyProduct = "Usp_create_CompanyProduct";
        public const string SpUpdateCompanyProduct = "Usp_update_CompanyProduct";
        public const string SpGetCompanyProduct = "Usp_Get_CompanyProduct";
        public const string SpGetCompanyProductById = "Usp_Get_CompanyProductById";
        public const string SpDeleteCompanyProduct = "Usp_Delete_CompanyProduct";
        public const string SpCompanyProductTotalCount = "Usp_Get_CompanyProductTotalCount";
        public const string SpGetCompanyProductExportDetails = "Usp_get_CompanyProductExportDetails";
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

        #region Dropdown
        public const string SpGetModules = "p_GetAll_Modules";
        public const string SpGetDropdownbyModule = "p_GetAll_DropdownByModuleId";


        #endregion

        #region AssignRights
        public const string SpGetRoleRights = "GetAll_RoleRightsByRoleId";
        public const string SpInsertUpdateRoleRights = "usp_create_update_rolerights";
        public const string SpGetUserRights = "usp_GetAll_UserRightsByUserId";
        public const string SpInsertUpdateUserRights = "usp_create_update_Userrights";
        #endregion

        #region Attachments
        public const string SpGetAttachmentTypes = "GetAll_AttachmentType";
        public const string SpGetAttachmentById = "GetAll_AttachmentById";
        public const string SpGetAttachments = "GetAll_Attachments";
        public const string SpGetAddAttachments = "usp_create_update_attachments";
        public const string SpDeleteAttachmentById = "Delete_AttachmentById";
        public const string SpDeleteAttachments = "Delete_Attachments";

        #endregion

        #region Vendor
        public const string SpCreateVendor = "Usp_Create_Update_Vendor";
        public const string SpGetVendor = "Usp_Get_Vendor";
        public const string SpDeleteVendor = "Usp_Delete_Vendor";
        #endregion

        #region password
        public const string SpGetForgetPasswordDetails = "Usp_get_ForgetPasswordDetails";
        #endregion

        #region ProcessorConfiguration
        public const string SpCreateProcessorConfiguration = "Usp_create_ProcessorConfiguration";
        public const string SpUpdateProcessorConfiguration = "Usp_update_ProcessorConfiguration";
        public const string SpGetProcessorConfiguration = "Usp_Get_ProcessorConfiguration";
        public const string SpGetProcessorConfigurationById = "Usp_Get_ProcessorConfigurationById";
        public const string SpDeleteProcessorConfiguration = "Usp_Delete_ProcessorConfiguration";
        #endregion

        #endregion

        #region Email Constant


        public const string ContactNumber = "03001200000";
        public const string supportemail = "support@IMS.com";
        public const string supporturl = "https://www.support.zakhaer.com";
        public const string CompanyEmail = "zakhaer2022@gmail.com";
        public const string CompanyName = "IMS";
        public const string Port = "587";
        public const bool EnableSSL = true;
        public const string SMTPuser = "zakhaer2022@gmail.com";
        public const string SMTPpassword = "zxdmxfzvarsvaycd";
        public const string Host = "smtp.gmail.com";
        public const string WebLink = "https://www.dashboard.IMS.com/";
        public const string LogoUrl = "https://www.IMS.com/images/Logo/logo.jpg";
        public const string ImageExtension = "Please Upload image of type .jpg,.png.";
        #endregion


        #region  Email Templates 
        public const string SendOTP = "\\Content\\EmailTemplates\\SendOTP.html";
        public const string ForgetPasswordEmailTemplate = "\\Content\\EmailTemplates\\forgetpassword.template.html";
        #endregion


        #region From Email
        public const string FromEmail = "info@IMS.com";

        #endregion


        #region Purchase Order
        public const string SpGetPurchaseOrderById = "usp_Get_PurchaseOrderById";
        public const string SpGetAllPurchaseOrder = "usp_GetALL_PurchaseOrder";
        public const string SpCreatePurchaseOrder = "usp_Create_PurchaseOrder";
        public const string SpCreatePurchaseItem = "usp_Create_PurchaseItem";
        public const string SpDeletePurchaseOrderById = "usp_Delete_PurchaseOrder";
        #endregion

    }
}

