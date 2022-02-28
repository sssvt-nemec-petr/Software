USE DB_Software
GO

CREATE PROCEDURE dbo.AddData
@mode nvarchar(10),
@ID int,
@Name varchar(50),
@Provider varchar(50),
@Version int,
@ReleaseDate date,
@LicenseID int,
@License varchar(50)
AS
	IF @mode='Add'
	BEGIN
	INSERT INTO Software
	(
	Name,
	Provider,
	Version,
	ReleaseDate,
	LicenseID,
	License
	)
	VALUES
	(
	@Name,
	@Provider,
	@Version,
	@ReleaseDate,
	@LicenseID,
	@License
	)
	END

	ELSE IF @mode='Edit'
	BEGIN
	UPDATE Software
	SET
	Name=@Name,
	Provider=@Provider,
	Version=@Version,
	ReleaseDate=@ReleaseDate,
	LicenseID=@LicenseID,
	License=@License
	WHERE ID = @ID
	END