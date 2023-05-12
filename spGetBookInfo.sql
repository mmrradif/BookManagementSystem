USE BookDb
GO

CREATE PROCEDURE spGetBookInfo @startDate DATE,
							   @endDate DATE
AS
BEGIN
	SELECT 
		Id,
		[Date],
		BookName,
		Author,
		Quantity
	FROM tblBook
	WHERE [Date] BETWEEN @startDate AND @endDate
END
GO

--EXEC spGetBookInfo @startDate = '2023-01-01', @endDate = '2023-02-01'

