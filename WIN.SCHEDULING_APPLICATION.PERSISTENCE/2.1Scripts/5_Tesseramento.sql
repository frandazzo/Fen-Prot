USE [App]
GO
/****** Object:  Table [dbo].[Amm_Tesseramento]    Script Date: 04/15/2012 01:05:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Amm_Tesseramento](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Anno] [int] NOT NULL,
	[NumeroTessere] [int] NULL,
	[CostoTessere] [float] NULL,
	[QuotaUIL] [float] NULL,
 CONSTRAINT [PK_Amm_Tesseramento] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
