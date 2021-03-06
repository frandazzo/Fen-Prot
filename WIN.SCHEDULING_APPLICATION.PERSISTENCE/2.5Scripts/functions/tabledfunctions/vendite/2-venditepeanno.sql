
/****** Object:  UserDefinedFunction [dbo].[GetBookingStatisticsByYear]    Script Date: 11/05/2012 17:05:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[GetBookingStatisticsByYear] 
(
	@myYear int
)
RETURNS @result TABLE 
(
	-- Columns returned by the function
	ID int NOT NULL,
	Stanza nvarchar(100) NOT NULL,
    Vendite int  NOT NULL, 
    Mese nvarchar(50) NOT NULL, 
    Anno int NOT NULL, 
    Tipo nvarchar(50) NOT NULL, 
    GiornateMese int NOT NULL
)
AS
BEGIN
	-- Fill the table variable with the rows for your result set
	INSERT @result
		SELECT * from dbo.GetBookingStatisticsByMonth(1, @myYear)
UNION ALL
		SELECT * from dbo.GetBookingStatisticsByMonth(2, @myYear)
UNION ALL
		SELECT * from dbo.GetBookingStatisticsByMonth(3, @myYear)
UNION ALL
		SELECT * from dbo.GetBookingStatisticsByMonth(4, @myYear)
UNION ALL
		SELECT * from dbo.GetBookingStatisticsByMonth(5, @myYear)
UNION ALL
		SELECT * from dbo.GetBookingStatisticsByMonth(6, @myYear)
UNION ALL
		SELECT * from dbo.GetBookingStatisticsByMonth(7, @myYear)
UNION ALL
		SELECT * from dbo.GetBookingStatisticsByMonth(8, @myYear)
UNION ALL
		SELECT * from dbo.GetBookingStatisticsByMonth(9, @myYear)
UNION ALL
		SELECT * from dbo.GetBookingStatisticsByMonth(10, @myYear)
UNION ALL
		SELECT * from dbo.GetBookingStatisticsByMonth(11, @myYear)
UNION ALL
		SELECT * from dbo.GetBookingStatisticsByMonth(12, @myYear)
	
	RETURN 
END
