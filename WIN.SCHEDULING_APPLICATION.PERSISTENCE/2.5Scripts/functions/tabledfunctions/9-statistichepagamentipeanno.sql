
/****** Object:  UserDefinedFunction [dbo].[GetCollectsByYear]    Script Date: 11/05/2012 17:04:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[GetCollectsByYear](@myYear int)
RETURNS TABLE 
AS
RETURN 
(
	select * from dbo.GetPaymentStatsByMonth(1,@myYear)
union all
	select * from dbo.GetPaymentStatsByMonth(2,@myYear)
union all
	select * from dbo.GetPaymentStatsByMonth(3,@myYear)
union all
	select * from dbo.GetPaymentStatsByMonth(4,@myYear)
union all
	select * from dbo.GetPaymentStatsByMonth(5,@myYear)
union all
	select * from dbo.GetPaymentStatsByMonth(6,@myYear)
union all
	select * from dbo.GetPaymentStatsByMonth(7,@myYear)
union all
	select * from dbo.GetPaymentStatsByMonth(8,@myYear)
union all
	select * from dbo.GetPaymentStatsByMonth(9,@myYear)
union all
	select * from dbo.GetPaymentStatsByMonth(10,@myYear)
union all
	select * from dbo.GetPaymentStatsByMonth(11,@myYear)
union all
	select * from dbo.GetPaymentStatsByMonth(12,@myYear)

)
