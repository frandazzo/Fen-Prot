/*
   mercoledì 29 giugno 201111.34.44
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
CREATE TABLE dbo.App_Documents
	(
	ID int NOT NULL IDENTITY (1, 1),
	Subject nvarchar(250) NULL,
	DocDate datetime NULL,
	Year int NULL,
	ScopeID int NULL,
	Responsable int NULL,
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
ALTER TABLE dbo.App_Documents ADD CONSTRAINT
	PK_App_Documents PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.App_Documents', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.App_Documents', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.App_Documents', 'Object', 'CONTROL') as Contr_Per 