USE [master]
GO
/****** Object:  Database [CafeMenu]    Script Date: 09/03/2025 19:58:00 ******/
CREATE DATABASE [CafeMenu]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CafeMenu', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CafeMenu.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CafeMenu_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CafeMenu_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CafeMenu] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CafeMenu].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CafeMenu] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CafeMenu] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CafeMenu] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CafeMenu] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CafeMenu] SET ARITHABORT OFF 
GO
ALTER DATABASE [CafeMenu] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CafeMenu] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CafeMenu] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CafeMenu] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CafeMenu] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CafeMenu] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CafeMenu] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CafeMenu] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CafeMenu] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CafeMenu] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CafeMenu] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CafeMenu] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CafeMenu] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CafeMenu] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CafeMenu] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CafeMenu] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CafeMenu] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CafeMenu] SET RECOVERY FULL 
GO
ALTER DATABASE [CafeMenu] SET  MULTI_USER 
GO
ALTER DATABASE [CafeMenu] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CafeMenu] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CafeMenu] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CafeMenu] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CafeMenu] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CafeMenu] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CafeMenu', N'ON'
GO
ALTER DATABASE [CafeMenu] SET QUERY_STORE = OFF
GO
USE [CafeMenu]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 09/03/2025 19:58:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](255) NULL,
	[ParentCategoryId] [int] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatorUserId] [int] NULL,
 CONSTRAINT [PK_CATEGORY] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 09/03/2025 19:58:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](255) NULL,
	[CategoryId] [int] NULL,
	[Price] [decimal](18, 2) NULL,
	[ImagePath] [nvarchar](255) NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatorUserId] [int] NULL,
 CONSTRAINT [PK_PRODUCT] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductProperty]    Script Date: 09/03/2025 19:58:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductProperty](
	[ProductPropertyId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[PropertyId] [int] NULL,
 CONSTRAINT [PK_PRODUCTPROPERTY] PRIMARY KEY CLUSTERED 
(
	[ProductPropertyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Property]    Script Date: 09/03/2025 19:58:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Property](
	[PropertyId] [int] IDENTITY(1,1) NOT NULL,
	[Key] [nvarchar](255) NULL,
	[Value] [nvarchar](255) NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatorUserId] [int] NULL,
 CONSTRAINT [PK_PROPERTY] PRIMARY KEY CLUSTERED 
(
	[PropertyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USER]    Script Date: 09/03/2025 19:58:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USER](
	[USERID] [int] IDENTITY(1,1) NOT NULL,
	[NAME] [nvarchar](50) NOT NULL,
	[SURNAME] [nvarchar](50) NULL,
	[USERNAME] [nvarchar](50) NULL,
	[PASSWORD] [nvarchar](50) NULL,
	[EMAIL] [nvarchar](50) NULL,
 CONSTRAINT [PK_SystemUser] PRIMARY KEY CLUSTERED 
(
	[USERID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryId], [CategoryName], [ParentCategoryId], [IsDeleted], [CreatedDate], [CreatorUserId]) VALUES (14, N'Kahvaltı', NULL, NULL, NULL, NULL)
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [ParentCategoryId], [IsDeleted], [CreatedDate], [CreatorUserId]) VALUES (15, N'Çorba', NULL, NULL, NULL, NULL)
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [ParentCategoryId], [IsDeleted], [CreatedDate], [CreatorUserId]) VALUES (16, N'Salata', NULL, NULL, NULL, NULL)
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [ParentCategoryId], [IsDeleted], [CreatedDate], [CreatorUserId]) VALUES (17, N'Ana yemek', NULL, NULL, NULL, NULL)
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [ParentCategoryId], [IsDeleted], [CreatedDate], [CreatorUserId]) VALUES (18, N'Tatlılar', NULL, NULL, NULL, NULL)
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [ParentCategoryId], [IsDeleted], [CreatedDate], [CreatorUserId]) VALUES (19, N'İçecekler', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [Price], [ImagePath], [IsDeleted], [CreatedDate], [CreatorUserId]) VALUES (24, N'Menemen', 14, CAST(100.00 AS Decimal(18, 2)), N'f4eccaa0-890b-466a-b762-d950d2da66b3.jpg', NULL, NULL, NULL)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [Price], [ImagePath], [IsDeleted], [CreatedDate], [CreatorUserId]) VALUES (25, N'Kahvatı tabağı', 14, CAST(100.00 AS Decimal(18, 2)), N'045ed58a-7265-4a82-82f5-0b7b2db83bf6.jpg', NULL, NULL, NULL)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [Price], [ImagePath], [IsDeleted], [CreatedDate], [CreatorUserId]) VALUES (26, N'Mercimek Çorbası', 15, CAST(100.00 AS Decimal(18, 2)), N'a2da438a-f384-4ec4-8fd1-223d5e02018f.jpg', NULL, NULL, NULL)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [Price], [ImagePath], [IsDeleted], [CreatedDate], [CreatorUserId]) VALUES (27, N'Beyran', 15, CAST(100.00 AS Decimal(18, 2)), N'2ac0cad2-6942-4f86-8782-e74fe734e150.jpg', NULL, NULL, NULL)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [Price], [ImagePath], [IsDeleted], [CreatedDate], [CreatorUserId]) VALUES (28, N'Pratik Salata', 16, CAST(100.00 AS Decimal(18, 2)), N'd7852ca5-53b7-4eb6-ad1d-74e941dba312.jpg', NULL, NULL, NULL)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [Price], [ImagePath], [IsDeleted], [CreatedDate], [CreatorUserId]) VALUES (29, N'Döner', 17, CAST(100.00 AS Decimal(18, 2)), N'a5a86c23-5aac-4c0f-8d68-bcaf9e3f75aa.jpg', NULL, NULL, NULL)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [Price], [ImagePath], [IsDeleted], [CreatedDate], [CreatorUserId]) VALUES (30, N'Künefe', 18, CAST(100.00 AS Decimal(18, 2)), N'3a8f90aa-1ba9-41b8-8bf9-7a4f0961f4d9.jpg', NULL, NULL, NULL)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [Price], [ImagePath], [IsDeleted], [CreatedDate], [CreatorUserId]) VALUES (31, N'Çay', 19, CAST(100.00 AS Decimal(18, 2)), N'af494e5b-73f6-414f-b984-e10926d579f1.jpg', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Property] ON 

