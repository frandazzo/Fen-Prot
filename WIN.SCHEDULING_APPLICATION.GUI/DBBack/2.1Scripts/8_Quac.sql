USE [App]
GO
/****** Object:  Table [dbo].[Amm_Quac]    Script Date: 04/15/2012 01:04:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Amm_Quac](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Data] [datetime] NOT NULL,
	[Importo] [float] NULL,
	[Id_Provincia] [int] NULL,
	[NomeProvincia] [nvarchar](150) NULL,
	[Id_Regione] [int] NULL,
	[Nomeregione] [nvarchar](150) NULL,
	[Note] [nvarchar](max) NULL,
	[Id_CausaleAmministrazione] [int] NULL,
 CONSTRAINT [PK_Amm_Quac] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Amm_Quac]  WITH CHECK ADD  CONSTRAINT [FK_Amm_Quac_Amm_CausaliAmministrazione] FOREIGN KEY([Id_CausaleAmministrazione])
REFERENCES [dbo].[Amm_CausaliAmministrazione] ([ID])
GO
ALTER TABLE [dbo].[Amm_Quac] CHECK CONSTRAINT [FK_Amm_Quac_Amm_CausaliAmministrazione]