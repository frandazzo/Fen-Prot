
/****** Object:  UserDefinedFunction [dbo].[GetToCollectByMonth]    Script Date: 11/05/2012 17:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create FUNCTION [dbo].[GetToCollectByMonth](@myMonth int, @myYear int)
RETURNS @result TABLE 
(
    -- Columns returned by the function
	Id_Booking int NOT NULL,
    DaIncassare int  NOT NULL, 
    Mese nvarchar(50) NOT NULL, 
    Anno int NOT NULL
)
AS 
-- Returns the first name, last name, job title, and contact type for the specified contact.
BEGIN
    DECLARE 
        @mese nvarchar(50), 
        @giornateMese int,
		@myStart smallDatetime,
		@myEnd smallDatetime;
	--set initialvariables
		Set @giornateMese = (select dbo.udf_GetNumDaysInMonthSimplified(@myYear, @myMonth));
		Set @mese = (select dbo.udf_GetNomeMese(@myMonth));
		Set @myStart = dbo.ConstructDate(@myYear,@myMonth,1);
		Set @myEnd = dbo.ConstructDate(@myYear,@mymonth, dbo.udf_GetNumDaysInMonthSimplified(@myYear,@myMonth));
		
    -- Get common contact information
    INSERT @result
    select f1.Id_Booking as Id_Booking, f1.DaIncassare as DaIncassare, @mese as Mese, @myYear as Anno from 
		(
			SELECT     Id_Booking, (totale -acconto -saldo) as DaIncassare
			FROM         Book_BookingPayment
			WHERE     (totale -acconto -saldo <> 0)
		) f1 
	inner join
		(
			Select Id_booking, max(enddate) as date from book_assignment group by id_booking 
		) f2
	on f1.Id_Booking = f2.Id_Booking 
	where f2.Date >= @myStart and f2.Date <= @myEnd
		
    RETURN;
END;





