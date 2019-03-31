USE [Rest_StudentCollege]
GO

/****** Object:  Table [dbo].[tbErrorLog]    Script Date: 30/3/2019 9:28:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbErrorLog](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[errorNo] [int] NOT NULL,
	[errorMessage] [varchar](max) NOT NULL,
	[objectName] [varchar](100) NOT NULL,
	[createdDate] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


