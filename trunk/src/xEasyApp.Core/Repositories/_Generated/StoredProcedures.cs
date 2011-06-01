


  
using System;
using System.Data;

namespace xEasyApp.Core.Repositories{
	public partial class StoredProcedures{

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
        public static StoredProcedure SP_SaveDeptInfo(string DeptCode,string DeptName,string ParentCode,string Remark,int Sequence,string LastUpdateUserUID,string LastUpdateUserName){
            StoredProcedure sp=new StoredProcedure("SP_SaveDeptInfo");
            sp.AddParameter("DeptCode",DeptCode,DbType.AnsiString);
            sp.AddParameter("DeptName",DeptName,DbType.String);
            sp.AddParameter("ParentCode",ParentCode,DbType.AnsiString);
            sp.AddParameter("Remark",Remark,DbType.String);
            sp.AddParameter("Sequence",Sequence,DbType.Int32);
            sp.AddParameter("LastUpdateUserUID",LastUpdateUserUID,DbType.AnsiString);
            sp.AddParameter("LastUpdateUserName",LastUpdateUserName,DbType.String);
            return sp;
        }
	
	}
	
}
 