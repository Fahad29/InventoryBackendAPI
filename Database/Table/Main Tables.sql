
CREATE TABLE [dbo].[City](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CountryId] [int] NULL,
	[Name] [varchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 8/15/2023 1:23:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[CompanyId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyCode] [varchar](10) NULL,
	[CompanyName] [varchar](50) NULL,
	[CountryId] [int] NULL,
	[Address] [nvarchar](200) NULL,
	[Fax] [varchar](50) NULL,
	[LandLine] [varchar](20) NULL,
	[Mobile] [varchar](20) NULL,
	[PostalCode] [varchar](50) NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyBranches]    Script Date: 8/15/2023 1:23:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyBranches](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[Name] [nvarchar](1000) NULL,
	[PhoneNumber] [varchar](20) NULL,
	[Email] [nvarchar](100) NULL,
	[Fax] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](max) NULL,
 CONSTRAINT [PK_CompanyBranches] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyWarehouse]    Script Date: 8/15/2023 1:23:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyWarehouse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[Name] [varchar](500) NULL,
	[PhoneNumber] [varchar](20) NULL,
	[Email] [varchar](100) NULL,
	[Fax] [varchar](50) NULL,
	[Address] [varchar](max) NULL,
 CONSTRAINT [PK_Warehouse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 8/15/2023 1:23:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[CountryCode] [varchar](5) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LastLoginDetail]    Script Date: 8/15/2023 1:23:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LastLoginDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsEmail] [bit] NULL,
	[IsMobile] [bit] NULL,
	[LastLoginTime] [datetime] NULL,
	[OTP] [int] NULL,
	[OTPVerified] [nchar](10) NULL,
 CONSTRAINT [PK_LastLoginDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductBrand]    Script Date: 8/15/2023 1:23:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductBrand](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Logo] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Brand] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 8/15/2023 1:23:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](250) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductDeals]    Script Date: 8/15/2023 1:23:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductDeals](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemDetailId] [int] NULL,
	[Quantiy] [int] NULL,
	[Price] [decimal](18, 2) NULL,
	[StartDate] [datetime] NULL,
	[ExpiryDate] [datetime] NULL,
 CONSTRAINT [PK_Deals] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductDetail]    Script Date: 8/15/2023 1:23:06 AM ******/
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
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_ItemDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductQuantity]    Script Date: 8/15/2023 1:23:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductQuantity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NULL,
	[Quantity] [decimal](18, 2) NULL,
	[Unit] [varchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_ItemQuantity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 8/15/2023 1:23:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 8/15/2023 1:23:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[Email] [varchar](50) NULL,
	[IsEmailVerified] [bit] NULL,
	[MobileNo] [varchar](25) NULL,
	[IsMobileNoVerified] [nchar](10) NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 8/15/2023 1:23:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserRoleID] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[RoleId] [int] NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[UserRoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[City] ON 

INSERT [dbo].[City] ([Id], [CountryId], [Name], [IsActive]) VALUES (1, 1, N'Dubai International', 1)
INSERT [dbo].[City] ([Id], [CountryId], [Name], [IsActive]) VALUES (2, 1, N'Abu Dhabi', 1)
INSERT [dbo].[City] ([Id], [CountryId], [Name], [IsActive]) VALUES (3, 1, N'Sharjah', 1)
INSERT [dbo].[City] ([Id], [CountryId], [Name], [IsActive]) VALUES (4, 1, N'Ajman', 1)
INSERT [dbo].[City] ([Id], [CountryId], [Name], [IsActive]) VALUES (5, 1, N'Ras Al-Khaimah', 1)
INSERT [dbo].[City] ([Id], [CountryId], [Name], [IsActive]) VALUES (6, 1, N'Fujairah', 1)
INSERT [dbo].[City] ([Id], [CountryId], [Name], [IsActive]) VALUES (7, 1, N'Umm Al Quwain', 1)
SET IDENTITY_INSERT [dbo].[City] OFF
GO
SET IDENTITY_INSERT [dbo].[Company] ON 

INSERT [dbo].[Company] ([CompanyId], [CompanyCode], [CompanyName], [CountryId], [Address], [Fax], [LandLine], [Mobile], [PostalCode], [CreatedBy], [CreatedOn], [IsActive]) VALUES (2, NULL, N'Imtiaz Super Market', NULL, N'Gulshan', N'090078601', N'090078601', N'090078601', NULL, 1, CAST(N'2023-08-05T01:42:32.350' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Company] OFF
GO
SET IDENTITY_INSERT [dbo].[CompanyBranches] ON 

INSERT [dbo].[CompanyBranches] ([Id], [CompanyId], [Name], [PhoneNumber], [Email], [Fax], [Address]) VALUES (1, 2, N'Gulshan Branch', N'111', N'Fahad@gmail.com', N'11', N'11')
INSERT [dbo].[CompanyBranches] ([Id], [CompanyId], [Name], [PhoneNumber], [Email], [Fax], [Address]) VALUES (2, 2, N'North Nazimaad', N'11', N'North@Gmail.com', N'22', N'22')
SET IDENTITY_INSERT [dbo].[CompanyBranches] OFF
GO
SET IDENTITY_INSERT [dbo].[CompanyWarehouse] ON 

INSERT [dbo].[CompanyWarehouse] ([Id], [CompanyId], [Name], [PhoneNumber], [Email], [Fax], [Address]) VALUES (1, 2, N'Liyari', N'11', N'Muh.Fahad29@Gmail.com', N'11', N'11')
SET IDENTITY_INSERT [dbo].[CompanyWarehouse] OFF
GO
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([Id], [Name], [CountryCode], [IsActive]) VALUES (1, N'United Arab Emirates', N'+971', 1)
SET IDENTITY_INSERT [dbo].[Country] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductBrand] ON 

INSERT [dbo].[ProductBrand] ([Id], [Name], [Logo], [IsActive]) VALUES (1, N'Nike', NULL, 1)
INSERT [dbo].[ProductBrand] ([Id], [Name], [Logo], [IsActive]) VALUES (2, N'Apple', NULL, 1)
INSERT [dbo].[ProductBrand] ([Id], [Name], [Logo], [IsActive]) VALUES (3, N'Microsoft', NULL, 1)
INSERT [dbo].[ProductBrand] ([Id], [Name], [Logo], [IsActive]) VALUES (4, N'Unilever', NULL, 1)
INSERT [dbo].[ProductBrand] ([Id], [Name], [Logo], [IsActive]) VALUES (5, N'Samsung', NULL, 0)
INSERT [dbo].[ProductBrand] ([Id], [Name], [Logo], [IsActive]) VALUES (6, N'Samsung', NULL, 0)
INSERT [dbo].[ProductBrand] ([Id], [Name], [Logo], [IsActive]) VALUES (7, N'RealMe', NULL, 0)
INSERT [dbo].[ProductBrand] ([Id], [Name], [Logo], [IsActive]) VALUES (8, N'Redmi', NULL, 0)
SET IDENTITY_INSERT [dbo].[ProductBrand] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductCategory] ON 

