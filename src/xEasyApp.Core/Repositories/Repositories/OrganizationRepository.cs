using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using xEasyApp.Core.Entities;

namespace xEasyApp.Core.Repositories
{
    public partial class OrganizationRepository
    {

        public List<Organization> GetChildOrgsByParentCode(string parentCode)
        {
            string sql = "SELECT [OrgCode],[OrgName],[ParentCode],[Path],[Remark],[Sequence],[LastUpdateUserUID],[LastUpdateUserName],[LastUpdateTime] FROM [Organizations] where ParentCode=@ParentCode Order by [Sequence]";
            SqlParameter p = new SqlParameter("@ParentCode", parentCode);
            List<Organization> list = new List<Organization>();
            using (IDataReader reader = base.ExcuteDataReader(sql, p))
            {
                while (reader.Read())
                {
                    Organization item = new Organization();
                    item.OrgCode = reader.GetString(0);
                    item.OrgName = reader.GetString(1);
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

        public void SaveOrgInfo(Organization d)
        {
            StoredProcedure sp = StoredProcedures.SP_SaveOrgInfo(d.OrgCode, d.OrgName, d.ParentCode, d.Remark, d.Sequence, d.LastUpdateUserUID, d.LastUpdateUserName);
            base.SPExecuteNonQuery(sp);
        }

        public Organization GetOrganization(string orgCode)
        {
            string sql = @"SELECT D1.[OrgCode],D1.[OrgName],D1.[ParentCode],D1.[Path],D1.[Remark],D1.[OrgType],D1.[UnitName],D1.[UnitCode]
                        ,D1.[Sequence],D1.[LastUpdateUserUID],D1.[LastUpdateUserName],D1.[LastUpdateTime],D2.[OrgName] as ParentName 
                        FROM Organizations D1
                        LEFT JOIN Organizations D2 ON D1.ParentCode =D2.OrgCode
                        WHERE D1.OrgCode=@OrgCode";
            SqlParameter p = new SqlParameter("@OrgCode", orgCode);
            Organization item = null;
            using (IDataReader reader = base.ExcuteDataReader(sql, p))
            {
                if (reader.Read())
                {
                    item = new Organization();
                    item.OrgCode = reader.GetString(0);
                    item.OrgName = reader.GetString(1);
                    if (!reader.IsDBNull(2))
                    {
                        item.ParentCode = reader.GetString(2);
                    }
                    item.Path = reader.GetString(3);
                    if (!reader.IsDBNull(4))
                    {
                        item.Remark = reader.GetString(4);
                    }
                    if (!reader.IsDBNull(5))
                    {
                        item.OrgType = reader.GetByte(5);
                    }
                    item.UnitName = reader.IsDBNull(6) ? null : reader.GetString(6);
                    item.UnitCode = reader.IsDBNull(7) ? null : reader.GetString(7);
                    item.Sequence = reader.GetInt32(8);
                    item.LastUpdateUserUID = reader.GetString(9);
                    item.LastUpdateUserName = reader.GetString(10);
                    item.LastUpdateTime = reader.GetDateTime(11);
                    item.ParentName = reader.IsDBNull(12) ? null : reader.GetString(12);
                }
            }
            return item;
        }

        public bool ValidOrgCode(string orgCode)
        {
            string sql = "select 1 from Organizations where OrgCode=@OrgCode";
            SqlParameter p = new SqlParameter("@OrgCode", orgCode);
            object o = base.ExecuteScalar(sql, p);
            return o == null;
        }

        public PagedList<UserInfo> QueryOrgUserList(PageView view, string orgCode)
        {
            string where = " AND OrgCode='" + orgCode + "'";
            StoredProcedure sp = StoredProcedures.SP_PAGESELECT(where, view.PageSize, view.PageIndex
             , "UserInfos", "[UserUID],[FullName],[Password],[OrgCode],[OrgName],[Sequence],[AccountState],[LastUpdateUserUID],[LastUpdateUserName],[LastUpdateTime]"
             , "[UserUID]", "");
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
                    u.OrgCode =  dr.IsDBNull(3) ? null : dr.GetString(3);
                    u.OrgName = dr.IsDBNull(4) ? null : dr.GetString(4);
                    u.Sequence = dr.GetInt32(5);
                    u.AccountState = dr.GetByte(6);
                    u.LastUpdateUserUID = dr.IsDBNull(7) ? null : dr.GetString(7);
                    u.LastUpdateUserName = dr.IsDBNull(8) ? null : dr.GetString(8);
                    u.LastUpdateTime = dr.IsDBNull(9) ? DateTime.MinValue : dr.GetDateTime(9);                 
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

        public int DeleteOrgInfo(string OrgCode)
        {
            //TODO:删除组织信息
            throw new NotImplementedException();
        }
    }
}
