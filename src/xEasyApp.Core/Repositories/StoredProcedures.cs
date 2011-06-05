using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace xEasyApp.Core.Repositories
{
    /// <summary>
    /// 存储过程类
    /// </summary>
    public partial class StoredProcedures
    {
        public static StoredProcedure SP_PAGESELECT(string SQLPARAMS, int PAGESIZE, int PAGEINDEX, string SQLTABLE, string SQLCOLUMNS, string SQLPK, string SQLORDER)
        {
            int Count = -1;
            StoredProcedure sp = new StoredProcedure("SP_PAGESELECT");
            sp.AddParameter("SQLPARAMS", SQLPARAMS, DbType.String);
            sp.AddParameter("PAGESIZE", PAGESIZE, DbType.Int32);
            sp.AddParameter("PAGEINDEX", PAGEINDEX, DbType.Int32);
            sp.AddParameter("SQLTABLE", SQLTABLE, DbType.AnsiString);
            sp.AddParameter("SQLCOLUMNS", SQLCOLUMNS, DbType.AnsiString);
            sp.AddParameter("SQLPK", SQLPK, DbType.AnsiString);
            sp.AddParameter("SQLORDER", SQLORDER, DbType.AnsiString);
            sp.AddParameter("Count", Count, DbType.Int32, ParameterDirection.Output);
            return sp;
        }
    }
}
