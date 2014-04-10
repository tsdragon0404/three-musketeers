/****** Object:  Table [dbo].[Area]    Script Date: 4/10/2014 4:30:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
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

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Branch]    Script Date: 4/10/2014 4:30:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
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

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BranchTax]    Script Date: 4/10/2014 4:30:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BranchTax](
	[RecordID] [int] IDENTITY(1,1) NOT NULL,
	[BranchID] [int] NULL,
	[TaxID] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedUser] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedUser] [varchar](50) NULL,
 CONSTRAINT [PK_BranchTax] PRIMARY KEY CLUSTERED 
(
	[RecordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Currency]    Script Date: 4/10/2014 4:30:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
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

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 4/10/2014 4:30:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
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

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ErrorMessage]    Script Date: 4/10/2014 4:30:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ErrorMessage](
	[ErrorCode] [int] NOT NULL,
	[VNMessage] [nvarchar](1000) NULL,
	[ENMessage] [nvarchar](1000) NULL,
 CONSTRAINT [PK_ErrorMessage] PRIMARY KEY CLUSTERED 
(
	[ErrorCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 4/10/2014 4:30:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
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

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InvoiceDetail]    Script Date: 4/10/2014 4:30:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceDetail](
	[InvoiceDetailID] [bigint] IDENTITY(1,1) NOT NULL,
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

GO
/****** Object:  Table [dbo].[InvoiceDiscount]    Script Date: 4/10/2014 4:30:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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

GO
/****** Object:  Table [dbo].[InvoiceTable]    Script Date: 4/10/2014 4:30:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
 CONSTRAINT [PK_InvoiceDetail] PRIMARY KEY CLUSTERED 
(
	[InvoiceTableID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 4/10/2014 4:30:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
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

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 4/10/2014 4:30:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
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

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductPriceHistory]    Script Date: 4/10/2014 4:30:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductPriceHistory](
	[RecordID] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductID] [bigint] NULL,
	[OldPrice] [numeric](12, 2) NULL,
	[NewPrice] [numeric](12, 2) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedUser] [varchar](50) NULL,
 CONSTRAINT [PK_ProductPriceHistory] PRIMARY KEY CLUSTERED 
(
	[RecordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SystemInfomation]    Script Date: 4/10/2014 4:30:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SystemInfomation](
	[RecordID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Value] [varchar](255) NULL,
 CONSTRAINT [PK_SystemInfomation_1] PRIMARY KEY CLUSTERED 
(
	[RecordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Table]    Script Date: 4/10/2014 4:30:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
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

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tax]    Script Date: 4/10/2014 4:30:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
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

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Unit]    Script Date: 4/10/2014 4:30:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
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

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 4/10/2014 4:30:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
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

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserBranch]    Script Date: 4/10/2014 4:30:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserBranch](
	[RecordID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[BranchID] [int] NULL,
	[AccessLevel] [tinyint] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedUser] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedUser] [varchar](50) NULL,
 CONSTRAINT [PK_UserBranch_1] PRIMARY KEY CLUSTERED 
(
	[RecordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
