USE [Rest_StudentCollege]
GO

/****** Object:  Table [dbo].[tbStudentRegistration]    Script Date: 30/3/2019 9:28:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbStudentRegistration](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NULL,
	[state] [varchar](50) NULL,
	[score] [int] NULL,
	[gpa] [int] NULL
) ON [PRIMARY]
GO


