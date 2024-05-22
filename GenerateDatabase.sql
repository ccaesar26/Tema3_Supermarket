USE [master]
GO
/****** Object:  Database [dbSupermarket]    Script Date: 22.05.2024 02:25:44 ******/
CREATE DATABASE [dbSupermarket]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbSupermarket', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\dbSupermarket.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbSupermarket_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\dbSupermarket_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [dbSupermarket] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbSupermarket].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbSupermarket] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbSupermarket] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbSupermarket] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbSupermarket] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbSupermarket] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbSupermarket] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbSupermarket] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbSupermarket] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbSupermarket] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbSupermarket] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbSupermarket] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbSupermarket] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbSupermarket] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbSupermarket] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbSupermarket] SET  ENABLE_BROKER 
GO
ALTER DATABASE [dbSupermarket] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbSupermarket] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbSupermarket] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbSupermarket] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbSupermarket] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbSupermarket] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [dbSupermarket] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbSupermarket] SET RECOVERY FULL 
GO
ALTER DATABASE [dbSupermarket] SET  MULTI_USER 
GO
ALTER DATABASE [dbSupermarket] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbSupermarket] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbSupermarket] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbSupermarket] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbSupermarket] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbSupermarket] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'dbSupermarket', N'ON'
GO
ALTER DATABASE [dbSupermarket] SET QUERY_STORE = ON
GO
ALTER DATABASE [dbSupermarket] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [dbSupermarket]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 22.05.2024 02:25:45 ******/
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
/****** Object:  Table [dbo].[Category]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Image] [nvarchar](200) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Offer]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Offer](
	[OfferId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[DiscountPercentage] [int] NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
	[Reason] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Offer] PRIMARY KEY CLUSTERED 
(
	[OfferId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producer]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producer](
	[ProducerId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[OriginCountry] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Producer] PRIMARY KEY CLUSTERED 
(
	[ProducerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Barcode] [nvarchar](50) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[ProducerId] [int] NOT NULL,
	[Image] [nvarchar](200) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductReceipt]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductReceipt](
	[ReceiptId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Unit] [int] NOT NULL,
	[Subtotal] [decimal](18, 2) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_ProductReceipt] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[ReceiptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Receipt]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receipt](
	[ReceiptId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[IssueDate] [datetime2](7) NOT NULL,
	[AmountReceived] [decimal](18, 2) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Receipt] PRIMARY KEY CLUSTERED 
(
	[ReceiptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[StockId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Unit] [int] NOT NULL,
	[SupplyDate] [datetime2](7) NOT NULL,
	[ExpiryDate] [datetime2](7) NULL,
	[PurchasePrice] [decimal](18, 2) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED 
(
	[StockId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[UserType] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_Offer_ProductId]    Script Date: 22.05.2024 02:25:45 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Offer_ProductId] ON [dbo].[Offer]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Product_CategoryId]    Script Date: 22.05.2024 02:25:45 ******/
