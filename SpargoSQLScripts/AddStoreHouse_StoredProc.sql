CREATE OR ALTER PROCEDURE AddStoreHouse
@PharmacyId int,
@StoreName nvarchar(255)
AS
BEGIN
INSERT INTO StoreHouse(PharmacyId, StoreName, IsDeleted)
VALUES(@PharmacyId, @StoreName, 0)
SELECT SCOPE_IDENTITY()
END