/*
   mercoledì 29 giugno 201112.08.20
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
select Has_Perms_By_Name(N'dbo.App_Customers', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.App_Customers', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.App_Customers', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
COMMIT
select Has_Perms_By_Name(N'dbo.App_Documents', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.App_Documents', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.App_Documents', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE dbo.App_Destinations
	(
	ID int NOT NULL IDENTITY (1, 1),
	DocumentID int NULL,
	ContactID int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.App_Destinations ADD CONSTRAINT
	PK_App_Destinations PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.App_Destinations ADD CONSTRAINT
	FK_App_Destinations_App_Documents FOREIGN KEY
	(
	DocumentID
	) REFERENCES dbo.App_Documents
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  CASCADE 
	
GO
ALTER TABLE dbo.App_Destinations ADD CONSTRAINT
	FK_App_Destinations_App_Customers FOREIGN KEY
	(
	ContactID
	) REFERENCES dbo.App_Customers
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.App_Destinations', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.App_Destinations', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.App_Destinations', 'Object', 'CONTROL') as Contr_Per 