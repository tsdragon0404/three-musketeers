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

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Branch]') AND type in (N'U'))
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

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BranchTax]') AND type in (N'U'))
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

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Currency]') AND type in (N'U'))
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
		[CustomerCode] [varchar](50) NOT NULL,
		[CustomerName] [nvarchar](255) NULL,
		[BranchID] [int] NULL,
		[Enable] [bit] NULL,
		[SEQ] [int] NULL,
		[CreatedDate] [datetime] NULL,
		[CreatedUser] [varchar](50) NULL,
		[ModifiedDate] [datetime] NULL,
		[ModifiedUser] [varchar](50) NULL,
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

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InvoiceDetail]') AND type in (N'U'))
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

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InvoiceTable]') AND type in (N'U'))
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

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProductPriceHistory]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[ProductPriceHistory](
		[ProductPriceHistoryID] [bigint] IDENTITY(1,1) NOT NULL,
		[ProductID] [int] NULL,
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

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SystemInfomation]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[SystemInfomation](
		[SystemInfomationID] [int] IDENTITY(1,1) NOT NULL,
		[Name] [varchar](255) NOT NULL,
		[Value] [varchar](255) NULL,
	 CONSTRAINT [PK_SystemInfomation] PRIMARY KEY CLUSTERED 
	(
		[SystemInfomationID] ASC
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

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tax]') AND type in (N'U'))
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
		[ModifiedUser] [varchar](50) NULL,
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

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
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
		[AccessLevel] [tinyint] NULL,
		[CreatedDate] [datetime] NULL,
		[CreatedUser] [varchar](50) NULL,
		[ModifiedDate] [datetime] NULL,
		[ModifiedUser] [varchar](50) NULL,
	 CONSTRAINT [PK_UserBranch] PRIMARY KEY CLUSTERED 
	(
		[UserBranchID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
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

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_Invoice_Customer]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[Invoice] WITH CHECK ADD CONSTRAINT [FK_Invoice_Customer] FOREIGN KEY([CustomerID])
	REFERENCES [dbo].[Customer] ([CustomerID])

	ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Customer]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_Invoice_User]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[Invoice] WITH CHECK ADD CONSTRAINT [FK_Invoice_User] FOREIGN KEY([UserID])
	REFERENCES [dbo].[User] ([UserID])

	ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_User]
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
