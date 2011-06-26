using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using xEasyApp.Core.Entities;

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
        /// <summary>
        /// 根据父ID查询角色列表
        /// </summary>
        /// <param name="parentid">The parentid.</param>
        /// <returns></returns>
        public List<RoleInfo> QueryRoleList(int parentid)
        {
            string sql = @"SELECT [RoleID],[RoleCode],[RoleName],[Remark],[ParentID],[IsSystem],[RolePath],[LastUpdateUserUID]
                        ,[LastUpdateUserName],[LastUpdateTime] FROM [RoleInfos] where ParentID=@ParentID";
            SqlParameter p = new SqlParameter("@ParentID", parentid);
            List<RoleInfo> list = new List<RoleInfo>();
            using (IDataReader reader = base.ExcuteDataReader(sql, p))
            {
                while (reader.Read())
                {
                    RoleInfo item = new RoleInfo();
                    item.RoleID = reader.GetInt32(0);
                    item.RoleCode = reader.GetString(1);
                    item.RoleName = reader.GetString(2);
                    if (!reader.IsDBNull(3))
                    {
                        item.Remark = reader.GetString(3);
                    }
                    if (!reader.IsDBNull(4))
                    {
                        item.ParentID = reader.GetInt32(4);
                    }
                    item.IsSystem = reader.GetBoolean(5);
                    if (!reader.IsDBNull(6))
                    {
                        item.RolePath = reader.GetString(6);
                    }
                    item.LastUpdateUserUID = reader.GetString(7);
                    item.LastUpdateUserName = reader.GetString(8);
                    item.LastUpdateTime = reader.GetDateTime(9);
                    item.IsNew =false;
                    list.Add(item);
                }
            }
            return list;
        }
        /// <summary>
        ///查询角色列表
        /// </summary>
        /// <param name="parentid">The parentid.</param>
        /// <returns></returns>
        public List<RoleInfo> QueryTopRoleList()
        {
            string sql = @"SELECT [RoleID],[RoleCode],[RoleName],[Remark],[ParentID],[IsSystem],[RolePath],[LastUpdateUserUID]
                        ,[LastUpdateUserName],[LastUpdateTime] FROM [RoleInfos] where ParentID is null";         
            List<RoleInfo> list = new List<RoleInfo>();
            using (IDataReader reader = base.ExcuteDataReader(sql))
            {
                while (reader.Read())
                {
                    RoleInfo item = new RoleInfo();
                    item.RoleID = reader.GetInt32(0);
                    item.RoleCode = reader.GetString(1);
                    item.RoleName = reader.GetString(2);
                    if (!reader.IsDBNull(3))
                    {
                        item.Remark = reader.GetString(3);
                    }
                    if (!reader.IsDBNull(4))
                    {
                        item.ParentID = reader.GetInt32(4);
                    }
                    item.IsSystem = reader.GetBoolean(5);
                    if (!reader.IsDBNull(6))
                    {
                        item.RolePath = reader.GetString(6);
                    }
                    item.LastUpdateUserUID = reader.GetString(7);
                    item.LastUpdateUserName = reader.GetString(8);
                    item.LastUpdateTime = reader.GetDateTime(9);
                    item.IsNew =false;
                    list.Add(item);
                }
            }
            return list;
        }
        /// <summary>
        /// 根据父ID查询角色列表
        /// </summary>
        /// <param name="parentid">The parentid.</param>
        /// <returns></returns>
        public List<RoleInfo> GetRolesByParentID(int parentid)
        {
            string sql = @"SELECT A.[RoleID],A.[RoleCode],A.[RoleName],A.[ParentID],A.[IsSystem]
                        ,A.[RolePath],ISNULL(C.ChildCount,0) as ChildCount FROM [RoleInfos] A                      
                        LEFT JOIN (SELECT COUNT(1) AS ChildCount , ParentID FROM [RoleInfos] Group By ParentID) C ON A.RoleID=C.ParentID
                        where A.ParentID =@ParentID";
            SqlParameter p = new SqlParameter("@ParentID", parentid);
            List<RoleInfo> list = new List<RoleInfo>();
            using (IDataReader reader = base.ExcuteDataReader(sql,p))
            {
                while (reader.Read())
                {
                    RoleInfo item = new RoleInfo();
                    item.RoleID = reader.GetInt32(0);
                    item.RoleCode = reader.GetString(1);
                    item.RoleName = reader.GetString(2);

                    if (!reader.IsDBNull(4))
                    {
                        item.ParentID = reader.GetInt32(3);
                    }
                    item.IsSystem = reader.GetBoolean(4);
                    if (!reader.IsDBNull(5))
                    {
                        item.RolePath = reader.GetString(5);
                    }
                    item.HasChild = reader.GetInt32(6) > 0;

                    item.IsNew = false;
                    list.Add(item);
                }
            }
            return list;
        }
        /// <summary>
        ///查询角色列表
        /// </summary>
        /// <param name="parentid">The parentid.</param>
        /// <returns></returns>
        public List<RoleInfo> GetTopRoles()
        {
            string sql = @"SELECT A.[RoleID],A.[RoleCode],A.[RoleName],A.[ParentID],A.[IsSystem]
                        ,A.[RolePath],ISNULL(C.ChildCount,0) as ChildCount FROM [RoleInfos] A                      
                        LEFT JOIN (SELECT COUNT(1) AS ChildCount , ParentID FROM [RoleInfos] Group By ParentID) C ON A.RoleID=C.ParentID
                        where A.ParentID is null";
            List<RoleInfo> list = new List<RoleInfo>();
            using (IDataReader reader = base.ExcuteDataReader(sql))
            {
                while (reader.Read())
                {
                    RoleInfo item = new RoleInfo();
                    item.RoleID = reader.GetInt32(0);
                    item.RoleCode = reader.GetString(1);
                    item.RoleName = reader.GetString(2);

                    if (!reader.IsDBNull(3))
                    {
                        item.ParentID = reader.GetInt32(3);
                    }
                    item.IsSystem = reader.GetBoolean(4);
                    if (!reader.IsDBNull(5))
                    {
                        item.RolePath = reader.GetString(5);
                    }
                    item.HasChild = reader.GetInt32(6) > 0;

                    item.IsNew = false;
                    list.Add(item);
                }
            }
            return list;
        }

        public List<RoleInfo> GetTopUserRoles(string userCode)
        {
            string sql = @"SELECT A.[RoleID],A.[RoleCode],A.[RoleName],A.[ParentID],A.[IsSystem]
                        ,A.[RolePath],ISNULL(C.ChildCount,0) as ChildCount FROM [RoleInfos] A
                        INNER JOIN RoleUserRelation B ON A.RoleID=B.RoleID
                        LEFT JOIN (SELECT COUNT(1) AS ChildCount , ParentID FROM [RoleInfos] Group By ParentID) C ON A.RoleID=C.ParentID
                        WHERE B.UserUID=@UserUID";
            SqlParameter p = new SqlParameter("@UserUID", userCode);
            List<RoleInfo> list = new List<RoleInfo>();
            using (IDataReader reader = base.ExcuteDataReader(sql, p))
            {
                while (reader.Read())
                {
                    RoleInfo item = new RoleInfo();
                    item.RoleID = reader.GetInt32(0);
                    item.RoleCode = reader.GetString(1);
                    item.RoleName = reader.GetString(2);
                  
                    if (!reader.IsDBNull(3))
                    {
                        item.ParentID = reader.GetInt32(3);
                    }
                    item.IsSystem = reader.GetBoolean(4);
                    if (!reader.IsDBNull(5))
                    {
                        item.RolePath = reader.GetString(5);
                    }
                    item.HasChild = reader.GetInt32(6)>0;

                    item.IsNew = false;
                    list.Add(item);
                }
            }
            return list;

        }
        public List<RoleInfo> QueryTopUserRolesList(string userCode)
        {
            string sql = @"SELECT A.[RoleID],A.[RoleCode],A.[RoleName],A.[ParentID],A.[IsSystem]
                        ,A.[RolePath] FROM [RoleInfos] A
                        INNER JOIN RoleUserRelation B ON A.RoleID=B.RoleID                       
                        WHERE B.UserUID=@UserUID";
            SqlParameter p = new SqlParameter("@UserUID", userCode);
            List<RoleInfo> list = new List<RoleInfo>();
            using (IDataReader reader = base.ExcuteDataReader(sql, p))
            {
                while (reader.Read())
                {
                    RoleInfo item = new RoleInfo();
                    item.RoleID = reader.GetInt32(0);
                    item.RoleCode = reader.GetString(1);
                    item.RoleName = reader.GetString(2);

                    if (!reader.IsDBNull(3))
                    {
                        item.ParentID = reader.GetInt32(3);
                    }
                    item.IsSystem = reader.GetBoolean(4);
                    if (!reader.IsDBNull(5))
                    {
                        item.RolePath = reader.GetString(5);
                    }
                    item.IsNew = false;
                    list.Add(item);
                }
            }
            return list;
        }

        public RoleInfo GetRoleInfo(int roleId)
        {
            string sql = @"SELECT  A.[RoleID],A.[RoleCode],A.[RoleName],A.[Remark],A.[ParentID],A.[IsSystem],A.[RolePath]
	                               ,A.[LastUpdateUserUID],A.[LastUpdateUserName],A.[LastUpdateTime] ,B.RoleName as ParentName
                              FROM [RoleInfos] A
                              LEFT JOIN [RoleInfos] B ON A.ParentID=B.RoleID
                              WHERE A.RoleID=@RoleID";

            SqlParameter p = new SqlParameter("@RoleID", roleId);
            RoleInfo item = null;
            using (IDataReader reader = base.ExcuteDataReader(sql, p))
            {
                if (reader.Read())
                {
                    item = new RoleInfo();
                    item.RoleID = reader.GetInt32(0);
                    item.RoleCode = reader.GetString(1);
                    item.RoleName = reader.GetString(2);
                    if (!reader.IsDBNull(3))
                    {
                        item.Remark = reader.GetString(3);
                    }
                    if (!reader.IsDBNull(4))
                    {
                        item.ParentID = reader.GetInt32(4);
                    }
                    item.IsSystem = reader.GetBoolean(5);
                    if (!reader.IsDBNull(6))
                    {
                        item.RolePath = reader.GetString(6);
                    }
                    item.LastUpdateUserUID = reader.GetString(7);
                    item.LastUpdateUserName = reader.GetString(8);
                    item.LastUpdateTime = reader.GetDateTime(9);
                    item.ParentName = reader.IsDBNull(10) ? null : reader.GetString(10);
                }
            }
            return item;
        }

        public void SaveRoleInfo(RoleInfo ri)
        {
            StoredProcedure sp = StoredProcedures.SP_SaveRoleInfo(ri.RoleID, ri.RoleCode, ri.RoleName, ri.Remark, ri.ParentID.HasValue ? ri.ParentID.Value : -1, ri.IsSystem, ri.LastUpdateUserUID, ri.LastUpdateUserName);
            base.SPExecuteNonQuery(sp);
        }

        public PagedList<UserInfo> QueryRoletUserList(Entities.PageView view, int roleId, string qtext)
        {
            string where = " AND B.RoleID=" + roleId;
            if (string.IsNullOrEmpty(qtext))
            {
                where += " AND (A.UserUID like '%" + qtext + "%' or A.FullName like '%" + qtext + "%')";
            }
            StoredProcedure sp = StoredProcedures.SP_PAGESELECT(where, view.PageSize, view.PageIndex,
                "UserInfos A INNER JOIN  RoleUserRelation B ON A.UserUID= B.UserUID",
                "A.[UserUID],A.[FullName],A.[Password],A.[OrgCode],A.[OrgName],A.[IsManager],A.[IsSystem],A.[Sequence],A.[AccountState],A.[LastUpdateUserUID],A.[LastUpdateUserName],A.[LastUpdateTime]",
                "A.[UserUID]", " Order By A.[Sequence]");
            var pl = new PagedList<UserInfo>();
            pl.DataList = new List<UserInfo>();
            using (IDataReader dr = base.SPExecuteDataReader(sp))
            {
                while (dr.Read())
                {
                    UserInfo u = new UserInfo();
                    u.UserUID = dr.IsDBNull(0) ? null : dr.GetString(0);
                    u.FullName = dr.IsDBNull(1) ? null : dr.GetString(1);
                    u.Password = dr.IsDBNull(2) ? null : dr.GetString(2);
                    u.OrgCode = dr.IsDBNull(3) ? null : dr.GetString(3);
                    u.OrgName = dr.IsDBNull(4) ? null : dr.GetString(4);
                    u.IsManager = dr.IsDBNull(5) ? false : dr.GetBoolean(5);
                    u.IsSystem = dr.IsDBNull(6) ? false : dr.GetBoolean(6);
                    u.Sequence = dr.GetInt32(7);
                    u.AccountState = dr.IsDBNull(8) ? (byte)0 : dr.GetByte(8);
                    u.LastUpdateUserUID = dr.IsDBNull(9) ? null : dr.GetString(9);
                    u.LastUpdateUserName = dr.IsDBNull(10) ? null : dr.GetString(10);
                    u.LastUpdateTime = dr.GetDateTime(11);                 
                    u.IsNew = false;
                    pl.DataList.Add(u);
                }
            }
            if (view.PageIndex == 0)
            {
                pl.Total = Convert.ToInt32(sp.GetParameterValue(sp.ParamsCount - 1));
            }
            pl.PageIndex = view.PageIndex;

            return pl;
        }

        public int DeleteRoleUser(int roleid, string userids)
        {
            StoredProcedure sp = StoredProcedures.SP_RemoveRoleUsers(roleid, userids);
            return base.SPExecuteNonQuery(sp);
        }

        public int AddRoleUser(int roleid, string userids, string opUserId, string opUserName)
        {
            StoredProcedure sp = StoredProcedures.SP_AddRoleUsers(roleid, userids, opUserId, opUserName);
            return base.SPExecuteNonQuery(sp);
        }

        public bool CheckUserAuthorizationRight(int RoleID, string userid)
        {
            StoredProcedure sp = StoredProcedures.SP_RoleCheckUserRight(RoleID, userid);
            object o = base.SPExecuteScalar(sp);
            if (o != null)
            {
                return Convert.ToInt32(o) > 0;
            }
            return false;
        }

        public List<Privilege> GetUserPermissions(string userId, string parentId)
        {
            string sql = null;        
            List<SqlParameter> plist = new List<SqlParameter>();
            plist.Add(new SqlParameter("@UserUID", userId));
            if (string.IsNullOrEmpty(parentId))
            {
                sql = @"SELECT A.[PrivilegeCode],A.[PrivilegeName],A.[PrivilegeType],A.[Uri],ISNULL(B.ChildCount,0) as  ChildCount FROM Privileges A 
                        LEFT JOIn (SELECT COUNT(1) as ChildCount,ParentID FROM Privileges  Group By ParentID) B ON A.PrivilegeCode = B.ParentID 
                        INNER JOIN RolePrivilegeRelation C on A.PrivilegeCode=C.PrivilegeCode
                        INNER JOIN RoleUserRelation D ON C.RoleID = D.RoleID
                        WHERE D.UserUID=@UserUID and A.ParentID IS NULL 
                        Order By a.Sequence";
              
            }
            else
            {
                sql = @"SELECT A.[PrivilegeCode],A.[PrivilegeName],A.[PrivilegeType],A.[Uri],ISNULL(B.ChildCount,0) as  ChildCount FROM Privileges A 
                        LEFT JOIn (SELECT COUNT(1) as ChildCount,ParentID FROM Privileges  Group By ParentID) B ON A.PrivilegeCode = B.ParentID 
                        INNER JOIN RolePrivilegeRelation C on A.PrivilegeCode=C.PrivilegeCode
                        INNER JOIN RoleUserRelation D ON C.RoleID = D.RoleID
                        WHERE D.UserUID=@UserUID and A.ParentID=@ParentID 
                        Order By a.Sequence";
                plist.Add(new SqlParameter("@ParentID", parentId));
            }

            List<Privilege> list = new List<Privilege>();
            using (IDataReader reader = base.ExcuteDataReader(sql, plist.ToArray()))
            {              
                while (reader.Read())
                {
                    Privilege pvi = new Privilege();
                    pvi.PrivilegeCode = reader.GetString(0);
                    pvi.PrivilegeName = reader.GetString(1);
                    pvi.PrivilegeType = reader.GetByte(2);
                    pvi.Uri = reader.IsDBNull(3) ? null : reader.GetString(3);
                    pvi.HasChild = reader.GetInt32(4) > 0;
                    list.Add(pvi);
                }
            }
            return list;
        }

        public List<Privilege> GetRolePermissions(int roleid, string parentId)
        {
            string sql = null;
            List<SqlParameter> plist = new List<SqlParameter>();
            plist.Add(new SqlParameter("@RoleID", roleid));
            if (string.IsNullOrEmpty(parentId))
            {
                sql = @"SELECT A.[PrivilegeCode],A.[PrivilegeName],A.[PrivilegeType],A.[Uri],ISNULL(B.ChildCount,0) as  ChildCount FROM Privileges A 
                        LEFT JOIn (SELECT COUNT(1) as ChildCount,ParentID FROM Privileges  Group By ParentID) B ON A.PrivilegeCode = B.ParentID 
                        INNER JOIN RolePrivilegeRelation C on A.PrivilegeCode=C.PrivilegeCode                        
                        WHERE C.RoleID=@RoleID and A.ParentID IS NULL 
                        Order By a.Sequence";

            }
            else
            {
                sql = @"SELECT A.[PrivilegeCode],A.[PrivilegeName],A.[PrivilegeType],A.[Uri],ISNULL(B.ChildCount,0) as  ChildCount FROM Privileges A 
                        LEFT JOIn (SELECT COUNT(1) as ChildCount,ParentID FROM Privileges  Group By ParentID) B ON A.PrivilegeCode = B.ParentID 
                        INNER JOIN RolePrivilegeRelation C on A.PrivilegeCode=C.PrivilegeCode
                        WHERE C.RoleID=@RoleID and A.ParentID=@ParentID 
                        Order By a.Sequence";
                plist.Add(new SqlParameter("@ParentID", parentId));
            }

            List<Privilege> list = new List<Privilege>();
            using (IDataReader reader = base.ExcuteDataReader(sql, plist.ToArray()))
            {
                while (reader.Read())
                {
                    Privilege pvi = new Privilege();
                    pvi.PrivilegeCode = reader.GetString(0);
                    pvi.PrivilegeName = reader.GetString(1);
                    pvi.PrivilegeType = reader.GetByte(2);
                    pvi.Uri = reader.IsDBNull(3) ? null : reader.GetString(3);
                    pvi.HasChild = reader.GetInt32(4) > 0;
                    list.Add(pvi);
                }
            }
            return list;
        }

        public void SetRolePrivilege(int roleid, string addids, string minusids,string userid,string username)
        {
            StoredProcedure sp = StoredProcedures.SP_SetRoleRolePrivilege(roleid, addids, minusids,userid,username);
            base.SPExecuteNonQuery(sp);
        }



        public List<RoleInfo> QueryUserPrivilegeRoles(string usercode, string pcode)
        {
            string sql = @"select Distinct A.RoleID,A.RoleCode,A.RoleName,A.IsSystem from RoleInfos A
                            INNER JOIN RolePrivilegeRelation  B On A.RoleID=B.RoleID
                            INNER JOIN RoleUserRelation C On A.RoleID=C.RoleID
                            Where C.UserUID=@UserID and B.PrivilegeCode=@PrivilegeCode ";
            SqlParameter[] arrp = new SqlParameter[2];
            arrp[0] = new SqlParameter("@UserID", usercode);
            arrp[1] = new SqlParameter("@PrivilegeCode", pcode);
            List<RoleInfo> list = new List<RoleInfo>();
            using (IDataReader reader = base.ExcuteDataReader(sql, arrp))
            {
                while (reader.Read())
                {
                    RoleInfo r = new RoleInfo();
                    r.RoleID = reader.GetInt32(0);
                    r.RoleCode = reader.GetString(1);
                    r.RoleName = reader.GetString(2);
                    r.IsSystem = reader.IsDBNull(3) ? false : reader.GetBoolean(3);
                    list.Add(r);
                }
            }
            return list;
        }

      
    }
}
