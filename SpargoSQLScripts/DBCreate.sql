USE SpargoPham;
CREATE TABLE [Product] (
	id integer NOT NULL,
	ProductName nvarchar(255) NOT NULL,
	IsDeleted bit NOT NULL,
  CONSTRAINT [PK_PRODUCT] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Pharmacy] (
	id integer NOT NULL,
	PharmacyName nvarchar(255) NOT NULL,
	PharmacyAdress nvarchar(255) NOT NULL,
	PharmacyPhoneNumber nvarchar(255) NOT NULL,
	IsDeleted bit NOT NULL,
  CONSTRAINT [PK_PHARMACY] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Stock] (
	id integer NOT NULL,
	StoreHouseId integer NOT NULL,
	ProductId integer NOT NULL,
	StockNumber integer NOT NULL,
	IsDeleted bit NOT NULL,
  CONSTRAINT [PK_STOCK] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [StoreHouse] (
	id integer NOT NULL,
	PharmacyId integer NOT NULL,
	StoreName nvarchar(255) NOT NULL,
	IsDeleted bit NOT NULL,
  CONSTRAINT [PK_STOREHOUSE] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO


ALTER TABLE [Stock] WITH CHECK ADD CONSTRAINT [Stock_fk0] FOREIGN KEY ([StoreHouseId]) REFERENCES [StoreHouse]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [Stock] CHECK CONSTRAINT [Stock_fk0]
GO
ALTER TABLE [Stock] WITH CHECK ADD CONSTRAINT [Stock_fk1] FOREIGN KEY ([ProductId]) REFERENCES [Product]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [Stock] CHECK CONSTRAINT [Stock_fk1]
GO

ALTER TABLE [StoreHouse] WITH CHECK ADD CONSTRAINT [StoreHouse_fk0] FOREIGN KEY ([PharmacyId]) REFERENCES [Pharmacy]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [StoreHouse] CHECK CONSTRAINT [StoreHouse_fk0]
GO
