USE [xEasyApp]
GO

/****** Object:  StoredProcedure [dbo].[SP_SaveDeptInfo]    Script Date: 06/05/2011 16:23:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_SaveDeptInfo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_SaveDeptInfo]
GO

USE [xEasyApp]
GO

/****** Object:  StoredProcedure [dbo].[SP_SaveDeptInfo]    Script Date: 06/05/2011 16:23:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<xuanye>
-- Create date: <2011-05-29>
-- Description:	<保存部门信息>
-- =============================================
CREATE PROCEDURE [dbo].[SP_SaveDeptInfo]
	@DeptCode varchar(50),
	@DeptName nvarchar(200),
    @ParentCode varchar(50),
    @Remark nvarchar(2000),
    @Sequence int,
    @LastUpdateUserUID varchar(50),
    @LastUpdateUserName nvarchar(100)    
AS
BEGIN

    DECLARE @Path varchar(1000)
	DECLARE @ParentPath varchar(1000)
	IF @ParentCode<>'-1'  
	BEGIN
		if  NOT EXISTS (SELECT 1 FROM [Departments] WHERE DeptCode=@ParentCode)
		BEGIN
			 RAISERROR ('你选择的父组织不存在，或者已经被删除', 16, 1)
			 RETURN
		END
    END
    SELECT @ParentPath=[Path] FROM [Departments] WHERE DeptCode=@ParentCode
    SELECT @Path = CASE WHEN ISNULL(@ParentPath,'')='' THEN '.'+@ParentCode+'.' ELSE @ParentPath+@ParentCode+'.' END 
    IF EXISTS (SELECT 1 FROM [Departments] WHERE DeptCode=@DeptCode)
    BEGIN
		UPDATE [Departments] SET [DeptName]=@DeptName,[ParentCode]=@ParentCode
		,[Path]=@Path,[Remark]=@Remark,[Sequence]=@Sequence,[LastUpdateUserUID]=@LastUpdateUserUID
		,[LastUpdateUserName]=@LastUpdateUserName,[LastUpdateTime]=GETDATE() 
		WHERE [DeptCode] =@DeptCode
    END
    ELSE
    BEGIN
		INSERT INTO [Departments] ([DeptCode],[DeptName],[ParentCode],[Path],[Remark],[Sequence],[LastUpdateUserUID],[LastUpdateUserName],[LastUpdateTime])
		VALUES (@DeptCode,@DeptName,@ParentCode,@Path,@Remark,@Sequence,@LastUpdateUserUID,@LastUpdateUserName,GETDATE())
    END    
   
END

GO


