/*
   venerdì 15 luglio 201117.43.34
   User: 
   Server: NOESIS4\NOESIS
   Database: App
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.App_LastProtocols
	(
	Year int NOT NULL,
	Protocol int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.App_LastProtocols ADD CONSTRAINT
	PK_App_LastProtocols PRIMARY KEY CLUSTERED 
	(
	Year
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.App_LastProtocols', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.App_LastProtocols', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.App_LastProtocols', 'Object', 'CONTROL') as Contr_Per 