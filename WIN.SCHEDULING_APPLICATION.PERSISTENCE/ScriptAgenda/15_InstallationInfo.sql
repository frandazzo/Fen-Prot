/****** Object:  Table [dbo].[InstallationInfo]    Script Date: 01/13/2009 20:34:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InstallationInfo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductVersion] [varchar](10) COLLATE Latin1_General_CI_AS NULL,
	[PackagePath] [varchar](255) COLLATE Latin1_General_CI_AS NULL,
	[ActivationDate] [datetime] NULL,
	[ActivationCode] [nvarchar](max) COLLATE Latin1_General_CI_AS NULL,
	[CustomerName] [nvarchar](max) COLLATE Latin1_General_CI_AS NULL,
	[TrialDays] [int] NULL,
	[Type] [int] NULL,
	[Start] [datetime] NULL,
	[Finish] [datetime] NULL,
	[Mail] [nvarchar](50) COLLATE Latin1_General_CI_AS NULL,
	[FirstRunDate] [datetime] NULL,
 CONSTRAINT [PK_VersionInfo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF