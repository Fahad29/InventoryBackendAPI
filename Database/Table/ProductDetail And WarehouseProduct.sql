/****** Object:  StoredProcedure [dbo].[Usp_update_productdetail]    Script Date: 8/21/2023 2:01:20 AM ******/
DROP PROCEDURE [dbo].[Usp_update_productdetail]
GO
/****** Object:  StoredProcedure [dbo].[Usp_get_productdetail]    Script Date: 8/21/2023 2:01:20 AM ******/
DROP PROCEDURE [dbo].[Usp_get_productdetail]
GO
/****** Object:  StoredProcedure [dbo].[Usp_Delete_ProductDetail]    Script Date: 8/21/2023 2:01:20 AM ******/
DROP PROCEDURE [dbo].[Usp_Delete_ProductDetail]
GO
/****** Object:  StoredProcedure [dbo].[Usp_create_productdetail]    Script Date: 8/21/2023 2:01:20 AM ******/
DROP PROCEDURE [dbo].[Usp_create_productdetail]
GO
/****** Object:  Table [dbo].[WarehouseProduct]    Script Date: 8/21/2023 2:01:20 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WarehouseProduct]') AND type in (N'U'))
DROP TABLE [dbo].[WarehouseProduct]
GO
/****** Object:  Table [dbo].[ProductDetail]    Script Date: 8/21/2023 2:01:20 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProductDetail]') AND type in (N'U'))
DROP TABLE [dbo].[ProductDetail]
GO
/****** Object:  Table [dbo].[ProductDetail]    Script Date: 8/21/2023 2:01:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BrandId] [int] NULL,
	[CategoryId] [int] NULL,
	[ItemQuantityId] [int] NULL,
	[Name] [varchar](max) NULL,
	[Description] [varchar](max) NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_ItemDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WarehouseProduct]    Script Date: 8/21/2023 2:01:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WarehouseProduct](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WareHouseId] [int] NULL,
	[ProductId] [int] NULL,
	[DeliveryDate] [datetime] NULL,
	[ManufacturerLabel] [date] NULL,
	[ExpiryLabel] [date] NULL,
	[Quantity] [decimal](18, 2) NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_WarehouseProduct] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Usp_create_productdetail]    Script Date: 8/21/2023 2:01:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Usp_create_productdetail] @Id             AS INT = NULL,
                                     @BrandId        AS INT = NULL,
                                     @CategoryId     AS INT = NULL,
                                     @ItemQuantityId AS INT = NULL,
                                     @Name           AS VARCHAR(max) = NULL,
                                     @Description    AS VARCHAR(max) = NULL,
                                     @CreatedBy      AS INT = NULL,
                                     @CreatedOn      AS DATETIME = NULL,
									 @UpdatedBy      AS INT = NULL,
                                     @UpdatedOn      AS DATETIME = NULL,
                                     @IsActive       AS BIT = NULL,
									 @IsDeleted       AS BIT = NULL
AS
  BEGIN
      INSERT INTO productdetail
                  ([brandid],
                   [categoryid],
                   [createdby],
                   [createdon],
                   [description],
                   [isactive],
                   [itemquantityid],
                   [name])
      VALUES      ( @BrandId,
                    @CategoryId,
                    @CreatedBy,
                    Getutcdate(),
                    @Description,
                    @IsActive,
                    @ItemQuantityId,
                    @Name);

      SET @Id= Scope_identity();

      SELECT *
      FROM   productdetail
      WHERE  id = @Id;
  END 
GO
/****** Object:  StoredProcedure [dbo].[Usp_Delete_ProductDetail]    Script Date: 8/21/2023 2:01:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Usp_Delete_ProductDetail]
@Id as Int
As
Begin
	Update ProductDetail
	Set IsDeleted = 1
	Where Id= @Id

End
GO
/****** Object:  StoredProcedure [dbo].[Usp_get_productdetail]    Script Date: 8/21/2023 2:01:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Usp_get_productdetail]    @Id             AS INT = NULL,
 									@BrandId        AS INT = NULL,
 									@CategoryId     AS INT = NULL,
									@ItemQuantityId AS INT = NULL,
									@Name           AS VARCHAR(max) = NULL,
									@Description    AS VARCHAR(max) = NULL

AS
  BEGIN
      
      SELECT *
      FROM   ProductDetail
      WHERE  (id = @Id or @Id is null)
	  AND (BrandId = @BrandId or @BrandId is null)
	  AND (CategoryId = @CategoryId or @CategoryId is null)
	  AND (ItemQuantityId = @ItemQuantityId or @ItemQuantityId is null)
	  AND (Name = @Name or @Name is null)
	  And IsDeleted=0
  END 
GO
/****** Object:  StoredProcedure [dbo].[Usp_update_productdetail]    Script Date: 8/21/2023 2:01:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Usp_update_productdetail] 
@Id             AS INT = NULL,
@BrandId        AS INT = NULL,
@CategoryId    AS INT = NULL,
@ItemQuantityId AS INT = NULL,
@Name           AS VARCHAR(max) = NULL,
@Description    AS VARCHAR(max) = NULL,
@CreatedBy      AS INT = NULL,
@CreatedOn      AS DATETIME = NULL,
@UpdatedBy      AS INT = NULL,
@UpdatedOn      AS DATETIME = NULL,
@IsActive       AS BIT = NULL,
@IsDeleted       AS BIT = NULL
AS
	
  BEGIN
      UPDATE productdetail
      SET    brandid = @BrandId,
             categoryid = @CategoryId,
             itemquantityid = @ItemQuantityId,
             NAME = @Name,
             description = @Description,
             UpdatedBy = @CreatedBy,
             UpdatedOn = Getutcdate(),
             isactive = @IsActive
      WHERE  id = @Id;

      SELECT *
      FROM   productdetail
      WHERE  id = @Id;
  END 
GO
