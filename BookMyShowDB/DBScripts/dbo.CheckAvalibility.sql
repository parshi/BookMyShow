CREATE PROCEDURE [dbo].[CheckAvalibility]
	@MovieName varchar(255),
	@Cinema varchar(255),
	@Location varchar(255),
	@City varchar(255),
	@Date varchar(255),
	@ShowTime Nvarchar(255)
AS

	SELECT sa.SliverClass,sa.GoldClass,sa.Platinum,sa.VIP,sa.TotalSeatsAvaliable from Screening scr 
			 JOIN Movie m ON m.Id =scr.MovieId
			 JOIN Screen sc on sc.Id =scr.ScreenId
			 JOIN SeatAvalibility sa ON sa.ScreeningId=scr.Id
			 JOIN SeatingCapacity scap on scap.ScreenId=sc.Id
			 WHERE m.Name=@MovieName and sc.Name=@Cinema 
			 and sc.Location=@Location and sc.City=@City and scr.ShowTime=@ShowTime and scr.ShowDate=@Date