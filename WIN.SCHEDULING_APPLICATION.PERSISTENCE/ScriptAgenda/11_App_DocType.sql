INSERT INTO [App].[dbo].[App_DocType]
           ([DocTypeName]
           ,[Color]
           ,[CreatedBy]
           ,[CreatedOn]
           ,[ModifiedBy]
           ,[ModifiedOn]
           ,[NotDeletable])
     VALUES
           ('(NESSUNA)'
           ,-1
           ,'Admin'
           ,GetDate()
           ,'Admin'
           ,GetDate()
           ,1)