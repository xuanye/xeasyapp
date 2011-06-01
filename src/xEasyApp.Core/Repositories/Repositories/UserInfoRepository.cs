using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;

namespace xEasyApp.Core.Repositories
{
    public partial class UserInfoRepository
    {
        public int DeleteUserInfo(string id)
        {
            StoredProcedure sp = StoredProcedures.SP_DeleteUserInfo(id);
            return base.SPExecuteNonQuery(sp);
        }

        public bool ValidUserUID(string UserUID)
        {
            string sql = "SELECT 1 FROM UserInfos where UserUID=@UserUID";
            SqlParameter p = new SqlParameter("@UserUID", UserUID);
            object o = base.ExecuteScalar(sql, p);
            return o == null;
        }
    }
}
