-- rename old table, check if it can be deleted or not
-- need to check exists
EXEC sp_rename 'User', 'UserProfile'
EXEC sp_rename N'UserProfile.PK_User', N'PK_UserProfile', N'INDEX'; 


/****** Object:  Table [dbo].[User]    Script Date: 06/27/2014 16:35:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](255) NOT NULL,
	[Password] [varchar](1000) NOT NULL,
	[DisplayName] [nvarchar](50) NULL,
	[LastLoginDate] [datetime] NULL,
	[IsLockedOut] [bit] NOT NULL,
	[LastLockedOutDate] [datetime] NULL,
	[FailedPasswordAttemptCount] [int] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedUser] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedUser] [varchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_IsLockedOut]  DEFAULT ((0)) FOR [IsLockedOut]
GO

ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_FailedPasswordAttemptCount]  DEFAULT ((0)) FOR [FailedPasswordAttemptCount]
GO



CREATE TABLE [dbo].[UserRole](
	[UserRoleID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](64) NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[UserRoleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[UsersInRole](
	[UsersInRoleID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[UserRoleID] [int] NOT NULL,
 CONSTRAINT [PK_UsersInRole] PRIMARY KEY CLUSTERED 
(
	[UsersInRoleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[UsersInRole]  WITH CHECK ADD  CONSTRAINT [FK_UsersInRole_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO

ALTER TABLE [dbo].[UsersInRole] CHECK CONSTRAINT [FK_UsersInRole_User]
GO

ALTER TABLE [dbo].[UsersInRole]  WITH CHECK ADD  CONSTRAINT [FK_UsersInRole_UserRole] FOREIGN KEY([UserRoleID])
REFERENCES [dbo].[UserRole] ([UserRoleID])
GO

ALTER TABLE [dbo].[UsersInRole] CHECK CONSTRAINT [FK_UsersInRole_UserRole]
GO


---create a few sample roles ..note application name can be anything you want but make sure you use the same in the web.confing file as well


insert into [UserRole](Name)
values('SystemAdmin')

insert into [UserRole](Name)
values('BranchAdmin')

insert into [UserRole](Name)
values('User')
