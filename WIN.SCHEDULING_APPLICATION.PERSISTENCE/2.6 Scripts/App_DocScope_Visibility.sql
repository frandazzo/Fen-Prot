/*
   giovedì 29 giugno 201716:55:34
   Utente: RegUsr
   Server: .\NOESIS
   Database: App
   Applicazione: 
*/

/* Per evitare potenziali problemi di perdita di dati, si consiglia di esaminare dettagliatamente lo script prima di eseguirlo al di fuori del contesto di Progettazione database.*/
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
	Visibility nvarchar(MAX) NULL
GO
COMMIT
