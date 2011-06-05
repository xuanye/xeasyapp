


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
