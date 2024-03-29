USE [master]
GO
/****** Object:  Database [TrackTasks]    Script Date: 3/1/2021 5:00:12 PM ******/
CREATE DATABASE [TrackTasks]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TrackTasks', FILENAME = N'C:\Users\Becky\TrackTasks.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TrackTasks_log', FILENAME = N'C:\Users\Becky\TrackTasks_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [TrackTasks] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TrackTasks].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TrackTasks] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TrackTasks] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TrackTasks] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TrackTasks] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TrackTasks] SET ARITHABORT OFF 
GO
ALTER DATABASE [TrackTasks] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [TrackTasks] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TrackTasks] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TrackTasks] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TrackTasks] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TrackTasks] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TrackTasks] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TrackTasks] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TrackTasks] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TrackTasks] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TrackTasks] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TrackTasks] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TrackTasks] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TrackTasks] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TrackTasks] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TrackTasks] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [TrackTasks] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TrackTasks] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TrackTasks] SET  MULTI_USER 
GO
ALTER DATABASE [TrackTasks] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TrackTasks] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TrackTasks] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TrackTasks] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TrackTasks] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TrackTasks] SET QUERY_STORE = OFF
GO
USE [TrackTasks]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [TrackTasks]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 3/1/2021 5:00:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Department_Name] [nvarchar](50) NOT NULL,
	[Code] [nvarchar](20) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Departments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemDepartment]    Script Date: 3/1/2021 5:00:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemDepartment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TaskItemId] [int] NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[IsImpacted] [bit] NOT NULL,
	[UserId] [int] NOT NULL,
	[ItemNumber] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.ItemDepartment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuarterItems]    Script Date: 3/1/2021 5:00:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuarterItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StartQuarterId] [int] NULL,
	[TaskItemId] [int] NOT NULL,
	[isOriginal] [bit] NOT NULL,
	[isUpdated] [bit] NOT NULL,
	[EndQuarterId] [int] NULL,
	[LastTimeModified] [datetime] NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_dbo.QuarterItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quarters]    Script Date: 3/1/2021 5:00:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quarters](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[Quarter_Desc] [nvarchar](20) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Quarters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 3/1/2021 5:00:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status_Desc] [nvarchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Status] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StrategicGoal]    Script Date: 3/1/2021 5:00:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StrategicGoal](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Goals] [nvarchar](500) NOT NULL,
	[StrategicPillarId] [int] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Goals] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StrategicPillars]    Script Date: 3/1/2021 5:00:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StrategicPillars](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StrategicPillar] [nvarchar](100) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.StrategicPillars] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaskItems]    Script Date: 3/1/2021 5:00:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [int] NOT NULL,
	[IsMandate] [bit] NOT NULL,
	[MandateComment] [nvarchar](25) NULL,
	[Action] [nvarchar](250) NULL,
	[IT_Project_Number] [nvarchar](20) NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CompletedDate] [datetime] NULL,
	[StartDate] [datetime] NOT NULL,
	[OperationalBudgetImplications] [money] NULL,
	[CapitolBudgetImplications] [money] NULL,
	[Outcome] [nvarchar](1000) NULL,
	[StrategicPillarId] [int] NOT NULL,
	[BudgetDesc] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.TaskItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Updates]    Script Date: 3/1/2021 5:00:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Updates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UpdateNotes] [nvarchar](max) NOT NULL,
	[TaskItemId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[LastModifiedDate] [datetime] NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_dbo.Updates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserDepartment]    Script Date: 3/1/2021 5:00:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDepartment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[DepId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.UserDepartment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/1/2021 5:00:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserIdentifier] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[UserType] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Departments] ON 

