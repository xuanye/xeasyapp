


  
//=============================================
// 该代码文件有程序自动生成，
// 生成时间: 2011-06-18 09:32:09
// =============================================
using System;
using System.Data;

namespace xEasyApp.Core.Repositories{
	public partial class StoredProcedures{

        public static StoredProcedure SP_AddRoleUsers(int RoleID,string UserIDs,string OpUserID,string OpUserName){
            StoredProcedure sp=new StoredProcedure("SP_AddRoleUsers");
            sp.AddParameter("RoleID",RoleID,DbType.Int32);
            sp.AddParameter("UserIDs",UserIDs,DbType.AnsiString);
            sp.AddParameter("OpUserID",OpUserID,DbType.AnsiString);
            sp.AddParameter("OpUserName",OpUserName,DbType.String);
            return sp;
        }
        public static StoredProcedure SP_DeletePrivilege(string PrivilegeCode){
            StoredProcedure sp=new StoredProcedure("SP_DeletePrivilege");
            sp.AddParameter("PrivilegeCode",PrivilegeCode,DbType.AnsiString);
            return sp;
        }
        public static StoredProcedure SP_DeleteUserInfo(string UserUID){
            StoredProcedure sp=new StoredProcedure("SP_DeleteUserInfo");
            sp.AddParameter("UserUID",UserUID,DbType.AnsiString);
            return sp;
        }
        public static StoredProcedure SP_PAGESELECT(string SQLPARAMS,int PAGESIZE,int PAGEINDEX,string SQLTABLE,string SQLCOLUMNS,string SQLPK,string SQLORDER,int Count){
            StoredProcedure sp=new StoredProcedure("SP_PAGESELECT");
            sp.AddParameter("SQLPARAMS",SQLPARAMS,DbType.String);
            sp.AddParameter("PAGESIZE",PAGESIZE,DbType.Int32);
            sp.AddParameter("PAGEINDEX",PAGEINDEX,DbType.Int32);
            sp.AddParameter("SQLTABLE",SQLTABLE,DbType.AnsiString);
            sp.AddParameter("SQLCOLUMNS",SQLCOLUMNS,DbType.AnsiString);
            sp.AddParameter("SQLPK",SQLPK,DbType.AnsiString);
            sp.AddParameter("SQLORDER",SQLORDER,DbType.AnsiString);
            sp.AddParameter("Count",Count,DbType.Int32);
            return sp;
        }
        public static StoredProcedure SP_RemoveRoleUsers(int RoleID,string UserIDs){
            StoredProcedure sp=new StoredProcedure("SP_RemoveRoleUsers");
            sp.AddParameter("RoleID",RoleID,DbType.Int32);
            sp.AddParameter("UserIDs",UserIDs,DbType.AnsiString);
            return sp;
        }
        public static StoredProcedure SP_RoleCheckUserRight(int RoleID,string UserID){
            StoredProcedure sp=new StoredProcedure("SP_RoleCheckUserRight");
            sp.AddParameter("RoleID",RoleID,DbType.Int32);
            sp.AddParameter("UserID",UserID,DbType.AnsiString);
            return sp;
        }
        public static StoredProcedure SP_SaveOrgInfo(string OrgCode,string OrgName,string ParentCode,string Remark,byte OrgType,int Sequence,string LastUpdateUserUID,string LastUpdateUserName){
            StoredProcedure sp=new StoredProcedure("SP_SaveOrgInfo");
            sp.AddParameter("OrgCode",OrgCode,DbType.AnsiString);
            sp.AddParameter("OrgName",OrgName,DbType.String);
            sp.AddParameter("ParentCode",ParentCode,DbType.AnsiString);
            sp.AddParameter("Remark",Remark,DbType.String);
            sp.AddParameter("OrgType",OrgType,DbType.Byte);
            sp.AddParameter("Sequence",Sequence,DbType.Int32);
            sp.AddParameter("LastUpdateUserUID",LastUpdateUserUID,DbType.AnsiString);
            sp.AddParameter("LastUpdateUserName",LastUpdateUserName,DbType.String);
            return sp;
        }
        public static StoredProcedure SP_SavePrivilege(string PrivilegeCode,string PrivilegeName,byte PrivilegeType,string Remark,string ParentID,string Uri,int Sequence,string LastUpdateUserUID,string LastUpdateUserName){
            StoredProcedure sp=new StoredProcedure("SP_SavePrivilege");
            sp.AddParameter("PrivilegeCode",PrivilegeCode,DbType.AnsiString);
            sp.AddParameter("PrivilegeName",PrivilegeName,DbType.String);
            sp.AddParameter("PrivilegeType",PrivilegeType,DbType.Byte);
            sp.AddParameter("Remark",Remark,DbType.String);
            sp.AddParameter("ParentID",ParentID,DbType.AnsiString);
            sp.AddParameter("Uri",Uri,DbType.AnsiString);
            sp.AddParameter("Sequence",Sequence,DbType.Int32);
            sp.AddParameter("LastUpdateUserUID",LastUpdateUserUID,DbType.AnsiString);
            sp.AddParameter("LastUpdateUserName",LastUpdateUserName,DbType.String);
            return sp;
        }
        public static StoredProcedure SP_SaveRoleInfo(int RoleID,string RoleCode,string RoleName,string Remark,int ParentID,bool IsSystem,string LastUpdateUserUID,string LastUpdateUserName){
            StoredProcedure sp=new StoredProcedure("SP_SaveRoleInfo");
            sp.AddParameter("RoleID",RoleID,DbType.Int32);
            sp.AddParameter("RoleCode",RoleCode,DbType.AnsiString);
            sp.AddParameter("RoleName",RoleName,DbType.String);
            sp.AddParameter("Remark",Remark,DbType.String);
            sp.AddParameter("ParentID",ParentID,DbType.Int32);
            sp.AddParameter("IsSystem",IsSystem,DbType.Boolean);
            sp.AddParameter("LastUpdateUserUID",LastUpdateUserUID,DbType.AnsiString);
            sp.AddParameter("LastUpdateUserName",LastUpdateUserName,DbType.String);
            return sp;
        }
        public static StoredProcedure SP_SetRoleRolePrivilege(int RoleID,string AddIDs,string MinusIDs,string UserID,string UserName){
            StoredProcedure sp=new StoredProcedure("SP_SetRoleRolePrivilege");
            sp.AddParameter("RoleID",RoleID,DbType.Int32);
            sp.AddParameter("AddIDs",AddIDs,DbType.AnsiString);
            sp.AddParameter("MinusIDs",MinusIDs,DbType.AnsiString);
            sp.AddParameter("UserID",UserID,DbType.AnsiString);
            sp.AddParameter("UserName",UserName,DbType.String);
            return sp;
        }
	
	}
	
}
 