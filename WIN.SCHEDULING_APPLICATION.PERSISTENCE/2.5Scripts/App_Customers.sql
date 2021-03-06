/*
   martedì 30 ottobre 201220.00.03
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
ALTER TABLE dbo.App_Customers ADD
	SESSO int NULL,
	DATA_NASCITA datetime NULL,
	ID_TB_NAZIONI int NULL,
	ID_TB_PROVINCIE_NASCITA int NULL,
	ID_TB_COMUNI_NASCITA int NULL,
	ID_TB_NAZIONI_RESIDENZA int NULL
GO
COMMIT
