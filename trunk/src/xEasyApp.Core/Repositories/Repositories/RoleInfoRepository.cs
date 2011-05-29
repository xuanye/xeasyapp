using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace xEasyApp.Core.Repositories
{
    public partial class RoleInfoRepository
    {
        public bool ValidRoleCode(string roleCode) 
        {
            string sql = "select 1 from RoleInfos where RoleCode=@RoleCode";
            SqlParameter p = new SqlParameter("@RoleCode", roleCode);
            object o = base.ExecuteScalar(sql, p);
            return o == null;
        }
    }
}
