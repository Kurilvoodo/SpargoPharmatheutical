CREATE OR ALTER PROCEDURE SoftDeletePharmacy
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