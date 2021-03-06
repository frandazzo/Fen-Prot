
/****** Object:  UserDefinedFunction [dbo].[TempDateTable]    Script Date: 11/05/2012 16:47:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[TempDateTable]
(
  @FirstDate	datetime,
  @LastDate	datetime
)
RETURNS @datetable TABLE (
  [date] smalldatetime
)
AS
BEGIN

  SELECT @FirstDate = DATEADD(dd, 0, DATEDIFF(dd, 0, @FirstDate));   SELECT @LastDate = DATEADD(dd, 0, DATEDIFF(dd, 0, @LastDate)); 
  WITH CTE_DatesTable
  AS 
  (
    SELECT @FirstDate AS [date]
    UNION ALL
    SELECT DATEADD(dd, 1, [date])
    FROM CTE_DatesTable
    WHERE DATEADD(dd, 1, [date]) <= @LastDate
  )
  INSERT INTO @datetable ([date])
  SELECT [date] FROM CTE_DatesTable
  OPTION (MAXRECURSION 0)

  RETURN
END

