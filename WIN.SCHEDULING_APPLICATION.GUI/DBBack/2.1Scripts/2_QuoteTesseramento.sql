USE [App]
GO
/****** Object:  Table [dbo].[Amm_QuoteTesseramento]    Script Date: 04/15/2012 01:04:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Amm_QuoteTesseramento](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Data] [datetime] NOT NULL,
	[Importo] [float] NULL,
	[Id_Provincia] [int] NULL,
	[NomeProvincia] [nvarchar](150) NULL,
	[Id_Regione] [int] NULL,
	[Nomeregione] [nvarchar](150) NULL,
	[Note] [nvarchar](max) NULL,
	[Id_CausaleAmministrazione] [int] NULL,
 CONSTRAINT [PK_QuoteTesseramento] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Amm_QuoteTesseramento]  WITH CHECK ADD  CONSTRAINT [FK_Amm_QuoteTesseramento_Amm_CausaliAmministrazione] FOREIGN KEY([Id_CausaleAmministrazione])
REFERENCES [dbo].[Amm_CausaliAmministrazione] ([ID])
GO
ALTER TABLE [dbo].[Amm_QuoteTesseramento] CHECK CONSTRAINT [FK_Amm_QuoteTesseramento_Amm_CausaliAmministrazione]