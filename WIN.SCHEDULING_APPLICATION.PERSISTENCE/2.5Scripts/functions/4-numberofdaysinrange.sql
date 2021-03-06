
/****** Object:  UserDefinedFunction [dbo].[NumberOfDaysInDataRangeIntersection]    Script Date: 11/05/2012 16:43:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
Create FUNCTION [dbo].[NumberOfDaysInDataRangeIntersection] 
(
	-- Add the parameters for the function here
	@myRange1Start smalldatetime,
	@myRange1End smalldatetime,
	@myRange2Start smalldatetime,
	@myRange2End smalldatetime
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @rt int

	-- Add the T-SQL statements to compute the return value here
	set @rt = (select count(*) from Book_CalendarDate where CalendarDate between @myRange1Start and @myRange1End
 and CalendarDate between @myRange2Start and @myRange2End)

	-- Return the result of the function
	RETURN @rt

END
