
CREATE DATABASE PicnicPlatform;
GO

CREATE LOGIN PicnicUser WITH PASSWORD = 'PicnicUs3r';

Use PicnicPlatform;
GO

IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'PicnicUser')
BEGIN
    CREATE USER PicnicUser FOR LOGIN PicnicUser
    EXEC sp_addrolemember N'db_owner', N'PicnicUser'
    EXEC master..sp_addsrvrolemember @loginame = N'PicnicUser', @rolename = N'sysadmin'
END;
GO

USE [PicnicPlatform]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 20/10/2022 18:25:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PicnicCollaborations]    Script Date: 20/10/2022 18:25:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PicnicCollaborations](
	[CollaborationId] [uniqueidentifier] NOT NULL,
	[InviteId] [uniqueidentifier] NOT NULL,
	[Description] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_PicnicCollaborations] PRIMARY KEY CLUSTERED 
(
	[CollaborationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PicnicInvites]    Script Date: 20/10/2022 18:25:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PicnicInvites](
	[InviteId] [uniqueidentifier] NOT NULL,
	[PicnicId] [uniqueidentifier] NOT NULL,
	[MemberId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_PicnicInvites] PRIMARY KEY CLUSTERED 
(
	[InviteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Picnics]    Script Date: 20/10/2022 18:25:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Picnics](
	[PicnicId] [uniqueidentifier] NOT NULL,
	[MemberId] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](100) NULL,
	[LocationLat] [decimal](8, 6) NOT NULL,
	[LocationLong] [decimal](9, 6) NOT NULL,
	[PicnicType] [smallint] NOT NULL,
 CONSTRAINT [PK_Picnics] PRIMARY KEY CLUSTERED 
(
	[PicnicId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
