
/****** Object:  UserDefinedFunction [dbo].[GetPaymentStatsByMonth]    Script Date: 11/05/2012 17:01:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[GetPaymentStatsByMonth](@myMonth int, @myYear int)
RETURNS @result TABLE 
(
    -- Columns returned by the function
	Id_Booking int NOT NULL,
	Incasso int   NULL,
    DaIncassare int   NULL, 
    Mese nvarchar(50) NOT NULL, 
    Anno int NOT NULL
)
AS 
-- Returns the first name, last name, job title, and contact type for the specified contact.
BEGIN
   
    -- Get common contact information
    INSERT  @result
    
		select  
			case when isnull(f1.id_booking, 0) = 0 then  f2.id_Booking else  f1.id_booking end as id_booking, 
			f1.incasso as Incasso, 
			f2.daincassare as DaIncassare,
			case when isnull(f1.mese, '') = '' then f2.mese else  f1.mese end as Mese,
			case when isnull(f1.anno, 0) = 0 then f2.anno else  f1.anno end as Anno

		from 

			 dbo.GetCollectsByMonth(@myMonth,@myYear) f1 

		full outer join

			 dbo.GetToCollectByMonth(@myMonth,@myYear) f2 

		on f1.Id_Booking = f2.Id_Booking
		
    RETURN;
END;





