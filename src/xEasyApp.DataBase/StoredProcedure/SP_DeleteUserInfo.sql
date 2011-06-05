USE [xEasyApp]
GO

/****** Object:  StoredProcedure [dbo].[SP_DeleteUserInfo]    Script Date: 06/05/2011 16:27:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_DeleteUserInfo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_DeleteUserInfo]
GO

USE [xEasyApp]
GO

/****** Object:  StoredProcedure [dbo].[SP_DeleteUserInfo]    Script Date: 06/05/2011 16:27:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<xuanye>
-- Create date: <2011-06-01>
-- Description:	<删除用户信息>
-- =============================================
CREATE PROCEDURE [dbo].[SP_DeleteUserInfo]
	@UserUID varchar(50)
AS
BEGIN
	DELETE FROM RoleUserRelation WHERE UserUID=@UserUID
	DELETE FROM UserInfos WHERE UserUID=@UserUID
END


GO


