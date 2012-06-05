USE [BDSWebsite]
GO
/****** Object:  Table [dbo].[tblProject]    Script Date: 06/05/2012 23:22:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProject](
	[ID] [bigint] NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Description] [nvarchar](1000) NULL,
 CONSTRAINT [PK_tblProject] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPlanning]    Script Date: 06/05/2012 23:22:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPlanning](
	[ID] [bigint] NOT NULL,
	[ProjectID] [bigint] NULL,
	[ImageLinks] [nvarchar](1000) NULL,
	[Description] [nvarchar](1000) NULL,
 CONSTRAINT [PK_tblPlanning] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblNews]    Script Date: 06/05/2012 23:22:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblNews](
	[ID] [bigint] NOT NULL,
	[Title] [nvarchar](1000) NULL,
	[Description] [nvarchar](2000) NULL,
	[Contents] [nvarchar](max) NULL,
	[CreateTime] [datetime] NULL,
	[EditTime] [datetime] NULL,
	[KeyWord] [nvarchar](500) NULL,
 CONSTRAINT [PK_tblNews] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblArea]    Script Date: 06/05/2012 23:22:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblArea](
	[ID] [bigint] NOT NULL,
	[ProjectID] [bigint] NULL,
	[ImageLinks] [nvarchar](1000) NULL,
	[Description] [nvarchar](1000) NULL,
 CONSTRAINT [PK_tblArea] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
