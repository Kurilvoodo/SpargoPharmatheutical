CREATE OR ALTER PROCEDURE AddStock
@StoreHouseId int,
@ProductId int,
@StockNumber int
AS
BEGIN
INSERT INTO Stock (StoreHouseId,ProductId,StockNumber, IsDeleted)
VALUES(@StoreHouseId,@ProductId, @StockNumber, 0)
SELECT SCOPE_IDENTITY()
END