USE [master]
GO
/****** Object:  Database [SLPValidation]    Script Date: 6/5/2017 12:25:53 PM ******/
CREATE DATABASE [SLPValidation]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SLPValidation', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\SLPValidation.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SLPValidation_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\SLPValidation_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SLPValidation] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SLPValidation].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SLPValidation] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SLPValidation] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SLPValidation] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SLPValidation] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SLPValidation] SET ARITHABORT OFF 
GO
ALTER DATABASE [SLPValidation] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SLPValidation] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SLPValidation] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SLPValidation] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SLPValidation] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SLPValidation] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SLPValidation] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SLPValidation] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SLPValidation] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SLPValidation] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SLPValidation] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SLPValidation] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SLPValidation] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SLPValidation] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SLPValidation] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SLPValidation] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SLPValidation] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SLPValidation] SET RECOVERY FULL 
GO
ALTER DATABASE [SLPValidation] SET  MULTI_USER 
GO
ALTER DATABASE [SLPValidation] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SLPValidation] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SLPValidation] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SLPValidation] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [SLPValidation] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SLPValidation', N'ON'
GO
USE [SLPValidation]
GO
/****** Object:  Table [dbo].[SLPRequestRecords]    Script Date: 6/5/2017 12:25:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SLPRequestRecords](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[RequestID] [varchar](50) NOT NULL,
	[RequestDate] [datetime] NOT NULL,
	[OPPID] [nvarchar](50) NOT NULL,
	[Amendment] [nvarchar](200) NULL,
	[Status] [int] NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[ValidationTime] [datetime] NULL,
	[ValidationResult] [nvarchar](200) NULL,
	[ScannedFile] [nvarchar](200) NULL,
 CONSTRAINT [PK_SLPRequestRecords] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserAccount]    Script Date: 6/5/2017 12:25:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAccount](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[RememberMe] [bit] NOT NULL CONSTRAINT [DF_UserAccount_RememberMe]  DEFAULT ((0)),
 CONSTRAINT [PK_UserAccount] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ValidationResult]    Script Date: 6/5/2017 12:25:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ValidationResult](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[RequestID] [varchar](50) NOT NULL,
	[RuleDescription] [nvarchar](500) NOT NULL,
	[Result] [int] NOT NULL,
	[DocumentName] [nvarchar](200) NULL,
	[FieldName] [nvarchar](100) NULL,
	[Expected] [nvarchar](100) NULL,
	[Actual] [nvarchar](100) NULL,
 CONSTRAINT [PK_ValidationResult] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[SLPRequestRecords] ON 

INSERT [dbo].[SLPRequestRecords] ([ID], [RequestID], [RequestDate], [OPPID], [Amendment], [Status], [Notes], [ValidationTime], [ValidationResult], [ScannedFile]) VALUES (1, N'201705150001', CAST(N'2017-05-15 00:00:00.000' AS DateTime), N'6-JLKVMUCB7', N'Y75/Y76/M197', 2, NULL, NULL, NULL, NULL)
INSERT [dbo].[SLPRequestRecords] ([ID], [RequestID], [RequestDate], [OPPID], [Amendment], [Status], [Notes], [ValidationTime], [ValidationResult], [ScannedFile]) VALUES (3, N'201705150002', CAST(N'2017-05-15 00:00:00.000' AS DateTime), N'5-JLKVMUCB5', N'Y75/Y76', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[SLPRequestRecords] ([ID], [RequestID], [RequestDate], [OPPID], [Amendment], [Status], [Notes], [ValidationTime], [ValidationResult], [ScannedFile]) VALUES (4, N'201705100001', CAST(N'2017-05-10 00:00:00.000' AS DateTime), N'5-JLKVMUCB3', N'', 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[SLPRequestRecords] ([ID], [RequestID], [RequestDate], [OPPID], [Amendment], [Status], [Notes], [ValidationTime], [ValidationResult], [ScannedFile]) VALUES (5, N'201705100002', CAST(N'2017-05-10 00:00:00.000' AS DateTime), N'5-JLKVMUCB1', N'SignForm/Y75', 2, NULL, NULL, NULL, NULL)
INSERT [dbo].[SLPRequestRecords] ([ID], [RequestID], [RequestDate], [OPPID], [Amendment], [Status], [Notes], [ValidationTime], [ValidationResult], [ScannedFile]) VALUES (7, N'201706030001', CAST(N'2017-06-03 23:33:35.163' AS DateTime), N'1111', NULL, 0, NULL, NULL, NULL, N'fd680508-d747-45f8-b5a0-36bfc43b17e4.txt')
INSERT [dbo].[SLPRequestRecords] ([ID], [RequestID], [RequestDate], [OPPID], [Amendment], [Status], [Notes], [ValidationTime], [ValidationResult], [ScannedFile]) VALUES (8, N'201706030002', CAST(N'2017-06-03 23:35:15.433' AS DateTime), N'3214', NULL, 0, NULL, NULL, NULL, N'57a79759-4097-453a-bde3-5efd20d6f093.xlsx')
INSERT [dbo].[SLPRequestRecords] ([ID], [RequestID], [RequestDate], [OPPID], [Amendment], [Status], [Notes], [ValidationTime], [ValidationResult], [ScannedFile]) VALUES (9, N'201706030003', CAST(N'2017-06-03 23:36:22.013' AS DateTime), N'sdfdff', NULL, 0, NULL, NULL, NULL, N'b6d570d2-ca2a-4245-98df-78641888bdca.txt')
INSERT [dbo].[SLPRequestRecords] ([ID], [RequestID], [RequestDate], [OPPID], [Amendment], [Status], [Notes], [ValidationTime], [ValidationResult], [ScannedFile]) VALUES (10, N'201706030004', CAST(N'2017-06-03 23:41:42.833' AS DateTime), N'1234', NULL, 0, NULL, NULL, NULL, N'b3aa65be-571f-4791-9768-c4dea478e239.txt')
SET IDENTITY_INSERT [dbo].[SLPRequestRecords] OFF
SET IDENTITY_INSERT [dbo].[UserAccount] ON 

INSERT [dbo].[UserAccount] ([ID], [Email], [Password], [RememberMe]) VALUES (2, N'keendom@163.com                                   ', N'111111', 0)
INSERT [dbo].[UserAccount] ([ID], [Email], [Password], [RememberMe]) VALUES (3, N'keendom@sina.com                                  ', N'111111', 0)
SET IDENTITY_INSERT [dbo].[UserAccount] OFF
SET IDENTITY_INSERT [dbo].[ValidationResult] ON 

INSERT [dbo].[ValidationResult] ([ID], [RequestID], [RuleDescription], [Result], [DocumentName], [FieldName], [Expected], [Actual]) VALUES (1, N'201705150001', N'Check OPPID in SignForm is consistent with MOPET', 0, N'Y74', N'OPPID', N'6-JLKVMUCB7', N'7-JLKVMUCB7')
INSERT [dbo].[ValidationResult] ([ID], [RequestID], [RuleDescription], [Result], [DocumentName], [FieldName], [Expected], [Actual]) VALUES (2, N'201705150001', N'Check OPPID in SignForm is consistent with MOPET', 0, N'Y74', N'OPPID', N'6-JLKVMUCB5', N'7-JLKVMUCB5')
SET IDENTITY_INSERT [dbo].[ValidationResult] OFF
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0 pending; 1 validation pass; 2 validation fail' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SLPRequestRecords', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0 fail; 1 pass' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ValidationResult', @level2type=N'COLUMN',@level2name=N'Result'
GO
USE [master]
GO
ALTER DATABASE [SLPValidation] SET  READ_WRITE 
GO
