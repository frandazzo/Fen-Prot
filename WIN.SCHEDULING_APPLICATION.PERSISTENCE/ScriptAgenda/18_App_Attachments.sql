/*
   giovedì 21 luglio 201110.58.05
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
select Has_Perms_By_Name(N'dbo.App_Documents', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.App_Documents', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.App_Documents', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE dbo.App_Attachments
	(
	ID int NOT NULL IDENTITY (1, 1),
	DocumentId int NULL,
	Path nvarchar(MAX) NULL,
	FileName nvarchar(MAX) NULL,
	Notes nvarchar(MAX) NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.App_Attachments ADD CONSTRAINT
	PK_App_Attachments PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.App_Attachments ADD CONSTRAINT
	FK_App_Attachments_App_Documents FOREIGN KEY
	(
	DocumentId
	) REFERENCES dbo.App_Documents
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.App_Attachments', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.App_Attachments', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.App_Attachments', 'Object', 'CONTROL') as Contr_Per 