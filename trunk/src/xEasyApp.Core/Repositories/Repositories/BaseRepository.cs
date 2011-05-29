using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using xEasyApp.Core.Configurations;


namespace xEasyApp.Core.Repositories
{
    public class BaseRepository
    {

        public BaseRepository():this(AppConfig.MainDbkey)
        { }
        public BaseRepository(string dbkey)
        {
            _ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[dbkey].ConnectionString;
        }
        private string _ConnectionString;
        protected string ConnectionString
        {
            get {
                return _ConnectionString;
            }
        }
        public SqlDataReader ExcuteDataReader(string sql)
        {
            return SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, sql);
        }
        public SqlDataReader ExcuteDataReader(string sql, params SqlParameter[] commandParameters)
        {
           return SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, sql, commandParameters);
        }
        public object ExecuteScalar(string sql)
        {
            return SqlHelper.ExecuteScalar(ConnectionString, CommandType.Text, sql);
        }
        public object ExecuteScalar(string sql, params SqlParameter[] commandParameters)
        {
            return SqlHelper.ExecuteScalar(ConnectionString, CommandType.Text, sql, commandParameters);
        }

        public int ExecuteNonQuery(string sql)
        {
            return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, sql);
        }
        public int ExecuteNonQuery(string sql, params SqlParameter[] commandParameters)
        {
            return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, sql, commandParameters);
        }

        public DataSet ExecuteDataSet(string sql)
        {
            return SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql);
        }

        public DataSet ExecuteDataSet(string sql, params SqlParameter[] commandParameters)
        {
            return SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql, commandParameters);
        }

        public object SPExecuteScalar(string spName)
        {
            return SqlHelper.ExecuteScalar(ConnectionString, CommandType.StoredProcedure, spName);
        }
        public object SPExecuteScalar(string spName, params SqlParameter[] commandParameters)
        {
            return SqlHelper.ExecuteScalar(ConnectionString, CommandType.StoredProcedure, spName, commandParameters);
        }

        public int SPExecuteNonQuery(string spName)
        {
            return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, spName);
        }
        public int SPExecuteNonQuery(string spName, params SqlParameter[] commandParameters)
        {            
            return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, spName, commandParameters);
        }

        public DataSet SPExecuteDataSet(string spName)
        {
            return SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, spName);
        }

        public DataSet SPExecuteDataSet(string spName, params SqlParameter[] commandParameters)
        {
            return SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, spName, commandParameters);
        }

        public object SPExecuteScalar(StoredProcedure sp)
        {
            return SqlHelper.ExecuteScalar(ConnectionString, CommandType.StoredProcedure, sp.SPName,sp.SPParams.ToArray());
        }


        public int SPExecuteNonQuery(StoredProcedure sp)
        {
            return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, sp.SPName, sp.SPParams.ToArray());
        }
        
        public DataSet SPExecuteDataSet(StoredProcedure sp)
        {
            return SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, sp.SPName, sp.SPParams.ToArray());
        }
        public SqlDataReader SPExecuteDataReader(StoredProcedure sp)
        {
            return SqlHelper.ExecuteReader(ConnectionString, CommandType.StoredProcedure, sp.SPName, sp.SPParams.ToArray());
        }
    }
    public class TestRRepository : BaseRepository
    {

        public void Save(ShortCut item)
        {
            if (item.IsNew)
            {
                Insert(item);
            }
            else
            {
                Update(item);
            }
        }
        public ShortCut Get( object key)
        {
            return null;
            
        }
        public int Delete(object key)
        {
            return 1;
        }
        public void Insert(ShortCut item)
        {
            string sql = "INSERT INTO [ShortCut] ([ShortCutName],[Remark],[PrivilegeCode],[UserUID],[LastModifyTime],[Sequence]) VALUES (@ShortCutName,@Remark,@PrivilegeCode,@UserUID,@LastModifyTime,@Sequence)";
           
            List<SqlParameter> SPParams = new List<SqlParameter>();
            SPParams.Add(new SqlParameter("@ShortCutName", item.ShortCutName));
            SPParams.Add(new SqlParameter("@Remark", item.Remark));
            SPParams.Add(new SqlParameter("@PrivilegeCode", item.PrivilegeCode));
            SPParams.Add(new SqlParameter("@UserUID", item.UserUID));
            SPParams.Add(new SqlParameter("@LastModifyTime", item.LastModifyTime));
            SPParams.Add(new SqlParameter("@Sequence", item.Sequence));
            base.ExecuteNonQuery(sql, SPParams.ToArray());
        }
        public void Update(ShortCut item)
        {
            if(item.ChangedPropertyCount>0)
            {
                StringBuilder sqlbuilder = new StringBuilder();
                sqlbuilder.Append("UPDATE [ShortCut] SET ");
                Dictionary<string,string> cols =new Dictionary<string,string>();
                cols.Add("ShortCutName","[ShortCutName]");
				cols.Add("Remark","[Remark]");
				cols.Add("PrivilegeCode","[PrivilegeCode]");
				cols.Add("UserUID","[UserUID]");
				cols.Add("LastModifyTime","[LastModifyTime]");
				cols.Add("Sequence","[Sequence]");
                int i = 0;
                //UPDATE COLUMNS
                foreach (string p in item.ChangedPropertyList)
                { 
                    if(!cols.ContainsKey(p))
                    {
                        continue;
                    }
                    if (i > 0)
                    {
                        sqlbuilder.Append(",");
                    }
                    sqlbuilder.AppendFormat("{0}=@{1}", cols[p], p);
                    i++;
                }
                //WHERE;
                sqlbuilder.Append("WHERE [ShortCutID]=@ShortCutID");
               
                List<SqlParameter> SPParams = new List<SqlParameter>();
                SPParams.Add(new SqlParameter("@ShortCutID", item.ShortCutID));
                if(item.IsChanged("ShortCutName"))
                {
                  SPParams.Add(new SqlParameter("@ShortCutName", item.ShortCutName));
                }
                SPParams.Add(new SqlParameter("@Remark", item.Remark));
                SPParams.Add(new SqlParameter("@PrivilegeCode", item.PrivilegeCode));
                SPParams.Add(new SqlParameter("@UserUID", item.UserUID));
                SPParams.Add(new SqlParameter("@LastModifyTime", item.LastModifyTime));
                SPParams.Add(new SqlParameter("@Sequence", item.Sequence));
                base.ExecuteNonQuery(sqlbuilder.ToString(), SPParams.ToArray());

            }
        }

    }
}
