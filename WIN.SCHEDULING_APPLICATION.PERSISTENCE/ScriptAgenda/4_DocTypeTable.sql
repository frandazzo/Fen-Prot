/*
   mercoledì 29 giugno 201111.21.14
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
CREATE TABLE dbo.Tmp_App_DocType
	(
	ID int NOT NULL IDENTITY (1, 1),
	DocTypeName nvarchar(50) NULL,
	Color int NULL,
	CreatedBy nvarchar(50) NULL,
	CreatedOn datetime NULL,
	ModifiedBy nvarchar(50) NULL,
	ModifiedOn datetime NULL,
	NotDeletable bit NULL
	)  ON [PRIMARY]
GO
SET IDENTITY_INSERT dbo.Tmp_App_DocType ON
GO
IF EXISTS(SELECT * FROM dbo.App_DocType)
	 EXEC('INSERT INTO dbo.Tmp_App_DocType (ID, DocTypeName, Color, CreatedBy, CreatedOn, ModifiedOn, NotDeletable)
		SELECT ID, DocTypeName, Color, CreatedBy, CreatedOn, CONVERT(datetime, ModifiedOn), NotDeletable FROM dbo.App_DocType WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_App_DocType OFF
GO
DROP TABLE dbo.App_DocType
GO
EXECUTE sp_rename N'dbo.Tmp_App_DocType', N'App_DocType', 'OBJECT' 
GO
ALTER TABLE dbo.App_DocType ADD CONSTRAINT
	PK_App_DocType PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.App_DocType', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.App_DocType', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.App_DocType', 'Object', 'CONTROL') as Contr_Per 