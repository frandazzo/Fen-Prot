
/****** Object:  UserDefinedFunction [dbo].[GetBookingStatisticsByMonth]    Script Date: 11/05/2012 17:05:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[GetBookingStatisticsByMonth](@myMonth int, @myYear int)
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
    SELECT     
		Book_Assignment.ID, 
		Book_Resources.Description as Stanza,  
		(select dbo.NumberOfDaysInDataRangeIntersection(Book_Assignment.StartDate, 
														DATEADD(dd,-1, Book_Assignment.EndDate), --tolgo un giorno alla data fine per il corretto calcolo dei giorni di intersezione
														@myStart,
														@myEnd))  as Vendite,
		@mese as Mese,
		@myYear as Anno,
        Book_BookingType.Descrizione  as Tipo,
		@giornateMese as GiornateMese

	FROM         Book_Assignment INNER JOIN

                      Book_Booking ON Book_Assignment.Id_Booking = Book_Booking.ID INNER JOIN
                      Book_BookingType ON Book_Booking.Id_BookingType = Book_BookingType.ID INNER JOIN
                      Book_Resources ON Book_Assignment.Id_Resource = Book_Resources.ID
	WHERE
				( EndDate > @myStart AND StartDate <= @myEnd ) 

    RETURN;
END;
