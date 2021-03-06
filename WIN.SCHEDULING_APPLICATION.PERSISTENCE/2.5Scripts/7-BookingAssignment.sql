
/****** Object:  Table [dbo].[Book_Assignment]    Script Date: 11/05/2012 16:36:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book_Assignment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Id_Booking] [int] NULL,
	[StartDate] [smalldatetime] NULL,
	[EndDate] [smalldatetime] NULL,
	[Description] [nvarchar](max) NULL,
	[Id_Resource] [int] NOT NULL,
	[Id_BedType] [int] NULL,
 CONSTRAINT [PK_Book_Assignment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Book_Assignment]  WITH CHECK ADD  CONSTRAINT [FK_Book_Assignment_Book_Booking] FOREIGN KEY([Id_Booking])
REFERENCES [dbo].[Book_Booking] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Book_Assignment] CHECK CONSTRAINT [FK_Book_Assignment_Book_Booking]
GO
ALTER TABLE [dbo].[Book_Assignment]  WITH CHECK ADD  CONSTRAINT [FK_Book_Assignment_Book_BookingBedTypes] FOREIGN KEY([Id_BedType])
REFERENCES [dbo].[Book_BookingBedTypes] ([ID])
GO
ALTER TABLE [dbo].[Book_Assignment] CHECK CONSTRAINT [FK_Book_Assignment_Book_BookingBedTypes]
GO
ALTER TABLE [dbo].[Book_Assignment]  WITH CHECK ADD  CONSTRAINT [FK_Book_Assignment_Book_Resources] FOREIGN KEY([Id_Resource])
REFERENCES [dbo].[Book_Resources] ([ID])
GO
ALTER TABLE [dbo].[Book_Assignment] CHECK CONSTRAINT [FK_Book_Assignment_Book_Resources]