
/****** Object:  UserDefinedFunction [dbo].[ufn_CreateDataRange]    Script Date: 11/05/2012 16:45:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[ufn_CreateDataRange]
                 ( @myMonth int,
					@myYear int 
				)
RETURNS table
AS
RETURN (
        SELECT dbo.ConstructDate(@myYear,@mymonth,1) as DateStart, 
			   dbo.ConstructDate(@myYear,@mymonth, dbo.udf_GetNumDaysInMonthSimplified(@myYear,@myMonth)) as DateEnd
       );
