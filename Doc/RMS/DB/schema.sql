/****************************************************************  CREATE_TABLE  *********************************************************************/
/*****************************************************************************************************************************************************/
/*****************************************************************************************************************************************************/

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Area]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[Area](
		[AreaID] [int] NOT NULL,
		[VNName] [nvarchar](255) NULL,
		[ENName] [nvarchar](255) NULL,
		[BranchID] [uniqueidentifier] NULL,
		[Enable] [bit] NULL,
		[SEQ] [int] NULL,
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
		[BranchID] [uniqueidentifier] NOT NULL,
		[VNName] [nvarchar](255) NULL,
		[ENName] [nvarchar](255) NULL,
		[Enable] [bit] NULL,
		[SEQ] [int] NULL,
	 CONSTRAINT [PK_Branch] PRIMARY KEY CLUSTERED 
	(
		[BranchID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BranchConfig]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[BranchConfig](
		[BranchID] [uniqueidentifier] NOT NULL,
		[Currency] [varchar](10) NULL,
		[UseTax] [bit] NULL,
		[Tax] [varchar](255) NULL,
		[UseServiceFee] [bit] NULL,
		[ServiceFee] [numeric](12, 2) NULL,
		[CreatedDate] [datetime] NULL,
		[CreatedUser] [uniqueidentifier] NULL,
		[ModifiedDate] [datetime] NULL,
		[ModifiedUser] [uniqueidentifier] NULL,
	 CONSTRAINT [PK_BranchConfig] PRIMARY KEY CLUSTERED 
	(
		[BranchID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Currency]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[Currency](
		[Currency] [varchar](10) NOT NULL,
		[Exchange] [numeric](12, 2) NULL,
		[Enable] [bit] NULL,
		[SEQ] [int] NULL,
		[CreatedDate] [datetime] NULL,
		[CreatedUser] [uniqueidentifier] NULL,
		[ModifiedDate] [datetime] NULL,
		[ModifiedUser] [uniqueidentifier] NULL,
	 CONSTRAINT [PK_Currency] PRIMARY KEY CLUSTERED 
	(
		[Currency] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[Customer](
		[CustomerID] [uniqueidentifier] NOT NULL,
		[CustomerName] [nvarchar](255) NULL,
		[BranchID] [uniqueidentifier] NULL,
		[Enable] [bit] NULL,
		[SEQ] [int] NULL,
		[CreatedDate] [datetime] NULL,
		[CreatedUser] [uniqueidentifier] NULL,
		[ModifiedDate] [datetime] NULL,
		[ModifiedUser] [uniqueidentifier] NULL,
	 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
	(
		[CustomerID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Invoice]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[Invoice](
		[InvoiceID] [varchar](50) NOT NULL,
		[BranchID] [uniqueidentifier] NOT NULL,
		[InvoiceDate] [datetime] NULL,
		[CustomerID] [uniqueidentifier] NULL,
		[UserID] [uniqueidentifier] NULL,
		[Comment] [nvarchar](255) NULL,
		[Tax] [numeric](12, 2) NULL,
		[ServiceFee] [numeric](12, 2) NULL,
		[OtherFee] [numeric](12, 2) NULL,
		[InvoiceAmount] [numeric](12, 2) NULL,
		[Currency] [varchar](10) NULL,
		[CreatedDate] [datetime] NULL,
		[CreatedUser] [uniqueidentifier] NULL,
		[ModifiedDate] [datetime] NULL,
		[ModifiedUser] [uniqueidentifier] NULL,
	 CONSTRAINT [PK_Invoice_1] PRIMARY KEY CLUSTERED 
	(
		[InvoiceID] ASC,
		[BranchID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InvoiceDetail]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[InvoiceDetail](
		[InvoiceDetailID] [bigint] NOT NULL,
		[InvoiceTableID] [bigint] NULL,
		[ProductID] [int] NULL,
		[Quantity] [numeric](10, 2) NULL,
		[Price] [numeric](12, 2) NULL,
		[Discount] [numeric](12, 2) NULL,
		[DiscountType] [tinyint] NULL,
		[Comment] [nvarchar](255) NULL,
	 CONSTRAINT [PK_InvoiceDetail_1] PRIMARY KEY CLUSTERED 
	(
		[InvoiceDetailID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InvoiceDiscount]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[InvoiceDiscount](
		[InvoiceDiscountID] [bigint] NOT NULL,
		[InvoiceID] [varchar](50) NULL,
		[BranchID] [uniqueidentifier] NULL,
		[Discount] [numeric](12, 2) NULL,
		[DiscountType] [tinyint] NULL,
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
		[InvoiceTableID] [bigint] NOT NULL,
		[InvoiceID] [varchar](50) NULL,
		[BranchID] [uniqueidentifier] NULL,
		[TableID] [int] NULL,
		[Discount] [numeric](12, 2) NULL,
		[DiscountType] [tinyint] NULL,
		[Comment] [nvarchar](255) NULL,
		[Tax] [numeric](12, 2) NULL,
		[ServiceFee] [numeric](12, 2) NULL,
		[OtherFee] [numeric](12, 2) NULL,
		[TableAmount] [numeric](12, 2) NULL,
	 CONSTRAINT [PK_InvoiceDetail] PRIMARY KEY CLUSTERED 
	(
		[InvoiceTableID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Product]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[Product](
		[ProductID] [int] NOT NULL,
		[VNName] [nvarchar](1000) NULL,
		[ENName] [nvarchar](1000) NULL,
		[VNDescription] [nvarchar](1000) NULL,
		[ENDescription] [nvarchar](1000) NULL,
		[Unit] [tinyint] NULL,
		[ProductCategoryID] [smallint] NULL,
		[Price] [numeric](12, 2) NULL,
		[Enable] [bit] NULL,
		[SEQ] [int] NULL,
		[CreatedDate] [datetime] NULL,
		[CreatedUser] [uniqueidentifier] NULL,
		[ModifiedDate] [datetime] NULL,
		[ModifiedUser] [uniqueidentifier] NULL,
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
		[ProductCategoryID] [smallint] NOT NULL,
		[VNName] [nvarchar](255) NULL,
		[ENName] [nvarchar](255) NULL,
		[VNDescription] [nvarchar](255) NULL,
		[ENDescription] [nvarchar](255) NULL,
		[BranchID] [uniqueidentifier] NULL,
		[Enable] [bit] NULL,
		[SEQ] [smalldatetime] NULL,
	 CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED 
	(
		[ProductCategoryID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Table]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[Table](
		[TableID] [int] NOT NULL,
		[VNName] [nvarchar](255) NULL,
		[ENName] [nvarchar](255) NULL,
		[AreaID] [int] NULL,
		[Enable] [bit] NULL,
		[SEQ] [int] NULL,
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
		[Tax] [varchar](10) NOT NULL,
		[Value] [numeric](5, 2) NULL,
		[BranchID] [uniqueidentifier] NULL,
		[Enable] [bit] NULL,
		[SEQ] [int] NULL,
		[CreatedDate] [datetime] NULL,
		[CreatedUser] [uniqueidentifier] NULL,
		[ModifiedDate] [datetime] NULL,
		[ModifiedUser] [uniqueidentifier] NULL,
	 CONSTRAINT [PK_Tax] PRIMARY KEY CLUSTERED 
	(
		[Tax] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[User](
		[UserID] [uniqueidentifier] NOT NULL,
		[UserCode] [nvarchar](255) NULL,
		[UserLogin] [varchar](255) NULL,
		[UserPassword] [varchar](1000) NULL,
		[FirstName] [nvarchar](255) NULL,
		[LastName] [nvarchar](255) NULL,
		[CellPhone] [varchar](50) NULL,
		[Enable] [bit] NULL,
		[SEQ] [int] NULL,
		[CreatedDate] [datetime] NULL,
		[CreateUser] [uniqueidentifier] NULL,
		[ModifiedDate] [datetime] NULL,
		[ModifiedUser] [uniqueidentifier] NULL,
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
		[UserID] [uniqueidentifier] NOT NULL,
		[BranchID] [uniqueidentifier] NOT NULL,
		[CreatedDate] [datetime] NULL,
		[CreatedUser] [uniqueidentifier] NULL,
		[ModifiedDate] [datetime] NULL,
		[ModifiedUser] [uniqueidentifier] NULL,
	 CONSTRAINT [PK_UserBranch] PRIMARY KEY CLUSTERED 
	(
		[UserID] ASC,
		[BranchID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ManageObject]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[ManageObject](
		[BranchID] [uniqueidentifier] NOT NULL,
		[ObjectName] [varchar](255) NOT NULL,
		[ObjectID] [bigint] NOT NULL,
	 CONSTRAINT [PK_ManageObject] PRIMARY KEY CLUSTERED 
	(
		[BranchID] ASC,
		[ObjectName] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SystemInfomation]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[SystemInfomation](
		[Name] [varchar](255) NOT NULL,
		[Value] [varchar](255) NULL,
	 CONSTRAINT [PK_SystemInfomation] PRIMARY KEY CLUSTERED 
	(
		[Name] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ErrorMessage]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[ErrorMessage](
		[ErrorCode] [int] NOT NULL,
		[VNMessage] [nvarchar](1000) NULL,
		[ENMessage] [nvarchar](1000) NULL,
	 CONSTRAINT [PK_ErrorMessage] PRIMARY KEY CLUSTERED 
	(
		[ErrorCode] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

END
GO

/**************************************************************   CREATE_CONSTRAINT   ****************************************************************/
/*****************************************************************************************************************************************************/
/*****************************************************************************************************************************************************/

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_Area_Branch]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[Area]  WITH CHECK ADD  CONSTRAINT [FK_Area_Branch] FOREIGN KEY([BranchID])
	REFERENCES [dbo].[Branch] ([BranchID])

	ALTER TABLE [dbo].[Area] CHECK CONSTRAINT [FK_Area_Branch]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_BranchConfig_Branch]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[BranchConfig]  WITH CHECK ADD  CONSTRAINT [FK_BranchConfig_Branch] FOREIGN KEY([BranchID])
	REFERENCES [dbo].[Branch] ([BranchID])

	ALTER TABLE [dbo].[BranchConfig] CHECK CONSTRAINT [FK_BranchConfig_Branch]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_Customer_Branch]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Branch] FOREIGN KEY([BranchID])
	REFERENCES [dbo].[Branch] ([BranchID])

	ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Branch]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_Invoice_Branch]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Branch] FOREIGN KEY([BranchID])
	REFERENCES [dbo].[Branch] ([BranchID])

	ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Branch]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_Invoice_Currency]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Currency] FOREIGN KEY([Currency])
	REFERENCES [dbo].[Currency] ([Currency])

	ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Currency]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_Invoice_Customer]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Customer] FOREIGN KEY([CustomerID])
	REFERENCES [dbo].[Customer] ([CustomerID])

	ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Customer]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_Invoice_User]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_User] FOREIGN KEY([UserID])
	REFERENCES [dbo].[User] ([UserID])

	ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_User]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_InvoiceDetail_InvoiceTable]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[InvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetail_InvoiceTable] FOREIGN KEY([InvoiceTableID])
	REFERENCES [dbo].[InvoiceTable] ([InvoiceTableID])

	ALTER TABLE [dbo].[InvoiceDetail] CHECK CONSTRAINT [FK_InvoiceDetail_InvoiceTable]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_InvoiceDetail_Product]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[InvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetail_Product] FOREIGN KEY([ProductID])
	REFERENCES [dbo].[Product] ([ProductID])

	ALTER TABLE [dbo].[InvoiceDetail] CHECK CONSTRAINT [FK_InvoiceDetail_Product]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_InvoiceDiscount_Invoice]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[InvoiceDiscount]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDiscount_Invoice] FOREIGN KEY([InvoiceID], [BranchID])
	REFERENCES [dbo].[Invoice] ([InvoiceID], [BranchID])

	ALTER TABLE [dbo].[InvoiceDiscount] CHECK CONSTRAINT [FK_InvoiceDiscount_Invoice]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_InvoiceTable_Invoice]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[InvoiceTable]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceTable_Invoice] FOREIGN KEY([InvoiceID], [BranchID])
	REFERENCES [dbo].[Invoice] ([InvoiceID], [BranchID])

	ALTER TABLE [dbo].[InvoiceTable] CHECK CONSTRAINT [FK_InvoiceTable_Invoice]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_InvoiceTable_Table]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[InvoiceTable]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceTable_Table] FOREIGN KEY([TableID])
	REFERENCES [dbo].[Table] ([TableID])

	ALTER TABLE [dbo].[InvoiceTable] CHECK CONSTRAINT [FK_InvoiceTable_Table]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_Product_ProductCategory]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductCategory] FOREIGN KEY([ProductCategoryID])
	REFERENCES [dbo].[ProductCategory] ([ProductCategoryID])

	ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductCategory]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_ProductCategory_Branch]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[ProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategory_Branch] FOREIGN KEY([BranchID])
	REFERENCES [dbo].[Branch] ([BranchID])

	ALTER TABLE [dbo].[ProductCategory] CHECK CONSTRAINT [FK_ProductCategory_Branch]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_Table_Area]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[Table]  WITH CHECK ADD  CONSTRAINT [FK_Table_Area] FOREIGN KEY([AreaID])
	REFERENCES [dbo].[Area] ([AreaID])

	ALTER TABLE [dbo].[Table] CHECK CONSTRAINT [FK_Table_Area]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_Tax_Branch]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[Tax]  WITH CHECK ADD  CONSTRAINT [FK_Tax_Branch] FOREIGN KEY([BranchID])
	REFERENCES [dbo].[Branch] ([BranchID])

	ALTER TABLE [dbo].[Tax] CHECK CONSTRAINT [FK_Tax_Branch]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_UserBranch_Branch]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[UserBranch]  WITH CHECK ADD  CONSTRAINT [FK_UserBranch_Branch] FOREIGN KEY([BranchID])
	REFERENCES [dbo].[Branch] ([BranchID])

	ALTER TABLE [dbo].[UserBranch] CHECK CONSTRAINT [FK_UserBranch_Branch]
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_UserBranch_User]') AND type in (N'F'))
BEGIN
	ALTER TABLE [dbo].[UserBranch]  WITH CHECK ADD  CONSTRAINT [FK_UserBranch_User] FOREIGN KEY([UserID])
	REFERENCES [dbo].[User] ([UserID])

	ALTER TABLE [dbo].[UserBranch] CHECK CONSTRAINT [FK_UserBranch_User]
