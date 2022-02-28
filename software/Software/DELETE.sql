USE DB_Software
GO

CREATE PROCEDURE dbo.DeleteData
@ID int
AS
	DELETE Software
	WHERE ID = @ID