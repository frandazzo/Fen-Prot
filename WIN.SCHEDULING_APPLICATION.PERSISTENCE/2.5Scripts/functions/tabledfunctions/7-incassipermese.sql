
/****** Object:  UserDefinedFunction [dbo].[GetCollectsByMonth]    Script Date: 11/05/2012 17:02:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[GetCollectsByMonth](@myMonth int, @myYear int)
RETURNS TABLE 
AS
RETURN 
(
	with temp as
	(
		select * from GetAccountCollectsByMonth(@myMonth, @myYear)
			union all
		select * from [GetRestOfPaymentCollectsByMonth](@myMonth, @myYear)
	)
	Select Id_Booking, sum(Incasso) as Incasso, Mese, Anno		
	 from  temp  group by id_Booking, Mese, Anno	
)
