/*
   mercoledì 6 luglio 201110.56.21
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
ALTER TABLE dbo.App_Documents
	DROP CONSTRAINT FK_App_Documents_App_Operators
GO
COMMIT
select Has_Perms_By_Name(N'dbo.App_Operators', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.App_Operators', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.App_Operators', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.App_Documents
	DROP CONSTRAINT FK_App_Documents_App_DocType
GO
COMMIT
select Has_Perms_By_Name(N'dbo.App_DocType', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.App_DocType', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.App_DocType', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.App_Documents
	DROP CONSTRAINT FK_App_Documents_App_DocScope
GO
COMMIT
select Has_Perms_By_Name(N'dbo.App_DocScope', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.App_DocScope', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.App_DocScope', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_App_Documents
	(
	ID int NOT NULL IDENTITY (1, 1),
	Subject nvarchar(250) NULL,
	DocDate datetime NULL,
	DocYear int NULL,
	ScopeID int NULL,
	Responsable nvarchar(150) NULL,
	OperatorID int NULL,
	DestinationList nvarchar(MAX) NULL,
	AttachmentList nvarchar(MAX) NULL,
	DocVersus int NULL,
	DocTypeID int NULL,
	Priority int NULL,
	DocBody varbinary(MAX) NULL,
	CreatedBy nvarchar(50) NULL,
	CreatedOn datetime NULL,
	ModifiedBy nvarchar(50) NULL,
	ModifiedOn datetime NULL,
	Protocol nvarchar(50) NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT dbo.Tmp_App_Documents ON
GO
IF EXISTS(SELECT * FROM dbo.App_Documents)
	 EXEC('INSERT INTO dbo.Tmp_App_Documents (ID, Subject, DocDate, DocYear, ScopeID, Responsable, OperatorID, DestinationList, AttachmentList, DocVersus, DocTypeID, Priority, DocBody, CreatedBy, CreatedOn, ModifiedBy, ModifiedOn, Protocol)
		SELECT ID, Subject, DocDate, DocYear, ScopeID, CONVERT(nvarchar(150), Responsable), OperatorID, DestinationList, AttachmentList, DocVersus, DocTypeID, Priority, DocBody, CreatedBy, CreatedOn, ModifiedBy, ModifiedOn, Protocol FROM dbo.App_Documents WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_App_Documents OFF
GO
ALTER TABLE dbo.App_Destinations
	DROP CONSTRAINT FK_App_Destinations_App_Documents
GO
DROP TABLE dbo.App_Documents
GO
EXECUTE sp_rename N'dbo.Tmp_App_Documents', N'App_Documents', 'OBJECT' 
GO
ALTER TABLE dbo.App_Documents ADD CONSTRAINT
	PK_App_Documents PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

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
select Has_Perms_By_Name(N'dbo.App_Documents', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.App_Documents', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.App_Documents', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
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
COMMIT
select Has_Perms_By_Name(N'dbo.App_Destinations', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.App_Destinations', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.App_Destinations', 'Object', 'CONTROL') as Contr_Per 