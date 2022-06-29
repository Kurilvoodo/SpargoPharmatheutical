CREATE OR ALTER PROCEDURE HardDeletePharmacy
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