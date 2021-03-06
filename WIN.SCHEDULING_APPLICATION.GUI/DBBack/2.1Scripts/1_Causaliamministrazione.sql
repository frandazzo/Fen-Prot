USE [App]
GO
/****** Object:  Table [dbo].[Amm_CausaliAmministrazione]    Script Date: 04/15/2012 01:00:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Amm_CausaliAmministrazione](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Descrizione] [nvarchar](150) NULL,
	[TipoCausale] [int] NULL,
 CONSTRAINT [PK_Amm_CausaliAmministrazione] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
