CREATE PROCEDURE [dbo].[AddScreen]
	@Name varchar(MAX),
	@Location varchar(MAX),
	@City varchar(MAX),
	@Capacity int,
	@SliverClass int,
	@GoldClass int,
	@PlatinumClass int,
	@VIP int
AS
DEclare @screenId int
	Insert into dbo.Screen values (@Name,@Location,@Capacity,@City)
	select @screenId=Id from Screen where Name = @Name
	Insert into SeatingCapacity values(@SliverClass,@GoldClass,@PlatinumClass,@VIP,@screenId,@Capacity)
RETURN 0