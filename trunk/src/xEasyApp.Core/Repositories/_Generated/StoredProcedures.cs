


  
using System;
using System.Data;

namespace xEasyApp.Core.Repositories{
	public partial class StoredProcedures{

  
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
 