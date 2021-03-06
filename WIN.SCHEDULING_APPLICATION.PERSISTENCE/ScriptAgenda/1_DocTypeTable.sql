/*
   mercoledì 29 giugno 201111.05.51
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
CREATE TABLE dbo.App_DocType
	(
	ID int NOT NULL,
	DocTypeName nvarchar(50) NULL,
	Color int NULL,
	CreatedBy nvarchar(50) NULL,
	CreatedOn datetime NULL,
	ModifiedOn nvarchar(50) NULL,
	NotDeletable bit NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.App_DocType ADD CONSTRAINT
	PK_App_DocType PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.App_DocType', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.App_DocType', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.App_DocType', 'Object', 'CONTROL') as Contr_Per 