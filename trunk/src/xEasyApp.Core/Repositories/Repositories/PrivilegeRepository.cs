using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace xEasyApp.Core.Repositories
{
    public partial class PrivilegeRepository
    {
        public bool ValidPrivilegeCode(string privilegeCode)
        {
            string sql = "SELECT 1 FROM Privileges WHERE PrivilegeCode=@PrivilegeCode";
            SqlParameter p = new SqlParameter("@PrivilegeCode", privilegeCode);
            object o = base.ExecuteScalar(sql, p);
            return o == null;
        }

        public List<Privilege> QueryPrivilegeListByParentCode(string parentCode)
        {
            string sql = @"SELECT A.[PrivilegeCode],A.[PrivilegeName],A.[PrivilegeType],A.[ParentID],A.[Remark]
                                  ,A.[Uri],A.[Sequence],A.[LastUpdateUserUID],A.[LastUpdateUserName],A.[LastUpdateTime],B.[PrivilegeName] AS ParentName
                            FROM Privileges A
                            LEFT JOIN Privileges B on A.[ParentID] =B.[PrivilegeCode]
                            where A.ParentID=@ParentCode Order By A.[Sequence]";
            SqlParameter pa = new SqlParameter("@ParentCode", parentCode);
            List<Privilege> list =new List<Privilege>();
            using (IDataReader reader = base.ExcuteDataReader(sql, pa))
            {
                while (reader.Read())
                {
                    Privilege p = new Privilege();
                    p.PrivilegeCode = reader.GetString(0);
                    p.PrivilegeName = reader.GetString(1);
                    p.PrivilegeType = reader.GetByte(2);
                    p.ParentID = reader.IsDBNull(3) ? null : reader.GetString(3);
                    p.Remark = reader.IsDBNull(4) ? null : reader.GetString(4);
                    p.Uri = reader.IsDBNull(5) ? null : reader.GetString(5);
                    p.Sequence = reader.IsDBNull(6) ? 0 : reader.GetInt32(6);
                    p.LastUpdateUserUID = reader.GetString(7);
                    p.LastUpdateUserName = reader.GetString(8);
                    p.LastUpdateTime = reader.GetDateTime(9);
                    p.ParentName = reader.IsDBNull(10) ? null : reader.GetString(10);
                    list.Add(p);
                }
            }
            return list;
        }
        public List<Privilege> QueryTopLevelPrivilegeList()
        {
            string sql = @"SELECT A.[PrivilegeCode],A.[PrivilegeName],A.[PrivilegeType],A.[ParentID],A.[Remark]
                                  ,A.[Uri],A.[Sequence],A.[LastUpdateUserUID],A.[LastUpdateUserName],A.[LastUpdateTime],B.[PrivilegeName] AS ParentName
                            FROM Privileges A
                            LEFT JOIN Privileges B on A.[ParentID] =B.[PrivilegeCode]
                            where A.ParentID IS Null Order By A.[Sequence] ";
        
            List<Privilege> list = new List<Privilege>();
            using (IDataReader reader = base.ExcuteDataReader(sql))
            {
                while (reader.Read())
                {
                    Privilege p = new Privilege();
                    p.PrivilegeCode = reader.GetString(0);
                    p.PrivilegeName = reader.GetString(1);
                    p.PrivilegeType = reader.GetByte(2);
                    p.ParentID = reader.IsDBNull(3) ? null : reader.GetString(3);
                    p.Remark = reader.IsDBNull(4) ? null : reader.GetString(4);
                    p.Uri = reader.IsDBNull(5) ? null : reader.GetString(5);
                    p.Sequence = reader.IsDBNull(6) ? 0 : reader.GetInt32(6);
                    p.LastUpdateUserUID = reader.GetString(7);
                    p.LastUpdateUserName = reader.GetString(8);
                    p.LastUpdateTime = reader.GetDateTime(9);
                    p.ParentName = reader.IsDBNull(10) ? null : reader.GetString(10);
                    list.Add(p);
                }
            }
            return list;
        }


        public int DeletePrivilege(string privilegeCode)
        {
            StoredProcedure sp = StoredProcedures.SP_DeletePrivilege(privilegeCode);
            return base.SPExecuteNonQuery(sp);
        }



        public List<Privilege> GetTopLevelPrivileges()
        {
            string sql = @"SELECT A.[PrivilegeCode],A.[PrivilegeName],A.[PrivilegeType],A.[ParentID]
                                  ,A.[Uri],ISNULL(B.ChildCount,0) AS ChildCount
                            FROM Privileges A
                            LEFT JOIN (SELECT COUNT(1) ChildCount,ParentID From Privileges Group By ParentID) B on A.[PrivilegeCode] =B.ParentID
                            where A.ParentID IS Null Order By A.[Sequence]";

            List<Privilege> list = new List<Privilege>();
            using (IDataReader reader = base.ExcuteDataReader(sql))
            {
                while (reader.Read())
                {
                    Privilege p = new Privilege();
                    p.PrivilegeCode = reader.GetString(0);
                    p.PrivilegeName = reader.GetString(1);
                    p.PrivilegeType = reader.GetByte(2);
                    p.ParentID = reader.IsDBNull(3) ? null : reader.GetString(3);

                    p.Uri = reader.IsDBNull(4) ? null : reader.GetString(4);
                    p.HasChild = reader.GetInt32(5) > 0;
                    list.Add(p);
                }
            }
            return list;
        }

        public List<Privilege> GetChildPrivileges(string parentCode)
        {
            string sql = @"SELECT A.[PrivilegeCode],A.[PrivilegeName],A.[PrivilegeType],A.[ParentID]
                                  ,A.[Uri],ISNULL(B.ChildCount,0) AS ChildCount
                            FROM Privileges A
                            LEFT JOIN (SELECT COUNT(1) ChildCount,ParentID From Privileges Group By ParentID) B on A.[PrivilegeCode] =B.ParentID
                            where A.ParentID=@ParentCode Order By A.[Sequence]";

            SqlParameter pa = new SqlParameter("@ParentCode", parentCode);
            List<Privilege> list = new List<Privilege>();
            using (IDataReader reader = base.ExcuteDataReader(sql,pa))
            {
                while (reader.Read())
                {
                    Privilege p = new Privilege();
                    p.PrivilegeCode = reader.GetString(0);
                    p.PrivilegeName = reader.GetString(1);
                    p.PrivilegeType = reader.GetByte(2);
                    p.ParentID = reader.IsDBNull(3) ? null : reader.GetString(3);

                    p.Uri = reader.IsDBNull(4) ? null : reader.GetString(4);
                    p.HasChild = reader.GetInt32(5) > 0;
                    list.Add(p);
                }
            }
            return list;
        }

        public Privilege GetPrivilege(string privilegeCode)
        {
            string sql = @"SELECT A.[PrivilegeCode],A.[PrivilegeName],A.[PrivilegeType],A.[ParentID],A.[Remark]
                                  ,A.[Uri],A.[Sequence],A.[LastUpdateUserUID],A.[LastUpdateUserName],A.[LastUpdateTime],B.[PrivilegeName] AS ParentName
                            FROM Privileges A
                            LEFT JOIN Privileges B on A.[ParentID] =B.[PrivilegeCode]
                            where A.PrivilegeCode = @PrivilegeCode ";

            Privilege p = null;
            SqlParameter pa = new SqlParameter("@PrivilegeCode",privilegeCode);
            using (IDataReader reader = base.ExcuteDataReader(sql, pa))
            {
                if (reader.Read())
                {
                    p = new Privilege();
                    p.PrivilegeCode = reader.GetString(0);
                    p.PrivilegeName = reader.GetString(1);
                    p.PrivilegeType = reader.GetByte(2);
                    p.ParentID = reader.IsDBNull(3) ? null : reader.GetString(3);
                    p.Remark = reader.IsDBNull(4) ? null : reader.GetString(4);
                    p.Uri = reader.IsDBNull(5) ? null : reader.GetString(5);
                    p.Sequence = reader.IsDBNull(6) ? 0 : reader.GetInt32(6);
                    p.LastUpdateUserUID = reader.GetString(7);
                    p.LastUpdateUserName = reader.GetString(8);
                    p.LastUpdateTime = reader.GetDateTime(9);
                    p.ParentName = reader.IsDBNull(10) ? null : reader.GetString(10);
                }
            }
            return p;
        }

     
    }
}
