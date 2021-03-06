USE [App]
GO
/****** Object:  Table [dbo].[Amm_ImpegniTesseramento]    Script Date: 04/15/2012 01:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Amm_ImpegniTesseramento](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Anno] [int] NOT NULL,
	[Id_Provincia] [int] NULL,
	[NomeProvincia] [nvarchar](150) NULL,
	[Id_Regione] [int] NULL,
	[NomeRegione] [nvarchar](150) NULL,
	[TessereRichieste] [int] NULL,
	[Gennaio] [float] NULL,
	[Febbraio] [float] NULL,
	[Marzo] [float] NULL,
	[Aprile] [float] NULL,
	[Maggio] [float] NULL,
	[Giugno] [float] NULL,
	[Luglio] [float] NULL,
	[Agosto] [float] NULL,
	[Settembre] [float] NULL,
	[Ottobre] [float] NULL,
	[Novembre] [float] NULL,
	[Dicembre] [float] NULL,
	[Altro] [float] NULL,
	[Totale] [float] NULL,
 CONSTRAINT [PK_Amm_ImpegniTesseramento] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
