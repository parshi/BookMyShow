CREATE PROCEDURE [dbo].[AddUser]
	@Name varchar(255),
	@Email nvarchar(max),
	@Password nvarchar(max)
AS
	Insert into Users values(@Name,@Email,@Password)
RETURN 0