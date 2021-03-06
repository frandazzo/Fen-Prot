
/****** Object:  UserDefinedFunction [dbo].[ConstructDate]    Script Date: 11/05/2012 16:44:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[ConstructDate] 
(
	-- Add the parameters for the function here
	@myYear INT,
	@myMonth INT,
	@myDay INT
)
RETURNS smalldatetime
AS
BEGIN
	-- Declare the return variable here
	DECLARE @rtDate smalldatetime

	-- Add the T-SQL statements to compute the return value here
	SET @rtDate = CAST(
		RIGHT('0' + CAST(@myDay AS VARCHAR(2)), 2) + '/' +
		RIGHT('0' + CAST(@myMonth AS VARCHAR(2)), 2) + '/' +
      CAST(@myYear AS VARCHAR(4))  
   AS DATETIME)

	-- Return the result of the function
	RETURN @rtDate

END
