
/****** Object:  Table [dbo].[Book_Booking]    Script Date: 11/05/2012 16:36:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book_Booking](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [smalldatetime] NULL,
	[Notes] [nvarchar](100) NULL,
	[Id_BookingType] [int] NULL,
	[Id_Operator] [int] NULL,
	[Color] [int] NULL,
	[Confirmed] [bit] NULL,
	[ColorBookings] [bit] NULL,
	[Notes1] [nvarchar](max) NULL,
	[State] [int] NULL,
 CONSTRAINT [PK_Book_Booking] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Book_Booking]  WITH CHECK ADD  CONSTRAINT [FK_Book_Booking_App_Operators] FOREIGN KEY([Id_Operator])
REFERENCES [dbo].[App_Operators] ([ID])
GO
ALTER TABLE [dbo].[Book_Booking] CHECK CONSTRAINT [FK_Book_Booking_App_Operators]
GO
ALTER TABLE [dbo].[Book_Booking]  WITH CHECK ADD  CONSTRAINT [FK_Book_Booking_Book_BookingType] FOREIGN KEY([Id_BookingType])
REFERENCES [dbo].[Book_BookingType] ([ID])
GO
ALTER TABLE [dbo].[Book_Booking] CHECK CONSTRAINT [FK_Book_Booking_Book_BookingType]