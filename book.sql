USE [master]
GO
/****** Object:  Database [BookDb]    Script Date: 5/10/2023 7:36:43 AM ******/
CREATE DATABASE [BookDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BookDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BookDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BookDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BookDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BookDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BookDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BookDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BookDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BookDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [BookDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BookDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BookDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BookDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BookDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BookDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BookDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BookDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BookDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BookDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BookDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BookDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BookDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BookDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BookDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BookDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BookDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BookDb] SET RECOVERY FULL 
GO
ALTER DATABASE [BookDb] SET  MULTI_USER 
GO
ALTER DATABASE [BookDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BookDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BookDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BookDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BookDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BookDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BookDb', N'ON'
GO
ALTER DATABASE [BookDb] SET QUERY_STORE = OFF
GO
USE [BookDb]
GO
/****** Object:  Table [dbo].[tblBook]    Script Date: 5/10/2023 7:36:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBook](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[BookName] [nvarchar](100) NOT NULL,
	[Author] [nvarchar](100) NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_tblBook] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblBook] ON 

INSERT [dbo].[tblBook] ([Id], [Date], [BookName], [Author], [Quantity]) VALUES (1, CAST(N'2022-01-01' AS Date), N'Man and Superman', N'G B Shaw', 1)
INSERT [dbo].[tblBook] ([Id], [Date], [BookName], [Author], [Quantity]) VALUES (2, CAST(N'2022-01-02' AS Date), N'The Castle', N'Franz Kalka', 1)
INSERT [dbo].[tblBook] ([Id], [Date], [BookName], [Author], [Quantity]) VALUES (3, CAST(N'2022-01-03' AS Date), N'A Woman''s Life', N'Guy the Manupassaul', 1)
INSERT [dbo].[tblBook] ([Id], [Date], [BookName], [Author], [Quantity]) VALUES (4, CAST(N'2022-01-04' AS Date), N'Bela Obela Kolbela', N'Jibanananda Das', 1)
INSERT [dbo].[tblBook] ([Id], [Date], [BookName], [Author], [Quantity]) VALUES (5, CAST(N'2022-01-05' AS Date), N'The Sense of an Ending', N'Julian Barnes', 1)
SET IDENTITY_INSERT [dbo].[tblBook] OFF
GO
/****** Object:  StoredProcedure [dbo].[spGetBookInfo]    Script Date: 5/10/2023 7:36:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetBookInfo] @startDate DATE,
							   @endDate DATE
AS
BEGIN
	SELECT 
		Id,
		[Date],
		BookName,
		Author,
		Quantity
	FROM tblBook
	WHERE [Date] BETWEEN @startDate AND @endDate
END
GO
USE [master]
GO
ALTER DATABASE [BookDb] SET  READ_WRITE 
GO
