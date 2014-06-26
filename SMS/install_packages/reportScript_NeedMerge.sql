USE [SMS]
GO

/****** Object:  Table [dbo].[Report]    Script Date: 06/21/2014 21:47:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Report](
	[ReportID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[VNTitle] [nvarchar](100) NULL,
  [ENTitle] [nvarchar](100) NULL,
 CONSTRAINT [PK_Report] PRIMARY KEY CLUSTERED 
(
	[ReportID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[ReportDatasource](
	[ReportDatasourceID] [int] NOT NULL,
	[ReportID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ReportDatasource] PRIMARY KEY CLUSTERED 
(
	[ReportDatasourceID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE TABLE [dbo].[ReportDatasourceParameter](
	[ReportDatasourceParameterID] [int] NOT NULL,
	[ReportDatasourceID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Type] [int] NULL,
 CONSTRAINT [PK_ReportDatasourceParameter] PRIMARY KEY CLUSTERED 
(
	[ReportDatasourceParameterID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/* them khoa ngoai cho may bang nay ho voi 
      Report 1--* ReportDatasource 1--* ReportDatasourceParameter 
   
   Cho may cai primarykey identity dum t luon
      */
