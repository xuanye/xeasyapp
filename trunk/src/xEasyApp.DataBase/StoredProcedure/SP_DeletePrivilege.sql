USE [xEasyApp]
GO

/****** Object:  StoredProcedure [dbo].[SP_DeletePrivilege]    Script Date: 06/05/2011 16:35:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_DeletePrivilege]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_DeletePrivilege]
GO

USE [xEasyApp]
GO

/****** Object:  StoredProcedure [dbo].[SP_DeletePrivilege]    Script Date: 06/05/2011 16:35:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<xuanye>
-- Create date: <2011-06-04>
-- Description:	<删除权限>
-- =============================================
CREATE PROCEDURE [dbo].[SP_DeletePrivilege]
	@PrivilegeCode Varchar(20)
AS
BEGIN
	IF  not Exists (Select 1 From Privileges where PrivilegeCode=@PrivilegeCode)
	BEGIN
		 RAISERROR ('权限不存在或者已经被删除', 16, 1)
		 RETURN
	END
	ELSE
	BEGIN
		Delete From RolePrivilegeRelation where PrivilegeCode=@PrivilegeCode
		Delete From Privileges where PrivilegeCode=@PrivilegeCode
	END
END

GO