CREATE NONCLUSTERED INDEX [IX_Product_CategoryId] ON [dbo].[Product]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Product_ProducerId]    Script Date: 22.05.2024 02:25:45 ******/
CREATE NONCLUSTERED INDEX [IX_Product_ProducerId] ON [dbo].[Product]
(
	[ProducerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductReceipt_ReceiptId]    Script Date: 22.05.2024 02:25:45 ******/
CREATE NONCLUSTERED INDEX [IX_ProductReceipt_ReceiptId] ON [dbo].[ProductReceipt]
(
	[ReceiptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Receipt_UserId]    Script Date: 22.05.2024 02:25:45 ******/
CREATE NONCLUSTERED INDEX [IX_Receipt_UserId] ON [dbo].[Receipt]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Stock_ProductId]    Script Date: 22.05.2024 02:25:45 ******/
CREATE NONCLUSTERED INDEX [IX_Stock_ProductId] ON [dbo].[Stock]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Category] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Offer] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Producer] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Product] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[ProductReceipt] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Receipt] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Stock] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Offer]  WITH CHECK ADD  CONSTRAINT [FK_Offer_Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Offer] CHECK CONSTRAINT [FK_Offer_Product_ProductId]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category_CategoryId]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Producer_ProducerId] FOREIGN KEY([ProducerId])
REFERENCES [dbo].[Producer] ([ProducerId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Producer_ProducerId]
GO
ALTER TABLE [dbo].[ProductReceipt]  WITH CHECK ADD  CONSTRAINT [FK_ProductReceipt_Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductReceipt] CHECK CONSTRAINT [FK_ProductReceipt_Product_ProductId]
GO
ALTER TABLE [dbo].[ProductReceipt]  WITH CHECK ADD  CONSTRAINT [FK_ProductReceipt_Receipt_ReceiptId] FOREIGN KEY([ReceiptId])
REFERENCES [dbo].[Receipt] ([ReceiptId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductReceipt] CHECK CONSTRAINT [FK_ProductReceipt_Receipt_ReceiptId]
GO
ALTER TABLE [dbo].[Receipt]  WITH CHECK ADD  CONSTRAINT [FK_Receipt_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Receipt] CHECK CONSTRAINT [FK_Receipt_User_UserId]
GO
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD  CONSTRAINT [FK_Stock_Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [FK_Stock_Product_ProductId]
GO
/****** Object:  StoredProcedure [dbo].[spCategoryDelete]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Delete operation for Category
CREATE PROCEDURE [dbo].[spCategoryDelete]
    @CategoryId int
AS
BEGIN
    UPDATE Category
    SET IsActive = 0
    WHERE CategoryId = @CategoryId
END
GO
/****** Object:  StoredProcedure [dbo].[spCategoryInsert]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Insert operation for Category
CREATE PROCEDURE [dbo].[spCategoryInsert]
    @Name nvarchar(50),
    @Image nvarchar(200)
AS
BEGIN
    INSERT INTO Category(Name, Image)
    VALUES (@Name, @Image)
END
GO
/****** Object:  StoredProcedure [dbo].[spCategorySelectAll]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SelectAll operation for Category
CREATE PROCEDURE [dbo].[spCategorySelectAll]
AS
BEGIN
    SELECT * FROM Category WHERE IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spCategorySelectOne]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- SelectOne operation for Category
CREATE PROCEDURE [dbo].[spCategorySelectOne]
    @CategoryId int
AS
BEGIN
    SELECT * FROM Category WHERE CategoryId = @CategoryId AND IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spCategoryUpdate]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Update operation for Category
CREATE PROCEDURE [dbo].[spCategoryUpdate]
    @CategoryId int,
    @Name nvarchar(50),
    @Image nvarchar(200)
AS
BEGIN
    UPDATE Category
    SET Name = @Name, Image = @Image
    WHERE CategoryId = @CategoryId
END
GO
/****** Object:  StoredProcedure [dbo].[spOfferDelete]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Delete operation for Offer
CREATE PROCEDURE [dbo].[spOfferDelete]
    @OfferId int
AS
BEGIN
    UPDATE Offer
    SET IsActive = 0
    WHERE OfferId = @OfferId
END
GO
/****** Object:  StoredProcedure [dbo].[spOfferInsert]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Insert operation for Offer
CREATE PROCEDURE [dbo].[spOfferInsert]
    @ProductId int,
    @DiscountPercentage int,
    @StartDate datetime,
    @EndDate datetime,
    @Reason int
AS
BEGIN
    INSERT INTO Offer(ProductId, DiscountPercentage, StartDate, EndDate, Reason)
    VALUES (@ProductId, @DiscountPercentage, @StartDate, @EndDate, @Reason)
END
GO
/****** Object:  StoredProcedure [dbo].[spOfferSelectAll]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SelectAll operation for Offer
CREATE PROCEDURE [dbo].[spOfferSelectAll]
AS
BEGIN
    SELECT * FROM Offer WHERE IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spOfferSelectOne]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- SelectOne operation for Offer
CREATE PROCEDURE [dbo].[spOfferSelectOne]
    @OfferId int
AS
BEGIN
    SELECT * FROM Offer WHERE OfferId = @OfferId AND IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spOfferUpdate]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Update operation for Offer
CREATE PROCEDURE [dbo].[spOfferUpdate]
    @OfferId int,
    @ProductId int,
    @DiscountPercentage int,
    @StartDate datetime,
    @EndDate datetime,
    @Reason int
AS
BEGIN
    UPDATE Offer
    SET ProductId = @ProductId, DiscountPercentage = @DiscountPercentage, StartDate = @StartDate, EndDate = @EndDate, Reason = @Reason
    WHERE OfferId = @OfferId
END
GO
/****** Object:  StoredProcedure [dbo].[spProducerDelete]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Delete operation for Producer
CREATE PROCEDURE [dbo].[spProducerDelete]
    @ProducerId int
AS
BEGIN
    UPDATE Producer
    SET IsActive = 0
    WHERE ProducerId = @ProducerId
END
GO
/****** Object:  StoredProcedure [dbo].[spProducerInsert]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Insert operation for Producer
CREATE PROCEDURE [dbo].[spProducerInsert]
    @Name nvarchar(50),
    @OriginCountry nvarchar(50)
AS
BEGIN
    INSERT INTO Producer(Name, OriginCountry)
    VALUES (@Name, @OriginCountry)
END
GO
/****** Object:  StoredProcedure [dbo].[spProducerSelectAll]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SelectAll operation for Producer
CREATE PROCEDURE [dbo].[spProducerSelectAll]
AS
BEGIN
    SELECT * FROM Producer WHERE IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spProducerSelectOne]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- SelectOne operation for Producer
CREATE PROCEDURE [dbo].[spProducerSelectOne]
    @ProducerId int
AS
BEGIN
    SELECT * FROM Producer WHERE ProducerId = @ProducerId AND IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spProducerUpdate]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Update operation for Producer
CREATE PROCEDURE [dbo].[spProducerUpdate]
    @ProducerId int,
    @Name nvarchar(50),
    @OriginCountry nvarchar(50)
AS
BEGIN
    UPDATE Producer
    SET Name = @Name, OriginCountry = @OriginCountry
    WHERE ProducerId = @ProducerId
END
GO
/****** Object:  StoredProcedure [dbo].[spProductDelete]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Delete operation for Product
CREATE PROCEDURE [dbo].[spProductDelete]
    @ProductId int
AS
BEGIN
    UPDATE Product
    SET IsActive = 0
    WHERE ProductId = @ProductId
END
GO
/****** Object:  StoredProcedure [dbo].[spProductInsert]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Insert operation for Product
CREATE PROCEDURE [dbo].[spProductInsert]
    @Name nvarchar(50),
    @Barcode nvarchar(50),
    @CategoryId int,
    @ProducerId int,
    @Image nvarchar(200)
AS
BEGIN
    INSERT INTO Product(Name, Barcode, CategoryId, ProducerId, Image)
    VALUES (@Name, @Barcode, @CategoryId, @ProducerId, @Image)
END
GO
/****** Object:  StoredProcedure [dbo].[spProductReceiptDelete]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Delete operation for ProductReceipt
CREATE PROCEDURE [dbo].[spProductReceiptDelete]
    @ReceiptId int,
    @ProductId int
AS
BEGIN
    UPDATE ProductReceipt
    SET IsActive = 0
    WHERE ReceiptId = @ReceiptId AND ProductId = @ProductId
END
GO
/****** Object:  StoredProcedure [dbo].[spProductReceiptInsert]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Insert operation for ProductReceipt
CREATE PROCEDURE [dbo].[spProductReceiptInsert]
    @ReceiptId int,
    @ProductId int,
    @Quantity int,
    @Unit int,
    @Subtotal decimal(18, 2)
AS
BEGIN
    INSERT INTO ProductReceipt(ReceiptId, ProductId, Quantity, Unit, Subtotal)
    VALUES (@ReceiptId, @ProductId, @Quantity, @Unit, @Subtotal)
END
GO
/****** Object:  StoredProcedure [dbo].[spProductReceiptSelectAll]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SelectAll operation for ProductReceipt
CREATE PROCEDURE [dbo].[spProductReceiptSelectAll]
AS
BEGIN
    SELECT * FROM ProductReceipt WHERE IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spProductReceiptSelectOne]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- SelectOne operation for ProductReceipt
CREATE PROCEDURE [dbo].[spProductReceiptSelectOne]
    @ReceiptId int,
    @ProductId int
AS
BEGIN
    SELECT * FROM ProductReceipt WHERE ReceiptId = @ReceiptId AND ProductId = @ProductId AND IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spProductReceiptUpdate]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Update operation for ProductReceipt
CREATE PROCEDURE [dbo].[spProductReceiptUpdate]
    @ReceiptId int,
    @ProductId int,
    @Quantity int,
    @Unit int,
    @Subtotal decimal(18, 2)
AS
BEGIN
    UPDATE ProductReceipt
    SET Quantity = @Quantity, Unit = @Unit, Subtotal = @Subtotal
    WHERE ReceiptId = @ReceiptId AND ProductId = @ProductId
END
GO
/****** Object:  StoredProcedure [dbo].[spProductSelectAll]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SelectAll operation for Product
CREATE PROCEDURE [dbo].[spProductSelectAll]
AS
BEGIN
    SELECT * FROM Product WHERE IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spProductSelectOne]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- SelectOne operation for Product
CREATE PROCEDURE [dbo].[spProductSelectOne]
    @ProductId int
AS
BEGIN
    SELECT * FROM Product WHERE ProductId = @ProductId AND IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spProductUpdate]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Update operation for Product
CREATE PROCEDURE [dbo].[spProductUpdate]
    @ProductId int,
    @Name nvarchar(50),
    @Barcode nvarchar(50),
    @CategoryId int,
    @ProducerId int,
    @Image nvarchar(200)
AS
BEGIN
    UPDATE Product
    SET Name = @Name, Barcode = @Barcode, CategoryId = @CategoryId, ProducerId = @ProducerId, Image = @Image
    WHERE ProductId = @ProductId
END
GO
/****** Object:  StoredProcedure [dbo].[spReceiptDelete]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Delete operation for Receipt
CREATE PROCEDURE [dbo].[spReceiptDelete]
    @ReceiptId int
AS
BEGIN
    UPDATE Receipt
    SET IsActive = 0
    WHERE ReceiptId = @ReceiptId
END
GO
/****** Object:  StoredProcedure [dbo].[spReceiptInsert]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Insert operation for Receipt
CREATE PROCEDURE [dbo].[spReceiptInsert]
    @UserId int,
    @IssueDate datetime,
    @AmountReceived decimal(18, 2),
    @ReceiptId int OUTPUT
AS
BEGIN
    INSERT INTO Receipt(UserId, IssueDate, AmountReceived)
    VALUES (@UserId, @IssueDate, @AmountReceived)

    -- Retrieve the generated ReceiptId
    SET @ReceiptId = SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[spReceiptSelectAll]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SelectAll operation for Receipt
CREATE PROCEDURE [dbo].[spReceiptSelectAll]
AS
BEGIN
    SELECT * FROM Receipt WHERE IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spReceiptSelectOne]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- SelectOne operation for Receipt
CREATE PROCEDURE [dbo].[spReceiptSelectOne]
    @ReceiptId int
AS
BEGIN
    SELECT * FROM Receipt WHERE ReceiptId = @ReceiptId AND IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spReceiptUpdate]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Update operation for Receipt
CREATE PROCEDURE [dbo].[spReceiptUpdate]
    @ReceiptId int,
    @UserId int,
    @IssueDate datetime,
    @AmountReceived decimal(18, 2)
AS
BEGIN
    UPDATE Receipt
    SET UserId = @UserId, IssueDate = @IssueDate, AmountReceived = @AmountReceived
    WHERE ReceiptId = @ReceiptId
END
GO
/****** Object:  StoredProcedure [dbo].[spSelectAllProductsByReceipt]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spSelectAllProductsByReceipt]
	-- Add the parameters for the stored procedure here
	@ReceiptId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT p.ProductId FROM Product AS p
	INNER JOIN ProductReceipt AS pr
	ON p.ProductId = pr.ProductId
	INNER JOIN Receipt AS r
	ON pr.ReceiptId = r.ReceiptId
	WHERE r.ReceiptId = @ReceiptId
END
GO
/****** Object:  StoredProcedure [dbo].[spStockDelete]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Delete operation for Stock
CREATE PROCEDURE [dbo].[spStockDelete]
    @StockId int
AS
BEGIN
    UPDATE Stock
    SET IsActive = 0
    WHERE StockId = @StockId
END
GO
/****** Object:  StoredProcedure [dbo].[spStockInsert]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Insert operation for Stock
CREATE PROCEDURE [dbo].[spStockInsert]
    @ProductId int,
    @Quantity int,
    @Unit int,
    @SupplyDate datetime,
    @ExpiryDate datetime,
    @PurchasePrice decimal(18, 2)
AS
BEGIN
    INSERT INTO Stock(ProductId, Quantity, Unit, SupplyDate, ExpiryDate, PurchasePrice)
    VALUES (@ProductId, @Quantity, @Unit, @SupplyDate, @ExpiryDate, @PurchasePrice)
END
GO
/****** Object:  StoredProcedure [dbo].[spStockSelectAll]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SelectAll operation for Stock
CREATE PROCEDURE [dbo].[spStockSelectAll]
AS
BEGIN
    SELECT * FROM Stock WHERE IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spStockSelectOne]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- SelectOne operation for Stock
CREATE PROCEDURE [dbo].[spStockSelectOne]
    @StockId int
AS
BEGIN
    SELECT * FROM Stock WHERE StockId = @StockId AND IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spStockUpdate]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Update operation for Stock
CREATE PROCEDURE [dbo].[spStockUpdate]
    @StockId int,
    @ProductId int,
    @Quantity int,
    @Unit int,
    @SupplyDate datetime,
    @ExpiryDate datetime,
    @PurchasePrice decimal(18, 2)
AS
BEGIN
    UPDATE Stock
    SET ProductId = @ProductId, Quantity = @Quantity, Unit = @Unit, SupplyDate = @SupplyDate, ExpiryDate = @ExpiryDate, PurchasePrice = @PurchasePrice
    WHERE StockId = @StockId
END
GO
/****** Object:  StoredProcedure [dbo].[spUserDelete]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Delete operation for User
CREATE PROCEDURE [dbo].[spUserDelete]
    @UserId int
AS
BEGIN
    UPDATE [User]
    SET IsActive = 0
    WHERE UserId = @UserId
END
GO
/****** Object:  StoredProcedure [dbo].[spUserInsert]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Insert operation for User
CREATE PROCEDURE [dbo].[spUserInsert]
    @Username nvarchar(50),
    @Password nvarchar(50),
    @UserType int
AS
BEGIN
    INSERT INTO [User](Username, Password, UserType)
    VALUES (@Username, @Password, @UserType)
END
GO
/****** Object:  StoredProcedure [dbo].[spUserSelectAll]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SelectAll operation for User
CREATE PROCEDURE [dbo].[spUserSelectAll]
AS
BEGIN
    SELECT * FROM [User] WHERE IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spUserSelectAllAdmins]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spUserSelectAllAdmins]
AS
BEGIN
    SELECT * FROM [User] WHERE UserType = 0 AND IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spUserSelectAllCashiers]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spUserSelectAllCashiers]
AS
BEGIN
    SELECT * FROM [User] WHERE UserType = 1 AND IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spUserSelectOne]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- SelectOne operation for User
CREATE PROCEDURE [dbo].[spUserSelectOne]
    @UserId int
AS
BEGIN
    SELECT * FROM [User] WHERE UserId = @UserId AND IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spUserUpdate]    Script Date: 22.05.2024 02:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Update operation for User
CREATE PROCEDURE [dbo].[spUserUpdate]
    @UserId int,
    @Username nvarchar(50),
    @Password nvarchar(50),
    @UserType int
AS
BEGIN
    UPDATE [User]
    SET Username = @Username, Password = @Password, UserType = @UserType
    WHERE UserId = @UserId
END
GO
USE [master]
GO
ALTER DATABASE [dbSupermarket] SET  READ_WRITE 
GO
