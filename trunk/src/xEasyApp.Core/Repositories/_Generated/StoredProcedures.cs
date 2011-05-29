


  
using System;
using System.Data;

namespace xEasyApp.Core.Repositories{
	public partial class StoredProcedures{

        public static StoredProcedure PAGESELECT(string SQLPARAMS,int PAGESIZE,int PAGEINDEX,string SQLTABLE,string SQLCOLUMNS,string SQLPK,string SQLORDER,int Count){
            StoredProcedure sp=new StoredProcedure("PAGESELECT");
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
	
	}
	
}
 