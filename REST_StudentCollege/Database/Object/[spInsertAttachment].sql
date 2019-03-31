SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE spInsertAttachment
	@filename varchar(200),
	@filetype varchar(100),
	@registrationId int,
	@file varbinary(max)
AS
BEGIN
	begin try
		insert into tbAttachment
		values (@filename, @filetype, @registrationId, @file, getdate())
	end try

	begin catch
		declare @errorNo int, @message varchar(4000), @currentDate datetime;
		set @errorNo = ERROR_NUMBER();
		set @message = ERROR_MESSAGE();
		set @currentDate = GETDATE();
		exec spInsertErrorLog @errorNo, @message, '[dbo].[spInsertAttachment]', @currentDate;
	end catch
END
GO
