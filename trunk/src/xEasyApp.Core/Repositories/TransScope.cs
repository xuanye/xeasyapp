using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using xEasyApp.Core.Configurations;

namespace xEasyApp.Core.Repositories
{
    public class TransScope
    {
        public TransScope()
            : this(AppConfig.MainDbkey)
        { }
        public TransScope(string dbkey)
        {
            _conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[dbkey].ConnectionString);
            _conn.Open();
            _tran = _conn.BeginTransaction();
        }
        private SqlConnection _conn;

        private SqlTransaction _tran;

        public SqlTransaction Transaction
        {
            get
            {
                return _tran;
            }
        }
        /// <summary>
        /// Commits this instance.
        /// </summary>
        public void Commit()
        {
            if (_tran != null)
            {
                _tran.Commit();
            }
        }
        /// <summary>
        /// Rolls the back.
        /// </summary>
        public void Rollback()
        {
            if (_tran != null)
            {
                _tran.Rollback();
            }

        }

    }
}
