USE [master]
GO
/****** Object:  Database [CoffeShop]    Script Date: 7.02.2020 03:34:14 ******/
CREATE DATABASE [CoffeShop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CoffeShop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\CoffeShop.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CoffeShop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\CoffeShop_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CoffeShop] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CoffeShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CoffeShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CoffeShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CoffeShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CoffeShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CoffeShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [CoffeShop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CoffeShop] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [CoffeShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CoffeShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CoffeShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CoffeShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CoffeShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CoffeShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CoffeShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CoffeShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CoffeShop] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CoffeShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CoffeShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CoffeShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CoffeShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CoffeShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CoffeShop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CoffeShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CoffeShop] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CoffeShop] SET  MULTI_USER 
GO
ALTER DATABASE [CoffeShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CoffeShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CoffeShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CoffeShop] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [CoffeShop]
GO
/****** Object:  Table [dbo].[Coffe]    Script Date: 7.02.2020 03:34:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coffe](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Coffe] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Coffe_CoffeSize_Mapping]    Script Date: 7.02.2020 03:34:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coffe_CoffeSize_Mapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CoffeSizeId] [int] NOT NULL,
	[CoffeId] [int] NOT NULL,
	[CoffeNeed] [decimal](18, 2) NOT NULL,
	[WaterNeed] [decimal](18, 2) NOT NULL,
	[MilkNeed] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_CoffeComponent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CoffeSize]    Script Date: 7.02.2020 03:34:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CoffeSize](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Size] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_CoffeSize] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Component]    Script Date: 7.02.2020 03:34:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Component](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ComponentName] [nvarchar](10) NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[Stock] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Component] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Coffe] ON 

INSERT [dbo].[Coffe] ([Id], [Name]) VALUES (1, N'Cappuccino')
INSERT [dbo].[Coffe] ([Id], [Name]) VALUES (2, N'Caffé Americano
')
INSERT [dbo].[Coffe] ([Id], [Name]) VALUES (3, N'Chai Tea Latte
')
INSERT [dbo].[Coffe] ([Id], [Name]) VALUES (4, N'Caramel Macchiato
')
SET IDENTITY_INSERT [dbo].[Coffe] OFF
SET IDENTITY_INSERT [dbo].[Coffe_CoffeSize_Mapping] ON 

INSERT [dbo].[Coffe_CoffeSize_Mapping] ([Id], [CoffeSizeId], [CoffeId], [CoffeNeed], [WaterNeed], [MilkNeed]) VALUES (1, 1, 1, CAST(2.50 AS Decimal(18, 2)), CAST(1.50 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)))
INSERT [dbo].[Coffe_CoffeSize_Mapping] ([Id], [CoffeSizeId], [CoffeId], [CoffeNeed], [WaterNeed], [MilkNeed]) VALUES (2, 2, 1, CAST(3.50 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(2.50 AS Decimal(18, 2)))
INSERT [dbo].[Coffe_CoffeSize_Mapping] ([Id], [CoffeSizeId], [CoffeId], [CoffeNeed], [WaterNeed], [MilkNeed]) VALUES (4, 3, 1, CAST(4.00 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)), CAST(4.00 AS Decimal(18, 2)))
INSERT [dbo].[Coffe_CoffeSize_Mapping] ([Id], [CoffeSizeId], [CoffeId], [CoffeNeed], [WaterNeed], [MilkNeed]) VALUES (7, 1, 2, CAST(1.00 AS Decimal(18, 2)), CAST(2.50 AS Decimal(18, 2)), CAST(2.50 AS Decimal(18, 2)))
INSERT [dbo].[Coffe_CoffeSize_Mapping] ([Id], [CoffeSizeId], [CoffeId], [CoffeNeed], [WaterNeed], [MilkNeed]) VALUES (9, 2, 2, CAST(2.00 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)))
INSERT [dbo].[Coffe_CoffeSize_Mapping] ([Id], [CoffeSizeId], [CoffeId], [CoffeNeed], [WaterNeed], [MilkNeed]) VALUES (11, 3, 2, CAST(3.50 AS Decimal(18, 2)), CAST(3.50 AS Decimal(18, 2)), CAST(4.00 AS Decimal(18, 2)))
INSERT [dbo].[Coffe_CoffeSize_Mapping] ([Id], [CoffeSizeId], [CoffeId], [CoffeNeed], [WaterNeed], [MilkNeed]) VALUES (12, 1, 3, CAST(3.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)))
INSERT [dbo].[Coffe_CoffeSize_Mapping] ([Id], [CoffeSizeId], [CoffeId], [CoffeNeed], [WaterNeed], [MilkNeed]) VALUES (14, 2, 3, CAST(3.50 AS Decimal(18, 2)), CAST(1.50 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)))
INSERT [dbo].[Coffe_CoffeSize_Mapping] ([Id], [CoffeSizeId], [CoffeId], [CoffeNeed], [WaterNeed], [MilkNeed]) VALUES (15, 3, 3, CAST(4.50 AS Decimal(18, 2)), CAST(2.50 AS Decimal(18, 2)), CAST(4.00 AS Decimal(18, 2)))
INSERT [dbo].[Coffe_CoffeSize_Mapping] ([Id], [CoffeSizeId], [CoffeId], [CoffeNeed], [WaterNeed], [MilkNeed]) VALUES (16, 1, 4, CAST(1.00 AS Decimal(18, 2)), CAST(1.50 AS Decimal(18, 2)), CAST(3.50 AS Decimal(18, 2)))
INSERT [dbo].[Coffe_CoffeSize_Mapping] ([Id], [CoffeSizeId], [CoffeId], [CoffeNeed], [WaterNeed], [MilkNeed]) VALUES (17, 2, 4, CAST(1.50 AS Decimal(18, 2)), CAST(2.50 AS Decimal(18, 2)), CAST(4.00 AS Decimal(18, 2)))
INSERT [dbo].[Coffe_CoffeSize_Mapping] ([Id], [CoffeSizeId], [CoffeId], [CoffeNeed], [WaterNeed], [MilkNeed]) VALUES (18, 3, 4, CAST(3.00 AS Decimal(18, 2)), CAST(3.50 AS Decimal(18, 2)), CAST(4.50 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Coffe_CoffeSize_Mapping] OFF
SET IDENTITY_INSERT [dbo].[CoffeSize] ON 

INSERT [dbo].[CoffeSize] ([Id], [Size]) VALUES (1, N'Tall')
INSERT [dbo].[CoffeSize] ([Id], [Size]) VALUES (2, N'Grande')
INSERT [dbo].[CoffeSize] ([Id], [Size]) VALUES (3, N'Venti')
SET IDENTITY_INSERT [dbo].[CoffeSize] OFF
SET IDENTITY_INSERT [dbo].[Component] ON 

INSERT [dbo].[Component] ([Id], [ComponentName], [UnitPrice], [Stock]) VALUES (1, N'Coffe', CAST(2.50 AS Decimal(18, 2)), CAST(50.00 AS Decimal(18, 2)))
INSERT [dbo].[Component] ([Id], [ComponentName], [UnitPrice], [Stock]) VALUES (2, N'Milk', CAST(1.50 AS Decimal(18, 2)), CAST(50.00 AS Decimal(18, 2)))
INSERT [dbo].[Component] ([Id], [ComponentName], [UnitPrice], [Stock]) VALUES (3, N'Water', CAST(1.00 AS Decimal(18, 2)), CAST(50.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Component] OFF
USE [master]
GO
ALTER DATABASE [CoffeShop] SET  READ_WRITE 
GO
