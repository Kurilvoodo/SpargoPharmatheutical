CREATE OR ALTER PROCEDURE GetProductsInPharmacy
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