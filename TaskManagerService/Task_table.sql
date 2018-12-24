USE [ReportServer]
GO

/****** Object:  Table [dbo].[Task]    Script Date: 12/24/2018 9:08:46 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Task](
	[Task_ID] [int] IDENTITY(1,1) NOT NULL,
	[Parent_ID] [int] NULL,
	[Task_Description] [varchar](50) NOT NULL,
	[Start_Date] [date] NOT NULL,
	[End_Date] [date] NOT NULL,
	[Priority] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Task_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