END
GO

/***************************************************************   STORE_FUNCTION   ******************************************************************/
/*****************************************************************************************************************************************************/
/*****************************************************************************************************************************************************/

IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spa_get_ObjectID]') AND type in (N'P'))
BEGIN
	DROP PROCEDURE [dbo].[spa_get_ObjectID]
END
GO
/********************************************************************************
* NAME: spa_get_ObjectID
* PURPOSE: Get Table ID
* NOTE:
* DATE        VERSION           AUTHOR           DESCRIPTION
*********************************************************************************
* 10/31/2013  1.00              DuyTran          Create new
*********************************************************************************
DECLARE @ID bigint
EXEC dbo.spa_get_ObjectID @I_vBranchID = 'D96B99C1-9A43-4DBF-9622-4F03774A7E45', @I_vObjectName = 'Area',@O_vObjectID = @ID out
SELECT @ID
*********************************************************************************/

CREATE PROCEDURE [dbo].[spa_get_ObjectID]
	 @I_vBranchID varchar(100)
	,@I_vObjectName varchar(100)
	,@O_vObjectID bigint out
AS
BEGIN
	
	DECLARE @intObjectID BIGINT,
			@intResult INT;
	
	SELECT  @intObjectID = 0,
			@intResult = 0;
	
	SET NOCOUNT ON;
	
	BEGIN TRANSACTION
	
	IF NOT EXISTS ( SELECT TOP 1 1 FROM dbo.ManageObject WHERE ObjectName = @I_vObjectName AND BranchID = @I_vBranchID )
	BEGIN
		SELECT @intObjectID = 1;
		
		INSERT INTO dbo.ManageObject ( BranchID , ObjectName, ObjectID )
		VALUES ( @I_vBranchID, @I_vObjectName, @intObjectID )
		
		SELECT @intResult = @@ERROR;
		IF ( @intResult <> 0 ) 
		BEGIN
			GOTO PROBLEM;
		END
	END
	ELSE
	BEGIN
		SELECT @intObjectID = ObjectID + 1 
		FROM dbo.ManageObject WITH (HOLDLOCK, ROWLOCK) 
		WHERE ObjectName = @I_vObjectName
			AND BranchID = @I_vBranchID;
		
		UPDATE dbo.ManageObject
		SET ObjectID = @intObjectID
		WHERE ObjectName = @I_vObjectName
			AND BranchID = @I_vBranchID
		
		SELECT @intResult = @@ERROR;
		IF ( @intResult <> 0 ) 
		BEGIN
			GOTO PROBLEM;
		END
	END
	
	SELECT O_vObjectID = @intObjectID
	
	COMMIT TRANSACTION
	RETURN ( @intResult );  
 
	PROBLEM:
	IF @intResult <> 0 
    BEGIN
        ROLLBACK TRANSACTION
        RETURN ( @intResult );
    END
END
GO