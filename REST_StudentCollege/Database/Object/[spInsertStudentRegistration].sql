USE [Rest_StudentCollege]
GO

/****** Object:  StoredProcedure [dbo].[spInsertStudentRegistration]    Script Date: 31/3/2019 12:28:57 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spInsertStudentRegistration]
	@name varchar(100),
	@state varchar(50),
	@score int,
	@gpa int
AS
BEGIN
	SET NOCOUNT ON;

	begin try
		declare @registrationId as int;

		set @registrationId = @@IDENTITY
		insert into tbStudentRegistration
		values(@registrationId,@name,@state,@score,@gpa)
		return @registrationId;
	end try
	begin catch
		declare @errorNo int, @message varchar(4000), @currentDate datetime;
		set @errorNo = ERROR_NUMBER();
		set @message = ERROR_MESSAGE();
		set @currentDate = GETDATE();
		exec spInsertErrorLog @errorNo, @message, '[dbo].[spInsertStudentRegistration]', @currentDate;
	end catch
END


GO


