USE [master]
GO
/****** Object:  Database [TrackTasks]    Script Date: 2/24/2021 5:15:18 PM ******/
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
/****** Object:  Table [dbo].[Departments]    Script Date: 2/24/2021 5:15:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Department_Name] [nvarchar](50) NOT NULL,
	[Department_Desc] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_dbo.Departments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemDepartment]    Script Date: 2/24/2021 5:15:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemDepartment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TaskItemId] [int] NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[IsImpacted] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ItemDepartment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuarterItems]    Script Date: 2/24/2021 5:15:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuarterItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QuarterId] [int] NOT NULL,
	[TaskItemDepId] [int] NOT NULL,
	[isOriginal] [bit] NOT NULL,
	[isUpdated] [bit] NOT NULL,
	[isActive] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.QuarterItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quarters]    Script Date: 2/24/2021 5:15:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quarters](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[Quarter_Desc] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_dbo.Quarters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 2/24/2021 5:15:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status_Desc] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.Status] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StrategicItems]    Script Date: 2/24/2021 5:15:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StrategicItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StrategicPillarId] [int] NOT NULL,
	[TaskItemID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.StrategicItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StrategicPillars]    Script Date: 2/24/2021 5:15:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StrategicPillars](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Goal] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_dbo.StrategicPillars] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaskItems]    Script Date: 2/24/2021 5:15:18 PM ******/
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
	[CompletedDate] [datetime] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[BudgetImpact] [money] NULL,
 CONSTRAINT [PK_dbo.TaskItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Updates]    Script Date: 2/24/2021 5:15:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Updates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UpdateNotes] [nvarchar](max) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[TaskItemId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Updates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserDepartment]    Script Date: 2/24/2021 5:15:18 PM ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 2/24/2021 5:15:18 PM ******/
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
/****** Object:  Index [IX_QuarterId]    Script Date: 2/24/2021 5:15:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_QuarterId] ON [dbo].[QuarterItems]
(
	[QuarterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TaskItemId]    Script Date: 2/24/2021 5:15:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_TaskItemId] ON [dbo].[QuarterItems]
(
	[TaskItemDepId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_StrategicPillarId]    Script Date: 2/24/2021 5:15:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_StrategicPillarId] ON [dbo].[StrategicItems]
(
	[StrategicPillarId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TaskItemID]    Script Date: 2/24/2021 5:15:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_TaskItemID] ON [dbo].[StrategicItems]
(
	[TaskItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TaskItemId]    Script Date: 2/24/2021 5:15:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_TaskItemId] ON [dbo].[Updates]
(
	[TaskItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ItemDepartment]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ItemDepartment_dbo.Departments_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ItemDepartment] CHECK CONSTRAINT [FK_dbo.ItemDepartment_dbo.Departments_DepartmentId]
GO
ALTER TABLE [dbo].[ItemDepartment]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ItemDepartment_dbo.TaskItems_TaskItemID] FOREIGN KEY([TaskItemId])
REFERENCES [dbo].[TaskItems] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ItemDepartment] CHECK CONSTRAINT [FK_dbo.ItemDepartment_dbo.TaskItems_TaskItemID]
GO
ALTER TABLE [dbo].[ItemDepartment]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ItemDepartment_dbo.Users_UsersId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ItemDepartment] CHECK CONSTRAINT [FK_dbo.ItemDepartment_dbo.Users_UsersId]
GO
ALTER TABLE [dbo].[QuarterItems]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.QuarterItems_dbo.ItemDepartment_ItemDepartmentId] FOREIGN KEY([TaskItemDepId])
REFERENCES [dbo].[ItemDepartment] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[QuarterItems] CHECK CONSTRAINT [FK_dbo.QuarterItems_dbo.ItemDepartment_ItemDepartmentId]
GO
ALTER TABLE [dbo].[QuarterItems]  WITH CHECK ADD  CONSTRAINT [FK_dbo.QuarterItems_dbo.Quarters_QuarterId] FOREIGN KEY([QuarterId])
REFERENCES [dbo].[Quarters] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[QuarterItems] CHECK CONSTRAINT [FK_dbo.QuarterItems_dbo.Quarters_QuarterId]
GO
ALTER TABLE [dbo].[StrategicItems]  WITH CHECK ADD  CONSTRAINT [FK_dbo.StrategicItems_dbo.StrategicPillars_StrategicPillarId] FOREIGN KEY([StrategicPillarId])
REFERENCES [dbo].[StrategicPillars] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StrategicItems] CHECK CONSTRAINT [FK_dbo.StrategicItems_dbo.StrategicPillars_StrategicPillarId]
GO
ALTER TABLE [dbo].[StrategicItems]  WITH CHECK ADD  CONSTRAINT [FK_dbo.StrategicItems_dbo.TaskItems_TaskItemID] FOREIGN KEY([TaskItemID])
REFERENCES [dbo].[TaskItems] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StrategicItems] CHECK CONSTRAINT [FK_dbo.StrategicItems_dbo.TaskItems_TaskItemID]
GO
ALTER TABLE [dbo].[TaskItems]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.TaskItems_dbo.Status_StatusId] FOREIGN KEY([Status])
REFERENCES [dbo].[Status] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TaskItems] CHECK CONSTRAINT [FK_dbo.TaskItems_dbo.Status_StatusId]
GO
ALTER TABLE [dbo].[Updates]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Updates_dbo.TaskItems_TaskItemId] FOREIGN KEY([TaskItemId])
REFERENCES [dbo].[TaskItems] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Updates] CHECK CONSTRAINT [FK_dbo.Updates_dbo.TaskItems_TaskItemId]
GO
ALTER TABLE [dbo].[Updates]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Updates_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Updates] CHECK CONSTRAINT [FK_dbo.Updates_dbo.Users_UserId]
GO
ALTER TABLE [dbo].[UserDepartment]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserDepartment_dbo.Departments_DepartmentId] FOREIGN KEY([DepId])
REFERENCES [dbo].[Departments] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserDepartment] CHECK CONSTRAINT [FK_dbo.UserDepartment_dbo.Departments_DepartmentId]
GO
ALTER TABLE [dbo].[UserDepartment]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserDepartment_dbo.Users_UsersId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserDepartment] CHECK CONSTRAINT [FK_dbo.UserDepartment_dbo.Users_UsersId]
GO
USE [master]
GO
ALTER DATABASE [TrackTasks] SET  READ_WRITE 
GO
