CREATE OR ALTER PROCEDURE SoftDeleteStoreHouse
@Id INT
AS
BEGIN
UPDATE Stock
SET IsDeleted = 1 WHERE StoreHouseId = @Id
UPDATE StoreHouse
SET IsDeleted = 1 WHERE id = @Id
END