INSERT [dbo].[ProductCategory] ([Id], [Name], [IsActive]) VALUES (1, N'Shoes', 1)
INSERT [dbo].[ProductCategory] ([Id], [Name], [IsActive]) VALUES (2, N'IPhone', 1)
INSERT [dbo].[ProductCategory] ([Id], [Name], [IsActive]) VALUES (3, N'Mac', 1)
INSERT [dbo].[ProductCategory] ([Id], [Name], [IsActive]) VALUES (4, N'IPad', 1)
INSERT [dbo].[ProductCategory] ([Id], [Name], [IsActive]) VALUES (5, N'Watch', 1)
INSERT [dbo].[ProductCategory] ([Id], [Name], [IsActive]) VALUES (6, N'Air Pod', 1)
INSERT [dbo].[ProductCategory] ([Id], [Name], [IsActive]) VALUES (7, N'Air Tag', 1)
INSERT [dbo].[ProductCategory] ([Id], [Name], [IsActive]) VALUES (8, N'Televison', 1)
INSERT [dbo].[ProductCategory] ([Id], [Name], [IsActive]) VALUES (9, N'Dove', 1)
INSERT [dbo].[ProductCategory] ([Id], [Name], [IsActive]) VALUES (10, N'Knorr', 1)
INSERT [dbo].[ProductCategory] ([Id], [Name], [IsActive]) VALUES (11, N'Axe', 1)
INSERT [dbo].[ProductCategory] ([Id], [Name], [IsActive]) VALUES (12, N'Comfort', 1)
INSERT [dbo].[ProductCategory] ([Id], [Name], [IsActive]) VALUES (13, N'LifeBoy', 1)
INSERT [dbo].[ProductCategory] ([Id], [Name], [IsActive]) VALUES (14, N'Rexona', 1)
INSERT [dbo].[ProductCategory] ([Id], [Name], [IsActive]) VALUES (15, N'Android 13', 0)
SET IDENTITY_INSERT [dbo].[ProductCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductDetail] ON 

INSERT [dbo].[ProductDetail] ([Id], [BrandId], [CategoryId], [ItemQuantityId], [Name], [Description], [CreatedBy], [CreatedOn], [IsActive]) VALUES (1, NULL, 4, 1, N'Dove Soap (Rose)', N'Dove Soap (Rose)', NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[ProductDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductQuantity] ON 

INSERT [dbo].[ProductQuantity] ([Id], [CategoryId], [Quantity], [Unit], [IsActive]) VALUES (1, NULL, CAST(1.00 AS Decimal(18, 2)), N'Piece', 1)
INSERT [dbo].[ProductQuantity] ([Id], [CategoryId], [Quantity], [Unit], [IsActive]) VALUES (2, NULL, CAST(250.00 AS Decimal(18, 2)), N'ml', 1)
INSERT [dbo].[ProductQuantity] ([Id], [CategoryId], [Quantity], [Unit], [IsActive]) VALUES (3, NULL, CAST(1.50 AS Decimal(18, 2)), N'Liter', 1)
INSERT [dbo].[ProductQuantity] ([Id], [CategoryId], [Quantity], [Unit], [IsActive]) VALUES (4, NULL, CAST(1.00 AS Decimal(18, 2)), N'Liter', 1)
INSERT [dbo].[ProductQuantity] ([Id], [CategoryId], [Quantity], [Unit], [IsActive]) VALUES (5, 1, CAST(200.00 AS Decimal(18, 2)), N'ml', 1)
INSERT [dbo].[ProductQuantity] ([Id], [CategoryId], [Quantity], [Unit], [IsActive]) VALUES (6, 1, CAST(2.40 AS Decimal(18, 2)), N'test', 0)
SET IDENTITY_INSERT [dbo].[ProductQuantity] OFF
GO
ALTER TABLE [dbo].[ProductQuantity] ADD  CONSTRAINT [DF_ItemQuantity_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
