USE [master]
GO
/****** Object:  Database [ShagunGraminHealth]    Script Date: 19-07-2024 12:06:00 ******/
CREATE DATABASE [ShagunGraminHealth]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ShagunGraminHealth', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ShagunGraminHealth.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ShagunGraminHealth_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ShagunGraminHealth_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ShagunGraminHealth] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ShagunGraminHealth].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ShagunGraminHealth] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ShagunGraminHealth] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ShagunGraminHealth] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ShagunGraminHealth] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ShagunGraminHealth] SET ARITHABORT OFF 
GO
ALTER DATABASE [ShagunGraminHealth] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ShagunGraminHealth] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ShagunGraminHealth] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ShagunGraminHealth] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ShagunGraminHealth] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ShagunGraminHealth] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ShagunGraminHealth] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ShagunGraminHealth] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ShagunGraminHealth] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ShagunGraminHealth] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ShagunGraminHealth] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ShagunGraminHealth] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ShagunGraminHealth] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ShagunGraminHealth] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ShagunGraminHealth] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ShagunGraminHealth] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ShagunGraminHealth] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ShagunGraminHealth] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ShagunGraminHealth] SET  MULTI_USER 
GO
ALTER DATABASE [ShagunGraminHealth] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ShagunGraminHealth] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ShagunGraminHealth] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ShagunGraminHealth] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ShagunGraminHealth] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ShagunGraminHealth] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ShagunGraminHealth] SET QUERY_STORE = ON
GO
ALTER DATABASE [ShagunGraminHealth] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ShagunGraminHealth]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 19-07-2024 12:06:01 ******/
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
/****** Object:  Table [dbo].[MembershipForm]    Script Date: 19-07-2024 12:06:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MembershipForm](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Application_Id] [nvarchar](255) NOT NULL,
	[PlanNumber] [nvarchar](255) NOT NULL,
	[Reference] [nvarchar](255) NOT NULL,
	[Candidate_Name] [nvarchar](255) NOT NULL,
	[Father_Name] [nvarchar](255) NOT NULL,
	[Parmanent_Address] [text] NOT NULL,
	[Current_Address] [text] NOT NULL,
	[Mobile] [nvarchar](15) NOT NULL,
	[Date_of_Birth_Days] [int] NOT NULL,
	[Date_of_Birth_Months] [int] NOT NULL,
	[Date_of_Birth_Years] [int] NOT NULL,
	[Sex] [nvarchar](10) NOT NULL,
	[Educational_Level] [nvarchar](255) NOT NULL,
	[Marriage] [nvarchar](255) NOT NULL,
	[Category] [nvarchar](10) NOT NULL,
	[Ration_Card] [nvarchar](255) NULL,
	[Aadhar_Card] [nvarchar](255) NOT NULL,
	[Bank_Account] [nvarchar](255) NOT NULL,
	[IFSC] [nvarchar](20) NOT NULL,
	[Bank_Name] [nvarchar](255) NOT NULL,
	[age_proof] [nvarchar](50) NOT NULL,
	[age_photo] [nvarchar](255) NOT NULL,
	[old_member_name] [nvarchar](255) NULL,
	[old_application_no] [nvarchar](255) NULL,
	[Photo] [nvarchar](255) NOT NULL,
	[Signature] [nvarchar](255) NOT NULL,
	[Place] [nvarchar](255) NOT NULL,
	[Form_Date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_MembershipForm] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MembershipPlan]    Script Date: 19-07-2024 12:06:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MembershipPlan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PlanNumber] [nvarchar](50) NOT NULL,
	[PlanName] [nvarchar](100) NOT NULL,
	[PlanFee] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_MembershipPlan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 19-07-2024 12:06:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](255) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 19-07-2024 12:06:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Mobile] [varchar](255) NULL,
	[Password] [nvarchar](100) NULL,
	[ReferenceId] [int] NULL,
	[Passcode] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[Email] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 19-07-2024 12:06:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[Id] [int] NOT NULL,
	[UserId] [int] NULL,
	[RoleId] [int] NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserRole_RoleId]    Script Date: 19-07-2024 12:06:01 ******/
CREATE NONCLUSTERED INDEX [IX_UserRole_RoleId] ON [dbo].[UserRole]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserRole_UserId]    Script Date: 19-07-2024 12:06:01 ******/
CREATE NONCLUSTERED INDEX [IX_UserRole_UserId] ON [dbo].[UserRole]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_Role]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_User]
GO
USE [master]
GO
ALTER DATABASE [ShagunGraminHealth] SET  READ_WRITE 
GO
