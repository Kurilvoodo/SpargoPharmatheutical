CREATE PROCEDURE AddPharmacy
@PharmacyName nvarchar(255),
@PharmacyAdress nvarchar(255),
@PharmacyPhoneNumber nvarchar(255)
AS
BEGIN
INSERT INTO Pharmacy (PharmacyName, PharmacyAdress, PharmacyPhoneNumber, IsDeleted)
VALUES(@PharmacyName, @PharmacyAdress, @PharmacyPhoneNumber, 0)
SELECT SCOPE_IDENTITY()
END