INSERT [dbo].[Departments] ([Id], [Department_Name], [Code], [Active]) VALUES (1, N'Information Technology', N'CIO', 1)
INSERT [dbo].[Departments] ([Id], [Department_Name], [Code], [Active]) VALUES (2, N'Executive Administration', N'EXEC', 1)
INSERT [dbo].[Departments] ([Id], [Department_Name], [Code], [Active]) VALUES (3, N'Business Development', N'BD', 1)
INSERT [dbo].[Departments] ([Id], [Department_Name], [Code], [Active]) VALUES (4, N'Communications', N'COM', 1)
INSERT [dbo].[Departments] ([Id], [Department_Name], [Code], [Active]) VALUES (5, N'Compliance & Internal Audit', N'CIA', 1)
INSERT [dbo].[Departments] ([Id], [Department_Name], [Code], [Active]) VALUES (6, N'Continuous Improvement', N'CI', 1)
INSERT [dbo].[Departments] ([Id], [Department_Name], [Code], [Active]) VALUES (7, N'Contract Administration', N'CA', 1)
INSERT [dbo].[Departments] ([Id], [Department_Name], [Code], [Active]) VALUES (8, N'Finance', N'FI', 1)
INSERT [dbo].[Departments] ([Id], [Department_Name], [Code], [Active]) VALUES (9, N'Government Contracts', N'GOV', 1)
INSERT [dbo].[Departments] ([Id], [Department_Name], [Code], [Active]) VALUES (10, N'Human Resources', N'HR', 1)
INSERT [dbo].[Departments] ([Id], [Department_Name], [Code], [Active]) VALUES (11, N'Iowa Medicaid', N'IAM', 1)
INSERT [dbo].[Departments] ([Id], [Department_Name], [Code], [Active]) VALUES (12, N'Legal', N'LGL', 1)
INSERT [dbo].[Departments] ([Id], [Department_Name], [Code], [Active]) VALUES (13, N'Medical Policy', N'MP', 1)
INSERT [dbo].[Departments] ([Id], [Department_Name], [Code], [Active]) VALUES (14, N'Medical Review', N'MR', 1)
INSERT [dbo].[Departments] ([Id], [Department_Name], [Code], [Active]) VALUES (15, N'North Dakota Medicaid', N'NDM', 1)
INSERT [dbo].[Departments] ([Id], [Department_Name], [Code], [Active]) VALUES (16, N'Contact Center & Education', N'CCE', 1)
INSERT [dbo].[Departments] ([Id], [Department_Name], [Code], [Active]) VALUES (17, N'Provider Audit', N'PA', 1)
INSERT [dbo].[Departments] ([Id], [Department_Name], [Code], [Active]) VALUES (18, N'Provider Enrollment', N'PE', 1)
INSERT [dbo].[Departments] ([Id], [Department_Name], [Code], [Active]) VALUES (19, N'Quality Assurance', N'QA', 1)
INSERT [dbo].[Departments] ([Id], [Department_Name], [Code], [Active]) VALUES (20, N'Recoupment', N'RCP', 1)
INSERT [dbo].[Departments] ([Id], [Department_Name], [Code], [Active]) VALUES (21, N'Supplemental Medical Review Contractor', N'SMRC', 1)
INSERT [dbo].[Departments] ([Id], [Department_Name], [Code], [Active]) VALUES (22, N'Support Services', N'SS', 1)
INSERT [dbo].[Departments] ([Id], [Department_Name], [Code], [Active]) VALUES (23, N'Talent Development', N'TD', 1)
SET IDENTITY_INSERT [dbo].[Departments] OFF
GO
SET IDENTITY_INSERT [dbo].[ItemDepartment] ON 

INSERT [dbo].[ItemDepartment] ([Id], [TaskItemId], [DepartmentId], [IsImpacted], [UserId], [ItemNumber]) VALUES (1, 26, 1, 0, 1, N'CIO-26')
INSERT [dbo].[ItemDepartment] ([Id], [TaskItemId], [DepartmentId], [IsImpacted], [UserId], [ItemNumber]) VALUES (2, 26, 4, 1, 1, N'CIO-26')
INSERT [dbo].[ItemDepartment] ([Id], [TaskItemId], [DepartmentId], [IsImpacted], [UserId], [ItemNumber]) VALUES (3, 26, 7, 1, 1, N'CIO-26')
INSERT [dbo].[ItemDepartment] ([Id], [TaskItemId], [DepartmentId], [IsImpacted], [UserId], [ItemNumber]) VALUES (4, 27, 1, 0, 2, N'CIO-27')
INSERT [dbo].[ItemDepartment] ([Id], [TaskItemId], [DepartmentId], [IsImpacted], [UserId], [ItemNumber]) VALUES (5, 27, 7, 1, 2, N'CIO-27')
INSERT [dbo].[ItemDepartment] ([Id], [TaskItemId], [DepartmentId], [IsImpacted], [UserId], [ItemNumber]) VALUES (6, 28, 1, 0, 2, N'CIO-28')
INSERT [dbo].[ItemDepartment] ([Id], [TaskItemId], [DepartmentId], [IsImpacted], [UserId], [ItemNumber]) VALUES (7, 28, 9, 1, 2, N'CIO-28')
SET IDENTITY_INSERT [dbo].[ItemDepartment] OFF
GO
SET IDENTITY_INSERT [dbo].[QuarterItems] ON 

