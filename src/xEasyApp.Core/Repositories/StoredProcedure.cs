using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace xEasyApp.Core.Repositories
{
    public class StoredProcedure
    {
        public StoredProcedure(string spName)
        {
            this.SPName = spName;
        }

        public string SPName
        {
            get;
            set;
        }

        private List<SqlParameter> _SPParams;
        public List<SqlParameter>  SPParams
        {
            get {
                if (_SPParams ==null)
                {
                    _SPParams = new List<SqlParameter>();
                }
                return _SPParams;
            }
        }
        public int ParamsCount
        {
            get {
                return SPParams.Count;
            }
        }
        public object GetParameterValue(string paramName)
        {
            foreach (SqlParameter p in SPParams)
            {
                if (p.ParameterName == paramName)
                {
                    return p.Value;
                }
            }
            return null;
        }
        public object GetParameterValue(int index)
        {
            if (index < SPParams.Count && index >= 0)
            {
                return SPParams[index].Value;
            }
            return null;
        }
        public void AddParameter(string paramName, object paramValue, DbType dbtype)
        {
            AddParameter(paramName, paramValue, dbtype, ParameterDirection.Input);
        }
        public void AddParameter(string paramName, object paramValue, DbType dbtype, ParameterDirection pDirection)
        {
            SqlParameter p = new SqlParameter();
            p.DbType = dbtype;
            p.ParameterName = paramName;
            p.Value = paramValue;
            p.Direction = pDirection;
            SPParams.Add(p);
        }
    }
}
