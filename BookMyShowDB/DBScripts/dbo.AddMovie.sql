CREATE PROCEDURE [dbo].[AddMovie]
	@Name varchar(MAX)
AS
BEGIN
	Insert into dbo.Movie values (@Name)
END