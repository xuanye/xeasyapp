using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace xEasyApp.Core.Repositories
{
    public partial class DictInfoRepository
    {

        /// <summary>
        /// 获取子数据字典信息
        /// </summary>
        /// <param name="dictCode">The dict code.</param>
        /// <returns></returns>
        public List<DictInfo> GetChildDictInfos(string dictCode)
        {
            string sql =  @"SELECT A.[DictID], A.[DictName], A.[DictCode], A.[IsSystem] FROM [DictInfos] A 
                            INNER JOIN [DictInfos] B ON A.ParentID=B.DictID 
                            Where B.DictCode=@ParentCode
                            Order by A.Sequence";
            SqlParameter pa = new SqlParameter("@ParentCode", dictCode);
            List<DictInfo> list = new List<DictInfo>();
            using (IDataReader reader = base.ExcuteDataReader(sql, pa))
            {
                while (reader.Read())
                {
                    DictInfo dict = new DictInfo();
                    dict.DictID = reader.GetInt32(0);
                    dict.DictName = reader.GetString(1);
                    dict.DictCode = reader.GetString(2);
                    dict.IsSystem = reader.GetBoolean(3);
                    dict.IsNew = false;
                    list.Add(dict);
                }
            }
            return list;
        }

        public List<DictInfo> QueryDictInfoList(int parentId)
        {
            string sql = @"SELECT [DictID],[DictName],[DictCode],[IsSystem],[ParentID],[Sequence],[Remark] 
                        FROM [DictInfos] WHERE ParentID=@ParentID Order By Sequence";
            SqlParameter pa = new SqlParameter("@ParentID", parentId);
            List<DictInfo> list = new List<DictInfo>();
            using (IDataReader reader = base.ExcuteDataReader(sql, pa))
            {
                while (reader.Read())
                {
                    DictInfo dict = new DictInfo();
                    dict.DictID = reader.GetInt32(0);
                    dict.DictName = reader.GetString(1);
                    dict.DictCode = reader.GetString(2);
                    dict.IsSystem = reader.GetBoolean(3);
                    dict.ParentID = reader.GetInt32(4);
                    dict.Sequence = reader.GetInt32(5);
                    dict.Remark = reader.IsDBNull(6)?"":reader.GetString(6);
                    dict.IsNew = false;
                    list.Add(dict);
                }
            }
            return list;
        }

        public List<DictInfo> GetDictInfoTree(int parentId)
        {
            string sql = @"SELECT A.[DictID],A.[DictName],A.[DictCode],A.[IsSystem],ISNULL(B.ChildCount,0) AS ChildCount 
                        FROM [DictInfos] A
                        LEFT JOIN (Select COUNT(1) as ChildCount, ParentID From DictInfos Group By ParentID) B ON A.DictID=B.ParentID
                        WHERE A.ParentID=@ParentID Order By A.Sequence";
            SqlParameter pa = new SqlParameter("@ParentID", parentId);
            List<DictInfo> list = new List<DictInfo>();
            using (IDataReader reader = base.ExcuteDataReader(sql, pa))
            {
                while (reader.Read())
                {
                    DictInfo dict = new DictInfo();
                    dict.DictID = reader.GetInt32(0);
                    dict.DictName = reader.GetString(1);
                    dict.DictCode = reader.GetString(2);
                    dict.IsSystem = reader.GetBoolean(3);
                    dict.HasChild = reader.GetInt32(4) > 0;
               
                    dict.IsNew = false;
                    list.Add(dict);
                }
            }
            return list;
        }

        public DictInfo GetDictInfo(int dictId)
        {
            string sql = @"SELECT A.[DictID],A.[DictName],A.[DictCode],A.[IsSystem],A.[ParentID],A.[Sequence],A.[Remark]
                          ,CASE WHEN A.ParentID=0 THEN '数据字典' ELSE B.DictName END AS ParentName 
                          FROM [DictInfos] A
                          LEFT JOIN [DictInfos] B on A.ParentID=B.DictID
                          Where a.DictID=@DictID
                          ORDER BY A.Sequence";
            SqlParameter pa = new SqlParameter("@DictID", dictId);
            DictInfo dict=null;
            using (IDataReader reader = base.ExcuteDataReader(sql, pa))
            {
                if (reader.Read())
                {
                    dict = new DictInfo();
                    dict.DictID = reader.GetInt32(0);
                    dict.DictName = reader.GetString(1);
                    dict.DictCode = reader.GetString(2);
                    dict.IsSystem = reader.GetBoolean(3);
                    dict.ParentID = reader.GetInt32(4);
                    dict.Sequence = reader.GetInt32(5);
                    dict.Remark = reader.IsDBNull(6) ? "" : reader.GetString(6);
                    dict.ParentName = reader.IsDBNull(7) ? "" : reader.GetString(7);
                    dict.IsNew = false;
                 
                }
            }
            return dict;
        }

        public bool CheckDictIsSystemOrHasChild(int id)
        {
            string sql = @"SELECT 1 FROM [DictInfos] A
                    LEFT JOIN (Select COUNT(1) as ChildCount, ParentID From DictInfos Group By ParentID) B ON A.DictID=B.ParentID
                    WHERE A.DictID=@DictID and (A.IsSystem=1 or isnull(B.ChildCount,0)>0)";
            SqlParameter pa = new SqlParameter("@DictID", id);
            object o = base.ExecuteScalar(sql, pa);
            return o != null;
        }
    }
}