INSERT [dbo].[Property] ([PropertyId], [Key], [Value], [IsDeleted], [CreatedDate], [CreatorUserId]) VALUES (1, N'Özellik 1', N'1', NULL, NULL, NULL)
INSERT [dbo].[Property] ([PropertyId], [Key], [Value], [IsDeleted], [CreatedDate], [CreatorUserId]) VALUES (2, N'1', N'1', NULL, NULL, NULL)
INSERT [dbo].[Property] ([PropertyId], [Key], [Value], [IsDeleted], [CreatedDate], [CreatorUserId]) VALUES (3, N'deneme', N'1', NULL, NULL, NULL)
INSERT [dbo].[Property] ([PropertyId], [Key], [Value], [IsDeleted], [CreatedDate], [CreatorUserId]) VALUES (4, N'1', N'1', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Property] OFF
GO
SET IDENTITY_INSERT [dbo].[USER] ON 

INSERT [dbo].[USER] ([USERID], [NAME], [SURNAME], [USERNAME], [PASSWORD], [EMAIL]) VALUES (1, N'Erdoğan', N'KABA', N'erdogankb57@gmail.com', N'123456', N'erdogankb57@gmail.com')
SET IDENTITY_INSERT [dbo].[USER] OFF
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_CATEGORY_CREATEDDATE]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_PRODUCT_CREATEDDATE]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Property] ADD  CONSTRAINT [DF_Property_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Category]  WITH CHECK ADD  CONSTRAINT [FK_CATEGORY_USER] FOREIGN KEY([CreatorUserId])
REFERENCES [dbo].[USER] ([USERID])
GO
ALTER TABLE [dbo].[Category] CHECK CONSTRAINT [FK_CATEGORY_USER]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCT_CATEGORY] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_PRODUCT_CATEGORY]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCT_USER] FOREIGN KEY([CreatorUserId])
REFERENCES [dbo].[USER] ([USERID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_PRODUCT_USER]
GO
ALTER TABLE [dbo].[ProductProperty]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCTPROPERTY_PRODUCT] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[ProductProperty] CHECK CONSTRAINT [FK_PRODUCTPROPERTY_PRODUCT]
GO
ALTER TABLE [dbo].[ProductProperty]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCTPROPERTY_PROPERTY] FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Property] ([PropertyId])
GO
ALTER TABLE [dbo].[ProductProperty] CHECK CONSTRAINT [FK_PRODUCTPROPERTY_PROPERTY]
GO
USE [master]
GO
ALTER DATABASE [CafeMenu] SET  READ_WRITE 
GO
