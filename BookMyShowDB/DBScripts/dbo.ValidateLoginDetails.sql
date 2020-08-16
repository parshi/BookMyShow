CREATE PROCEDURE [dbo].[ValidateLoginDetails]
	@Email NVARCHAR(MAX),
	@Password NVARCHAR(MAX)
AS
	SELECT * from Users where Email=@Email and Password=@Password