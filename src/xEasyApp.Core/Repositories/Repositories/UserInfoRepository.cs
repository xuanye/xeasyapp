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
        public bool CheckUserRight(string userUid, string privilegeCode)
        {
            string sql = @"SELECT 1 FROM RoleUserRelation A
                        INNER JOIN RolePrivilegeRelation  B ON A.RoleID=B.RoleID
                        Where B.PrivilegeCode=@PrivilegeCode and A.UserUID=@UserCode";
            SqlParameter[] pas = new SqlParameter[2];
            pas[0] = new SqlParameter("@PrivilegeCode", privilegeCode);
            pas[1] = new SqlParameter("@UserCode", userUid);
            object o = base.ExecuteScalar(sql, pas);
            return o != null;
        }

        public UserInfo GetUserInfo(string UserId)
        {
            string sql = @"SELECT A.[UserUID],A.[FullName],A.[Password],
            A.[OrgCode],A.[OrgName],A.[IsManager],A.[IsSystem],
            A.[Sequence],A.[AccountState],A.[LastUpdateUserUID],
            A.[LastUpdateUserName],A.[LastUpdateTime],B.UnitCode,B.UnitName
            FROM [UserInfos] A LEFT JOIN Organizations B ON A.OrgCode=B.OrgCode
            WHERE A.[UserUID]=@UserUID";
            SqlParameter p = new SqlParameter("@UserUID", UserId);
            UserInfo item = null;
            using (IDataReader reader = base.ExcuteDataReader(sql, p))
            {
                if (reader.Read())
                {
                    item = new UserInfo();
                    item.UserUID = reader.GetString(0);
                    item.FullName = reader.GetString(1);
                    item.Password = reader.GetString(2);
                    item.OrgCode = reader.GetString(3);
                    if (!reader.IsDBNull(4))
                    {
                        item.OrgName = reader.GetString(4);
                    }
                    item.IsManager = reader.GetBoolean(5);
                    item.IsSystem = reader.GetBoolean(6);
                    item.Sequence = reader.GetInt32(7);
                    item.AccountState = reader.GetByte(8);
                    item.LastUpdateUserUID = reader.GetString(9);
                    item.LastUpdateUserName = reader.GetString(10);
                    item.LastUpdateTime = reader.GetDateTime(11);
                    item.UnitCode = reader.IsDBNull(12) ? null : reader.GetString(12);
                    item.UnitName = reader.IsDBNull(13) ? null : reader.GetString(13);
                }
            }
            return item;
        }
    }
}
