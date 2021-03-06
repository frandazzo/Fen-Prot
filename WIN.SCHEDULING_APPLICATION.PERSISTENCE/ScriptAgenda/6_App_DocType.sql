/*
   mercoledì 29 giugno 201111.57.58
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
COMMIT
select Has_Perms_By_Name(N'dbo.App_Operators', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.App_Operators', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.App_Operators', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
COMMIT
select Has_Perms_By_Name(N'dbo.App_DocScope', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.App_DocScope', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.App_DocScope', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
COMMIT
select Has_Perms_By_Name(N'dbo.App_DocType', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.App_DocType', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.App_DocType', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
EXECUTE sp_rename N'dbo.App_Documents.Year', N'Tmp_DocYear', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.App_Documents.Tmp_DocYear', N'DocYear', 'COLUMN' 
GO
CREATE NONCLUSTERED INDEX IX_App_Documents_Year ON dbo.App_Documents
	(
	DocYear
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_App_Documents_Scope_Type_Date ON dbo.App_Documents
	(
	DocDate,
	DocTypeID,
	ScopeID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_App_Documents_Subject ON dbo.App_Documents
	(
	Subject
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE dbo.App_Documents ADD CONSTRAINT
	FK_App_Documents_App_DocScope FOREIGN KEY
	(
	ScopeID
	) REFERENCES dbo.App_DocScope
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.App_Documents ADD CONSTRAINT
	FK_App_Documents_App_DocType FOREIGN KEY
	(
	DocTypeID
	) REFERENCES dbo.App_DocType
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.App_Documents ADD CONSTRAINT
	FK_App_Documents_App_Operators FOREIGN KEY
	(
	OperatorID
	) REFERENCES dbo.App_Operators
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.App_Documents', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.App_Documents', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.App_Documents', 'Object', 'CONTROL') as Contr_Per 