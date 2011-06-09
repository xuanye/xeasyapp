using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

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

                    if (!reader.IsDBNull(4))
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
    }
}
