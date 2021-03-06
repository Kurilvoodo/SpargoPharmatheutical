USE [SpargoPham]
GO
/****** Object:  Table [dbo].[Pharmacy]    Script Date: 29.06.2022 20:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pharmacy](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PharmacyName] [nvarchar](255) NOT NULL,
	[PharmacyAdress] [nvarchar](255) NOT NULL,
	[PharmacyPhoneNumber] [nvarchar](255) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_PHARMACY] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 29.06.2022 20:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](255) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_PRODUCT] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 29.06.2022 20:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[StoreHouseId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[StockNumber] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_STOCK] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StoreHouse]    Script Date: 29.06.2022 20:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StoreHouse](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PharmacyId] [int] NOT NULL,
	[StoreName] [nvarchar](255) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_STOREHOUSE] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD  CONSTRAINT [Stock_fk0] FOREIGN KEY([StoreHouseId])
REFERENCES [dbo].[StoreHouse] ([id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [Stock_fk0]
GO
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD  CONSTRAINT [Stock_fk1] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [Stock_fk1]
GO
ALTER TABLE [dbo].[StoreHouse]  WITH CHECK ADD  CONSTRAINT [StoreHouse_fk0] FOREIGN KEY([PharmacyId])
REFERENCES [dbo].[Pharmacy] ([id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[StoreHouse] CHECK CONSTRAINT [StoreHouse_fk0]
GO
/****** Object:  StoredProcedure [dbo].[AddPharmacy]    Script Date: 29.06.2022 20:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddPharmacy]
@PharmacyName nvarchar(255),
@PharmacyAdress nvarchar(255),
@PharmacyPhoneNumber nvarchar(255)
AS
BEGIN
INSERT INTO Pharmacy (PharmacyName, PharmacyAdress, PharmacyPhoneNumber, IsDeleted)
VALUES(@PharmacyName, @PharmacyAdress, @PharmacyPhoneNumber, 0)
SELECT SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[AddProduct]    Script Date: 29.06.2022 20:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[AddProduct]
@ProductName nvarchar(255)
AS
BEGIN
INSERT INTO Product (ProductName, IsDeleted)
VALUES(@ProductName, 0)
SELECT SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[AddStock]    Script Date: 29.06.2022 20:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[AddStock]
@StoreHouseId int,
@ProductId int,
@StockNumber int
AS
BEGIN
INSERT INTO Stock (StoreHouseId,ProductId,StockNumber, IsDeleted)
VALUES(@StoreHouseId,@ProductId, @StockNumber, 0)
SELECT SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[AddStoreHouse]    Script Date: 29.06.2022 20:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddStoreHouse]
@PharmacyId int,
@StoreName nvarchar(255)
AS
BEGIN
INSERT INTO StoreHouse(PharmacyId, StoreName, IsDeleted)
VALUES(@PharmacyId, @StoreName, 0)
SELECT SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[GetProductsInPharmacy]    Script Date: 29.06.2022 20:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[GetProductsInPharmacy]
@Id INT
AS
BEGIN
SELECT Pr.ProductName AS ProductName, SUM(S.StockNumber) AS ProductQuantity
FROM Pharmacy P
INNER JOIN StoreHouse SH ON P.id = SH.PharmacyId AND SH.IsDeleted = 0
INNER JOIN Stock S ON SH.id = S.StoreHouseId AND S.IsDeleted = 0
INNER JOIN Product Pr ON Pr.id = S.ProductId AND Pr.IsDeleted = 0
WHERE P.Id = @id AND P.IsDeleted = 0
GROUP BY Pr.ProductName
END
GO
/****** Object:  StoredProcedure [dbo].[HardDeletePharmacy]    Script Date: 29.06.2022 20:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[HardDeletePharmacy]
@Id INT
AS
BEGIN
DELETE FROM Stock
WHERE StoreHouseId IN
	(SELECT St.StoreHouseId 
		FROM Stock st
			INNER JOIN StoreHouse Sh on sh.Id = st.StoreHouseId WHERE sh.PharmacyId = @Id)
	
DELETE FROM StoreHouse WHERE PharmacyId = @Id
DELETE FROM Pharmacy WHERE id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[HardDeleteProduct]    Script Date: 29.06.2022 20:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[HardDeleteProduct]
@Id INT
AS
BEGIN
DELETE FROM Stock WHERE ProductId = @Id
DELETE FROM Product WHERE id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[HardDeleteStock]    Script Date: 29.06.2022 20:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[HardDeleteStock]
@Id INT
AS
BEGIN
DELETE FROM Stock WHERE id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[HardDeleteStoreHouse]    Script Date: 29.06.2022 20:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[HardDeleteStoreHouse]
@Id INT
AS
BEGIN
DELETE FROM Stock WHERE StoreHouseId = @Id
DELETE FROM StoreHouse WHERE id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[SoftDeletePharmacy]    Script Date: 29.06.2022 20:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SoftDeletePharmacy]
@Id INT
AS
BEGIN
UPDATE Stock
SET 
	isDeleted = 1 
FROM
	Sh AS StoreHouse
	INNER JOIN St AS Stock 
		ON Sh.id = St.StoreHouseId
WHERE
	Sh.PharmacyId = @Id

UPDATE StoreHouseId
SET isDeleted = 1 WHERE PharmacyId = @Id
UPDATE Pharmacy
SET IsDeleted = 1 WHERE id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[SoftDeleteProduct]    Script Date: 29.06.2022 20:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SoftDeleteProduct]
@Id INT
AS
BEGIN
UPDATE Stock
SET IsDeleted = 1 WHERE ProductId = @Id
UPDATE Product
SET IsDeleted = 1 WHERE id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[SoftDeleteStock]    Script Date: 29.06.2022 20:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SoftDeleteStock]
@Id INT
AS
BEGIN
UPDATE Stock
SET IsDeleted = 1 WHERE id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[SoftDeleteStoreHouse]    Script Date: 29.06.2022 20:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SoftDeleteStoreHouse]
@Id INT
AS
BEGIN
UPDATE Stock
SET IsDeleted = 1 WHERE StoreHouseId = @Id
UPDATE StoreHouse
SET IsDeleted = 1 WHERE id = @Id
END
GO
