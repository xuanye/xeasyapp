


  
using System;
using SubSonic;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace xEasyApp.Core.Repositories{
	public partial class xEasyAppDB{

        public StoredProcedure GetSeNum(string SECODE){
            StoredProcedure sp=new StoredProcedure("GetSeNum",this.Provider);
            sp.Command.AddParameter("SECODE",SECODE,DbType.AnsiString);
            return sp;
        }
        public StoredProcedure PAGESELECT(string SQLPARAMS,int PAGESIZE,int PAGEINDEX,string SQLTABLE,string SQLCOLUMNS,string SQLPK,string SQLORDER,int Count){
            StoredProcedure sp=new StoredProcedure("PAGESELECT",this.Provider);
            sp.Command.AddParameter("SQLPARAMS",SQLPARAMS,DbType.String);
            sp.Command.AddParameter("PAGESIZE",PAGESIZE,DbType.Int32);
            sp.Command.AddParameter("PAGEINDEX",PAGEINDEX,DbType.Int32);
            sp.Command.AddParameter("SQLTABLE",SQLTABLE,DbType.AnsiString);
            sp.Command.AddParameter("SQLCOLUMNS",SQLCOLUMNS,DbType.AnsiString);
            sp.Command.AddParameter("SQLPK",SQLPK,DbType.AnsiString);
            sp.Command.AddParameter("SQLORDER",SQLORDER,DbType.AnsiString);
            sp.Command.AddParameter("Count",Count,DbType.Int32);
            return sp;
        }
        public StoredProcedure proc_migration(int returncode){
            StoredProcedure sp=new StoredProcedure("proc_migration",this.Provider);
            sp.Command.AddParameter("returncode",returncode,DbType.Int32);
            return sp;
        }
        public StoredProcedure QueryClassMarkScore(string schoolYear,string gradeCode,string classCode){
            StoredProcedure sp=new StoredProcedure("QueryClassMarkScore",this.Provider);
            sp.Command.AddParameter("schoolYear",schoolYear,DbType.AnsiString);
            sp.Command.AddParameter("gradeCode",gradeCode,DbType.AnsiString);
            sp.Command.AddParameter("classCode",classCode,DbType.AnsiString);
            return sp;
        }
	
	}
	
}
 