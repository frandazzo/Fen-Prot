
/****** Object:  Table [dbo].[Book_BookingPaymentType]    Script Date: 11/05/2012 16:34:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book_BookingPaymentType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Descrizione] [nvarchar](100) NULL,
 CONSTRAINT [PK_Book_BookingPaymentType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
