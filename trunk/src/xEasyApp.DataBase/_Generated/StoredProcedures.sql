



-- =============================================
-- 该代码文件有程序自动生成，
-- 生成时间: 2011-06-05 16:54:30
-- =============================================

USE [xEasyApp]
GO


/****** Object:  StoredProcedure [dbo].[SP_DeleteShortCut] ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_DeleteShortCut]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[SP_DeleteShortCut]
GO


/****** Object:  StoredProcedure [dbo].[SP_DeleteShortCut] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
--=====================================
-- 删除表 ShortCut 中的记录
--=====================================
CREATE PROCEDURE [dbo].[SP_DeleteShortCut]
		@ShortCutID INT
AS
BEGIN	
	IF  NOT EXISTS (SELECT 1 FROM [ShortCut] WHERE [ShortCutID]=@ShortCutID)
	BEGIN
		 RAISERROR ('记录不存在或者已经被删除', 16, 1)
		 RETURN
	END
	ELSE
	BEGIN
		DELETE FROM [ShortCut] WHERE  [ShortCutID]=@ShortCutID	
	END
END

GO
      

/****** Object:  StoredProcedure [dbo].[SP_SaveShortCut] ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_SaveShortCut]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[SP_SaveShortCut]
GO


/****** Object:  StoredProcedure [dbo].[SP_SaveShortCut]  ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
--=====================================
-- 将记录保存到 ShortCut 中
--=====================================
CREATE PROCEDURE [dbo].[SP_SaveShortCut]
	@ShortCutID  INT
	,@ShortCutName  NVARCHAR(200)
	,@Remark  NVARCHAR(2000)
	,@PrivilegeCode  VARCHAR(2000)
	,@UserUID  VARCHAR(50)
	,@LastModifyTime  DATETIME
	,@Sequence  INT
AS
BEGIN	
	IF  NOT EXISTS (SELECT 1 FROM [ShortCut] WHERE [ShortCutID]=@ShortCutID)
	BEGIN --修改
		UPDATE [ShortCut] SET [ShortCutName]=@ShortCutName,[Remark]=@Remark,[PrivilegeCode]=@PrivilegeCode,[UserUID]=@UserUID,[LastModifyTime]=@LastModifyTime,[Sequence]=@Sequence		
		WHERE [ShortCutID]=@ShortCutID 		
	END
	ELSE
	BEGIN  --新增
		INSERT INTO [ShortCut] 
			   ([ShortCutName],[Remark],[PrivilegeCode],[UserUID],[LastModifyTime],[Sequence])
		VALUES (@ShortCutName,@Remark,@PrivilegeCode,@UserUID,@LastModifyTime,@Sequence)
	END
END

GO

/****** Object:  StoredProcedure [dbo].[SP_DeleteDictInfos] ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_DeleteDictInfo]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[SP_DeleteDictInfo]
GO


/****** Object:  StoredProcedure [dbo].[SP_DeleteDictInfo] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
--=====================================
-- 删除表 DictInfos 中的记录
--=====================================
CREATE PROCEDURE [dbo].[SP_DeleteDictInfo]
		@DictID INT
AS
BEGIN	
	IF  NOT EXISTS (SELECT 1 FROM [DictInfos] WHERE [DictID]=@DictID)
	BEGIN
		 RAISERROR ('记录不存在或者已经被删除', 16, 1)
		 RETURN
	END
	ELSE
	BEGIN
		DELETE FROM [DictInfos] WHERE  [DictID]=@DictID	
	END
END

GO
      

/****** Object:  StoredProcedure [dbo].[SP_SaveDictInfo] ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_SaveDictInfo]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[SP_SaveDictInfo]
GO


/****** Object:  StoredProcedure [dbo].[SP_SaveDictInfo]  ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
--=====================================
-- 将记录保存到 DictInfos 中
--=====================================
CREATE PROCEDURE [dbo].[SP_SaveDictInfo]
	@DictID  INT
	,@DictName  VARCHAR(100)
	,@DictCode  VARCHAR(50)
	,@DictType  TINYINT
	,@ParentID  INT
	,@Sequence  INT
	,@SQLCMD  VARCHAR(4000)
	,@Remark  VARCHAR(200)
AS
BEGIN	
	IF  NOT EXISTS (SELECT 1 FROM [DictInfos] WHERE [DictID]=@DictID)
	BEGIN --修改
		UPDATE [DictInfos] SET [DictName]=@DictName,[DictCode]=@DictCode,[DictType]=@DictType,[ParentID]=@ParentID,[Sequence]=@Sequence,[SQLCMD]=@SQLCMD,[Remark]=@Remark		
		WHERE [DictID]=@DictID 		
	END
	ELSE
	BEGIN  --新增
		INSERT INTO [DictInfos] 
			   ([DictName],[DictCode],[DictType],[ParentID],[Sequence],[SQLCMD],[Remark])
		VALUES (@DictName,@DictCode,@DictType,@ParentID,@Sequence,@SQLCMD,@Remark)
	END
END

GO

/****** Object:  StoredProcedure [dbo].[SP_DeleteLogs] ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_DeleteLog]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[SP_DeleteLog]
GO


/****** Object:  StoredProcedure [dbo].[SP_DeleteLog] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
--=====================================
-- 删除表 Logs 中的记录
--=====================================
CREATE PROCEDURE [dbo].[SP_DeleteLog]
		@Id INT
AS
BEGIN	
	IF  NOT EXISTS (SELECT 1 FROM [Logs] WHERE [Id]=@Id)
	BEGIN
		 RAISERROR ('记录不存在或者已经被删除', 16, 1)
		 RETURN
	END
	ELSE
	BEGIN
		DELETE FROM [Logs] WHERE  [Id]=@Id	
	END
END

GO
      

/****** Object:  StoredProcedure [dbo].[SP_SaveLog] ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_SaveLog]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[SP_SaveLog]
GO


/****** Object:  StoredProcedure [dbo].[SP_SaveLog]  ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
--=====================================
-- 将记录保存到 Logs 中
--=====================================
CREATE PROCEDURE [dbo].[SP_SaveLog]
	@Id  INT
	,@Topic  NVARCHAR(400)
	,@Content  NVARCHAR(MAX)
	,@OperateCode  VARCHAR(100)
	,@LogType  TINYINT
	,@OperateUID  VARCHAR(20)
	,@OperateName  NVARCHAR(400)
	,@IPAddress  VARCHAR(15)
	,@OperateTime  DATETIME
AS
BEGIN	
	IF  NOT EXISTS (SELECT 1 FROM [Logs] WHERE [Id]=@Id)
	BEGIN --修改
		UPDATE [Logs] SET [Topic]=@Topic,[Content]=@Content,[OperateCode]=@OperateCode,[LogType]=@LogType,[OperateUID]=@OperateUID,[OperateName]=@OperateName,[IPAddress]=@IPAddress,[OperateTime]=@OperateTime		
		WHERE [Id]=@Id 		
	END
	ELSE
	BEGIN  --新增
		INSERT INTO [Logs] 
			   ([Topic],[Content],[OperateCode],[LogType],[OperateUID],[OperateName],[IPAddress],[OperateTime])
		VALUES (@Topic,@Content,@OperateCode,@LogType,@OperateUID,@OperateName,@IPAddress,@OperateTime)
	END
END

GO

/****** Object:  StoredProcedure [dbo].[SP_DeleteRolePrivilegeRelation] ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_DeleteRolePrivilegeRelation]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[SP_DeleteRolePrivilegeRelation]
GO


/****** Object:  StoredProcedure [dbo].[SP_DeleteRolePrivilegeRelation] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
--=====================================
-- 删除表 RolePrivilegeRelation 中的记录
--=====================================
CREATE PROCEDURE [dbo].[SP_DeleteRolePrivilegeRelation]
		@RoleCode VARCHAR(50)
	,	@PrivilegeCode VARCHAR(20)
AS
BEGIN	
	IF  NOT EXISTS (SELECT 1 FROM [RolePrivilegeRelation] WHERE [RoleCode]=@RoleCode AND [PrivilegeCode]=@PrivilegeCode)
	BEGIN
		 RAISERROR ('记录不存在或者已经被删除', 16, 1)
		 RETURN
	END
	ELSE
	BEGIN
		DELETE FROM [RolePrivilegeRelation] WHERE  [RoleCode]=@RoleCode AND [PrivilegeCode]=@PrivilegeCode	
	END
END

GO
      

/****** Object:  StoredProcedure [dbo].[SP_SaveRolePrivilegeRelation] ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_SaveRolePrivilegeRelation]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[SP_SaveRolePrivilegeRelation]
GO


/****** Object:  StoredProcedure [dbo].[SP_SaveRolePrivilegeRelation]  ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
--=====================================
-- 将记录保存到 RolePrivilegeRelation 中
--=====================================
CREATE PROCEDURE [dbo].[SP_SaveRolePrivilegeRelation]
	@RoleCode  VARCHAR(50)
	,@PrivilegeCode  VARCHAR(20)
	,@LastUpdateUserUID  VARCHAR(50)
	,@LastUpdateUserName  NVARCHAR(200)
	,@LastUpdateTime  DATETIME
AS
BEGIN	
	IF  NOT EXISTS (SELECT 1 FROM [RolePrivilegeRelation] WHERE [RoleCode]=@RoleCode AND [PrivilegeCode]=@PrivilegeCode)
	BEGIN --修改
		UPDATE [RolePrivilegeRelation] SET [LastUpdateUserUID]=@LastUpdateUserUID,[LastUpdateUserName]=@LastUpdateUserName,[LastUpdateTime]=@LastUpdateTime		
		WHERE [RoleCode]=@RoleCode  AND [PrivilegeCode]=@PrivilegeCode 		
	END
	ELSE
	BEGIN  --新增
		INSERT INTO [RolePrivilegeRelation] 
			   ([RoleCode],[PrivilegeCode],[LastUpdateUserUID],[LastUpdateUserName],[LastUpdateTime])
		VALUES (@RoleCode,@PrivilegeCode,@LastUpdateUserUID,@LastUpdateUserName,@LastUpdateTime)
	END
END

GO

/****** Object:  StoredProcedure [dbo].[SP_DeleteRoleUserRelation] ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_DeleteRoleUserRelation]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[SP_DeleteRoleUserRelation]
GO


/****** Object:  StoredProcedure [dbo].[SP_DeleteRoleUserRelation] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
--=====================================
-- 删除表 RoleUserRelation 中的记录
--=====================================
CREATE PROCEDURE [dbo].[SP_DeleteRoleUserRelation]
		@RoleCode VARCHAR(50)
	,	@UserUID VARCHAR(20)
AS
BEGIN	
	IF  NOT EXISTS (SELECT 1 FROM [RoleUserRelation] WHERE [RoleCode]=@RoleCode AND [UserUID]=@UserUID)
	BEGIN
		 RAISERROR ('记录不存在或者已经被删除', 16, 1)
		 RETURN
	END
	ELSE
	BEGIN
		DELETE FROM [RoleUserRelation] WHERE  [RoleCode]=@RoleCode AND [UserUID]=@UserUID	
	END
END

GO
      

/****** Object:  StoredProcedure [dbo].[SP_SaveRoleUserRelation] ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_SaveRoleUserRelation]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[SP_SaveRoleUserRelation]
GO


/****** Object:  StoredProcedure [dbo].[SP_SaveRoleUserRelation]  ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
--=====================================
-- 将记录保存到 RoleUserRelation 中
--=====================================
CREATE PROCEDURE [dbo].[SP_SaveRoleUserRelation]
	@RoleCode  VARCHAR(50)
	,@UserUID  VARCHAR(20)
	,@LastUpdateUserUID  VARCHAR(50)
	,@LastUpdateUserName  NVARCHAR(200)
	,@LastUpdateTime  DATETIME
AS
BEGIN	
	IF  NOT EXISTS (SELECT 1 FROM [RoleUserRelation] WHERE [RoleCode]=@RoleCode AND [UserUID]=@UserUID)
	BEGIN --修改
		UPDATE [RoleUserRelation] SET [LastUpdateUserUID]=@LastUpdateUserUID,[LastUpdateUserName]=@LastUpdateUserName,[LastUpdateTime]=@LastUpdateTime		
		WHERE [RoleCode]=@RoleCode  AND [UserUID]=@UserUID 		
	END
	ELSE
	BEGIN  --新增
		INSERT INTO [RoleUserRelation] 
			   ([RoleCode],[UserUID],[LastUpdateUserUID],[LastUpdateUserName],[LastUpdateTime])
		VALUES (@RoleCode,@UserUID,@LastUpdateUserUID,@LastUpdateUserName,@LastUpdateTime)
	END
END

GO

/****** Object:  StoredProcedure [dbo].[SP_DeleteDepartments] ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_DeleteDepartment]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[SP_DeleteDepartment]
GO


/****** Object:  StoredProcedure [dbo].[SP_DeleteDepartment] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
--=====================================
-- 删除表 Departments 中的记录
--=====================================
CREATE PROCEDURE [dbo].[SP_DeleteDepartment]
		@DeptCode VARCHAR(50)
AS
BEGIN	
	IF  NOT EXISTS (SELECT 1 FROM [Departments] WHERE [DeptCode]=@DeptCode)
	BEGIN
		 RAISERROR ('记录不存在或者已经被删除', 16, 1)
		 RETURN
	END
	ELSE
	BEGIN
		DELETE FROM [Departments] WHERE  [DeptCode]=@DeptCode	
	END
END

GO
      

/****** Object:  StoredProcedure [dbo].[SP_SaveDepartment] ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_SaveDepartment]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[SP_SaveDepartment]
GO


/****** Object:  StoredProcedure [dbo].[SP_SaveDepartment]  ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
--=====================================
-- 将记录保存到 Departments 中
--=====================================
CREATE PROCEDURE [dbo].[SP_SaveDepartment]
	@DeptCode  VARCHAR(50)
	,@DeptName  NVARCHAR(400)
	,@ParentCode  VARCHAR(50)
	,@Path  VARCHAR(1000)
	,@Remark  NVARCHAR(4000)
	,@Sequence  INT
	,@LastUpdateUserUID  VARCHAR(50)
	,@LastUpdateUserName  NVARCHAR(200)
	,@LastUpdateTime  DATETIME
AS
BEGIN	
	IF  NOT EXISTS (SELECT 1 FROM [Departments] WHERE [DeptCode]=@DeptCode)
	BEGIN --修改
		UPDATE [Departments] SET [DeptName]=@DeptName,[ParentCode]=@ParentCode,[Path]=@Path,[Remark]=@Remark,[Sequence]=@Sequence,[LastUpdateUserUID]=@LastUpdateUserUID,[LastUpdateUserName]=@LastUpdateUserName,[LastUpdateTime]=@LastUpdateTime		
		WHERE [DeptCode]=@DeptCode 		
	END
	ELSE
	BEGIN  --新增
		INSERT INTO [Departments] 
			   ([DeptCode],[DeptName],[ParentCode],[Path],[Remark],[Sequence],[LastUpdateUserUID],[LastUpdateUserName],[LastUpdateTime])
		VALUES (@DeptCode,@DeptName,@ParentCode,@Path,@Remark,@Sequence,@LastUpdateUserUID,@LastUpdateUserName,@LastUpdateTime)
	END
END

GO

/****** Object:  StoredProcedure [dbo].[SP_DeleteUserInfos] ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_DeleteUserInfo]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[SP_DeleteUserInfo]
GO


/****** Object:  StoredProcedure [dbo].[SP_DeleteUserInfo] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
--=====================================
-- 删除表 UserInfos 中的记录
--=====================================
CREATE PROCEDURE [dbo].[SP_DeleteUserInfo]
		@UserUID VARCHAR(20)
AS
BEGIN	
	IF  NOT EXISTS (SELECT 1 FROM [UserInfos] WHERE [UserUID]=@UserUID)
	BEGIN
		 RAISERROR ('记录不存在或者已经被删除', 16, 1)
		 RETURN
	END
	ELSE
	BEGIN
		DELETE FROM [UserInfos] WHERE  [UserUID]=@UserUID	
	END
END

GO
      

/****** Object:  StoredProcedure [dbo].[SP_SaveUserInfo] ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_SaveUserInfo]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[SP_SaveUserInfo]
GO


/****** Object:  StoredProcedure [dbo].[SP_SaveUserInfo]  ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
--=====================================
-- 将记录保存到 UserInfos 中
--=====================================
CREATE PROCEDURE [dbo].[SP_SaveUserInfo]
	@UserUID  VARCHAR(20)
	,@FullName  NVARCHAR(400)
	,@Password  VARCHAR(200)
	,@DeptCode  VARCHAR(50)
	,@DeptName  NVARCHAR(400)
	,@IsManager  TINYINT
	,@IsSystem  TINYINT
	,@Sequence  INT
	,@AccountState  TINYINT
	,@LastUpdateUserUID  VARCHAR(50)
	,@LastUpdateUserName  NVARCHAR(200)
	,@LastUpdateTime  DATETIME
AS
BEGIN	
	IF  NOT EXISTS (SELECT 1 FROM [UserInfos] WHERE [UserUID]=@UserUID)
	BEGIN --修改
		UPDATE [UserInfos] SET [FullName]=@FullName,[Password]=@Password,[DeptCode]=@DeptCode,[DeptName]=@DeptName,[IsManager]=@IsManager,[IsSystem]=@IsSystem,[Sequence]=@Sequence,[AccountState]=@AccountState,[LastUpdateUserUID]=@LastUpdateUserUID,[LastUpdateUserName]=@LastUpdateUserName,[LastUpdateTime]=@LastUpdateTime		
		WHERE [UserUID]=@UserUID 		
	END
	ELSE
	BEGIN  --新增
		INSERT INTO [UserInfos] 
			   ([UserUID],[FullName],[Password],[DeptCode],[DeptName],[IsManager],[IsSystem],[Sequence],[AccountState],[LastUpdateUserUID],[LastUpdateUserName],[LastUpdateTime])
		VALUES (@UserUID,@FullName,@Password,@DeptCode,@DeptName,@IsManager,@IsSystem,@Sequence,@AccountState,@LastUpdateUserUID,@LastUpdateUserName,@LastUpdateTime)
	END
END

GO

/****** Object:  StoredProcedure [dbo].[SP_DeletePrivileges] ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_DeletePrivilege]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[SP_DeletePrivilege]
GO


/****** Object:  StoredProcedure [dbo].[SP_DeletePrivilege] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
--=====================================
-- 删除表 Privileges 中的记录
--=====================================
CREATE PROCEDURE [dbo].[SP_DeletePrivilege]
		@PrivilegeCode VARCHAR(20)
AS
BEGIN	
	IF  NOT EXISTS (SELECT 1 FROM [Privileges] WHERE [PrivilegeCode]=@PrivilegeCode)
	BEGIN
		 RAISERROR ('记录不存在或者已经被删除', 16, 1)
		 RETURN
	END
	ELSE
	BEGIN
		DELETE FROM [Privileges] WHERE  [PrivilegeCode]=@PrivilegeCode	
	END
END

GO
      

/****** Object:  StoredProcedure [dbo].[SP_SavePrivilege] ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_SavePrivilege]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[SP_SavePrivilege]
GO


/****** Object:  StoredProcedure [dbo].[SP_SavePrivilege]  ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
--=====================================
-- 将记录保存到 Privileges 中
--=====================================
CREATE PROCEDURE [dbo].[SP_SavePrivilege]
	@PrivilegeCode  VARCHAR(20)
	,@PrivilegeName  NVARCHAR(200)
	,@PrivilegeType  TINYINT
	,@Remark  NVARCHAR(2000)
	,@ParentID  VARCHAR(20)
	,@Uri  VARCHAR(2000)
	,@Sequence  INT
	,@LastUpdateUserUID  VARCHAR(50)
	,@LastUpdateUserName  NVARCHAR(200)
	,@LastUpdateTime  DATETIME
AS
BEGIN	
	IF  NOT EXISTS (SELECT 1 FROM [Privileges] WHERE [PrivilegeCode]=@PrivilegeCode)
	BEGIN --修改
		UPDATE [Privileges] SET [PrivilegeName]=@PrivilegeName,[PrivilegeType]=@PrivilegeType,[Remark]=@Remark,[ParentID]=@ParentID,[Uri]=@Uri,[Sequence]=@Sequence,[LastUpdateUserUID]=@LastUpdateUserUID,[LastUpdateUserName]=@LastUpdateUserName,[LastUpdateTime]=@LastUpdateTime		
		WHERE [PrivilegeCode]=@PrivilegeCode 		
	END
	ELSE
	BEGIN  --新增
		INSERT INTO [Privileges] 
			   ([PrivilegeCode],[PrivilegeName],[PrivilegeType],[Remark],[ParentID],[Uri],[Sequence],[LastUpdateUserUID],[LastUpdateUserName],[LastUpdateTime])
		VALUES (@PrivilegeCode,@PrivilegeName,@PrivilegeType,@Remark,@ParentID,@Uri,@Sequence,@LastUpdateUserUID,@LastUpdateUserName,@LastUpdateTime)
	END
END

GO

/****** Object:  StoredProcedure [dbo].[SP_DeleteRoleInfos] ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_DeleteRoleInfo]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[SP_DeleteRoleInfo]
GO


/****** Object:  StoredProcedure [dbo].[SP_DeleteRoleInfo] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
--=====================================
-- 删除表 RoleInfos 中的记录
--=====================================
CREATE PROCEDURE [dbo].[SP_DeleteRoleInfo]
		@RoleCode VARCHAR(50)
AS
BEGIN	
	IF  NOT EXISTS (SELECT 1 FROM [RoleInfos] WHERE [RoleCode]=@RoleCode)
	BEGIN
		 RAISERROR ('记录不存在或者已经被删除', 16, 1)
		 RETURN
	END
	ELSE
	BEGIN
		DELETE FROM [RoleInfos] WHERE  [RoleCode]=@RoleCode	
	END
END

GO
      

/****** Object:  StoredProcedure [dbo].[SP_SaveRoleInfo] ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_SaveRoleInfo]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[SP_SaveRoleInfo]
GO


/****** Object:  StoredProcedure [dbo].[SP_SaveRoleInfo]  ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
--=====================================
-- 将记录保存到 RoleInfos 中
--=====================================
CREATE PROCEDURE [dbo].[SP_SaveRoleInfo]
	@RoleCode  VARCHAR(50)
	,@RoleName  NVARCHAR(200)
	,@LastUpdateUserUID  VARCHAR(50)
	,@LastUpdateUserName  NVARCHAR(200)
	,@LastUpdateTime  DATETIME
	,@IsSystem  TINYINT
AS
BEGIN	
	IF  NOT EXISTS (SELECT 1 FROM [RoleInfos] WHERE [RoleCode]=@RoleCode)
	BEGIN --修改
		UPDATE [RoleInfos] SET [RoleName]=@RoleName,[LastUpdateUserUID]=@LastUpdateUserUID,[LastUpdateUserName]=@LastUpdateUserName,[LastUpdateTime]=@LastUpdateTime,[IsSystem]=@IsSystem		
		WHERE [RoleCode]=@RoleCode 		
	END
	ELSE
	BEGIN  --新增
		INSERT INTO [RoleInfos] 
			   ([RoleCode],[RoleName],[LastUpdateUserUID],[LastUpdateUserName],[LastUpdateTime],[IsSystem])
		VALUES (@RoleCode,@RoleName,@LastUpdateUserUID,@LastUpdateUserName,@LastUpdateTime,@IsSystem)
	END
END

GO

/****** Object:  StoredProcedure [dbo].[SP_DeleteSysParams] ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_DeleteSysParam]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[SP_DeleteSysParam]
GO


/****** Object:  StoredProcedure [dbo].[SP_DeleteSysParam] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
--=====================================
-- 删除表 SysParams 中的记录
--=====================================
CREATE PROCEDURE [dbo].[SP_DeleteSysParam]
		@ParamCode VARCHAR(200)
AS
BEGIN	
	IF  NOT EXISTS (SELECT 1 FROM [SysParams] WHERE [ParamCode]=@ParamCode)
	BEGIN
		 RAISERROR ('记录不存在或者已经被删除', 16, 1)
		 RETURN
	END
	ELSE
	BEGIN
		DELETE FROM [SysParams] WHERE  [ParamCode]=@ParamCode	
	END
END

GO
      

/****** Object:  StoredProcedure [dbo].[SP_SaveSysParam] ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_SaveSysParam]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[SP_SaveSysParam]
GO


/****** Object:  StoredProcedure [dbo].[SP_SaveSysParam]  ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
--=====================================
-- 将记录保存到 SysParams 中
--=====================================
CREATE PROCEDURE [dbo].[SP_SaveSysParam]
	@ParamCode  VARCHAR(200)
	,@ParamName  NVARCHAR(400)
	,@ParamValue  VARCHAR(1000)
	,@Remark  NVARCHAR(2000)
AS
BEGIN	
	IF  NOT EXISTS (SELECT 1 FROM [SysParams] WHERE [ParamCode]=@ParamCode)
	BEGIN --修改
		UPDATE [SysParams] SET [ParamName]=@ParamName,[ParamValue]=@ParamValue,[Remark]=@Remark		
		WHERE [ParamCode]=@ParamCode 		
	END
	ELSE
	BEGIN  --新增
		INSERT INTO [SysParams] 
			   ([ParamCode],[ParamName],[ParamValue],[Remark])
		VALUES (@ParamCode,@ParamName,@ParamValue,@Remark)
	END
END

GO
