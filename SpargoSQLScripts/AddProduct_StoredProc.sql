CREATE OR ALTER PROCEDURE AddProduct
@ProductName nvarchar(255)
AS
BEGIN
INSERT INTO Product (ProductName, IsDeleted)
VALUES(@ProductName, 0)
SELECT SCOPE_IDENTITY()
END