SET NOCOUNT ON;

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Area]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Area](
        [AreaID] [int] IDENTITY(1,1) NOT NULL,
        [VNName] [nvarchar](255) NULL,
        [ENName] [nvarchar](255) NULL,
        [BranchID] [int] NULL,
        [Enable] [bit] NULL,
        [SEQ] [int] NULL,
        [CreatedDate] [datetime] NULL,
        [CreatedUser] [nvarchar](50) NULL,
        [ModifiedDate] [datetime] NULL,
        [ModifiedUser] [nvarchar](50) NULL,
     CONSTRAINT [PK_Area] PRIMARY KEY CLUSTERED 
    (
        [AreaID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Branch]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Branch](
        [BranchID] [int] IDENTITY(1,1) NOT NULL,
        [VNName] [nvarchar](255) NULL,
        [ENName] [nvarchar](255) NULL,
        [CurrencyID] [int] NULL,
        [UseServiceFee] [bit] NULL,
        [ServiceFee] [numeric](19, 2) NULL,
        [UseDiscountOnProduct] [bit] NULL,
        [UseKitchenFunction] [bit] NULL,
		[UseInventory] [bit] NULL,
		[DepotID] [int] NULL,
        [Enable] [bit] NULL,
        [SEQ] [int] NULL,
        [CreatedDate] [datetime] NULL,
        [CreatedUser] [nvarchar](50) NULL,
        [ModifiedDate] [datetime] NULL,
        [ModifiedUser] [nvarchar](50) NULL,
     CONSTRAINT [PK_Branch] PRIMARY KEY CLUSTERED 
    (
        [BranchID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BranchInfo]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[BranchInfo](
        [BranchID] [int] NOT NULL,
        [CompanyCode] [nvarchar](255) NULL,
        [CompanyName] [nvarchar](510) NULL,
        [Phone] [nvarchar](50) NULL,
        [Fax] [nvarchar](50) NULL,
        [Email] [nvarchar](255) NULL,
        [TaxCode] [nvarchar](50) NULL,
        [Address] [nvarchar](510) NULL,
        [Info1] [nvarchar](510) NULL,
        [Info2] [nvarchar](510) NULL,
        [Info3] [nvarchar](510) NULL,
        [Info4] [nvarchar](510) NULL,
        [Info5] [nvarchar](510) NULL,
        [Info6] [nvarchar](510) NULL,
        [Info7] [nvarchar](510) NULL,
        [Info8] [nvarchar](510) NULL,
        [Info9] [nvarchar](510) NULL,
        [Info10] [nvarchar](510) NULL,
     CONSTRAINT [PK_BranchInfo] PRIMARY KEY CLUSTERED 
    (
        [BranchID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BranchTax]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[BranchTax](
        [BranchTaxID] [int] IDENTITY(1,1) NOT NULL,
        [BranchID] [int] NULL,
        [TaxID] [int] NULL,
     CONSTRAINT [PK_BranchTax] PRIMARY KEY CLUSTERED 
    (
        [BranchTaxID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Currency]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Currency](
        [CurrencyID] [int] IDENTITY(1,1) NOT NULL,
        [Name] [nvarchar](50) NOT NULL,
        [Description] [nvarchar](255) NOT NULL,
        [Exchange] [numeric](19, 2) NULL,
        [Enable] [bit] NULL,
        [SEQ] [int] NULL,
        [CreatedDate] [datetime] NULL,
        [CreatedUser] [nvarchar](50) NULL,
        [ModifiedDate] [datetime] NULL,
        [ModifiedUser] [nvarchar](50) NULL,
     CONSTRAINT [PK_Currency] PRIMARY KEY CLUSTERED 
    (
        [CurrencyID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Customer](
        [CustomerID] [int] IDENTITY(1,1) NOT NULL,
        [CustomerCode] [nvarchar](50) NOT NULL,
        [CustomerName] [nvarchar](255) NULL,
        [CellPhone] [nvarchar](50) NULL,
        [Address] [nvarchar](510) NULL,
        [DOB] [datetime] NULL,
        [BranchID] [int] NULL,
        [Enable] [bit] NULL,
        [SEQ] [int] NULL,
        [CreatedDate] [datetime] NULL,
        [CreatedUser] [nvarchar](50) NULL,
        [ModifiedDate] [datetime] NULL,
        [ModifiedUser] [nvarchar](50) NULL,
     CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
    (
        [CustomerID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ErrorMessage]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[ErrorMessage](
        [ErrorMessageID] [int] NOT NULL,
        [MessageID] [int] NULL,
        [BranchID] [int] NULL,
        [VNMessage] [nvarchar](1000) NULL,
        [ENMessage] [nvarchar](1000) NULL,
     CONSTRAINT [PK_ErrorMessage] PRIMARY KEY CLUSTERED 
    (
        [ErrorMessageID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Invoice]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Invoice](
        [InvoiceID] [bigint] IDENTITY(1,1) NOT NULL,
        [BranchID] [int] NULL,
        [InvoiceNumber] [nvarchar](50) NULL,
        [InvoiceDate] [datetime] NULL,
		[InvoiceCreatedBy] [nvarchar](50) NULL,
        [Comment] [nvarchar](255) NULL,
        [CustomerID] [int] NULL,
        [CustomerName] [nvarchar](255) NULL,
        [CellPhone] [nvarchar](50) NULL,
        [Address] [nvarchar](510) NULL,
        [DOB] [datetime] NULL,
        [ServiceFee] [numeric](19, 2) NULL,
        [OtherFee] [numeric](19, 2) NULL,
        [OtherFeeDescription] [nvarchar](255) NULL,
		[TaxInfo] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        [Currency] [nvarchar](50) NULL,
        [PaymentMethod] [tinyint] NULL,
		[TaxAmount] [numeric](19, 2) NULL,
		[DiscountAmount] [numeric](19, 2) NULL,
		[InvoiceAmount] [numeric](19, 2) NULL,
        [CreatedDate] [datetime] NULL,
        [CreatedUser] [nvarchar](50) NULL,
        [ModifiedDate] [datetime] NULL,
        [ModifiedUser] [nvarchar](50) NULL,
     CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
    (
        [InvoiceID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InvoiceDetail]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[InvoiceDetail](
        [InvoiceDetailID] [bigint] IDENTITY(1,1) NOT NULL,
        [InvoiceTableID] [bigint] NULL,
        [ProductCode] [nvarchar](50) NULL,
        [ProductVNName] [nvarchar](1000) NULL,
        [ProductENName] [nvarchar](1000) NULL,
        [Quantity] [numeric](10, 2) NULL,
        [UnitVNName] [nvarchar](255) NULL,
        [UnitENName] [nvarchar](255) NULL,
        [Price] [numeric](19, 2) NULL,
        [Discount] [numeric](19, 2) NULL,
        [DiscountType] [tinyint] NULL,
        [DiscountCode] [nvarchar](50) NULL,
        [DiscountComment] [nvarchar](255) NULL,
		[DiscountAmount] [numeric](19, 2) NULL,
		[Amount] [numeric](19, 2) NULL,
		[CreatedDate] [datetime] NULL,
        [CreatedUser] [nvarchar](50) NULL,
        [ModifiedDate] [datetime] NULL,
        [ModifiedUser] [nvarchar](50) NULL,
     CONSTRAINT [PK_InvoiceDetail] PRIMARY KEY CLUSTERED 
    (
        [InvoiceDetailID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InvoiceDiscount]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[InvoiceDiscount](
        [InvoiceDiscountID] [bigint] IDENTITY(1,1) NOT NULL,
        [InvoiceID] [bigint] NULL,
        [Discount] [numeric](19, 2) NULL,
        [DiscountType] [tinyint] NULL,
        [DiscountCode] [nvarchar](50) NULL,
        [DiscountComment] [nvarchar](255) NULL,
     CONSTRAINT [PK_InvoiceDiscount] PRIMARY KEY CLUSTERED 
    (
        [InvoiceDiscountID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InvoiceTable]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[InvoiceTable](
        [InvoiceTableID] [bigint] IDENTITY(1,1) NOT NULL,
        [InvoiceID] [bigint] NULL,
        [TableID] [int] NULL,
        [TableVNName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        [TableENName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        [Discount] [numeric](19, 2) NULL,
        [DiscountType] [tinyint] NULL,
        [DiscountCode] [nvarchar](50) NULL,
        [DiscountComment] [nvarchar](255) NULL,
        [ServiceFee] [numeric](19, 2) NULL,
        [OtherFee] [numeric](19, 2) NULL,
        [OtherFeeDescription] [nvarchar](255) NULL,
		[DetailAmount] [numeric](19, 2) NULL,
		[DiscountAmount] [numeric](19, 2) NULL,
		[Amount] [numeric](19, 2) NULL,
        [CreatedDate] [datetime] NULL,
        [CreatedUser] [nvarchar](50) NULL,
        [ModifiedDate] [datetime] NULL,
        [ModifiedUser] [nvarchar](50) NULL,
     CONSTRAINT [PK_InvoiceTable] PRIMARY KEY CLUSTERED 
    (
        [InvoiceTableID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Product]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Product](
        [ProductID] [int] IDENTITY(1,1) NOT NULL,
        [ProductCode] [nvarchar](50) NULL,
        [VNName] [nvarchar](1000) NULL,
        [ENName] [nvarchar](1000) NULL,
        [VNDescription] [nvarchar](1000) NULL,
        [ENDescription] [nvarchar](1000) NULL,
        [UnitID] [int] NULL,
        [ProductCategoryID] [int] NULL,
        [Price] [numeric](19, 2) NULL,
        [Enable] [bit] NULL,
        [SEQ] [int] NULL,
        [CreatedDate] [datetime] NULL,
        [CreatedUser] [nvarchar](50) NULL,
        [ModifiedDate] [datetime] NULL,
        [ModifiedUser] [nvarchar](50) NULL,
     CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
    (
        [ProductID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProductCategory]') AND type in (N'U'))
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
        [CreatedUser] [nvarchar](50) NULL,
        [ModifiedDate] [datetime] NULL,
        [ModifiedUser] [nvarchar](50) NULL,
     CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED 
    (
        [ProductCategoryID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProductPriceHistory]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[ProductPriceHistory](
        [ProductPriceHistoryID] [bigint] IDENTITY(1,1) NOT NULL,
        [ProductID] [int] NULL,
        [OldPrice] [numeric](19, 2) NULL,
        [NewPrice] [numeric](19, 2) NULL,
        [CreatedDate] [datetime] NULL,
        [CreatedUser] [nvarchar](50) NULL,
     CONSTRAINT [PK_ProductPriceHistory] PRIMARY KEY CLUSTERED 
    (
        [ProductPriceHistoryID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SystemInformation]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[SystemInformation](
        [SystemInformationID] [int] IDENTITY(1,1) NOT NULL,
        [Name] [nvarchar](255) NOT NULL,
		[Description] [nvarchar](255) NOT NULL,
        [Value] [nvarchar](510) NULL,
		[Type] [tinyint] NULL,
     CONSTRAINT [PK_SystemInformation] PRIMARY KEY CLUSTERED 
    (
        [SystemInformationID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Table]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Table](
        [TableID] [int] IDENTITY(1,1) NOT NULL,
        [VNName] [nvarchar](255) NULL,
        [ENName] [nvarchar](255) NULL,
        [AreaID] [int] NULL,
        [Enable] [bit] NULL,
        [SEQ] [int] NULL,
        [CreatedDate] [datetime] NULL,
        [CreatedUser] [nvarchar](50) NULL,
        [ModifiedDate] [datetime] NULL,
        [ModifiedUser] [nvarchar](50) NULL,
     CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED 
    (
        [TableID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tax]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Tax](
        [TaxID] [int] IDENTITY(1,1) NOT NULL,
        [Name] [nvarchar](10) NOT NULL,
        [Description] [nvarchar](255) NULL,
        [Value] [numeric](5, 2) NULL,
        [Enable] [bit] NULL,
        [SEQ] [int] NULL,
        [CreatedDate] [datetime] NULL,
        [CreatedUser] [nvarchar](50) NULL,
        [ModifiedDate] [datetime] NULL,
        [ModifiedUser] [nvarchar](50) NULL,
     CONSTRAINT [PK_Tax] PRIMARY KEY CLUSTERED 
    (
        [TaxID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Unit]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Unit](
        [UnitID] [int] IDENTITY(1,1) NOT NULL,
        [BranchID] [int] NULL,
        [VNName] [nvarchar](255) NULL,
        [ENName] [nvarchar](255) NULL,
        [Enable] [bit] NULL,
        [SEQ] [int] NULL,
        [CreatedDate] [datetime] NULL,
        [CreatedUser] [nvarchar](50) NULL,
        [ModifiedDate] [datetime] NULL,
        [ModifiedUser] [nvarchar](50) NULL,
     CONSTRAINT [PK_Unit] PRIMARY KEY CLUSTERED 
    (
        [UnitID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[User](
        [UserID] [int] IDENTITY(1,1) NOT NULL,
        [Username] [nvarchar](255) NOT NULL,
        [Password] [nvarchar](1000) NOT NULL,
        [FirstName] [nvarchar](255) NULL,
        [LastName] [nvarchar](255) NULL,
        [CellPhone] [nvarchar](50) NULL,
        [Email] [nvarchar](255) NULL,
        [Address] [nvarchar](255) NULL,
        [LastLoginDate] [datetime] NULL,
        [IsSystemAdmin] [bit] NOT NULL,
        [UseSystemConfig] [bit] NOT NULL DEFAULT(0),
        [IsLockedOut] [bit] NOT NULL,
        [LastLockedOutDate] [datetime] NULL,
        [FailedPasswordAttemptCount] [int] NOT NULL,
        [CreatedDate] [datetime] NULL,
        [CreatedUser] [nvarchar](50) NULL,
        [ModifiedDate] [datetime] NULL,
        [ModifiedUser] [nvarchar](50) NULL,
     CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
    (
        [UserID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserBranch]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[UserBranch](
    [UserBranchID] [bigint] IDENTITY(1,1) NOT NULL,
    [UserID] [int] NULL,
    [BranchID] [int] NULL,
 CONSTRAINT [PK_UserBranch] PRIMARY KEY CLUSTERED 
(
    [UserBranchID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserConfig]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[UserConfig](
        [UserConfigID] [bigint] IDENTITY(1,1) NOT NULL,
        [UserID] [int] NULL,
        [BranchID] [int] NULL,
        [IsSuspended] [bit] NULL,
        [DefaultAreaID] [bigint] NULL,
        [ListTableHeight] [numeric](19, 2) NULL,
        [PageSize] [int] NULL,
        [Theme] [nvarchar](50) NULL,
        [CreatedDate] [datetime] NULL,
        [CreatedUser] [nvarchar](50) NULL,
        [ModifiedDate] [datetime] NULL,
        [ModifiedUser] [nvarchar](50) NULL,
     CONSTRAINT [PK_UserConfig] PRIMARY KEY CLUSTERED 
    (
        [UserConfigID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UsersInRole]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[UsersInRole](
        [UsersInRoleID] [int] IDENTITY(1,1) NOT NULL,
        [UserID] [int] NOT NULL,
        [RoleID] [int] NOT NULL,
        [CreatedDate] [datetime] NULL,
        [CreatedUser] [nvarchar](50) NULL,
        [ModifiedDate] [datetime] NULL,
        [ModifiedUser] [nvarchar](50) NULL,
     CONSTRAINT [PK_UsersInRole] PRIMARY KEY CLUSTERED 
    (
        [UsersInRoleID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
END

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Page]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Page](
        [PageID] [int] NOT NULL,
        [VNTitle] [nvarchar](255) NULL,
        [ENTitle] [nvarchar](255) NULL,
        [VNDescription] [nvarchar](500) NULL,
        [ENDescription] [nvarchar](500) NULL,
        [Type] [tinyint] NULL,
        [Area] [nvarchar](50) NULL,
        [Controller] [nvarchar](50) NULL,
        [Action] [nvarchar](50) NULL,
		[Enable] [bit] NULL,
    CONSTRAINT [PK_Page] PRIMARY KEY CLUSTERED 
    (
        [PageID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PageLabel]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[PageLabel](
        [PageLabelID] [bigint] IDENTITY(1,1) NOT NULL,
        [LabelID] [nvarchar](50) NULL,
        [BranchID] [int] NULL,
        [PageID] [int] NULL,
        [VNText] [nvarchar](500) NULL,
        [ENText] [nvarchar](500) NULL,
     CONSTRAINT [PK_PageLabel] PRIMARY KEY CLUSTERED 
    (
        [PageLabelID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Order]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Order](
        [OrderID] [bigint] IDENTITY(1,1) NOT NULL,
        [BranchID] [int] NULL,
        [OrderNumber] [nvarchar](50) NULL,
        [Comment] [nvarchar](255) NULL,
        [CustomerID] [int] NULL,
        [CustomerName] [nvarchar](255) NULL,
        [CellPhone] [nvarchar](50) NULL,
        [Address] [nvarchar](510) NULL,
        [DOB] [datetime] NULL,
        [OtherFee] [numeric](19, 2) NULL,
        [OtherFeeDescription] [nvarchar](255) NULL,
		[OrderProgressStatus] [tinyint] NULL,
        [CreatedDate] [datetime] NULL,
        [CreatedUser] [nvarchar](50) NULL,
        [ModifiedDate] [datetime] NULL,
        [ModifiedUser] [nvarchar](50) NULL,
     CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
    (
        [OrderID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderDetail]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[OrderDetail](
        [OrderDetailID] [bigint] IDENTITY(1,1) NOT NULL,
        [OrderTableID] [bigint] NULL,
        [ProductID] [int] NULL,
        [Quantity] [numeric](10, 2) NULL,
        [Comment] [nvarchar](255) NULL,
        [Discount] [numeric](19, 2) NULL,
        [DiscountType] [tinyint] NULL,
        [DiscountCode] [nvarchar](50) NULL,
        [DiscountComment] [nvarchar](255) NULL,
        [KitchenComment] [nvarchar] (255) NULL,
        [OrderStatus] [tinyint] NULL,
		[CreatedDate] [datetime] NULL,
        [CreatedUser] [nvarchar](50) NULL,
        [ModifiedDate] [datetime] NULL,
        [ModifiedUser] [nvarchar](50) NULL,
     CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
    (
        [OrderDetailID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderDiscount]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[OrderDiscount](
        [OrderDiscountID] [bigint] IDENTITY(1,1) NOT NULL,
        [OrderID] [bigint] NULL,
        [Discount] [numeric](19, 2) NULL,
        [DiscountType] [tinyint] NULL,
        [DiscountCode] [nvarchar](50) NULL,
        [DiscountComment] [nvarchar](255) NULL,
     CONSTRAINT [PK_OrderDiscount] PRIMARY KEY CLUSTERED 
    (
        [OrderDiscountID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderTable]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[OrderTable](
        [OrderTableID] [bigint] IDENTITY(1,1) NOT NULL,
        [OrderID] [bigint] NULL,
        [TableID] [int] NULL,
        [Discount] [numeric](19, 2) NULL,
        [DiscountType] [tinyint] NULL,
        [DiscountCode] [nvarchar](50) NULL,
        [DiscountComment] [nvarchar](255) NULL,
        [UseServiceFee] [bit] NULL,
        [OtherFee] [numeric](19, 2) NULL,
        [OtherFeeDescription] [nvarchar](255) NULL,
        [CreatedDate] [datetime] NULL,
        [CreatedUser] [nvarchar](50) NULL,
        [ModifiedDate] [datetime] NULL,
        [ModifiedUser] [nvarchar](50) NULL,
    CONSTRAINT [PK_OrderTable] PRIMARY KEY CLUSTERED 
    (
        [OrderTableID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PageMenu]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[PageMenu](
        [PageMenuID] [int] NOT NULL,
        [GroupName] [nvarchar](50) NULL,
        [ParentID] [int] NULL,
        [PageID] [int] NULL,
        [SEQ] [int] NULL,
    CONSTRAINT [PK_PageMenu] PRIMARY KEY CLUSTERED 
    (
        [PageMenuID] ASC
    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
    ) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Role]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Role](
        [RoleID] [int] IDENTITY(1,1) NOT NULL,
        [Name] [nvarchar](64) NOT NULL,
        [BranchID] [int] NULL,
        [Enable] [bit] NULL,
     CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
    (
        [RoleID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RolePermission]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[RolePermission](
        [RolePermissionID] [bigint] IDENTITY(1,1) NOT NULL,
        [RoleID] [int] NOT NULL,
        [PageID] [int] NOT NULL,
        [CreatedDate] [datetime] NULL,
        [CreatedUser] [nvarchar](50) NULL,
        [ModifiedDate] [datetime] NULL,
        [ModifiedUser] [nvarchar](50) NULL,
     CONSTRAINT [PK_RolePermission] PRIMARY KEY CLUSTERED 
    (
        [RolePermissionID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Report]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Report](
        [ReportID] [int] IDENTITY(1,1) NOT NULL,
        [Name] [nvarchar](50) NOT NULL,
        [VNTitle] [nvarchar](100) NULL,
        [ENTitle] [nvarchar](100) NULL,
     CONSTRAINT [PK_Report] PRIMARY KEY CLUSTERED 
    (
        [ReportID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReportDatasource]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[ReportDatasource](
        [ReportDatasourceID] [int] IDENTITY(1,1) NOT NULL,
        [ReportID] [int] NULL,
        [Name] [nvarchar](50) NULL,
     CONSTRAINT [PK_ReportDatasource] PRIMARY KEY CLUSTERED 
    (
        [ReportDatasourceID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReportDatasourceParameter]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[ReportDatasourceParameter](
        [ReportDatasourceParameterID] [int] IDENTITY(1,1) NOT NULL,
        [ReportDatasourceID] [int] NULL,
        [Name] [nvarchar](50) NULL,
        [Type] [int] NULL,
     CONSTRAINT [PK_ReportDatasourceParameter] PRIMARY KEY CLUSTERED 
    (
        [ReportDatasourceParameterID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reject]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Reject](
        [RejectID] [bigint] IDENTITY(1,1) NOT NULL,
        [BranchID] [int] NULL,
        [ProductCode] [nvarchar](50) NULL,
        [ProductVNName] [nvarchar](1000) NULL,
        [ProductENName] [nvarchar](1000) NULL,
        [Quantity] [numeric](10, 2) NULL,
        [UnitVNName] [nvarchar](255) NULL,
        [UnitENName] [nvarchar](255) NULL,
        [OrderComment] [nvarchar](255) NULL,
        [KitchenComment] [nvarchar](255) NULL,
        [CreatedDate] [datetime] NULL,
        [CreatedUser] [nvarchar](50) NULL,
     CONSTRAINT [PK_Reject] PRIMARY KEY CLUSTERED 
    (
        [RejectID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BrandingText]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[BrandingText](
        [BrandingTextID] [int] IDENTITY(1,1) NOT NULL,
        [BranchID] [int] NULL,
        [Key] [nvarchar](100) NULL,
        [VNValue] [nvarchar](1000) NULL,
        [ENValue] [nvarchar](1000) NULL,
     CONSTRAINT [PK_BrandingText] PRIMARY KEY CLUSTERED 
    (
        [BrandingTextID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UploadedFile]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[UploadedFile](
        [UploadedFileID] [int] IDENTITY(1,1) NOT NULL,
        [Category] [tinyint] NULL,
        [PhysicalPath] [nvarchar](100) NULL,
        [UploadedDateTime] [datetime] NULL,
        [UploadedBy] [nvarchar](50) NULL,
     CONSTRAINT [PK_UploadedFile] PRIMARY KEY CLUSTERED 
    (
        [UploadedFileID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Depot]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[Depot](
		[DepotID] [int] IDENTITY(1,1) NOT NULL,
		[DepotCode] [nvarchar](50) NULL,
		[DepotName] [nvarchar](1000) NULL,
		[Phone] [nvarchar](50) NULL,
		[Fax] [nvarchar](50) NULL,
		[Email] [nvarchar](255) NULL,
		[Address] [nvarchar](510) NULL,
		[Enable] [bit] NULL,
		[SEQ] [int] NULL,
		[CreatedDate] [datetime] NULL,
		[CreatedUser] [nvarchar](50) NULL,
		[ModifiedDate] [datetime] NULL,
		[ModifiedUser] [nvarchar](50) NULL,
	 CONSTRAINT [PK_Depot] PRIMARY KEY CLUSTERED 
	(
		[DepotID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Item]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[Item](
		[ItemID] [bigint] IDENTITY(1,1) NOT NULL,
		[ItemCode] [nvarchar](50) NULL,
		[VNName] [nvarchar](1000) NULL,
		[ENName] [nvarchar](1000) NULL,
		[VNDescription] [nvarchar](1000) NULL,
		[ENDescription] [nvarchar](1000) NULL,
		[UnitID] [int] NULL,
		[ProductCategoryID] [int] NULL,
		[IsInventory] [bit] NULL,
		[MinQuantity] [numeric](10, 2) NULL,
		[Enable] [bit] NULL,
		[SEQ] [int] NULL,
		[CreatedDate] [datetime] NULL,
		[CreatedUser] [nvarchar](50) NULL,
		[ModifiedDate] [datetime] NULL,
		[ModifiedUser] [nvarchar](50) NULL,
	 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
	(
		[ItemID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Vendor]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[Vendor](
		[VendorID] [bigint] IDENTITY(1,1) NOT NULL,
		[VendorNumber] [nvarchar](50) NULL,
		[VendorName] [nvarchar](1000) NULL,
		[Phone] [nvarchar](50) NULL,
		[Fax] [nvarchar](50) NULL,
		[Email] [nvarchar](255) NULL,
		[TaxCode] [nvarchar](50) NULL,
		[Address] [nvarchar](510) NULL,
		[Enable] [bit] NULL,
		[SEQ] [int] NULL,
		[CreatedDate] [datetime] NULL,
		[CreatedUser] [nvarchar](50) NULL,
		[ModifiedDate] [datetime] NULL,
		[ModifiedUser] [nvarchar](50) NULL,
	 CONSTRAINT [PK_Vendor] PRIMARY KEY CLUSTERED 
	(
		[VendorID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeliveryItem]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[DeliveryItem](
		[DeliveryItemID] [bigint] IDENTITY(1,1) NOT NULL,
		[DeliveryNoteID] [bigint] NULL,
		[ItemID] [bigint] NULL,
		[Quantity] [numeric](10, 2) NULL,
		[Price] [numeric](19, 2) NULL,
		[Amount] [numeric](19, 2) NULL,
		[CreatedDate] [datetime] NULL,
		[CreatedUser] [nvarchar](50) NULL,
		[ModifiedDate] [datetime] NULL,
		[ModifiedUser] [nvarchar](50) NULL,
	 CONSTRAINT [PK_DeliveryItem] PRIMARY KEY CLUSTERED 
	(
		[DeliveryItemID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeliveryNote]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[DeliveryNote](
		[DeliveryNoteID] [bigint] IDENTITY(1,1) NOT NULL,
		[BranchID] [int] NULL,
		[DeliveryNumber] [nvarchar](50) NULL,
		[DeliveryDate] [datetime] NULL,
		[DeliveryTypeID] [tinyint] NULL,
		[Comment] [nvarchar](255) NULL,
		[CustomerID] [bigint] NULL,
		[ToDepotID] [bigint] NULL,
		[DocumentID] [bigint] NULL,
		[Recipient] [nvarchar](1000) NULL,
		[Address] [nvarchar](1000) NULL,
		[ContactInformation] [nvarchar](1000) NULL,
		[TotalAmount] [numeric](19, 2) NULL,
		[Currency] [nvarchar](50) NULL,
		[DebitAmount] [numeric](19, 2) NULL,
		[PaymentDate] [datetime] NULL,
		[CreatedDate] [datetime] NULL,
		[CreatedUser] [nvarchar](50) NULL,
		[ModifiedDare] [datetime] NULL,
		[ModifiedUser] [nvarchar](50) NULL,
	 CONSTRAINT [PK_DeliveryNote] PRIMARY KEY CLUSTERED 
	(
		[DeliveryNoteID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeliveryType]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[DeliveryType](
		[DeliveryTypeID] [tinyint] IDENTITY(1,1) NOT NULL,
		[VNName] [nvarchar](255) NULL,
		[ENName] [nvarchar](255) NULL,
		[UseImportPrice] [bit] NULL,
		[CreatedDate] [datetime] NULL,
		[CreatedUser] [nvarchar](50) NULL,
		[ModifiedDate] [datetime] NULL,
		[ModifiedUser] [nvarchar](50) NULL,
	 CONSTRAINT [PK_DeliveryType] PRIMARY KEY CLUSTERED 
	(
		[DeliveryTypeID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Inventory]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[Inventory](
		[InventoryID] [bigint] IDENTITY(1,1) NOT NULL,
		[DepotID] [int] NULL,
		[ItemID] [bigint] NULL,
		[Quantity] [numeric](10, 2) NULL,
		[CreatedDate] [datetime] NULL,
		[CreatedUser] [nvarchar](50) NULL,
		[ModifiedDate] [datetime] NULL,
		[ModifiedUser] [nvarchar](50) NULL,
	 CONSTRAINT [PK_Inventory] PRIMARY KEY CLUSTERED 
	(
		[InventoryID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReceiptNote]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[ReceiptNote](
		[ReceiptNoteID] [bigint] IDENTITY(1,1) NOT NULL,
		[BranchID] [int] NULL,
		[ReceiptNumber] [nvarchar](50) NULL,
		[ReceiptDate] [datetime] NULL,
		[VendorID] [bigint] NULL,
		[DepotID] [int] NULL,
		[Comment] [nvarchar](255) NULL,
		[DocumentID] [bigint] NULL,
		[TotalReceipt] [numeric](19, 2) NULL,
		[Currency] [nvarchar](50) NULL,
		[DebitAmount] [numeric](19, 2) NULL,
		[PaymentDate] [datetime] NULL,
		[CreatedDate] [datetime] NULL,
		[CreatedUser] [nvarchar](50) NULL,
		[ModifiedDate] [datetime] NULL,
		[ModifiedUser] [nvarchar](50) NULL,
	 CONSTRAINT [PK_ReceiptNote] PRIMARY KEY CLUSTERED 
	(
		[ReceiptNoteID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReceiptItem]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[ReceiptItem](
		[ReceiptItemID] [bigint] IDENTITY(1,1) NOT NULL,
		[ReceiptNoteID] [bigint] NULL,
		[ItemID] [bigint] NULL,
		[Quantity] [numeric](10, 2) NULL,
		[Price] [numeric](19, 2) NULL,
		[Amount] [numeric](19, 2) NULL,
		[CreatedDate] [datetime] NULL,
		[CreatedUser] [nvarchar](50) NULL,
		[ModifiedDate] [datetime] NULL,
		[ModifiedUser] [nvarchar](50) NULL,
	 CONSTRAINT [PK_ReceiptItem] PRIMARY KEY CLUSTERED 
	(
		[ReceiptItemID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

/*************************************************************************************/
/*************************************************************************************/
/*************************************************************************************/
/*************************************************************************************/

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_PageLabel_Page]') AND type in (N'F'))
BEGIN
    ALTER TABLE [dbo].[PageLabel]  WITH CHECK ADD  CONSTRAINT [FK_PageLabel_Page] FOREIGN KEY([PageID])
    REFERENCES [dbo].[Page] ([PageID])

    ALTER TABLE [dbo].[PageLabel] CHECK CONSTRAINT [FK_PageLabel_Page]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_Area_Branch]') AND type in (N'F'))
BEGIN
    ALTER TABLE [dbo].[Area] WITH CHECK ADD CONSTRAINT [FK_Area_Branch] FOREIGN KEY([BranchID])
    REFERENCES [dbo].[Branch] ([BranchID])

    ALTER TABLE [dbo].[Area] CHECK CONSTRAINT [FK_Area_Branch]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_Branch_Currency]') AND type in (N'F'))
BEGIN
    ALTER TABLE [dbo].[Branch] WITH CHECK ADD CONSTRAINT [FK_Branch_Currency] FOREIGN KEY([CurrencyID])
    REFERENCES [dbo].[Currency] ([CurrencyID])

    ALTER TABLE [dbo].[Branch] CHECK CONSTRAINT [FK_Branch_Currency]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_BranchTax_Branch]') AND type in (N'F'))
BEGIN
    ALTER TABLE [dbo].[BranchTax] WITH CHECK ADD CONSTRAINT [FK_BranchTax_Branch] FOREIGN KEY([BranchID])
    REFERENCES [dbo].[Branch] ([BranchID])

    ALTER TABLE [dbo].[BranchTax] CHECK CONSTRAINT [FK_BranchTax_Branch]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_BranchTax_Tax]') AND type in (N'F'))
BEGIN
    ALTER TABLE [dbo].[BranchTax] WITH CHECK ADD CONSTRAINT [FK_BranchTax_Tax] FOREIGN KEY([TaxID])
    REFERENCES [dbo].[Tax] ([TaxID])

    ALTER TABLE [dbo].[BranchTax] CHECK CONSTRAINT [FK_BranchTax_Tax]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_Customer_Branch]') AND type in (N'F'))
BEGIN
    ALTER TABLE [dbo].[Customer] WITH CHECK ADD CONSTRAINT [FK_Customer_Branch] FOREIGN KEY([BranchID])
    REFERENCES [dbo].[Branch] ([BranchID])

    ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Branch]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_Invoice_Branch]') AND type in (N'F'))
BEGIN
    ALTER TABLE [dbo].[Invoice] WITH CHECK ADD CONSTRAINT [FK_Invoice_Branch] FOREIGN KEY([BranchID])
    REFERENCES [dbo].[Branch] ([BranchID])

    ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Branch]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_InvoiceDetail_InvoiceTable]') AND type in (N'F'))
BEGIN
    ALTER TABLE [dbo].[InvoiceDetail] WITH CHECK ADD CONSTRAINT [FK_InvoiceDetail_InvoiceTable] FOREIGN KEY([InvoiceTableID])
    REFERENCES [dbo].[InvoiceTable] ([InvoiceTableID])

    ALTER TABLE [dbo].[InvoiceDetail] CHECK CONSTRAINT [FK_InvoiceDetail_InvoiceTable]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_InvoiceDiscount_Invoice]') AND type in (N'F'))
BEGIN
    ALTER TABLE [dbo].[InvoiceDiscount] WITH CHECK ADD CONSTRAINT [FK_InvoiceDiscount_Invoice] FOREIGN KEY([InvoiceID])
    REFERENCES [dbo].[Invoice] ([InvoiceID])

    ALTER TABLE [dbo].[InvoiceDiscount] CHECK CONSTRAINT [FK_InvoiceDiscount_Invoice]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_InvoiceTable_Invoice]') AND type in (N'F'))
BEGIN
    ALTER TABLE [dbo].[InvoiceTable] WITH CHECK ADD CONSTRAINT [FK_InvoiceTable_Invoice] FOREIGN KEY([InvoiceID])
    REFERENCES [dbo].[Invoice] ([InvoiceID])

    ALTER TABLE [dbo].[InvoiceTable] CHECK CONSTRAINT [FK_InvoiceTable_Invoice]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_InvoiceTable_Table]') AND type in (N'F'))
BEGIN
    ALTER TABLE [dbo].[InvoiceTable] WITH CHECK ADD CONSTRAINT [FK_InvoiceTable_Table] FOREIGN KEY([TableID])
    REFERENCES [dbo].[Table] ([TableID])

    ALTER TABLE [dbo].[InvoiceTable] CHECK CONSTRAINT [FK_InvoiceTable_Table]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_Product_ProductCategory]') AND type in (N'F'))
BEGIN
    ALTER TABLE [dbo].[Product] WITH CHECK ADD CONSTRAINT [FK_Product_ProductCategory] FOREIGN KEY([ProductCategoryID])
    REFERENCES [dbo].[ProductCategory] ([ProductCategoryID])

    ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductCategory]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_Product_Unit]') AND type in (N'F'))
BEGIN
    ALTER TABLE [dbo].[Product] WITH CHECK ADD CONSTRAINT [FK_Product_Unit] FOREIGN KEY([UnitID])
    REFERENCES [dbo].[Unit] ([UnitID])

    ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Unit]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_ProductCategory_Branch]') AND type in (N'F'))
BEGIN
    ALTER TABLE [dbo].[ProductCategory] WITH CHECK ADD CONSTRAINT [FK_ProductCategory_Branch] FOREIGN KEY([BranchID])
    REFERENCES [dbo].[Branch] ([BranchID])

    ALTER TABLE [dbo].[ProductCategory] CHECK CONSTRAINT [FK_ProductCategory_Branch]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_ProductPriceHistory_Product]') AND type in (N'F'))
BEGIN
    ALTER TABLE [dbo].[ProductPriceHistory] WITH CHECK ADD CONSTRAINT [FK_ProductPriceHistory_Product] FOREIGN KEY([ProductID])
    REFERENCES [dbo].[Product] ([ProductID])

    ALTER TABLE [dbo].[ProductPriceHistory] CHECK CONSTRAINT [FK_ProductPriceHistory_Product]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_Table_Area]') AND type in (N'F'))
BEGIN
    ALTER TABLE [dbo].[Table] WITH CHECK ADD CONSTRAINT [FK_Table_Area] FOREIGN KEY([AreaID])
    REFERENCES [dbo].[Area] ([AreaID])

    ALTER TABLE [dbo].[Table] CHECK CONSTRAINT [FK_Table_Area]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_Unit_Branch]') AND type in (N'F'))
BEGIN
    ALTER TABLE [dbo].[Unit] WITH CHECK ADD CONSTRAINT [FK_Unit_Branch] FOREIGN KEY([BranchID])
    REFERENCES [dbo].[Branch] ([BranchID])

    ALTER TABLE [dbo].[Unit] CHECK CONSTRAINT [FK_Unit_Branch]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_UserBranch_Branch]') AND type in (N'F'))
BEGIN
    ALTER TABLE [dbo].[UserBranch] WITH CHECK ADD CONSTRAINT [FK_UserBranch_Branch] FOREIGN KEY([BranchID])
    REFERENCES [dbo].[Branch] ([BranchID])

    ALTER TABLE [dbo].[UserBranch] CHECK CONSTRAINT [FK_UserBranch_Branch]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_UserBranch_User]') AND type in (N'F'))
BEGIN
    ALTER TABLE [dbo].[UserBranch] WITH CHECK ADD CONSTRAINT [FK_UserBranch_User] FOREIGN KEY([UserID])
    REFERENCES [dbo].[User] ([UserID])

    ALTER TABLE [dbo].[UserBranch] CHECK CONSTRAINT [FK_UserBranch_User]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_OrderDetail_OrderTable]') AND type in (N'F'))
BEGIN
    ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_OrderTable] FOREIGN KEY([OrderTableID])
    REFERENCES [dbo].[OrderTable] ([OrderTableID])

    ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_OrderTable]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_OrderDetail_Product]') AND type in (N'F'))
BEGIN
    ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Product] FOREIGN KEY([ProductID])
    REFERENCES [dbo].[Product] ([ProductID])

    ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Product]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_OrderDiscount_Order]') AND type in (N'F'))
BEGIN
    ALTER TABLE [dbo].[OrderDiscount]  WITH CHECK ADD  CONSTRAINT [FK_OrderDiscount_Order] FOREIGN KEY([OrderID])
    REFERENCES [dbo].[Order] ([OrderID])

    ALTER TABLE [dbo].[OrderDiscount] CHECK CONSTRAINT [FK_OrderDiscount_Order]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_OrderTable_Order]') AND type in (N'F'))
BEGIN
    ALTER TABLE [dbo].[OrderTable]  WITH CHECK ADD  CONSTRAINT [FK_OrderTable_Order] FOREIGN KEY([OrderID])
    REFERENCES [dbo].[Order] ([OrderID])

    ALTER TABLE [dbo].[OrderTable] CHECK CONSTRAINT [FK_OrderTable_Order]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_OrderTable_Table]') AND type in (N'F'))
BEGIN
    ALTER TABLE [dbo].[OrderTable]  WITH CHECK ADD  CONSTRAINT [FK_OrderTable_Table] FOREIGN KEY([TableID])
    REFERENCES [dbo].[Table] ([TableID])

    ALTER TABLE [dbo].[OrderTable] CHECK CONSTRAINT [FK_OrderTable_Table]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_Order_Branch]') AND type in (N'F'))
BEGIN
    ALTER TABLE [dbo].[Order] WITH CHECK ADD CONSTRAINT [FK_Order_Branch] FOREIGN KEY([BranchID])
    REFERENCES [dbo].[Branch] ([BranchID])

    ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Branch]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_Role_Branch]') AND type in (N'F'))
BEGIN
    ALTER TABLE [dbo].[Role]  WITH CHECK ADD  CONSTRAINT [FK_Role_Branch] FOREIGN KEY([BranchID])
    REFERENCES [dbo].[Branch] ([BranchID])

    ALTER TABLE [dbo].[Role] CHECK CONSTRAINT [FK_Role_Branch]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_PageMenu_Page]') AND type in (N'F'))
BEGIN
    ALTER TABLE [dbo].[PageMenu]  WITH CHECK ADD  CONSTRAINT [FK_PageMenu_Page] FOREIGN KEY([PageID])
    REFERENCES [dbo].[Page] ([PageID])

    ALTER TABLE [dbo].[PageMenu] CHECK CONSTRAINT [FK_PageMenu_Page]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[DF_User_IsSystemAdmin]') AND type in (N'D'))
BEGIN
    ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_IsSystemAdmin]  DEFAULT ((0)) FOR [IsSystemAdmin]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[DF_User_IsLockedOut]') AND type in (N'D'))
BEGIN
    ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_IsLockedOut]  DEFAULT ((0)) FOR [IsLockedOut]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[DF_User_FailedPasswordAttemptCount]') AND type in (N'D'))
BEGIN
    ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_FailedPasswordAttemptCount]  DEFAULT ((0)) FOR [FailedPasswordAttemptCount]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_UsersInRole_Role]') AND type in (N'F'))
BEGIN
    ALTER TABLE [dbo].[UsersInRole]  WITH CHECK ADD  CONSTRAINT [FK_UsersInRole_Role] FOREIGN KEY([RoleID])
    REFERENCES [dbo].[Role] ([RoleID])

    ALTER TABLE [dbo].[UsersInRole] CHECK CONSTRAINT [FK_UsersInRole_Role]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_UsersInRole_User]') AND type in (N'F'))
BEGIN
    ALTER TABLE [dbo].[UsersInRole]  WITH CHECK ADD  CONSTRAINT [FK_UsersInRole_User] FOREIGN KEY([UserID])
    REFERENCES [dbo].[User] ([UserID])

    ALTER TABLE [dbo].[UsersInRole] CHECK CONSTRAINT [FK_UsersInRole_User]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_RolePermission_Role]') AND type in (N'F'))
BEGIN
    ALTER TABLE [dbo].[RolePermission]  WITH CHECK ADD  CONSTRAINT [FK_RolePermission_Role] FOREIGN KEY([RoleID])
    REFERENCES [dbo].[Role] ([RoleID])

    ALTER TABLE [dbo].[RolePermission] CHECK CONSTRAINT [FK_RolePermission_Role]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_RolePermission_User]') AND type in (N'F'))
BEGIN
    ALTER TABLE [dbo].[RolePermission]  WITH CHECK ADD  CONSTRAINT [FK_RolePermission_User] FOREIGN KEY([PageID])
    REFERENCES [dbo].[Page] ([PageID])

    ALTER TABLE [dbo].[RolePermission] CHECK CONSTRAINT [FK_RolePermission_User]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_BrandingText_Branch]') AND type in (N'F'))
BEGIN
    ALTER TABLE [dbo].[BrandingText] WITH CHECK ADD CONSTRAINT [FK_BrandingText_Branch] FOREIGN KEY([BranchID])
    REFERENCES [dbo].[Branch] ([BranchID])

    ALTER TABLE [dbo].[BrandingText] CHECK CONSTRAINT [FK_BrandingText_Branch]
END
GO

/*************************************************************************************/
/*************************************************************************************/
/*************************************************************************************/
/*************************************************************************************/

CREATE TRIGGER [dbo].[trigger_ProductPriceLog] ON dbo.Product FOR UPDATE
AS
    SET NOCOUNT ON
    IF UPDATE(Price)
    BEGIN
        DECLARE @oldPrice NUMERIC(12, 2);
        SELECT @oldPrice = Price FROM deleted;

        IF EXISTS ( SELECT TOP 1 1 FROM inserted WHERE Price <> @oldPrice )
        BEGIN
            INSERT INTO dbo.ProductPriceHistory (ProductID, OldPrice, NewPrice, CreatedDate, CreatedUser )
            SELECT ProductID, @oldPrice, Price, ModifiedDate, ModifiedUser FROM inserted
        END
    END
GO