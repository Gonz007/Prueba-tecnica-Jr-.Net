USE [master]
GO
/****** Object:  Database [HotelsBd]    Script Date: 14/11/2023 12:57:27 p. m. ******/
CREATE DATABASE [HotelsBd]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HotelsBd', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\HotelsBd.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HotelsBd_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\HotelsBd_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [HotelsBd] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HotelsBd].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HotelsBd] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HotelsBd] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HotelsBd] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HotelsBd] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HotelsBd] SET ARITHABORT OFF 
GO
ALTER DATABASE [HotelsBd] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [HotelsBd] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HotelsBd] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HotelsBd] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HotelsBd] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HotelsBd] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HotelsBd] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HotelsBd] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HotelsBd] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HotelsBd] SET  ENABLE_BROKER 
GO
ALTER DATABASE [HotelsBd] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HotelsBd] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HotelsBd] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HotelsBd] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HotelsBd] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HotelsBd] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [HotelsBd] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HotelsBd] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HotelsBd] SET  MULTI_USER 
GO
ALTER DATABASE [HotelsBd] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HotelsBd] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HotelsBd] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HotelsBd] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HotelsBd] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HotelsBd] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [HotelsBd] SET QUERY_STORE = ON
GO
ALTER DATABASE [HotelsBd] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [HotelsBd]
GO
/****** Object:  User [Juan]    Script Date: 14/11/2023 12:57:27 p. m. ******/
CREATE USER [Juan] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 14/11/2023 12:57:27 p. m. ******/
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
/****** Object:  Table [dbo].[Hotels]    Script Date: 14/11/2023 12:57:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Stars] [int] NOT NULL,
 CONSTRAINT [PK_Hotels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231114083627_Nombre', N'7.0.13')
GO
SET IDENTITY_INSERT [dbo].[Hotels] ON 

INSERT [dbo].[Hotels] ([Id], [Name], [Stars]) VALUES (4, N'Hotel A', 4)
INSERT [dbo].[Hotels] ([Id], [Name], [Stars]) VALUES (5, N'Hotel B', 5)
INSERT [dbo].[Hotels] ([Id], [Name], [Stars]) VALUES (6, N'Hotel C', 3)
INSERT [dbo].[Hotels] ([Id], [Name], [Stars]) VALUES (7, N'Hotel D', 4)
INSERT [dbo].[Hotels] ([Id], [Name], [Stars]) VALUES (8, N'Hotel E', 5)
INSERT [dbo].[Hotels] ([Id], [Name], [Stars]) VALUES (9, N'Hotel F', 3)
INSERT [dbo].[Hotels] ([Id], [Name], [Stars]) VALUES (10, N'Hotel G', 4)
INSERT [dbo].[Hotels] ([Id], [Name], [Stars]) VALUES (11, N'Hotel H', 5)
INSERT [dbo].[Hotels] ([Id], [Name], [Stars]) VALUES (12, N'Hotel I', 3)
INSERT [dbo].[Hotels] ([Id], [Name], [Stars]) VALUES (13, N'Hotel J', 4)
INSERT [dbo].[Hotels] ([Id], [Name], [Stars]) VALUES (14, N'Hotel K', 5)
INSERT [dbo].[Hotels] ([Id], [Name], [Stars]) VALUES (15, N'Hotel L', 3)
INSERT [dbo].[Hotels] ([Id], [Name], [Stars]) VALUES (16, N'Hotel M', 4)
INSERT [dbo].[Hotels] ([Id], [Name], [Stars]) VALUES (17, N'Hotel N', 5)
INSERT [dbo].[Hotels] ([Id], [Name], [Stars]) VALUES (18, N'Hotel O', 3)
INSERT [dbo].[Hotels] ([Id], [Name], [Stars]) VALUES (19, N'Hotel P', 4)
INSERT [dbo].[Hotels] ([Id], [Name], [Stars]) VALUES (20, N'Hotel Q', 5)
INSERT [dbo].[Hotels] ([Id], [Name], [Stars]) VALUES (21, N'Hotel R', 3)
INSERT [dbo].[Hotels] ([Id], [Name], [Stars]) VALUES (22, N'Hotel S', 4)
INSERT [dbo].[Hotels] ([Id], [Name], [Stars]) VALUES (23, N'Hotel T', 5)
INSERT [dbo].[Hotels] ([Id], [Name], [Stars]) VALUES (24, N'Hotel U', 3)
INSERT [dbo].[Hotels] ([Id], [Name], [Stars]) VALUES (25, N'Hotel V', 4)
INSERT [dbo].[Hotels] ([Id], [Name], [Stars]) VALUES (26, N'Hotel W', 5)
INSERT [dbo].[Hotels] ([Id], [Name], [Stars]) VALUES (27, N'Hotel X', 3)
INSERT [dbo].[Hotels] ([Id], [Name], [Stars]) VALUES (28, N'Hotel Y', 4)
INSERT [dbo].[Hotels] ([Id], [Name], [Stars]) VALUES (29, N'Hotel Z', 5)
INSERT [dbo].[Hotels] ([Id], [Name], [Stars]) VALUES (30, N'Hotel AA', 3)
INSERT [dbo].[Hotels] ([Id], [Name], [Stars]) VALUES (31, N'Hotel BB', 4)
INSERT [dbo].[Hotels] ([Id], [Name], [Stars]) VALUES (32, N'Hotel CC', 5)
INSERT [dbo].[Hotels] ([Id], [Name], [Stars]) VALUES (33, N'Hotel DD', 3)
INSERT [dbo].[Hotels] ([Id], [Name], [Stars]) VALUES (34, N'Hotel EE', 4)
INSERT [dbo].[Hotels] ([Id], [Name], [Stars]) VALUES (35, N'Hotel FF', 5)
INSERT [dbo].[Hotels] ([Id], [Name], [Stars]) VALUES (36, N'Hotel GG', 3)
INSERT [dbo].[Hotels] ([Id], [Name], [Stars]) VALUES (37, N'Hotel HH', 4)
INSERT [dbo].[Hotels] ([Id], [Name], [Stars]) VALUES (38, N'Hotel II', 5)
INSERT [dbo].[Hotels] ([Id], [Name], [Stars]) VALUES (39, N'Hotel JJ', 3)
INSERT [dbo].[Hotels] ([Id], [Name], [Stars]) VALUES (40, N'Hotel KK', 4)
INSERT [dbo].[Hotels] ([Id], [Name], [Stars]) VALUES (41, N'Hotel LL', 5)
SET IDENTITY_INSERT [dbo].[Hotels] OFF
GO
USE [master]
GO
ALTER DATABASE [HotelsBd] SET  READ_WRITE 
GO
