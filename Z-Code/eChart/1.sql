USE [eChart]
GO

/****** Object:  Table [dbo].[Server_Contents_Answers]    Script Date: 09/16/2011 17:56:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Server_Contents_Answers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MessageID] [int] NOT NULL,
	[Answer] [nvarchar](4000) NULL,
	[isDeleted] [bit] NULL
) ON [PRIMARY]

GO


USE [eChart]
GO

/****** Object:  Table [dbo].[Server_Contents_Folders]    Script Date: 09/16/2011 17:56:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Server_Contents_Folders](
	[FolderID] [int] IDENTITY(1,1) NOT NULL,
	[Foldername] [nvarchar](50) NULL,
	[ParentID] [int] NULL,
	[isDeleted] [bit] NULL,
	[isOffline] [bit] NULL
) ON [PRIMARY]

GO


USE [eChart]
GO

/****** Object:  Table [dbo].[Server_Contents_Message]    Script Date: 09/16/2011 17:57:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Server_Contents_Message](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FolderID] [int] NULL,
	[isOffLine] [bit] NULL,
	[isPublic] [bit] NULL,
	[isVariations] [bit] NULL,
	[sortOrder] [int] NULL,
	[Question] [nvarchar](1000) NULL,
	[RelatedID] [int] NULL,
	[isDeleted] [bit] NULL
) ON [PRIMARY]

GO

USE [eChart]
GO

/****** Object:  Table [dbo].[Server_Contents_Theases]    Script Date: 09/16/2011 17:57:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Server_Contents_Theases](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FolderID] [int] NULL,
	[isOffLine] [bit] NULL,
	[sortOrder] [int] NULL,
	[Thease] [nvarchar](500) NULL,
	[isDeleted] [bit] NULL
) ON [PRIMARY]

GO


USE [eChart]
GO

/****** Object:  Table [dbo].[Accounts_Users]    Script Date: 09/16/2011 17:57:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Accounts_Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FundID] [int] NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Age] [int] NULL,
	[City] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Gender] [int] NULL,
	[UserStatus] [int] NULL
) ON [PRIMARY]

GO



