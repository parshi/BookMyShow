CREATE PROCEDURE [dbo].[GetMoviesDetailsByMovieName]
	@movieName varchar(max)
AS
	SELECT m.Name,scr.Name as Cinema,scr.Location,scr.City,sc.ShowTime from
	 Screening sc JOIN Movie m on sc.MovieId = m.Id JOIN  Screen scr on scr.Id=sc.ScreenId Where m.Name = @movieName
RETURN 0