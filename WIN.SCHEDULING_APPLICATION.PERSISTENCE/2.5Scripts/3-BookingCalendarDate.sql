
/****** Object:  Table [dbo].[Book_CalendarDate]    Script Date: 11/05/2012 16:33:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book_CalendarDate](
	[CalendarDate] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Book_CalendarDate] PRIMARY KEY CLUSTERED 
(
	[CalendarDate] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
