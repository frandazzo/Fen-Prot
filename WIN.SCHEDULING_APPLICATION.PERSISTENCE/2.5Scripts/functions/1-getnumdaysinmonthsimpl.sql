
/****** Object:  UserDefinedFunction [dbo].[udf_GetNumDaysInMonthSimplified]    Script Date: 11/05/2012 16:42:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
Create FUNCTION [dbo].[udf_GetNumDaysInMonthSimplified] ( @myYear int, @myMonth int )
RETURNS INT
AS
BEGIN
DECLARE @rtDate INT
SET @rtDate = CASE WHEN @myMonth
IN (1, 3, 5, 7, 8, 10, 12) THEN 31
WHEN @myMonth IN (4, 6, 9, 11) THEN 30
ELSE CASE WHEN (@myYear % 4 = 0
AND
@myYear % 100 != 0)
OR
(@myYear % 400 = 0)
THEN 29
ELSE 28 END
END
RETURN @rtDate
END
