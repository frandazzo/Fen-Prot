
/****** Object:  UserDefinedFunction [dbo].[udf_GetNomeMese]    Script Date: 11/05/2012 16:43:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[udf_GetNomeMese] 
(
	-- Add the parameters for the function here
	@myMonth int
)
RETURNS nvarchar(50)
AS
BEGIN
	
		if (@myMonth = 1)
			RETURN '01 - Gennaio';
if (@myMonth = 2)
			RETURN '02 - Febbraio';
if (@myMonth = 3)
			RETURN '03 - Marzo';
if (@myMonth = 4)
			RETURN '04 - Aprile';
if (@myMonth = 5)
			RETURN '05 - Maggio';
if (@myMonth = 6)
			RETURN '06 - Giugno';
if (@myMonth = 7)
			RETURN '07 - Luglio';
if (@myMonth = 8)
			RETURN '08 - Agosto';
if (@myMonth = 9)
			RETURN '09 - Settembre';
if (@myMonth = 10)
			RETURN '10 - Ottobre';
if (@myMonth = 11)
			RETURN '11 - Novembre';
if (@myMonth = 12)
			RETURN '12 - Dicembre';

return '';

END
