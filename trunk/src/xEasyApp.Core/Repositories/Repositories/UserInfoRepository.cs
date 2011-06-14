using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

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

        public List<string> GetUserRoleCodes(string userCode)
        {
            string sql = "SELECT A.[RoleID],A.[RoleCode] FROM [RoleInfos] A INNER JOIN RoleUserRelation B ON A.RoleID=B.RoleID WHERE B.UserUID=@UserUID";
            SqlParameter sp = new SqlParameter("@UserUID", userCode);
            List<string> list = new List<string>();
            using (IDataReader reader = base.ExcuteDataReader(sql, sp))
            {
                while (reader.Read())
                {
                    list.Add(reader.GetString(1));
                }
            }
            return list;
            
        }
        public List<UserInfo> QueryTopUserList(string qtext)
        {
            string sql = "SELECT [UserUID],[FullName],[IsManager],[IsSystem] FROM [UserInfos] WHERE UserUID like '%"+qtext+"%' or FullName like '%"+qtext+"%' order by Sequence";
          
            List<UserInfo> list = new List<UserInfo>();
            using (IDataReader reader = base.ExcuteDataReader(sql))
            {
                while (reader.Read())
                {
                    UserInfo user = new UserInfo();
                    user.UserUID = reader.GetString(0);
                    user.FullName = reader.GetString(1);
                    user.IsManager = reader.IsDBNull(2) ? false : reader.GetBoolean(2);
                    user.IsSystem = reader.IsDBNull(3) ? false : reader.GetBoolean(3);
                    user.IsNew = false;

                    list.Add(user);
                }
            }
            return list;
        }
        public List<UserInfo> GetUserListByOrgCode(string orgCode)
        {
            string sql = "SELECT [UserUID],[FullName],[IsManager],[IsSystem] FROM [UserInfos] WHERE OrgCode=@OrgCode Order By Sequence";
            SqlParameter sp = new SqlParameter("@OrgCode", orgCode);
            List<UserInfo> list = new List<UserInfo>();
            using (IDataReader reader = base.ExcuteDataReader(sql, sp))
            {
                while (reader.Read())
                {
                    UserInfo user = new UserInfo();
                    user.UserUID = reader.GetString(0);
                    user.FullName = reader.GetString(1);

                    user.IsManager =reader.IsDBNull(2)?false: reader.GetBoolean(2);
                    user.IsSystem = reader.IsDBNull(3) ? false : reader.GetBoolean(3);
                    user.IsNew = false;

                    list.Add(user);
                }
            }
            return list;
        }
    }
}
