UPDATE [dbo].[NOESIS_UPDATE_CENTER]
   SET [DB_VERSION] = '2.6.0.0'
      ,[SOFTWARE_VERSION] = '5.0.0.0'
      ,[LAST_UPDATE] = getDate()
      ,[DB_UPDATE_PATH] = ''
      ,[SOFTWARE_UPDATE_PATH] = ''
 WHERE ID = 1