INSERT [dbo].[QuarterItems] ([Id], [StartQuarterId], [TaskItemId], [isOriginal], [isUpdated], [EndQuarterId], [LastTimeModified], [CreatedDate]) VALUES (2, 13, 26, 1, 0, 12, NULL, CAST(N'2020-11-15T00:00:00.000' AS DateTime))
INSERT [dbo].[QuarterItems] ([Id], [StartQuarterId], [TaskItemId], [isOriginal], [isUpdated], [EndQuarterId], [LastTimeModified], [CreatedDate]) VALUES (3, 11, 26, 0, 1, NULL, NULL, CAST(N'2020-11-15T00:00:00.000' AS DateTime))
INSERT [dbo].[QuarterItems] ([Id], [StartQuarterId], [TaskItemId], [isOriginal], [isUpdated], [EndQuarterId], [LastTimeModified], [CreatedDate]) VALUES (4, 13, 27, 1, 0, 15, NULL, CAST(N'2019-11-15T00:00:00.000' AS DateTime))
INSERT [dbo].[QuarterItems] ([Id], [StartQuarterId], [TaskItemId], [isOriginal], [isUpdated], [EndQuarterId], [LastTimeModified], [CreatedDate]) VALUES (5, 13, 28, 1, 0, 16, NULL, CAST(N'2019-11-15T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[QuarterItems] OFF
GO
SET IDENTITY_INSERT [dbo].[Quarters] ON 

INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (1, CAST(N'2021-01-01T00:00:00.000' AS DateTime), CAST(N'2021-03-31T00:00:00.000' AS DateTime), N'2021:Q1', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (2, CAST(N'2021-04-01T00:00:00.000' AS DateTime), CAST(N'2021-06-30T00:00:00.000' AS DateTime), N'2021:Q2', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (3, CAST(N'2021-07-01T00:00:00.000' AS DateTime), CAST(N'2021-09-30T00:00:00.000' AS DateTime), N'2021:Q3', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (4, CAST(N'2021-10-01T00:00:00.000' AS DateTime), CAST(N'2021-12-31T00:00:00.000' AS DateTime), N'2021:Q4', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (5, CAST(N'2022-01-01T00:00:00.000' AS DateTime), CAST(N'2022-03-31T00:00:00.000' AS DateTime), N'2022:Q1', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (6, CAST(N'2022-04-01T00:00:00.000' AS DateTime), CAST(N'2022-06-30T00:00:00.000' AS DateTime), N'2022:Q2', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (7, CAST(N'2022-07-01T00:00:00.000' AS DateTime), CAST(N'2022-09-30T00:00:00.000' AS DateTime), N'2022:Q3', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (8, CAST(N'2022-10-01T00:00:00.000' AS DateTime), CAST(N'2022-12-31T00:00:00.000' AS DateTime), N'2022:Q4', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (9, CAST(N'2020-01-01T00:00:00.000' AS DateTime), CAST(N'2020-03-31T00:00:00.000' AS DateTime), N'2020:Q1', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (10, CAST(N'2020-04-01T00:00:00.000' AS DateTime), CAST(N'2020-06-30T00:00:00.000' AS DateTime), N'2020:Q2', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (11, CAST(N'2020-07-01T00:00:00.000' AS DateTime), CAST(N'2020-09-30T00:00:00.000' AS DateTime), N'2020:Q3', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (12, CAST(N'2020-10-01T00:00:00.000' AS DateTime), CAST(N'2020-12-31T00:00:00.000' AS DateTime), N'2020:Q4', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (13, CAST(N'2019-01-01T00:00:00.000' AS DateTime), CAST(N'2019-03-31T00:00:00.000' AS DateTime), N'2019:Q1', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (14, CAST(N'2019-04-01T00:00:00.000' AS DateTime), CAST(N'2019-06-30T00:00:00.000' AS DateTime), N'2019:Q2', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (15, CAST(N'2019-07-01T00:00:00.000' AS DateTime), CAST(N'2019-09-30T00:00:00.000' AS DateTime), N'2019:Q3', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (16, CAST(N'2019-10-01T00:00:00.000' AS DateTime), CAST(N'2019-12-31T00:00:00.000' AS DateTime), N'2019:Q4', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (17, CAST(N'2023-01-01T00:00:00.000' AS DateTime), CAST(N'2023-03-31T00:00:00.000' AS DateTime), N'2023:Q1', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (18, CAST(N'2023-04-01T00:00:00.000' AS DateTime), CAST(N'2023-06-30T00:00:00.000' AS DateTime), N'2023:Q2', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (19, CAST(N'2023-07-01T00:00:00.000' AS DateTime), CAST(N'2023-09-30T00:00:00.000' AS DateTime), N'2023:Q3', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (20, CAST(N'2023-10-01T00:00:00.000' AS DateTime), CAST(N'2023-12-31T00:00:00.000' AS DateTime), N'2023:Q4', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (21, CAST(N'2024-01-01T00:00:00.000' AS DateTime), CAST(N'2024-03-31T00:00:00.000' AS DateTime), N'2024:Q1', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (22, CAST(N'2024-04-01T00:00:00.000' AS DateTime), CAST(N'2024-06-30T00:00:00.000' AS DateTime), N'2024:Q2', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (23, CAST(N'2024-07-01T00:00:00.000' AS DateTime), CAST(N'2024-09-30T00:00:00.000' AS DateTime), N'2024:Q3', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (24, CAST(N'2024-10-01T00:00:00.000' AS DateTime), CAST(N'2024-12-31T00:00:00.000' AS DateTime), N'2024:Q4', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (25, CAST(N'2025-01-01T00:00:00.000' AS DateTime), CAST(N'2025-03-31T00:00:00.000' AS DateTime), N'2025:Q1', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (26, CAST(N'2025-04-01T00:00:00.000' AS DateTime), CAST(N'2025-06-30T00:00:00.000' AS DateTime), N'2025:Q2', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (27, CAST(N'2025-07-01T00:00:00.000' AS DateTime), CAST(N'2025-09-30T00:00:00.000' AS DateTime), N'2025:Q3', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (28, CAST(N'2025-10-01T00:00:00.000' AS DateTime), CAST(N'2025-12-31T00:00:00.000' AS DateTime), N'2025:Q4', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (29, CAST(N'2026-01-01T00:00:00.000' AS DateTime), CAST(N'2026-03-31T00:00:00.000' AS DateTime), N'2026:Q1', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (30, CAST(N'2026-04-01T00:00:00.000' AS DateTime), CAST(N'2026-06-30T00:00:00.000' AS DateTime), N'2026:Q2', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (31, CAST(N'2026-07-01T00:00:00.000' AS DateTime), CAST(N'2026-09-30T00:00:00.000' AS DateTime), N'2026:Q3', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (32, CAST(N'2026-10-01T00:00:00.000' AS DateTime), CAST(N'2026-12-31T00:00:00.000' AS DateTime), N'2026:Q4', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (33, CAST(N'2027-01-01T00:00:00.000' AS DateTime), CAST(N'2027-03-31T00:00:00.000' AS DateTime), N'2027:Q1', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (34, CAST(N'2027-04-01T00:00:00.000' AS DateTime), CAST(N'2027-06-30T00:00:00.000' AS DateTime), N'2027:Q2', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (35, CAST(N'2027-07-01T00:00:00.000' AS DateTime), CAST(N'2027-09-30T00:00:00.000' AS DateTime), N'2027:Q3', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (36, CAST(N'2027-10-01T00:00:00.000' AS DateTime), CAST(N'2027-12-31T00:00:00.000' AS DateTime), N'2027:Q4', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (37, CAST(N'2028-01-01T00:00:00.000' AS DateTime), CAST(N'2028-03-31T00:00:00.000' AS DateTime), N'2028:Q1', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (38, CAST(N'2028-04-01T00:00:00.000' AS DateTime), CAST(N'2028-06-30T00:00:00.000' AS DateTime), N'2028:Q2', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (39, CAST(N'2028-07-01T00:00:00.000' AS DateTime), CAST(N'2028-09-30T00:00:00.000' AS DateTime), N'2028:Q3', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (40, CAST(N'2028-10-01T00:00:00.000' AS DateTime), CAST(N'2028-12-31T00:00:00.000' AS DateTime), N'2028:Q4', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (41, CAST(N'2029-01-01T00:00:00.000' AS DateTime), CAST(N'2029-03-31T00:00:00.000' AS DateTime), N'2029:Q1', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (42, CAST(N'2029-04-01T00:00:00.000' AS DateTime), CAST(N'2029-06-30T00:00:00.000' AS DateTime), N'2029:Q2', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (43, CAST(N'2029-07-01T00:00:00.000' AS DateTime), CAST(N'2029-09-30T00:00:00.000' AS DateTime), N'2029:Q3', 1)
INSERT [dbo].[Quarters] ([Id], [StartDate], [EndDate], [Quarter_Desc], [Active]) VALUES (44, CAST(N'2029-10-01T00:00:00.000' AS DateTime), CAST(N'2029-12-31T00:00:00.000' AS DateTime), N'2029:Q4', 1)
SET IDENTITY_INSERT [dbo].[Quarters] OFF
GO
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([Id], [Status_Desc], [Active]) VALUES (1, N'Not Started', 1)
INSERT [dbo].[Status] ([Id], [Status_Desc], [Active]) VALUES (2, N'In Process – On Track', 1)
INSERT [dbo].[Status] ([Id], [Status_Desc], [Active]) VALUES (3, N'In Process – Delayed Finish', 1)
INSERT [dbo].[Status] ([Id], [Status_Desc], [Active]) VALUES (4, N'Pushed Start Out', 1)
INSERT [dbo].[Status] ([Id], [Status_Desc], [Active]) VALUES (5, N'Cancelled', 1)
INSERT [dbo].[Status] ([Id], [Status_Desc], [Active]) VALUES (6, N'Completed', 1)
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
SET IDENTITY_INSERT [dbo].[StrategicGoal] ON 

INSERT [dbo].[StrategicGoal] ([Id], [Goals], [StrategicPillarId], [Active]) VALUES (1, N'Collaborate with key customers', 1, 1)
INSERT [dbo].[StrategicGoal] ([Id], [Goals], [StrategicPillarId], [Active]) VALUES (2, N'Achieve award fee 80%', 1, 1)
INSERT [dbo].[StrategicGoal] ([Id], [Goals], [StrategicPillarId], [Active]) VALUES (3, N'Achieve QASP scores 90%', 1, 1)
INSERT [dbo].[StrategicGoal] ([Id], [Goals], [StrategicPillarId], [Active]) VALUES (4, N'Refine and Modernize metrics', 1, 1)
INSERT [dbo].[StrategicGoal] ([Id], [Goals], [StrategicPillarId], [Active]) VALUES (5, N'Increase operational efficiencies A/B CPC', 1, 1)
INSERT [dbo].[StrategicGoal] ([Id], [Goals], [StrategicPillarId], [Active]) VALUES (6, N'Leverage automation A/B/DME', 1, 1)
INSERT [dbo].[StrategicGoal] ([Id], [Goals], [StrategicPillarId], [Active]) VALUES (7, N'Achieve 90% Medicaid Performance Metrics', 1, 1)
INSERT [dbo].[StrategicGoal] ([Id], [Goals], [StrategicPillarId], [Active]) VALUES (8, N'Achieve 75% Fixed Fee SMRC', 1, 1)
INSERT [dbo].[StrategicGoal] ([Id], [Goals], [StrategicPillarId], [Active]) VALUES (9, N'Maintain ROIC ratio', 2, 1)
INSERT [dbo].[StrategicGoal] ([Id], [Goals], [StrategicPillarId], [Active]) VALUES (10, N'Offer to pay parent dividend', 2, 1)
INSERT [dbo].[StrategicGoal] ([Id], [Goals], [StrategicPillarId], [Active]) VALUES (11, N'Maintain Days Cash on Hand', 2, 1)
INSERT [dbo].[StrategicGoal] ([Id], [Goals], [StrategicPillarId], [Active]) VALUES (12, N'Improve EBIT to 6%', 2, 1)
INSERT [dbo].[StrategicGoal] ([Id], [Goals], [StrategicPillarId], [Active]) VALUES (13, N'Process to track same store growth', 3, 1)
INSERT [dbo].[StrategicGoal] ([Id], [Goals], [StrategicPillarId], [Active]) VALUES (14, N'Win JE Procurement', 3, 1)
INSERT [dbo].[StrategicGoal] ([Id], [Goals], [StrategicPillarId], [Active]) VALUES (15, N'Win 3 Medicaid Contracts', 3, 1)
INSERT [dbo].[StrategicGoal] ([Id], [Goals], [StrategicPillarId], [Active]) VALUES (16, N'Conduct Assessment back office services', 3, 1)
INSERT [dbo].[StrategicGoal] ([Id], [Goals], [StrategicPillarId], [Active]) VALUES (17, N'Be selected PEO IDIQ', 3, 1)
INSERT [dbo].[StrategicGoal] ([Id], [Goals], [StrategicPillarId], [Active]) VALUES (18, N'Establish GSA offering', 3, 1)
INSERT [dbo].[StrategicGoal] ([Id], [Goals], [StrategicPillarId], [Active]) VALUES (19, N'Win VA Contract', 3, 1)
INSERT [dbo].[StrategicGoal] ([Id], [Goals], [StrategicPillarId], [Active]) VALUES (20, N'Win RRB', 3, 1)
INSERT [dbo].[StrategicGoal] ([Id], [Goals], [StrategicPillarId], [Active]) VALUES (21, N'Continue to grow business with partners', 3, 1)
INSERT [dbo].[StrategicGoal] ([Id], [Goals], [StrategicPillarId], [Active]) VALUES (22, N'Complete IT Infrastructure Implementation', 4, 1)
INSERT [dbo].[StrategicGoal] ([Id], [Goals], [StrategicPillarId], [Active]) VALUES (23, N'Reduce other IT licenses and expenses', 4, 1)
INSERT [dbo].[StrategicGoal] ([Id], [Goals], [StrategicPillarId], [Active]) VALUES (24, N'Reduce Application expenses', 4, 1)
INSERT [dbo].[StrategicGoal] ([Id], [Goals], [StrategicPillarId], [Active]) VALUES (25, N'Achieve 912 top 3 rating', 4, 1)
INSERT [dbo].[StrategicGoal] ([Id], [Goals], [StrategicPillarId], [Active]) VALUES (26, N'Increase systems availability', 4, 1)
INSERT [dbo].[StrategicGoal] ([Id], [Goals], [StrategicPillarId], [Active]) VALUES (27, N'Prepare for multiple security requirements LOBs', 4, 1)
INSERT [dbo].[StrategicGoal] ([Id], [Goals], [StrategicPillarId], [Active]) VALUES (28, N'Conduct Data Warehouse proof of concept', 4, 1)
INSERT [dbo].[StrategicGoal] ([Id], [Goals], [StrategicPillarId], [Active]) VALUES (29, N'Achieve 95% SLA IT vendors', 4, 1)
INSERT [dbo].[StrategicGoal] ([Id], [Goals], [StrategicPillarId], [Active]) VALUES (30, N'Implement Ops Planning and align to strategy', 5, 1)
INSERT [dbo].[StrategicGoal] ([Id], [Goals], [StrategicPillarId], [Active]) VALUES (31, N'Develop leadership eval system', 5, 1)
INSERT [dbo].[StrategicGoal] ([Id], [Goals], [StrategicPillarId], [Active]) VALUES (32, N'Continuously re-evaluate org structure alignment', 5, 1)
INSERT [dbo].[StrategicGoal] ([Id], [Goals], [StrategicPillarId], [Active]) VALUES (33, N'Design/Implement Learning and Development Program', 5, 1)
INSERT [dbo].[StrategicGoal] ([Id], [Goals], [StrategicPillarId], [Active]) VALUES (34, N'Implement Talent Management Program with Career Development', 5, 1)
INSERT [dbo].[StrategicGoal] ([Id], [Goals], [StrategicPillarId], [Active]) VALUES (35, N'Maintain Employee Engagement', 5, 1)
INSERT [dbo].[StrategicGoal] ([Id], [Goals], [StrategicPillarId], [Active]) VALUES (36, N'Maintain Voluntary Turnover rate 15% or less', 5, 1)
INSERT [dbo].[StrategicGoal] ([Id], [Goals], [StrategicPillarId], [Active]) VALUES (37, N'Develop Innovation Center proof of concept', 5, 1)
SET IDENTITY_INSERT [dbo].[StrategicGoal] OFF
GO
SET IDENTITY_INSERT [dbo].[StrategicPillars] ON 

INSERT [dbo].[StrategicPillars] ([Id], [StrategicPillar], [Active]) VALUES (1, N'Operational Excellence', 1)
INSERT [dbo].[StrategicPillars] ([Id], [StrategicPillar], [Active]) VALUES (2, N'Financial Performance', 1)
INSERT [dbo].[StrategicPillars] ([Id], [StrategicPillar], [Active]) VALUES (3, N'Organizational Growth', 1)
INSERT [dbo].[StrategicPillars] ([Id], [StrategicPillar], [Active]) VALUES (4, N'Information Technology', 1)
INSERT [dbo].[StrategicPillars] ([Id], [StrategicPillar], [Active]) VALUES (5, N'Organizational Culture', 1)
SET IDENTITY_INSERT [dbo].[StrategicPillars] OFF
GO
SET IDENTITY_INSERT [dbo].[TaskItems] ON 

INSERT [dbo].[TaskItems] ([Id], [Status], [IsMandate], [MandateComment], [Action], [IT_Project_Number], [LastModifiedDate], [CreatedDate], [CompletedDate], [StartDate], [OperationalBudgetImplications], [CapitolBudgetImplications], [Outcome], [StrategicPillarId], [BudgetDesc]) VALUES (26, 1, 0, NULL, N'Research and implement an operational data warehouse', N'N/A', CAST(N'2019-01-01T00:00:00.000' AS DateTime), CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, CAST(N'2019-02-01T00:00:00.000' AS DateTime), 0.0000, 500000.0000, N'to improve quality of reporting and to reduce staff labor used to create standard reports [BUDGET DEPENDENT]', 4, NULL)
INSERT [dbo].[TaskItems] ([Id], [Status], [IsMandate], [MandateComment], [Action], [IT_Project_Number], [LastModifiedDate], [CreatedDate], [CompletedDate], [StartDate], [OperationalBudgetImplications], [CapitolBudgetImplications], [Outcome], [StrategicPillarId], [BudgetDesc]) VALUES (27, 1, 0, NULL, N'Implement standard services for application access', N'PS13876', CAST(N'2019-01-01T08:30:00.000' AS DateTime), CAST(N'2019-01-01T08:30:00.000' AS DateTime), NULL, CAST(N'2019-02-01T00:00:00.000' AS DateTime), 100000.0000, NULL, N'to implement IVR and portal as well as starting foundation for Standard System Modernization', 4, N'IT Labor')
INSERT [dbo].[TaskItems] ([Id], [Status], [IsMandate], [MandateComment], [Action], [IT_Project_Number], [LastModifiedDate], [CreatedDate], [CompletedDate], [StartDate], [OperationalBudgetImplications], [CapitolBudgetImplications], [Outcome], [StrategicPillarId], [BudgetDesc]) VALUES (28, 1, 0, NULL, N'Establish a non-MAC security environment', N'Not Submitted', CAST(N'2019-01-01T11:30:00.000' AS DateTime), CAST(N'2019-01-01T11:30:00.000' AS DateTime), NULL, CAST(N'2019-02-01T10:30:00.000' AS DateTime), 0.0000, 1000000.0000, N'to support future business growth [BUDGET DEPENDENT]', 4, NULL)
SET IDENTITY_INSERT [dbo].[TaskItems] OFF
GO
SET IDENTITY_INSERT [dbo].[Updates] ON 

INSERT [dbo].[Updates] ([Id], [UpdateNotes], [TaskItemId], [UserId], [LastModifiedDate], [CreatedDate]) VALUES (1, N'2019 Q4: Included funds in the budget for proof of concept in 2020. Will kick off in earnest in 2020 (late Q1) to determine which area. Possibly DME Call Center in advance of rebid efforts.', 26, 1, CAST(N'2019-11-15T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Updates] ([Id], [UpdateNotes], [TaskItemId], [UserId], [LastModifiedDate], [CreatedDate]) VALUES (2, N'2020 Q1: Meetings being held in April to strategize and identify first area to move forward with.', 26, 2, CAST(N'2020-01-15T00:00:00.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Updates] OFF
GO
SET IDENTITY_INSERT [dbo].[UserDepartment] ON 

INSERT [dbo].[UserDepartment] ([Id], [UserId], [DepId]) VALUES (1, 1, 1)
SET IDENTITY_INSERT [dbo].[UserDepartment] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [UserIdentifier], [FirstName], [LastName], [UserType]) VALUES (1, N'rebecca.chepkirwok@ndsu.edu', N'Rebecca', N'Jero', 0)
INSERT [dbo].[Users] ([Id], [UserIdentifier], [FirstName], [LastName], [UserType]) VALUES (2, N'gladys.rotich@ndsu.edu', N'Gladys', N'Rotich', 0)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [IX_QuarterId]    Script Date: 3/1/2021 5:00:12 PM ******/
CREATE NONCLUSTERED INDEX [IX_QuarterId] ON [dbo].[QuarterItems]
(
	[StartQuarterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TaskItemId]    Script Date: 3/1/2021 5:00:12 PM ******/
CREATE NONCLUSTERED INDEX [IX_TaskItemId] ON [dbo].[QuarterItems]
(
	[TaskItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TaskItemId]    Script Date: 3/1/2021 5:00:12 PM ******/
CREATE NONCLUSTERED INDEX [IX_TaskItemId] ON [dbo].[Updates]
(
	[TaskItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ItemDepartment]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ItemDepartment_dbo.Departments_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([Id])
GO
ALTER TABLE [dbo].[ItemDepartment] CHECK CONSTRAINT [FK_dbo.ItemDepartment_dbo.Departments_DepartmentId]
GO
ALTER TABLE [dbo].[ItemDepartment]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ItemDepartment_dbo.TaskItems_TaskItemID] FOREIGN KEY([TaskItemId])
REFERENCES [dbo].[TaskItems] ([Id])
GO
ALTER TABLE [dbo].[ItemDepartment] CHECK CONSTRAINT [FK_dbo.ItemDepartment_dbo.TaskItems_TaskItemID]
GO
ALTER TABLE [dbo].[ItemDepartment]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ItemDepartment_dbo.Users_UsersId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[ItemDepartment] CHECK CONSTRAINT [FK_dbo.ItemDepartment_dbo.Users_UsersId]
GO
ALTER TABLE [dbo].[QuarterItems]  WITH CHECK ADD  CONSTRAINT [FK_dbo.QuarterItems_dbo.Quarters_EndQuarterId] FOREIGN KEY([EndQuarterId])
REFERENCES [dbo].[Quarters] ([Id])
GO
ALTER TABLE [dbo].[QuarterItems] CHECK CONSTRAINT [FK_dbo.QuarterItems_dbo.Quarters_EndQuarterId]
GO
ALTER TABLE [dbo].[QuarterItems]  WITH CHECK ADD  CONSTRAINT [FK_dbo.QuarterItems_dbo.Quarters_StartQuarterId] FOREIGN KEY([StartQuarterId])
REFERENCES [dbo].[Quarters] ([Id])
GO
ALTER TABLE [dbo].[QuarterItems] CHECK CONSTRAINT [FK_dbo.QuarterItems_dbo.Quarters_StartQuarterId]
GO
ALTER TABLE [dbo].[QuarterItems]  WITH CHECK ADD  CONSTRAINT [FK_dbo.QuarterItems_dbo.TaskItems_TaskItemsId] FOREIGN KEY([TaskItemId])
REFERENCES [dbo].[TaskItems] ([Id])
GO
ALTER TABLE [dbo].[QuarterItems] CHECK CONSTRAINT [FK_dbo.QuarterItems_dbo.TaskItems_TaskItemsId]
GO
ALTER TABLE [dbo].[StrategicGoal]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Goals_dbo.StrategicPillars_StrategicPillarId] FOREIGN KEY([StrategicPillarId])
REFERENCES [dbo].[StrategicPillars] ([Id])
GO
ALTER TABLE [dbo].[StrategicGoal] CHECK CONSTRAINT [FK_dbo.Goals_dbo.StrategicPillars_StrategicPillarId]
GO
ALTER TABLE [dbo].[TaskItems]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TaskItems_dbo.Status_StatusId] FOREIGN KEY([Status])
REFERENCES [dbo].[Status] ([Id])
GO
ALTER TABLE [dbo].[TaskItems] CHECK CONSTRAINT [FK_dbo.TaskItems_dbo.Status_StatusId]
GO
ALTER TABLE [dbo].[TaskItems]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TaskItems_dbo.StrategicPillars_StrategicPillarId] FOREIGN KEY([StrategicPillarId])
REFERENCES [dbo].[StrategicPillars] ([Id])
GO
ALTER TABLE [dbo].[TaskItems] CHECK CONSTRAINT [FK_dbo.TaskItems_dbo.StrategicPillars_StrategicPillarId]
GO
ALTER TABLE [dbo].[Updates]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Updates_dbo.TaskItems_TaskItemId] FOREIGN KEY([TaskItemId])
REFERENCES [dbo].[TaskItems] ([Id])
GO
ALTER TABLE [dbo].[Updates] CHECK CONSTRAINT [FK_dbo.Updates_dbo.TaskItems_TaskItemId]
GO
ALTER TABLE [dbo].[Updates]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Updates_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Updates] CHECK CONSTRAINT [FK_dbo.Updates_dbo.Users_UserId]
GO
ALTER TABLE [dbo].[UserDepartment]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserDepartment_dbo.Departments_DepartmentId] FOREIGN KEY([DepId])
REFERENCES [dbo].[Departments] ([Id])
GO
ALTER TABLE [dbo].[UserDepartment] CHECK CONSTRAINT [FK_dbo.UserDepartment_dbo.Departments_DepartmentId]
GO
ALTER TABLE [dbo].[UserDepartment]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserDepartment_dbo.Users_UsersId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserDepartment] CHECK CONSTRAINT [FK_dbo.UserDepartment_dbo.Users_UsersId]
GO
USE [master]
GO
ALTER DATABASE [TrackTasks] SET  READ_WRITE 
GO
