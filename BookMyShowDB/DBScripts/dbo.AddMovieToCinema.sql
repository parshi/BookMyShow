CREATE PROCEDURE [dbo].[AddMovieToCinema]
	@Movie varchar(255),
	@Cinema varchar(255),
	@ShowDate Nvarchar(255),
	@ShowTime Nvarchar(255)
AS
Declare @MovieId int
Declare @ScreenId int
select  @MovieId = Id from Movie where Name=@Movie
select  @ScreenId = Id from Screen where Name=@Cinema

 Insert Screening values (@MovieId,@ScreenId,@ShowTime,@ShowDate)

 DEclare @screeningId int
 select @screeningId=Id from Screening where MovieId=@MovieId and ScreenId=@ScreenId
Declare @Capacity int,	@SliverClass int,	@GoldClass int,	@PlatinumClass int,	@VIP int

 select @SliverClass=SliverClass,@GoldClass=GoldClass,@PlatinumClass=Platinum,@VIP=VIP,@Capacity=TotalSeats  from SeatingCapacity where ScreenId=@ScreenId
	Insert into SeatAvalibility values(@SliverClass,@GoldClass,@PlatinumClass,@VIP,@screeningId,@Capacity)