
/****** Object:  Table [dbo].[Book_BookingPayment]    Script Date: 11/05/2012 16:37:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book_BookingPayment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Id_Booking] [int] NULL,
	[DataAcconto] [smalldatetime] NULL,
	[Acconto] [float] NULL,
	[Id_MezzoPagamentoAcconto] [int] NULL,
	[DataSaldo] [smalldatetime] NULL,
	[Saldo] [float] NULL,
	[Id_MezzoPagamentoSaldo] [int] NULL,
	[TassaSoggiorno] [float] NULL,
	[Totale] [float] NULL,
 CONSTRAINT [PK_Book_BookingPayment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Book_BookingPayment]  WITH CHECK ADD  CONSTRAINT [FK_Book_BookingPayment_Book_Booking] FOREIGN KEY([Id_Booking])
REFERENCES [dbo].[Book_Booking] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Book_BookingPayment] CHECK CONSTRAINT [FK_Book_BookingPayment_Book_Booking]
GO
ALTER TABLE [dbo].[Book_BookingPayment]  WITH CHECK ADD  CONSTRAINT [FK_Book_BookingPayment_Book_BookingPaymentType] FOREIGN KEY([Id_MezzoPagamentoAcconto])
REFERENCES [dbo].[Book_BookingPaymentType] ([ID])
GO
ALTER TABLE [dbo].[Book_BookingPayment] CHECK CONSTRAINT [FK_Book_BookingPayment_Book_BookingPaymentType]
GO
ALTER TABLE [dbo].[Book_BookingPayment]  WITH CHECK ADD  CONSTRAINT [FK_Book_BookingPayment_Book_BookingPaymentType1] FOREIGN KEY([Id_MezzoPagamentoSaldo])
REFERENCES [dbo].[Book_BookingPaymentType] ([ID])
GO
ALTER TABLE [dbo].[Book_BookingPayment] CHECK CONSTRAINT [FK_Book_BookingPayment_Book_BookingPaymentType1]