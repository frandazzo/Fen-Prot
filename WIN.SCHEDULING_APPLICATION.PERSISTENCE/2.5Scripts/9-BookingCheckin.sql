
/****** Object:  Table [dbo].[Book_Checkin]    Script Date: 11/05/2012 16:38:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book_Checkin](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Id_Contact] [int] NULL,
	[Id_Assignment] [int] NULL,
	[Checkin] [smalldatetime] NULL,
 CONSTRAINT [PK_Book_Checkin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Book_Checkin]  WITH CHECK ADD  CONSTRAINT [FK_Book_Checkin_App_Customers] FOREIGN KEY([Id_Contact])
REFERENCES [dbo].[App_Customers] ([ID])
GO
ALTER TABLE [dbo].[Book_Checkin] CHECK CONSTRAINT [FK_Book_Checkin_App_Customers]
GO
ALTER TABLE [dbo].[Book_Checkin]  WITH CHECK ADD  CONSTRAINT [FK_Book_Checkin_Book_Checkin] FOREIGN KEY([Id_Assignment])
REFERENCES [dbo].[Book_Assignment] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Book_Checkin] CHECK CONSTRAINT [FK_Book_Checkin_Book_Checkin]