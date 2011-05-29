using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace xEasyApp.Core.Repositories
{
    public partial class DepartmentRepository
    {

        public List<Department> GetChildDeptsByParentCode(string parentCode)
        {
            string sql = "SELECT [DeptCode],[DeptName],[ParentCode],[Path],[Remark],[Sequence],[LastUpdateUserUID],[LastUpdateUserName],[LastUpdateTime] FROM [Departments] where ParentCode=@ParentCode Order by [Sequence]";
            SqlParameter p = new SqlParameter("@ParentCode", parentCode);
            List<Department> list = new List<Department>();
            using (IDataReader reader = base.ExcuteDataReader(sql, p))
            {
                while (reader.Read())
                {
                    Department item = new Department();
                    item.DeptCode = reader.GetString(0);
                    item.DeptName = reader.GetString(1);
                    if (!reader.IsDBNull(2))
                    {
                        item.ParentCode = reader.GetString(2);
                    }
                    item.Path = reader.GetString(3);
                    if (!reader.IsDBNull(4))
                    {
                        item.Remark = reader.GetString(4);
                    }
                    item.Sequence = reader.GetInt32(5);
                    item.LastUpdateUserUID = reader.GetString(6);
                    item.LastUpdateUserName = reader.GetString(7);
                    item.LastUpdateTime = reader.GetDateTime(8);
                    list.Add(item);
                }
            }
            return list;
        }

        public void SaveDeptInfo(Department d)
        {
            StoredProcedure sp = StoredProcedures.SP_SaveDeptInfo(d.DeptCode, d.DeptName, d.ParentCode, d.Remark, d.Sequence, d.LastUpdateUserUID, d.LastUpdateUserName);
            base.SPExecuteNonQuery(sp);
        }

        public Department GetDepartment(string deptCode)
        {
            string sql = @"SELECT D1.[DeptCode],D1.[DeptName],D1.[ParentCode],D1.[Path],D1.[Remark],D1.[Sequence],D1.[LastUpdateUserUID],D1.[LastUpdateUserName],D1.[LastUpdateTime],D2.[DeptName] as ParentName 
                        FROM Departments D1
                        LEFT JOIN Departments D2 ON D1.ParentCode =D2.DeptCode
                        WHERE D1.DeptCode=@DeptCode";
            SqlParameter p = new SqlParameter("@DeptCode", deptCode);
            Department item = null;
            using (IDataReader reader = base.ExcuteDataReader(sql, p))
            {
                if (reader.Read())
                {
                    item = new Department();
                    item.DeptCode = reader.GetString(0);
                    item.DeptName = reader.GetString(1);
                    if (!reader.IsDBNull(2))
                    {
                        item.ParentCode = reader.GetString(2);
                    }
                    item.Path = reader.GetString(3);
                    if (!reader.IsDBNull(4))
                    {
                        item.Remark = reader.GetString(4);
                    }
                    item.Sequence = reader.GetInt32(5);
                    item.LastUpdateUserUID = reader.GetString(6);
                    item.LastUpdateUserName = reader.GetString(7);
                    item.LastUpdateTime = reader.GetDateTime(8);
                    item.ParentName = reader.IsDBNull(9) ? null : reader.GetString(9);
                }
            }
            return item;
        }

        public bool ValidDeptCode(string deptCode)
        {
            string sql = "select 1 from Departments where DeptCode=@DeptCode";
            SqlParameter p = new SqlParameter("@DeptCode", deptCode);
            object o = base.ExecuteScalar(sql, p);
            return o == null;
        }
    }
}
