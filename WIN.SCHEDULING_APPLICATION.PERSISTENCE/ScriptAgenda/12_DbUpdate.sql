UPDATE [App].[dbo].[NOESIS_UPDATE_CENTER]
   SET [DB_VERSION] = '1.5.0.0'
      ,[SOFTWARE_VERSION] = '1.5.0.0'
      ,[LAST_UPDATE] = GetDate()
      ,[DB_UPDATE_PATH] = ''
      ,[SOFTWARE_UPDATE_PATH] = ''
 WHERE ID = 1