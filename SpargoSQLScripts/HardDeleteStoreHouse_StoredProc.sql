CREATE OR ALTER PROCEDURE HardDeleteStoreHouse
@Id INT
AS
BEGIN
DELETE FROM Stock WHERE StoreHouseId = @Id
DELETE FROM StoreHouse WHERE id = @Id
END