/*
   venerdì 15 luglio 201111.21.16
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
ALTER TABLE dbo.InstallationInfo ADD
	HardwareId nvarchar(200) NULL
GO
COMMIT
select Has_Perms_By_Name(N'dbo.InstallationInfo', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.InstallationInfo', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.InstallationInfo', 'Object', 'CONTROL') as Contr_Per 