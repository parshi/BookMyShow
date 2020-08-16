CREATE PROCEDURE [dbo].[GetMoviesByCity]
	@city varchar(MAX)
AS
BEGIN
	SELECT distinct m.Name,SCR.Location,sc.ShowDate,sc.ShowTime from Screening sc 
	JOIN Movie m on sc.MovieId = m.Id 
	JOIN  Screen scr on scr.Id=sc.ScreenId 
	Where scr.City = @city
END