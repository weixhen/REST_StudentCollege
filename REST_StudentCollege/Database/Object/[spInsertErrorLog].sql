USE [Rest_StudentCollege]
GO

/****** Object:  StoredProcedure [dbo].[spInsertErrorLog]    Script Date: 30/3/2019 9:29:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spInsertErrorLog]
	@errorNo int,
	@message varchar(100),
	@objectName varchar(100),
	@currentDate datetime
AS
BEGIN

	SET NOCOUNT ON;

    insert into tbErrorLog
	values(@errorNo, @message, @objectName, @currentDate)
END
GO


