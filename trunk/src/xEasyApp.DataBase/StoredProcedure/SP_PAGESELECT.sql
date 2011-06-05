USE [xEasyApp]
GO

/****** Object:  StoredProcedure [dbo].[SP_PAGESELECT]    Script Date: 06/05/2011 16:25:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_PAGESELECT]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_PAGESELECT]
GO

USE [xEasyApp]
GO

/****** Object:  StoredProcedure [dbo].[SP_PAGESELECT]    Script Date: 06/05/2011 16:25:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<wangshaoming>
-- Create date: <2008-12-12>
-- Description:	<分页存储过程>
-- =============================================
CREATE PROCEDURE [dbo].[SP_PAGESELECT]
	@SQLPARAMS nvarchar(2000)='', --查询条件
	@PAGESIZE int=20,--每页的记录数
	@PAGEINDEX int=0, --第几页,默认第一页
	@SQLTABLE varchar(5000),--要查询的表或视图,也可以一句sql语句
	@SQLCOLUMNS varchar(4000),--查询的字段
	@SQLPK varchar(50),--主键 
	@SQLORDER varchar(200),--排序
	@Count int=-1 output
AS
BEGIN	
	SET NOCOUNT ON;
	DECLARE @PAGELOWERBOUND INT 
	DECLARE @PAGEUPPERBOUND INT
	DECLARE @SQLSTR nvarchar(4000)
	--获取记录数
	IF @PAGEINDEX=0  --可根据实际要求修改条件,如果是总是获取记录数
	BEGIN
	set @SQLSTR=N'select @sCount=count(1) FROM '+@SQLTABLE+' WHERE 1=1'+@SQLPARAMS
	Exec sp_executesql @sqlstr,N'@sCount int outPut',@Count output
	END
	ELSE
	BEGIN
		SET @COUNT =-1 
	END


	SET @PAGELOWERBOUND= @PAGEINDEX *@PAGESIZE+1
	SET @PAGEUPPERBOUND = @PAGELOWERBOUND +@PAGESIZE-1
	IF @SQLORDER=''
	BEGIN
		SET @SQLORDER='ORDER BY '+@SQLPK
	END
	
	
	SET @SQLSTR=N'SELECT * FROM (select '+@SQLCOLUMNS+',ROW_NUMBER() Over('+@SQLORDER+') as PAGESELECT_rowNum FROM '+@SQLTABLE+' WHERE 1=1'+@SQLPARAMS+ ') as PAGESELECT_TABLE
				where PAGESELECT_rowNum between '+STR(@PAGELOWERBOUND)+' and '+STR(@PAGEUPPERBOUND)+' '


	Exec sp_executesql @SQLSTR

END


GO


