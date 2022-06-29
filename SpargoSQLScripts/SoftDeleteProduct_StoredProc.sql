CREATE OR ALTER PROCEDURE SoftDeleteProduct
@Id INT
AS
BEGIN
UPDATE Stock
SET IsDeleted = 1 WHERE ProductId = @Id
UPDATE Product
SET IsDeleted = 1 WHERE id = @Id
END