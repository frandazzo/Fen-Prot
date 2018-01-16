/*
   giovedì 21 luglio 201117.03.24
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
ALTER TABLE dbo.App_DocScope ADD
	DefaultPath nvarchar(MAX) NULL
GO
COMMIT
select Has_Perms_By_Name(N'dbo.App_DocScope', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.App_DocScope', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.App_DocScope', 'Object', 'CONTROL') as Contr_Per 