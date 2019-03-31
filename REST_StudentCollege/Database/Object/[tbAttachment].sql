USE [Rest_StudentCollege]
GO

/****** Object:  Table [dbo].[tbAttachment]    Script Date: 31/3/2019 12:28:38 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbAttachment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fileName] [varchar](200) NOT NULL,
	[fileType] [varchar](100) NOT NULL,
	[registrationId] [int] NOT NULL,
	[file] [varbinary](max) NOT NULL,
	[dateCreated] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


