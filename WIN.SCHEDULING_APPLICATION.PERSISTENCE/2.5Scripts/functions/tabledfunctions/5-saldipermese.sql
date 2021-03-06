
/****** Object:  UserDefinedFunction [dbo].[GetRestOfPaymentCollectsByMonth]    Script Date: 11/05/2012 17:01:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[GetRestOfPaymentCollectsByMonth](@myMonth int, @myYear int)
RETURNS @result TABLE 
(
    -- Columns returned by the function
	Id_Booking int NOT NULL,
    Incasso int  NOT NULL, 
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
    SELECT
		Id_Booking, Saldo, @mese as Mese, @myYear as Anno
			from Book_BookingPayment where datasaldo >= @myStart and datasaldo <= @myEnd

    RETURN;
END;
