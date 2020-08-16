CREATE PROCEDURE [dbo].[BookTicket]
    @SeatType varchar(100),
    @NumOfTickets int,
	@MovieName varchar(255),
	@Cinema varchar(255),
	@ShowDate Nvarchar(255),
	@ShowTime Nvarchar(255)
AS
    IF(@SeatType = 'SliverClass')
	Begin
	Update SeatAvalibility SET SliverClass=SliverClass - @NumOfTickets, TotalSeatsAvaliable=TotalSeatsAvaliable-@NumOfTickets where ScreeningId = (Select Id from Screening where ScreenId =(select Id from Screen where Name= @Cinema) and ShowTime=@ShowTime and ShowDate=@ShowDate and MovieId =(select Id from Movie where Name= @MovieName))
	END
	IF(@SeatType = 'GoldClass')
	Begin
	Update SeatAvalibility SET GoldClass=GoldClass - @NumOfTickets, TotalSeatsAvaliable=TotalSeatsAvaliable-@NumOfTickets where ScreeningId = (Select Id from Screening where ScreenId =(select Id from Screen where Name= @Cinema) and ShowTime=@ShowTime and ShowDate=@ShowDate and MovieId =(select Id from Movie where Name= @MovieName))
	END
	IF(@SeatType = 'Platinum')
	Begin
	Update SeatAvalibility SET Platinum=Platinum - @NumOfTickets, TotalSeatsAvaliable=TotalSeatsAvaliable-@NumOfTickets where ScreeningId = (Select Id from Screening where ScreenId =(select Id from Screen where Name= @Cinema) and ShowTime=@ShowTime and ShowDate=@ShowDate and MovieId =(select Id from Movie where Name= @MovieName))
	END
	IF(@SeatType = 'VIP')
	Begin
	Update SeatAvalibility SET VIP=VIP - @NumOfTickets, TotalSeatsAvaliable=TotalSeatsAvaliable-@NumOfTickets where ScreeningId = (Select Id from Screening where ScreenId =(select Id from Screen where Name= @Cinema) and ShowTime=@ShowTime and ShowDate=@ShowDate and MovieId =(select Id from Movie where Name= @MovieName))
	END