IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Area]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[Area](
		[AreaID] [int] IDENTITY(1,1) NOT NULL,
		[VNName] [nvarchar](255) NULL,
		[ENName] [nvarchar](255) NULL,
		[BranchID] [int] NULL,
		[Enable] [bit] NULL,
		[SEQ] [int] NULL,
		[CreatedDate] [datetime] NULL,
		[CreatedUser] [varchar](50) NULL,
		[ModifiedDate] [datetime] NULL,
		[ModifiedUser] [varchar](50) NULL,
	 CONSTRAINT [PK_Area] PRIMARY KEY CLUSTERED 
	(
		[AreaID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Branch]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[Branch](
		[BranchID] [int] IDENTITY(1,1) NOT NULL,
		[VNName] [nvarchar](255) NULL,
		[ENName] [nvarchar](255) NULL,
		[CurrencyID] [int] NULL,
		[UseServiceFee] [bit] NULL,
		[ServiceFee] [numeric](12, 2) NULL,
		[Enable] [bit] NULL,
		[SEQ] [int] NULL,
		[CreatedDate] [datetime] NULL,
		[CreatedUser] [varchar](50) NULL,
		[ModifiedDate] [datetime] NULL,
		[ModifiedUser] [varchar](50) NULL,
	 CONSTRAINT [PK_Branch] PRIMARY KEY CLUSTERED 
	(
		[BranchID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BranchTax]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[BranchTax](
		[BranchTaxID] [int] IDENTITY(1,1) NOT NULL,
		[BranchID] [int] NULL,
		[TaxID] [int] NULL,
		[CreatedDate] [datetime] NULL,
		[CreatedUser] [varchar](50) NULL,
		[ModifiedDate] [datetime] NULL,
		[ModifiedUser] [varchar](50) NULL,
	 CONSTRAINT [PK_BranchTax] PRIMARY KEY CLUSTERED 
	(
		[BranchTaxID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Currency]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[Currency](
		[CurrencyID] [int] IDENTITY(1,1) NOT NULL,
		[Currency] [varchar](10) NOT NULL,
		[Exchange] [numeric](12, 2) NULL,
		[Enable] [bit] NULL,
		[SEQ] [int] NULL,
		[CreatedDate] [datetime] NULL,
		[CreatedUser] [varchar](50) NULL,
		[ModifiedDate] [datetime] NULL,
		[ModifiedUser] [varchar](50) NULL,
	 CONSTRAINT [PK_Currency_1] PRIMARY KEY CLUSTERED 
	(
		[CurrencyID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[Customer](
		[CustomerID] [int] IDENTITY(1,1) NOT NULL,
		[CustomerCode] [varchar](50) NOT NULL,
		[CustomerName] [nvarchar](255) NULL,
		[BranchID] [int] NULL,
		[Enable] [bit] NULL,
		[SEQ] [int] NULL,
		[CreatedDate] [datetime] NULL,
		[CreatedUser] [varchar](50) NULL,
		[ModifiedDate] [datetime] NULL,
		[ModifiedUser] [varchar](50) NULL,
	 CONSTRAINT [PK_Customer_1] PRIMARY KEY CLUSTERED 
	(
		[CustomerID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ErrorMessage]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[ErrorMessage](
		[ErrorMessageID] [int] NOT NULL,
		[VNMessage] [nvarchar](1000) NULL,
		[ENMessage] [nvarchar](1000) NULL,
	 CONSTRAINT [PK_ErrorMessage] PRIMARY KEY CLUSTERED 
	(
		[ErrorMessageID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Invoice]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[Invoice](
		[InvoiceID] [bigint] IDENTITY(1,1) NOT NULL,
		[BranchID] [int] NULL,
		[InvoiceNumber] [nvarchar](50) NULL,
		[InvoiceDate] [datetime] NULL,
		[Comment] [nvarchar](255) NULL,
		[CustomerID] [int] NULL,
		[UserID] [int] NULL,
		[Tax] [numeric](12, 2) NULL,
		[ServiceFee] [numeric](12, 2) NULL,
		[OtherFee] [numeric](12, 2) NULL,
		[OtherFeeDescription] [nvarchar](255) NULL,
		[InvoiceAmount] [numeric](12, 2) NULL,
		[Currency] [varchar](10) NULL,
		[CreatedDate] [datetime] NULL,
		[CreatedUser] [varchar](50) NULL,
		[ModifiedDate] [datetime] NULL,
		[ModifiedUser] [varchar](50) NULL,
	 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
	(
		[InvoiceID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InvoiceDetail]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[InvoiceDetail](
		[InvoiceDetailID] [bigint] IDENTITY(1,1) NOT NULL,
		[InvoiceTableID] [bigint] NULL,
		[ProductCode] [varchar](50) NULL,
		[ProductVNName] [nvarchar](1000) NULL,
		[ProductENName] [nvarchar](1000) NULL,
		[Quantity] [numeric](10, 2) NULL,
		[UnitVNName] [nvarchar](255) NULL,
		[UnitENName] [nvarchar](255) NULL,
		[Price] [numeric](12, 2) NULL,
		[Discount] [numeric](12, 2) NULL,
		[DiscountType] [tinyint] NULL,
		[DiscountCode] [nvarchar](50) NULL,
		[Comment] [nvarchar](255) NULL,
	 CONSTRAINT [PK_InvoiceDetail_1] PRIMARY KEY CLUSTERED 
	(
		[InvoiceDetailID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InvoiceDiscount]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[InvoiceDiscount](
		[InvoiceDiscountID] [bigint] IDENTITY(1,1) NOT NULL,
		[InvoiceID] [bigint] NULL,
		[Discount] [numeric](12, 2) NULL,
		[DiscountType] [tinyint] NULL,
		[DiscountCode] [nvarchar](50) NULL,
		[Comment] [nvarchar](255) NULL,
	 CONSTRAINT [PK_InvoiceDiscount] PRIMARY KEY CLUSTERED 
	(
		[InvoiceDiscountID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InvoiceTable]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[InvoiceTable](
		[InvoiceTableID] [bigint] IDENTITY(1,1) NOT NULL,
		[InvoiceID] [bigint] NULL,
		[TableID] [int] NULL,
		[Discount] [numeric](12, 2) NULL,
		[DiscountType] [tinyint] NULL,
		[DiscountCode] [nvarchar](50) NULL,
		[Comment] [nvarchar](255) NULL,
		[Tax] [numeric](12, 2) NULL,
		[ServiceFee] [numeric](12, 2) NULL,
		[OtherFee] [numeric](12, 2) NULL,
		[OtherFeeDescription] [nvarchar](255) NULL,
		[TableAmount] [numeric](12, 2) NULL,
		[CreatedDate] [datetime] NULL,
		[CreatedUser] [varchar](50) NULL,
		[ModifiedDate] [datetime] NULL,
		[ModifiedUser] [varchar](50) NULL,
	 CONSTRAINT [PK_InvoiceDetail] PRIMARY KEY CLUSTERED 
	(
		[InvoiceTableID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Product]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[Product](
		[ProductID] [int] IDENTITY(1,1) NOT NULL,
		[ProductCode] [nvarchar](50) NULL,
		[VNName] [nvarchar](1000) NULL,
		[ENName] [nvarchar](1000) NULL,
		[VNDescription] [nvarchar](1000) NULL,
		[ENDescription] [nvarchar](1000) NULL,
		[UnitID] [tinyint] NULL,
		[ProductCategoryID] [int] NULL,
		[Price] [numeric](12, 2) NULL,
		[Enable] [bit] NULL,
		[SEQ] [int] NULL,
		[CreatedDate] [datetime] NULL,
		[CreatedUser] [varchar](50) NULL,
		[ModifiedDate] [datetime] NULL,
		[ModifiedUser] [varchar](50) NULL,
	 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
	(
		[ProductID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProductCategory]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[ProductCategory](
		[ProductCategoryID] [int] IDENTITY(1,1) NOT NULL,
		[ProductCategoryCode] [nvarchar](50) NULL,
		[VNName] [nvarchar](255) NULL,
		[ENName] [nvarchar](255) NULL,
		[VNDescription] [nvarchar](255) NULL,
		[ENDescription] [nvarchar](255) NULL,
		[BranchID] [int] NULL,
		[Enable] [bit] NULL,
		[SEQ] [int] NULL,
		[CreatedDate] [datetime] NULL,
		[CreatedUser] [varchar](50) NULL,
		[ModifiedDate] [datetime] NULL,
		[ModifiedUser] [varchar](50) NULL,
	 CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED 
	(
		[ProductCategoryID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProductPriceHistory]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[ProductPriceHistory](
		[ProductPriceHistoryID] [bigint] IDENTITY(1,1) NOT NULL,
		[ProductID] [bigint] NULL,
		[OldPrice] [numeric](12, 2) NULL,
		[NewPrice] [numeric](12, 2) NULL,
		[CreatedDate] [datetime] NULL,
		[CreatedUser] [varchar](50) NULL,
	 CONSTRAINT [PK_ProductPriceHistory] PRIMARY KEY CLUSTERED 
	(
		[ProductPriceHistoryID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SystemInfomation]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[SystemInfomation](
		[SystemInfomationID] [int] IDENTITY(1,1) NOT NULL,
		[Name] [varchar](255) NOT NULL,
		[Value] [varchar](255) NULL,
	 CONSTRAINT [PK_SystemInfomation_1] PRIMARY KEY CLUSTERED 
	(
		[SystemInfomationID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Table]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[Table](
		[TableID] [int] IDENTITY(1,1) NOT NULL,
		[VNName] [nvarchar](255) NULL,
		[ENName] [nvarchar](255) NULL,
		[AreaID] [int] NULL,
		[Enable] [bit] NULL,
		[SEQ] [int] NULL,
		[CreatedDate] [datetime] NULL,
		[CreatedUser] [varchar](50) NULL,
		[ModifiedDate] [datetime] NULL,
		[ModifiedUser] [varchar](50) NULL,
	 CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED 
	(
		[TableID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tax]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[Tax](
		[TaxID] [int] IDENTITY(1,1) NOT NULL,
		[Tax] [varchar](10) NOT NULL,
		[Description] [nvarchar](255) NULL,
		[Value] [numeric](5, 2) NULL,
		[Enable] [bit] NULL,
		[SEQ] [int] NULL,
		[CreatedDate] [datetime] NULL,
		[CreatedUser] [varchar](50) NULL,
		[ModifiedDate] [datetime] NULL,
		[ModifiedUser] [varchar](50) NULL
	) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Unit]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[Unit](
		[UnitID] [int] IDENTITY(1,1) NOT NULL,
		[BranchID] [int] NULL,
		[VNName] [nvarchar](255) NULL,
		[ENName] [nvarchar](255) NULL,
		[Enable] [bit] NULL,
		[SEQ] [int] NULL,
		[CreatedDate] [datetime] NULL,
		[CreatedUser] [varchar](50) NULL,
		[ModifiedDate] [datetime] NULL,
		[ModifiedUser] [varchar](50) NULL,
	 CONSTRAINT [PK_Unit] PRIMARY KEY CLUSTERED 
	(
		[UnitID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[User](
		[UserID] [int] IDENTITY(1,1) NOT NULL,
		[UserCode] [nvarchar](255) NULL,
		[UserLogin] [varchar](255) NULL,
		[UserPassword] [varchar](1000) NULL,
		[FirstName] [nvarchar](255) NULL,
		[LastName] [nvarchar](255) NULL,
		[CellPhone] [varchar](50) NULL,
		[Enable] [bit] NULL,
		[SEQ] [int] NULL,
		[CreatedDate] [datetime] NULL,
		[CreateUser] [varchar](50) NULL,
		[ModifiedDate] [datetime] NULL,
		[ModifiedUser] [varchar](50) NULL,
	 CONSTRAINT [PK_User_1] PRIMARY KEY CLUSTERED 
	(
		[UserID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserBranch]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[UserBranch](
		[UserBranchID] [bigint] IDENTITY(1,1) NOT NULL,
		[UserID] [int] NULL,
		[BranchID] [int] NULL,
		[AccessLevel] [tinyint] NULL,
		[CreatedDate] [datetime] NULL,
		[CreatedUser] [varchar](50) NULL,
		[ModifiedDate] [datetime] NULL,
		[ModifiedUser] [varchar](50) NULL,
	 CONSTRAINT [PK_UserBranch_1] PRIMARY KEY CLUSTERED 
	(
		[UserBranchID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO
