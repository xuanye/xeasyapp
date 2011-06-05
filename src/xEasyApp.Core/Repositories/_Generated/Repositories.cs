


//=============================================
// 该代码文件有程序自动生成，
// 生成时间: 2011-06-05 16:54:28
// =============================================
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;


namespace xEasyApp.Core.Repositories {
	
        /// <summary>
        /// Table: ShortCut
        /// Primary Key: ShortCutID
        /// </summary>
        public partial class ShortCutRepository:BaseRepository 
		{			
			public void Save(ShortCut item)
			{
				if(item.IsNew)
				{
					Insert(item);
				}
				else
				{
					Update(item);
				}
			}	
		    public ShortCut Get(int key)
			{
				string sql = "SELECT [ShortCutID],[ShortCutName],[Remark],[PrivilegeCode],[UserUID],[LastModifyTime],[Sequence] FROM [ShortCut] WHERE [ShortCutID]=@ShortCutID";
				SqlParameter p =new SqlParameter("@ShortCutID",key);
				ShortCut item =null;
				using(IDataReader reader = base.ExcuteDataReader(sql,p))
				{
					if(reader.Read())
					{
						item =new ShortCut();
						item.ShortCutID = reader.GetInt32(0);
							item.ShortCutName = reader.GetString(1);
							if(!reader.IsDBNull(2))
						 {
							item.Remark = reader.GetString(2);
						 }
						 if(!reader.IsDBNull(3))
						 {
							item.PrivilegeCode = reader.GetString(3);
						 }
						 if(!reader.IsDBNull(4))
						 {
							item.UserUID = reader.GetString(4);
						 }
						 if(!reader.IsDBNull(5))
						 {
							item.LastModifyTime = reader.GetDateTime(5);
						 }
						 if(!reader.IsDBNull(6))
						 {
							item.Sequence = reader.GetInt32(6);
						 }
						 
					}
				}
				return item;
			}
			public int Delete(int key)
			{
				string sql ="DELETE FROM [ShortCut] WHERE [ShortCutID]=@ShortCutID";
				SqlParameter p =new SqlParameter("@ShortCutID",key);
				return base.ExecuteNonQuery(sql,p);	
			}
			public void Insert(ShortCut item)
			{
				string sql="INSERT INTO [ShortCut] ([ShortCutName],[Remark],[PrivilegeCode],[UserUID],[LastModifyTime],[Sequence]) VALUES (@ShortCutName,@Remark,@PrivilegeCode,@UserUID,@LastModifyTime,@Sequence)";
				List<SqlParameter> SPParams = new List<SqlParameter>();
				SPParams.Add(new SqlParameter("@ShortCutName",item.ShortCutName));	
				SPParams.Add(new SqlParameter("@Remark",item.Remark));	
				SPParams.Add(new SqlParameter("@PrivilegeCode",item.PrivilegeCode));	
				SPParams.Add(new SqlParameter("@UserUID",item.UserUID));	
				SPParams.Add(new SqlParameter("@LastModifyTime",item.LastModifyTime));	
				SPParams.Add(new SqlParameter("@Sequence",item.Sequence));	
				sql +=";SELECT Scope_Identity()";
				object o = base.ExecuteScalar(sql, SPParams.ToArray());
				if(o!=null){
					item.ShortCutID =Convert.ToInt32(o);
				}
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
					sqlbuilder.Append(" WHERE [ShortCutID]=@ShortCutID");

					List<SqlParameter> SPParams = new List<SqlParameter>();
					 SPParams.Add(new SqlParameter("@ShortCutID",item.ShortCutID));	
 	
					if(item.IsChanged("ShortCutName"))
					{
						SPParams.Add(new SqlParameter("@ShortCutName",item.ShortCutName));	
					} 	
					if(item.IsChanged("Remark"))
					{
						SPParams.Add(new SqlParameter("@Remark",item.Remark));	
					} 	
					if(item.IsChanged("PrivilegeCode"))
					{
						SPParams.Add(new SqlParameter("@PrivilegeCode",item.PrivilegeCode));	
					} 	
					if(item.IsChanged("UserUID"))
					{
						SPParams.Add(new SqlParameter("@UserUID",item.UserUID));	
					} 	
					if(item.IsChanged("LastModifyTime"))
					{
						SPParams.Add(new SqlParameter("@LastModifyTime",item.LastModifyTime));	
					} 	
					if(item.IsChanged("Sequence"))
					{
						SPParams.Add(new SqlParameter("@Sequence",item.Sequence));	
					}
					base.ExecuteNonQuery(sqlbuilder.ToString(), SPParams.ToArray());
				}
			}
			public List<ShortCut> QueryAll()
			{
				string sql ="SELECT [ShortCutID],[ShortCutName],[Remark],[PrivilegeCode],[UserUID],[LastModifyTime],[Sequence] FROM [ShortCut]";
				List<ShortCut>  list =new List<ShortCut>();
				using(IDataReader reader = base.ExcuteDataReader(sql))
				{
					while(reader.Read())
					{
						ShortCut item =new ShortCut();
						item.ShortCutID = reader.GetInt32(0);
							item.ShortCutName = reader.GetString(1);
							if(!reader.IsDBNull(2))
						 {
							item.Remark = reader.GetString(2);
						 }
						 if(!reader.IsDBNull(3))
						 {
							item.PrivilegeCode = reader.GetString(3);
						 }
						 if(!reader.IsDBNull(4))
						 {
							item.UserUID = reader.GetString(4);
						 }
						 if(!reader.IsDBNull(5))
						 {
							item.LastModifyTime = reader.GetDateTime(5);
						 }
						 if(!reader.IsDBNull(6))
						 {
							item.Sequence = reader.GetInt32(6);
						 }
						 						list.Add(item);
					}
				}
				return list;
			}

        }
        
        /// <summary>
        /// Table: DictInfos
        /// Primary Key: DictID
        /// </summary>
        public partial class DictInfoRepository:BaseRepository 
		{			
			public void Save(DictInfo item)
			{
				if(item.IsNew)
				{
					Insert(item);
				}
				else
				{
					Update(item);
				}
			}	
		    public DictInfo Get(int key)
			{
				string sql = "SELECT [DictID],[DictName],[DictCode],[DictType],[ParentID],[Sequence],[SQLCMD],[Remark] FROM [DictInfos] WHERE [DictID]=@DictID";
				SqlParameter p =new SqlParameter("@DictID",key);
				DictInfo item =null;
				using(IDataReader reader = base.ExcuteDataReader(sql,p))
				{
					if(reader.Read())
					{
						item =new DictInfo();
						item.DictID = reader.GetInt32(0);
							item.DictName = reader.GetString(1);
							item.DictCode = reader.GetString(2);
							item.DictType = reader.GetByte(3);
							if(!reader.IsDBNull(4))
						 {
							item.ParentID = reader.GetInt32(4);
						 }
						 if(!reader.IsDBNull(5))
						 {
							item.Sequence = reader.GetInt32(5);
						 }
						 if(!reader.IsDBNull(6))
						 {
							item.SQLCMD = reader.GetString(6);
						 }
						 if(!reader.IsDBNull(7))
						 {
							item.Remark = reader.GetString(7);
						 }
						 
					}
				}
				return item;
			}
			public int Delete(int key)
			{
				string sql ="DELETE FROM [DictInfos] WHERE [DictID]=@DictID";
				SqlParameter p =new SqlParameter("@DictID",key);
				return base.ExecuteNonQuery(sql,p);	
			}
			public void Insert(DictInfo item)
			{
				string sql="INSERT INTO [DictInfos] ([DictName],[DictCode],[DictType],[ParentID],[Sequence],[SQLCMD],[Remark]) VALUES (@DictName,@DictCode,@DictType,@ParentID,@Sequence,@SQLCMD,@Remark)";
				List<SqlParameter> SPParams = new List<SqlParameter>();
				SPParams.Add(new SqlParameter("@DictName",item.DictName));	
				SPParams.Add(new SqlParameter("@DictCode",item.DictCode));	
				SPParams.Add(new SqlParameter("@DictType",item.DictType));	
				SPParams.Add(new SqlParameter("@ParentID",item.ParentID));	
				SPParams.Add(new SqlParameter("@Sequence",item.Sequence));	
				SPParams.Add(new SqlParameter("@SQLCMD",item.SQLCMD));	
				SPParams.Add(new SqlParameter("@Remark",item.Remark));	
				sql +=";SELECT Scope_Identity()";
				object o = base.ExecuteScalar(sql, SPParams.ToArray());
				if(o!=null){
					item.DictID =Convert.ToInt32(o);
				}
			}
            public void Update(DictInfo item)
			{
				if(item.ChangedPropertyCount>0)
				{
					StringBuilder sqlbuilder = new StringBuilder();
					sqlbuilder.Append("UPDATE [DictInfos] SET ");
					Dictionary<string,string> cols =new Dictionary<string,string>();
					cols.Add("DictName","[DictName]");
					cols.Add("DictCode","[DictCode]");
					cols.Add("DictType","[DictType]");
					cols.Add("ParentID","[ParentID]");
					cols.Add("Sequence","[Sequence]");
					cols.Add("SQLCMD","[SQLCMD]");
					cols.Add("Remark","[Remark]");
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
					sqlbuilder.Append(" WHERE [DictID]=@DictID");

					List<SqlParameter> SPParams = new List<SqlParameter>();
					 SPParams.Add(new SqlParameter("@DictID",item.DictID));	
 	
					if(item.IsChanged("DictName"))
					{
						SPParams.Add(new SqlParameter("@DictName",item.DictName));	
					} 	
					if(item.IsChanged("DictCode"))
					{
						SPParams.Add(new SqlParameter("@DictCode",item.DictCode));	
					} 	
					if(item.IsChanged("DictType"))
					{
						SPParams.Add(new SqlParameter("@DictType",item.DictType));	
					} 	
					if(item.IsChanged("ParentID"))
					{
						SPParams.Add(new SqlParameter("@ParentID",item.ParentID));	
					} 	
					if(item.IsChanged("Sequence"))
					{
						SPParams.Add(new SqlParameter("@Sequence",item.Sequence));	
					} 	
					if(item.IsChanged("SQLCMD"))
					{
						SPParams.Add(new SqlParameter("@SQLCMD",item.SQLCMD));	
					} 	
					if(item.IsChanged("Remark"))
					{
						SPParams.Add(new SqlParameter("@Remark",item.Remark));	
					}
					base.ExecuteNonQuery(sqlbuilder.ToString(), SPParams.ToArray());
				}
			}
			public List<DictInfo> QueryAll()
			{
				string sql ="SELECT [DictID],[DictName],[DictCode],[DictType],[ParentID],[Sequence],[SQLCMD],[Remark] FROM [DictInfos]";
				List<DictInfo>  list =new List<DictInfo>();
				using(IDataReader reader = base.ExcuteDataReader(sql))
				{
					while(reader.Read())
					{
						DictInfo item =new DictInfo();
						item.DictID = reader.GetInt32(0);
							item.DictName = reader.GetString(1);
							item.DictCode = reader.GetString(2);
							item.DictType = reader.GetByte(3);
							if(!reader.IsDBNull(4))
						 {
							item.ParentID = reader.GetInt32(4);
						 }
						 if(!reader.IsDBNull(5))
						 {
							item.Sequence = reader.GetInt32(5);
						 }
						 if(!reader.IsDBNull(6))
						 {
							item.SQLCMD = reader.GetString(6);
						 }
						 if(!reader.IsDBNull(7))
						 {
							item.Remark = reader.GetString(7);
						 }
						 						list.Add(item);
					}
				}
				return list;
			}

        }
        
        /// <summary>
        /// Table: Logs
        /// Primary Key: Id
        /// </summary>
        public partial class LogRepository:BaseRepository 
		{			
			public void Save(Log item)
			{
				if(item.IsNew)
				{
					Insert(item);
				}
				else
				{
					Update(item);
				}
			}	
		    public Log Get(int key)
			{
				string sql = "SELECT [Id],[Topic],[Content],[OperateCode],[LogType],[OperateUID],[OperateName],[IPAddress],[OperateTime] FROM [Logs] WHERE [Id]=@Id";
				SqlParameter p =new SqlParameter("@Id",key);
				Log item =null;
				using(IDataReader reader = base.ExcuteDataReader(sql,p))
				{
					if(reader.Read())
					{
						item =new Log();
						item.Id = reader.GetInt32(0);
							item.Topic = reader.GetString(1);
							item.Content = reader.GetString(2);
							item.OperateCode = reader.GetString(3);
							item.LogType = reader.GetByte(4);
							item.OperateUID = reader.GetString(5);
							item.OperateName = reader.GetString(6);
							item.IPAddress = reader.GetString(7);
							item.OperateTime = reader.GetDateTime(8);
							
					}
				}
				return item;
			}
			public int Delete(int key)
			{
				string sql ="DELETE FROM [Logs] WHERE [Id]=@Id";
				SqlParameter p =new SqlParameter("@Id",key);
				return base.ExecuteNonQuery(sql,p);	
			}
			public void Insert(Log item)
			{
				string sql="INSERT INTO [Logs] ([Topic],[Content],[OperateCode],[LogType],[OperateUID],[OperateName],[IPAddress],[OperateTime]) VALUES (@Topic,@Content,@OperateCode,@LogType,@OperateUID,@OperateName,@IPAddress,@OperateTime)";
				List<SqlParameter> SPParams = new List<SqlParameter>();
				SPParams.Add(new SqlParameter("@Topic",item.Topic));	
				SPParams.Add(new SqlParameter("@Content",item.Content));	
				SPParams.Add(new SqlParameter("@OperateCode",item.OperateCode));	
				SPParams.Add(new SqlParameter("@LogType",item.LogType));	
				SPParams.Add(new SqlParameter("@OperateUID",item.OperateUID));	
				SPParams.Add(new SqlParameter("@OperateName",item.OperateName));	
				SPParams.Add(new SqlParameter("@IPAddress",item.IPAddress));	
				SPParams.Add(new SqlParameter("@OperateTime",item.OperateTime));	
				sql +=";SELECT Scope_Identity()";
				object o = base.ExecuteScalar(sql, SPParams.ToArray());
				if(o!=null){
					item.Id =Convert.ToInt32(o);
				}
			}
            public void Update(Log item)
			{
				if(item.ChangedPropertyCount>0)
				{
					StringBuilder sqlbuilder = new StringBuilder();
					sqlbuilder.Append("UPDATE [Logs] SET ");
					Dictionary<string,string> cols =new Dictionary<string,string>();
					cols.Add("Topic","[Topic]");
					cols.Add("Content","[Content]");
					cols.Add("OperateCode","[OperateCode]");
					cols.Add("LogType","[LogType]");
					cols.Add("OperateUID","[OperateUID]");
					cols.Add("OperateName","[OperateName]");
					cols.Add("IPAddress","[IPAddress]");
					cols.Add("OperateTime","[OperateTime]");
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
					sqlbuilder.Append(" WHERE [Id]=@Id");

					List<SqlParameter> SPParams = new List<SqlParameter>();
					 SPParams.Add(new SqlParameter("@Id",item.Id));	
 	
					if(item.IsChanged("Topic"))
					{
						SPParams.Add(new SqlParameter("@Topic",item.Topic));	
					} 	
					if(item.IsChanged("Content"))
					{
						SPParams.Add(new SqlParameter("@Content",item.Content));	
					} 	
					if(item.IsChanged("OperateCode"))
					{
						SPParams.Add(new SqlParameter("@OperateCode",item.OperateCode));	
					} 	
					if(item.IsChanged("LogType"))
					{
						SPParams.Add(new SqlParameter("@LogType",item.LogType));	
					} 	
					if(item.IsChanged("OperateUID"))
					{
						SPParams.Add(new SqlParameter("@OperateUID",item.OperateUID));	
					} 	
					if(item.IsChanged("OperateName"))
					{
						SPParams.Add(new SqlParameter("@OperateName",item.OperateName));	
					} 	
					if(item.IsChanged("IPAddress"))
					{
						SPParams.Add(new SqlParameter("@IPAddress",item.IPAddress));	
					} 	
					if(item.IsChanged("OperateTime"))
					{
						SPParams.Add(new SqlParameter("@OperateTime",item.OperateTime));	
					}
					base.ExecuteNonQuery(sqlbuilder.ToString(), SPParams.ToArray());
				}
			}
			public List<Log> QueryAll()
			{
				string sql ="SELECT [Id],[Topic],[Content],[OperateCode],[LogType],[OperateUID],[OperateName],[IPAddress],[OperateTime] FROM [Logs]";
				List<Log>  list =new List<Log>();
				using(IDataReader reader = base.ExcuteDataReader(sql))
				{
					while(reader.Read())
					{
						Log item =new Log();
						item.Id = reader.GetInt32(0);
							item.Topic = reader.GetString(1);
							item.Content = reader.GetString(2);
							item.OperateCode = reader.GetString(3);
							item.LogType = reader.GetByte(4);
							item.OperateUID = reader.GetString(5);
							item.OperateName = reader.GetString(6);
							item.IPAddress = reader.GetString(7);
							item.OperateTime = reader.GetDateTime(8);
													list.Add(item);
					}
				}
				return list;
			}

        }
        
        /// <summary>
        /// Table: RolePrivilegeRelation
        /// Primary Key: PrivilegeCode
        /// </summary>
        public partial class RolePrivilegeRelationRepository:BaseRepository 
		{			
			public void Save(RolePrivilegeRelation item)
			{
				if(item.IsNew)
				{
					Insert(item);
				}
				else
				{
					Update(item);
				}
			}	
		    public RolePrivilegeRelation Get(string key)
			{
				string sql = "SELECT [RoleCode],[PrivilegeCode],[LastUpdateUserUID],[LastUpdateUserName],[LastUpdateTime] FROM [RolePrivilegeRelation] WHERE [PrivilegeCode]=@PrivilegeCode";
				SqlParameter p =new SqlParameter("@PrivilegeCode",key);
				RolePrivilegeRelation item =null;
				using(IDataReader reader = base.ExcuteDataReader(sql,p))
				{
					if(reader.Read())
					{
						item =new RolePrivilegeRelation();
						item.RoleCode = reader.GetString(0);
							item.PrivilegeCode = reader.GetString(1);
							item.LastUpdateUserUID = reader.GetString(2);
							item.LastUpdateUserName = reader.GetString(3);
							item.LastUpdateTime = reader.GetDateTime(4);
							
					}
				}
				return item;
			}
			public int Delete(string key)
			{
				string sql ="DELETE FROM [RolePrivilegeRelation] WHERE [PrivilegeCode]=@PrivilegeCode";
				SqlParameter p =new SqlParameter("@PrivilegeCode",key);
				return base.ExecuteNonQuery(sql,p);	
			}
			public void Insert(RolePrivilegeRelation item)
			{
				string sql="INSERT INTO [RolePrivilegeRelation] ([RoleCode],[PrivilegeCode],[LastUpdateUserUID],[LastUpdateUserName],[LastUpdateTime]) VALUES (@RoleCode,@PrivilegeCode,@LastUpdateUserUID,@LastUpdateUserName,@LastUpdateTime)";
				List<SqlParameter> SPParams = new List<SqlParameter>();
				SPParams.Add(new SqlParameter("@RoleCode",item.RoleCode));	
				SPParams.Add(new SqlParameter("@PrivilegeCode",item.PrivilegeCode));	
				SPParams.Add(new SqlParameter("@LastUpdateUserUID",item.LastUpdateUserUID));	
				SPParams.Add(new SqlParameter("@LastUpdateUserName",item.LastUpdateUserName));	
				SPParams.Add(new SqlParameter("@LastUpdateTime",item.LastUpdateTime));	
				base.ExecuteNonQuery(sql, SPParams.ToArray());
			}
            public void Update(RolePrivilegeRelation item)
			{
				if(item.ChangedPropertyCount>0)
				{
					StringBuilder sqlbuilder = new StringBuilder();
					sqlbuilder.Append("UPDATE [RolePrivilegeRelation] SET ");
					Dictionary<string,string> cols =new Dictionary<string,string>();
					cols.Add("LastUpdateUserUID","[LastUpdateUserUID]");
					cols.Add("LastUpdateUserName","[LastUpdateUserName]");
					cols.Add("LastUpdateTime","[LastUpdateTime]");
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
					sqlbuilder.Append(" WHERE [PrivilegeCode]=@PrivilegeCode");

					List<SqlParameter> SPParams = new List<SqlParameter>();
					 SPParams.Add(new SqlParameter("@RoleCode",item.RoleCode));	
 SPParams.Add(new SqlParameter("@PrivilegeCode",item.PrivilegeCode));	
 	
					if(item.IsChanged("LastUpdateUserUID"))
					{
						SPParams.Add(new SqlParameter("@LastUpdateUserUID",item.LastUpdateUserUID));	
					} 	
					if(item.IsChanged("LastUpdateUserName"))
					{
						SPParams.Add(new SqlParameter("@LastUpdateUserName",item.LastUpdateUserName));	
					} 	
					if(item.IsChanged("LastUpdateTime"))
					{
						SPParams.Add(new SqlParameter("@LastUpdateTime",item.LastUpdateTime));	
					}
					base.ExecuteNonQuery(sqlbuilder.ToString(), SPParams.ToArray());
				}
			}
			public List<RolePrivilegeRelation> QueryAll()
			{
				string sql ="SELECT [RoleCode],[PrivilegeCode],[LastUpdateUserUID],[LastUpdateUserName],[LastUpdateTime] FROM [RolePrivilegeRelation]";
				List<RolePrivilegeRelation>  list =new List<RolePrivilegeRelation>();
				using(IDataReader reader = base.ExcuteDataReader(sql))
				{
					while(reader.Read())
					{
						RolePrivilegeRelation item =new RolePrivilegeRelation();
						item.RoleCode = reader.GetString(0);
							item.PrivilegeCode = reader.GetString(1);
							item.LastUpdateUserUID = reader.GetString(2);
							item.LastUpdateUserName = reader.GetString(3);
							item.LastUpdateTime = reader.GetDateTime(4);
													list.Add(item);
					}
				}
				return list;
			}

        }
        
        /// <summary>
        /// Table: RoleUserRelation
        /// Primary Key: RoleCode
        /// </summary>
        public partial class RoleUserRelationRepository:BaseRepository 
		{			
			public void Save(RoleUserRelation item)
			{
				if(item.IsNew)
				{
					Insert(item);
				}
				else
				{
					Update(item);
				}
			}	
		    public RoleUserRelation Get(string key)
			{
				string sql = "SELECT [RoleCode],[UserUID],[LastUpdateUserUID],[LastUpdateUserName],[LastUpdateTime] FROM [RoleUserRelation] WHERE [RoleCode]=@RoleCode";
				SqlParameter p =new SqlParameter("@RoleCode",key);
				RoleUserRelation item =null;
				using(IDataReader reader = base.ExcuteDataReader(sql,p))
				{
					if(reader.Read())
					{
						item =new RoleUserRelation();
						item.RoleCode = reader.GetString(0);
							item.UserUID = reader.GetString(1);
							item.LastUpdateUserUID = reader.GetString(2);
							item.LastUpdateUserName = reader.GetString(3);
							item.LastUpdateTime = reader.GetDateTime(4);
							
					}
				}
				return item;
			}
			public int Delete(string key)
			{
				string sql ="DELETE FROM [RoleUserRelation] WHERE [RoleCode]=@RoleCode";
				SqlParameter p =new SqlParameter("@RoleCode",key);
				return base.ExecuteNonQuery(sql,p);	
			}
			public void Insert(RoleUserRelation item)
			{
				string sql="INSERT INTO [RoleUserRelation] ([RoleCode],[UserUID],[LastUpdateUserUID],[LastUpdateUserName],[LastUpdateTime]) VALUES (@RoleCode,@UserUID,@LastUpdateUserUID,@LastUpdateUserName,@LastUpdateTime)";
				List<SqlParameter> SPParams = new List<SqlParameter>();
				SPParams.Add(new SqlParameter("@RoleCode",item.RoleCode));	
				SPParams.Add(new SqlParameter("@UserUID",item.UserUID));	
				SPParams.Add(new SqlParameter("@LastUpdateUserUID",item.LastUpdateUserUID));	
				SPParams.Add(new SqlParameter("@LastUpdateUserName",item.LastUpdateUserName));	
				SPParams.Add(new SqlParameter("@LastUpdateTime",item.LastUpdateTime));	
				base.ExecuteNonQuery(sql, SPParams.ToArray());
			}
            public void Update(RoleUserRelation item)
			{
				if(item.ChangedPropertyCount>0)
				{
					StringBuilder sqlbuilder = new StringBuilder();
					sqlbuilder.Append("UPDATE [RoleUserRelation] SET ");
					Dictionary<string,string> cols =new Dictionary<string,string>();
					cols.Add("LastUpdateUserUID","[LastUpdateUserUID]");
					cols.Add("LastUpdateUserName","[LastUpdateUserName]");
					cols.Add("LastUpdateTime","[LastUpdateTime]");
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
					sqlbuilder.Append(" WHERE [RoleCode]=@RoleCode");

					List<SqlParameter> SPParams = new List<SqlParameter>();
					 SPParams.Add(new SqlParameter("@RoleCode",item.RoleCode));	
 SPParams.Add(new SqlParameter("@UserUID",item.UserUID));	
 	
					if(item.IsChanged("LastUpdateUserUID"))
					{
						SPParams.Add(new SqlParameter("@LastUpdateUserUID",item.LastUpdateUserUID));	
					} 	
					if(item.IsChanged("LastUpdateUserName"))
					{
						SPParams.Add(new SqlParameter("@LastUpdateUserName",item.LastUpdateUserName));	
					} 	
					if(item.IsChanged("LastUpdateTime"))
					{
						SPParams.Add(new SqlParameter("@LastUpdateTime",item.LastUpdateTime));	
					}
					base.ExecuteNonQuery(sqlbuilder.ToString(), SPParams.ToArray());
				}
			}
			public List<RoleUserRelation> QueryAll()
			{
				string sql ="SELECT [RoleCode],[UserUID],[LastUpdateUserUID],[LastUpdateUserName],[LastUpdateTime] FROM [RoleUserRelation]";
				List<RoleUserRelation>  list =new List<RoleUserRelation>();
				using(IDataReader reader = base.ExcuteDataReader(sql))
				{
					while(reader.Read())
					{
						RoleUserRelation item =new RoleUserRelation();
						item.RoleCode = reader.GetString(0);
							item.UserUID = reader.GetString(1);
							item.LastUpdateUserUID = reader.GetString(2);
							item.LastUpdateUserName = reader.GetString(3);
							item.LastUpdateTime = reader.GetDateTime(4);
													list.Add(item);
					}
				}
				return list;
			}

        }
        
        /// <summary>
        /// Table: Departments
        /// Primary Key: DeptCode
        /// </summary>
        public partial class DepartmentRepository:BaseRepository 
		{			
			public void Save(Department item)
			{
				if(item.IsNew)
				{
					Insert(item);
				}
				else
				{
					Update(item);
				}
			}	
		    public Department Get(string key)
			{
				string sql = "SELECT [DeptCode],[DeptName],[ParentCode],[Path],[Remark],[Sequence],[LastUpdateUserUID],[LastUpdateUserName],[LastUpdateTime] FROM [Departments] WHERE [DeptCode]=@DeptCode";
				SqlParameter p =new SqlParameter("@DeptCode",key);
				Department item =null;
				using(IDataReader reader = base.ExcuteDataReader(sql,p))
				{
					if(reader.Read())
					{
						item =new Department();
						item.DeptCode = reader.GetString(0);
							item.DeptName = reader.GetString(1);
							if(!reader.IsDBNull(2))
						 {
							item.ParentCode = reader.GetString(2);
						 }
						 item.Path = reader.GetString(3);
							if(!reader.IsDBNull(4))
						 {
							item.Remark = reader.GetString(4);
						 }
						 item.Sequence = reader.GetInt32(5);
							item.LastUpdateUserUID = reader.GetString(6);
							item.LastUpdateUserName = reader.GetString(7);
							item.LastUpdateTime = reader.GetDateTime(8);
							
					}
				}
				return item;
			}
			public int Delete(string key)
			{
				string sql ="DELETE FROM [Departments] WHERE [DeptCode]=@DeptCode";
				SqlParameter p =new SqlParameter("@DeptCode",key);
				return base.ExecuteNonQuery(sql,p);	
			}
			public void Insert(Department item)
			{
				string sql="INSERT INTO [Departments] ([DeptCode],[DeptName],[ParentCode],[Path],[Remark],[Sequence],[LastUpdateUserUID],[LastUpdateUserName],[LastUpdateTime]) VALUES (@DeptCode,@DeptName,@ParentCode,@Path,@Remark,@Sequence,@LastUpdateUserUID,@LastUpdateUserName,@LastUpdateTime)";
				List<SqlParameter> SPParams = new List<SqlParameter>();
				SPParams.Add(new SqlParameter("@DeptCode",item.DeptCode));	
				SPParams.Add(new SqlParameter("@DeptName",item.DeptName));	
				SPParams.Add(new SqlParameter("@ParentCode",item.ParentCode));	
				SPParams.Add(new SqlParameter("@Path",item.Path));	
				SPParams.Add(new SqlParameter("@Remark",item.Remark));	
				SPParams.Add(new SqlParameter("@Sequence",item.Sequence));	
				SPParams.Add(new SqlParameter("@LastUpdateUserUID",item.LastUpdateUserUID));	
				SPParams.Add(new SqlParameter("@LastUpdateUserName",item.LastUpdateUserName));	
				SPParams.Add(new SqlParameter("@LastUpdateTime",item.LastUpdateTime));	
				base.ExecuteNonQuery(sql, SPParams.ToArray());
			}
            public void Update(Department item)
			{
				if(item.ChangedPropertyCount>0)
				{
					StringBuilder sqlbuilder = new StringBuilder();
					sqlbuilder.Append("UPDATE [Departments] SET ");
					Dictionary<string,string> cols =new Dictionary<string,string>();
					cols.Add("DeptName","[DeptName]");
					cols.Add("ParentCode","[ParentCode]");
					cols.Add("Path","[Path]");
					cols.Add("Remark","[Remark]");
					cols.Add("Sequence","[Sequence]");
					cols.Add("LastUpdateUserUID","[LastUpdateUserUID]");
					cols.Add("LastUpdateUserName","[LastUpdateUserName]");
					cols.Add("LastUpdateTime","[LastUpdateTime]");
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
					sqlbuilder.Append(" WHERE [DeptCode]=@DeptCode");

					List<SqlParameter> SPParams = new List<SqlParameter>();
					 SPParams.Add(new SqlParameter("@DeptCode",item.DeptCode));	
 	
					if(item.IsChanged("DeptName"))
					{
						SPParams.Add(new SqlParameter("@DeptName",item.DeptName));	
					} 	
					if(item.IsChanged("ParentCode"))
					{
						SPParams.Add(new SqlParameter("@ParentCode",item.ParentCode));	
					} 	
					if(item.IsChanged("Path"))
					{
						SPParams.Add(new SqlParameter("@Path",item.Path));	
					} 	
					if(item.IsChanged("Remark"))
					{
						SPParams.Add(new SqlParameter("@Remark",item.Remark));	
					} 	
					if(item.IsChanged("Sequence"))
					{
						SPParams.Add(new SqlParameter("@Sequence",item.Sequence));	
					} 	
					if(item.IsChanged("LastUpdateUserUID"))
					{
						SPParams.Add(new SqlParameter("@LastUpdateUserUID",item.LastUpdateUserUID));	
					} 	
					if(item.IsChanged("LastUpdateUserName"))
					{
						SPParams.Add(new SqlParameter("@LastUpdateUserName",item.LastUpdateUserName));	
					} 	
					if(item.IsChanged("LastUpdateTime"))
					{
						SPParams.Add(new SqlParameter("@LastUpdateTime",item.LastUpdateTime));	
					}
					base.ExecuteNonQuery(sqlbuilder.ToString(), SPParams.ToArray());
				}
			}
			public List<Department> QueryAll()
			{
				string sql ="SELECT [DeptCode],[DeptName],[ParentCode],[Path],[Remark],[Sequence],[LastUpdateUserUID],[LastUpdateUserName],[LastUpdateTime] FROM [Departments]";
				List<Department>  list =new List<Department>();
				using(IDataReader reader = base.ExcuteDataReader(sql))
				{
					while(reader.Read())
					{
						Department item =new Department();
						item.DeptCode = reader.GetString(0);
							item.DeptName = reader.GetString(1);
							if(!reader.IsDBNull(2))
						 {
							item.ParentCode = reader.GetString(2);
						 }
						 item.Path = reader.GetString(3);
							if(!reader.IsDBNull(4))
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

        }
        
        /// <summary>
        /// Table: UserInfos
        /// Primary Key: UserUID
        /// </summary>
        public partial class UserInfoRepository:BaseRepository 
		{			
			public void Save(UserInfo item)
			{
				if(item.IsNew)
				{
					Insert(item);
				}
				else
				{
					Update(item);
				}
			}	
		    public UserInfo Get(string key)
			{
				string sql = "SELECT [UserUID],[FullName],[Password],[DeptCode],[DeptName],[IsManager],[IsSystem],[Sequence],[AccountState],[LastUpdateUserUID],[LastUpdateUserName],[LastUpdateTime] FROM [UserInfos] WHERE [UserUID]=@UserUID";
				SqlParameter p =new SqlParameter("@UserUID",key);
				UserInfo item =null;
				using(IDataReader reader = base.ExcuteDataReader(sql,p))
				{
					if(reader.Read())
					{
						item =new UserInfo();
						item.UserUID = reader.GetString(0);
							item.FullName = reader.GetString(1);
							item.Password = reader.GetString(2);
							item.DeptCode = reader.GetString(3);
							if(!reader.IsDBNull(4))
						 {
							item.DeptName = reader.GetString(4);
						 }
						 item.IsManager = reader.GetBoolean(5);
							item.IsSystem = reader.GetBoolean(6);
							item.Sequence = reader.GetInt32(7);
							item.AccountState = reader.GetByte(8);
							item.LastUpdateUserUID = reader.GetString(9);
							item.LastUpdateUserName = reader.GetString(10);
							item.LastUpdateTime = reader.GetDateTime(11);
							
					}
				}
				return item;
			}
			public int Delete(string key)
			{
				string sql ="DELETE FROM [UserInfos] WHERE [UserUID]=@UserUID";
				SqlParameter p =new SqlParameter("@UserUID",key);
				return base.ExecuteNonQuery(sql,p);	
			}
			public void Insert(UserInfo item)
			{
				string sql="INSERT INTO [UserInfos] ([UserUID],[FullName],[Password],[DeptCode],[DeptName],[IsManager],[IsSystem],[Sequence],[AccountState],[LastUpdateUserUID],[LastUpdateUserName],[LastUpdateTime]) VALUES (@UserUID,@FullName,@Password,@DeptCode,@DeptName,@IsManager,@IsSystem,@Sequence,@AccountState,@LastUpdateUserUID,@LastUpdateUserName,@LastUpdateTime)";
				List<SqlParameter> SPParams = new List<SqlParameter>();
				SPParams.Add(new SqlParameter("@UserUID",item.UserUID));	
				SPParams.Add(new SqlParameter("@FullName",item.FullName));	
				SPParams.Add(new SqlParameter("@Password",item.Password));	
				SPParams.Add(new SqlParameter("@DeptCode",item.DeptCode));	
				SPParams.Add(new SqlParameter("@DeptName",item.DeptName));	
				SPParams.Add(new SqlParameter("@IsManager",item.IsManager));	
				SPParams.Add(new SqlParameter("@IsSystem",item.IsSystem));	
				SPParams.Add(new SqlParameter("@Sequence",item.Sequence));	
				SPParams.Add(new SqlParameter("@AccountState",item.AccountState));	
				SPParams.Add(new SqlParameter("@LastUpdateUserUID",item.LastUpdateUserUID));	
				SPParams.Add(new SqlParameter("@LastUpdateUserName",item.LastUpdateUserName));	
				SPParams.Add(new SqlParameter("@LastUpdateTime",item.LastUpdateTime));	
				base.ExecuteNonQuery(sql, SPParams.ToArray());
			}
            public void Update(UserInfo item)
			{
				if(item.ChangedPropertyCount>0)
				{
					StringBuilder sqlbuilder = new StringBuilder();
					sqlbuilder.Append("UPDATE [UserInfos] SET ");
					Dictionary<string,string> cols =new Dictionary<string,string>();
					cols.Add("FullName","[FullName]");
					cols.Add("Password","[Password]");
					cols.Add("DeptCode","[DeptCode]");
					cols.Add("DeptName","[DeptName]");
					cols.Add("IsManager","[IsManager]");
					cols.Add("IsSystem","[IsSystem]");
					cols.Add("Sequence","[Sequence]");
					cols.Add("AccountState","[AccountState]");
					cols.Add("LastUpdateUserUID","[LastUpdateUserUID]");
					cols.Add("LastUpdateUserName","[LastUpdateUserName]");
					cols.Add("LastUpdateTime","[LastUpdateTime]");
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
					sqlbuilder.Append(" WHERE [UserUID]=@UserUID");

					List<SqlParameter> SPParams = new List<SqlParameter>();
					 SPParams.Add(new SqlParameter("@UserUID",item.UserUID));	
 	
					if(item.IsChanged("FullName"))
					{
						SPParams.Add(new SqlParameter("@FullName",item.FullName));	
					} 	
					if(item.IsChanged("Password"))
					{
						SPParams.Add(new SqlParameter("@Password",item.Password));	
					} 	
					if(item.IsChanged("DeptCode"))
					{
						SPParams.Add(new SqlParameter("@DeptCode",item.DeptCode));	
					} 	
					if(item.IsChanged("DeptName"))
					{
						SPParams.Add(new SqlParameter("@DeptName",item.DeptName));	
					} 	
					if(item.IsChanged("IsManager"))
					{
						SPParams.Add(new SqlParameter("@IsManager",item.IsManager));	
					} 	
					if(item.IsChanged("IsSystem"))
					{
						SPParams.Add(new SqlParameter("@IsSystem",item.IsSystem));	
					} 	
					if(item.IsChanged("Sequence"))
					{
						SPParams.Add(new SqlParameter("@Sequence",item.Sequence));	
					} 	
					if(item.IsChanged("AccountState"))
					{
						SPParams.Add(new SqlParameter("@AccountState",item.AccountState));	
					} 	
					if(item.IsChanged("LastUpdateUserUID"))
					{
						SPParams.Add(new SqlParameter("@LastUpdateUserUID",item.LastUpdateUserUID));	
					} 	
					if(item.IsChanged("LastUpdateUserName"))
					{
						SPParams.Add(new SqlParameter("@LastUpdateUserName",item.LastUpdateUserName));	
					} 	
					if(item.IsChanged("LastUpdateTime"))
					{
						SPParams.Add(new SqlParameter("@LastUpdateTime",item.LastUpdateTime));	
					}
					base.ExecuteNonQuery(sqlbuilder.ToString(), SPParams.ToArray());
				}
			}
			public List<UserInfo> QueryAll()
			{
				string sql ="SELECT [UserUID],[FullName],[Password],[DeptCode],[DeptName],[IsManager],[IsSystem],[Sequence],[AccountState],[LastUpdateUserUID],[LastUpdateUserName],[LastUpdateTime] FROM [UserInfos]";
				List<UserInfo>  list =new List<UserInfo>();
				using(IDataReader reader = base.ExcuteDataReader(sql))
				{
					while(reader.Read())
					{
						UserInfo item =new UserInfo();
						item.UserUID = reader.GetString(0);
							item.FullName = reader.GetString(1);
							item.Password = reader.GetString(2);
							item.DeptCode = reader.GetString(3);
							if(!reader.IsDBNull(4))
						 {
							item.DeptName = reader.GetString(4);
						 }
						 item.IsManager = reader.GetBoolean(5);
							item.IsSystem = reader.GetBoolean(6);
							item.Sequence = reader.GetInt32(7);
							item.AccountState = reader.GetByte(8);
							item.LastUpdateUserUID = reader.GetString(9);
							item.LastUpdateUserName = reader.GetString(10);
							item.LastUpdateTime = reader.GetDateTime(11);
													list.Add(item);
					}
				}
				return list;
			}

        }
        
        /// <summary>
        /// Table: Privileges
        /// Primary Key: PrivilegeCode
        /// </summary>
        public partial class PrivilegeRepository:BaseRepository 
		{			
			public void Save(Privilege item)
			{
				if(item.IsNew)
				{
					Insert(item);
				}
				else
				{
					Update(item);
				}
			}	
		    public Privilege Get(string key)
			{
				string sql = "SELECT [PrivilegeCode],[PrivilegeName],[PrivilegeType],[Remark],[ParentID],[Uri],[Sequence],[LastUpdateUserUID],[LastUpdateUserName],[LastUpdateTime] FROM [Privileges] WHERE [PrivilegeCode]=@PrivilegeCode";
				SqlParameter p =new SqlParameter("@PrivilegeCode",key);
				Privilege item =null;
				using(IDataReader reader = base.ExcuteDataReader(sql,p))
				{
					if(reader.Read())
					{
						item =new Privilege();
						item.PrivilegeCode = reader.GetString(0);
							item.PrivilegeName = reader.GetString(1);
							item.PrivilegeType = reader.GetByte(2);
							if(!reader.IsDBNull(3))
						 {
							item.Remark = reader.GetString(3);
						 }
						 if(!reader.IsDBNull(4))
						 {
							item.ParentID = reader.GetString(4);
						 }
						 if(!reader.IsDBNull(5))
						 {
							item.Uri = reader.GetString(5);
						 }
						 item.Sequence = reader.GetInt32(6);
							item.LastUpdateUserUID = reader.GetString(7);
							item.LastUpdateUserName = reader.GetString(8);
							item.LastUpdateTime = reader.GetDateTime(9);
							
					}
				}
				return item;
			}
			public int Delete(string key)
			{
				string sql ="DELETE FROM [Privileges] WHERE [PrivilegeCode]=@PrivilegeCode";
				SqlParameter p =new SqlParameter("@PrivilegeCode",key);
				return base.ExecuteNonQuery(sql,p);	
			}
			public void Insert(Privilege item)
			{
				string sql="INSERT INTO [Privileges] ([PrivilegeCode],[PrivilegeName],[PrivilegeType],[Remark],[ParentID],[Uri],[Sequence],[LastUpdateUserUID],[LastUpdateUserName],[LastUpdateTime]) VALUES (@PrivilegeCode,@PrivilegeName,@PrivilegeType,@Remark,@ParentID,@Uri,@Sequence,@LastUpdateUserUID,@LastUpdateUserName,@LastUpdateTime)";
				List<SqlParameter> SPParams = new List<SqlParameter>();
				SPParams.Add(new SqlParameter("@PrivilegeCode",item.PrivilegeCode));	
				SPParams.Add(new SqlParameter("@PrivilegeName",item.PrivilegeName));	
				SPParams.Add(new SqlParameter("@PrivilegeType",item.PrivilegeType));	
				SPParams.Add(new SqlParameter("@Remark",item.Remark));	
				SPParams.Add(new SqlParameter("@ParentID",item.ParentID));	
				SPParams.Add(new SqlParameter("@Uri",item.Uri));	
				SPParams.Add(new SqlParameter("@Sequence",item.Sequence));	
				SPParams.Add(new SqlParameter("@LastUpdateUserUID",item.LastUpdateUserUID));	
				SPParams.Add(new SqlParameter("@LastUpdateUserName",item.LastUpdateUserName));	
				SPParams.Add(new SqlParameter("@LastUpdateTime",item.LastUpdateTime));	
				base.ExecuteNonQuery(sql, SPParams.ToArray());
			}
            public void Update(Privilege item)
			{
				if(item.ChangedPropertyCount>0)
				{
					StringBuilder sqlbuilder = new StringBuilder();
					sqlbuilder.Append("UPDATE [Privileges] SET ");
					Dictionary<string,string> cols =new Dictionary<string,string>();
					cols.Add("PrivilegeName","[PrivilegeName]");
					cols.Add("PrivilegeType","[PrivilegeType]");
					cols.Add("Remark","[Remark]");
					cols.Add("ParentID","[ParentID]");
					cols.Add("Uri","[Uri]");
					cols.Add("Sequence","[Sequence]");
					cols.Add("LastUpdateUserUID","[LastUpdateUserUID]");
					cols.Add("LastUpdateUserName","[LastUpdateUserName]");
					cols.Add("LastUpdateTime","[LastUpdateTime]");
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
					sqlbuilder.Append(" WHERE [PrivilegeCode]=@PrivilegeCode");

					List<SqlParameter> SPParams = new List<SqlParameter>();
					 SPParams.Add(new SqlParameter("@PrivilegeCode",item.PrivilegeCode));	
 	
					if(item.IsChanged("PrivilegeName"))
					{
						SPParams.Add(new SqlParameter("@PrivilegeName",item.PrivilegeName));	
					} 	
					if(item.IsChanged("PrivilegeType"))
					{
						SPParams.Add(new SqlParameter("@PrivilegeType",item.PrivilegeType));	
					} 	
					if(item.IsChanged("Remark"))
					{
						SPParams.Add(new SqlParameter("@Remark",item.Remark));	
					} 	
					if(item.IsChanged("ParentID"))
					{
						SPParams.Add(new SqlParameter("@ParentID",item.ParentID));	
					} 	
					if(item.IsChanged("Uri"))
					{
						SPParams.Add(new SqlParameter("@Uri",item.Uri));	
					} 	
					if(item.IsChanged("Sequence"))
					{
						SPParams.Add(new SqlParameter("@Sequence",item.Sequence));	
					} 	
					if(item.IsChanged("LastUpdateUserUID"))
					{
						SPParams.Add(new SqlParameter("@LastUpdateUserUID",item.LastUpdateUserUID));	
					} 	
					if(item.IsChanged("LastUpdateUserName"))
					{
						SPParams.Add(new SqlParameter("@LastUpdateUserName",item.LastUpdateUserName));	
					} 	
					if(item.IsChanged("LastUpdateTime"))
					{
						SPParams.Add(new SqlParameter("@LastUpdateTime",item.LastUpdateTime));	
					}
					base.ExecuteNonQuery(sqlbuilder.ToString(), SPParams.ToArray());
				}
			}
			public List<Privilege> QueryAll()
			{
				string sql ="SELECT [PrivilegeCode],[PrivilegeName],[PrivilegeType],[Remark],[ParentID],[Uri],[Sequence],[LastUpdateUserUID],[LastUpdateUserName],[LastUpdateTime] FROM [Privileges]";
				List<Privilege>  list =new List<Privilege>();
				using(IDataReader reader = base.ExcuteDataReader(sql))
				{
					while(reader.Read())
					{
						Privilege item =new Privilege();
						item.PrivilegeCode = reader.GetString(0);
							item.PrivilegeName = reader.GetString(1);
							item.PrivilegeType = reader.GetByte(2);
							if(!reader.IsDBNull(3))
						 {
							item.Remark = reader.GetString(3);
						 }
						 if(!reader.IsDBNull(4))
						 {
							item.ParentID = reader.GetString(4);
						 }
						 if(!reader.IsDBNull(5))
						 {
							item.Uri = reader.GetString(5);
						 }
						 item.Sequence = reader.GetInt32(6);
							item.LastUpdateUserUID = reader.GetString(7);
							item.LastUpdateUserName = reader.GetString(8);
							item.LastUpdateTime = reader.GetDateTime(9);
													list.Add(item);
					}
				}
				return list;
			}

        }
        
        /// <summary>
        /// Table: RoleInfos
        /// Primary Key: RoleCode
        /// </summary>
        public partial class RoleInfoRepository:BaseRepository 
		{			
			public void Save(RoleInfo item)
			{
				if(item.IsNew)
				{
					Insert(item);
				}
				else
				{
					Update(item);
				}
			}	
		    public RoleInfo Get(string key)
			{
				string sql = "SELECT [RoleCode],[RoleName],[LastUpdateUserUID],[LastUpdateUserName],[LastUpdateTime],[IsSystem] FROM [RoleInfos] WHERE [RoleCode]=@RoleCode";
				SqlParameter p =new SqlParameter("@RoleCode",key);
				RoleInfo item =null;
				using(IDataReader reader = base.ExcuteDataReader(sql,p))
				{
					if(reader.Read())
					{
						item =new RoleInfo();
						item.RoleCode = reader.GetString(0);
							item.RoleName = reader.GetString(1);
							item.LastUpdateUserUID = reader.GetString(2);
							item.LastUpdateUserName = reader.GetString(3);
							item.LastUpdateTime = reader.GetDateTime(4);
							if(!reader.IsDBNull(5))
						 {
							item.IsSystem = reader.GetBoolean(5);
						 }
						 
					}
				}
				return item;
			}
			public int Delete(string key)
			{
				string sql ="DELETE FROM [RoleInfos] WHERE [RoleCode]=@RoleCode";
				SqlParameter p =new SqlParameter("@RoleCode",key);
				return base.ExecuteNonQuery(sql,p);	
			}
			public void Insert(RoleInfo item)
			{
				string sql="INSERT INTO [RoleInfos] ([RoleCode],[RoleName],[LastUpdateUserUID],[LastUpdateUserName],[LastUpdateTime],[IsSystem]) VALUES (@RoleCode,@RoleName,@LastUpdateUserUID,@LastUpdateUserName,@LastUpdateTime,@IsSystem)";
				List<SqlParameter> SPParams = new List<SqlParameter>();
				SPParams.Add(new SqlParameter("@RoleCode",item.RoleCode));	
				SPParams.Add(new SqlParameter("@RoleName",item.RoleName));	
				SPParams.Add(new SqlParameter("@LastUpdateUserUID",item.LastUpdateUserUID));	
				SPParams.Add(new SqlParameter("@LastUpdateUserName",item.LastUpdateUserName));	
				SPParams.Add(new SqlParameter("@LastUpdateTime",item.LastUpdateTime));	
				SPParams.Add(new SqlParameter("@IsSystem",item.IsSystem));	
				base.ExecuteNonQuery(sql, SPParams.ToArray());
			}
            public void Update(RoleInfo item)
			{
				if(item.ChangedPropertyCount>0)
				{
					StringBuilder sqlbuilder = new StringBuilder();
					sqlbuilder.Append("UPDATE [RoleInfos] SET ");
					Dictionary<string,string> cols =new Dictionary<string,string>();
					cols.Add("RoleName","[RoleName]");
					cols.Add("LastUpdateUserUID","[LastUpdateUserUID]");
					cols.Add("LastUpdateUserName","[LastUpdateUserName]");
					cols.Add("LastUpdateTime","[LastUpdateTime]");
					cols.Add("IsSystem","[IsSystem]");
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
					sqlbuilder.Append(" WHERE [RoleCode]=@RoleCode");

					List<SqlParameter> SPParams = new List<SqlParameter>();
					 SPParams.Add(new SqlParameter("@RoleCode",item.RoleCode));	
 	
					if(item.IsChanged("RoleName"))
					{
						SPParams.Add(new SqlParameter("@RoleName",item.RoleName));	
					} 	
					if(item.IsChanged("LastUpdateUserUID"))
					{
						SPParams.Add(new SqlParameter("@LastUpdateUserUID",item.LastUpdateUserUID));	
					} 	
					if(item.IsChanged("LastUpdateUserName"))
					{
						SPParams.Add(new SqlParameter("@LastUpdateUserName",item.LastUpdateUserName));	
					} 	
					if(item.IsChanged("LastUpdateTime"))
					{
						SPParams.Add(new SqlParameter("@LastUpdateTime",item.LastUpdateTime));	
					} 	
					if(item.IsChanged("IsSystem"))
					{
						SPParams.Add(new SqlParameter("@IsSystem",item.IsSystem));	
					}
					base.ExecuteNonQuery(sqlbuilder.ToString(), SPParams.ToArray());
				}
			}
			public List<RoleInfo> QueryAll()
			{
				string sql ="SELECT [RoleCode],[RoleName],[LastUpdateUserUID],[LastUpdateUserName],[LastUpdateTime],[IsSystem] FROM [RoleInfos]";
				List<RoleInfo>  list =new List<RoleInfo>();
				using(IDataReader reader = base.ExcuteDataReader(sql))
				{
					while(reader.Read())
					{
						RoleInfo item =new RoleInfo();
						item.RoleCode = reader.GetString(0);
							item.RoleName = reader.GetString(1);
							item.LastUpdateUserUID = reader.GetString(2);
							item.LastUpdateUserName = reader.GetString(3);
							item.LastUpdateTime = reader.GetDateTime(4);
							if(!reader.IsDBNull(5))
						 {
							item.IsSystem = reader.GetBoolean(5);
						 }
						 						list.Add(item);
					}
				}
				return list;
			}

        }
        
        /// <summary>
        /// Table: SysParams
        /// Primary Key: ParamCode
        /// </summary>
        public partial class SysParamRepository:BaseRepository 
		{			
			public void Save(SysParam item)
			{
				if(item.IsNew)
				{
					Insert(item);
				}
				else
				{
					Update(item);
				}
			}	
		    public SysParam Get(string key)
			{
				string sql = "SELECT [ParamCode],[ParamName],[ParamValue],[Remark] FROM [SysParams] WHERE [ParamCode]=@ParamCode";
				SqlParameter p =new SqlParameter("@ParamCode",key);
				SysParam item =null;
				using(IDataReader reader = base.ExcuteDataReader(sql,p))
				{
					if(reader.Read())
					{
						item =new SysParam();
						item.ParamCode = reader.GetString(0);
							if(!reader.IsDBNull(1))
						 {
							item.ParamName = reader.GetString(1);
						 }
						 if(!reader.IsDBNull(2))
						 {
							item.ParamValue = reader.GetString(2);
						 }
						 if(!reader.IsDBNull(3))
						 {
							item.Remark = reader.GetString(3);
						 }
						 
					}
				}
				return item;
			}
			public int Delete(string key)
			{
				string sql ="DELETE FROM [SysParams] WHERE [ParamCode]=@ParamCode";
				SqlParameter p =new SqlParameter("@ParamCode",key);
				return base.ExecuteNonQuery(sql,p);	
			}
			public void Insert(SysParam item)
			{
				string sql="INSERT INTO [SysParams] ([ParamCode],[ParamName],[ParamValue],[Remark]) VALUES (@ParamCode,@ParamName,@ParamValue,@Remark)";
				List<SqlParameter> SPParams = new List<SqlParameter>();
				SPParams.Add(new SqlParameter("@ParamCode",item.ParamCode));	
				SPParams.Add(new SqlParameter("@ParamName",item.ParamName));	
				SPParams.Add(new SqlParameter("@ParamValue",item.ParamValue));	
				SPParams.Add(new SqlParameter("@Remark",item.Remark));	
				base.ExecuteNonQuery(sql, SPParams.ToArray());
			}
            public void Update(SysParam item)
			{
				if(item.ChangedPropertyCount>0)
				{
					StringBuilder sqlbuilder = new StringBuilder();
					sqlbuilder.Append("UPDATE [SysParams] SET ");
					Dictionary<string,string> cols =new Dictionary<string,string>();
					cols.Add("ParamName","[ParamName]");
					cols.Add("ParamValue","[ParamValue]");
					cols.Add("Remark","[Remark]");
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
					sqlbuilder.Append(" WHERE [ParamCode]=@ParamCode");

					List<SqlParameter> SPParams = new List<SqlParameter>();
					 SPParams.Add(new SqlParameter("@ParamCode",item.ParamCode));	
 	
					if(item.IsChanged("ParamName"))
					{
						SPParams.Add(new SqlParameter("@ParamName",item.ParamName));	
					} 	
					if(item.IsChanged("ParamValue"))
					{
						SPParams.Add(new SqlParameter("@ParamValue",item.ParamValue));	
					} 	
					if(item.IsChanged("Remark"))
					{
						SPParams.Add(new SqlParameter("@Remark",item.Remark));	
					}
					base.ExecuteNonQuery(sqlbuilder.ToString(), SPParams.ToArray());
				}
			}
			public List<SysParam> QueryAll()
			{
				string sql ="SELECT [ParamCode],[ParamName],[ParamValue],[Remark] FROM [SysParams]";
				List<SysParam>  list =new List<SysParam>();
				using(IDataReader reader = base.ExcuteDataReader(sql))
				{
					while(reader.Read())
					{
						SysParam item =new SysParam();
						item.ParamCode = reader.GetString(0);
							if(!reader.IsDBNull(1))
						 {
							item.ParamName = reader.GetString(1);
						 }
						 if(!reader.IsDBNull(2))
						 {
							item.ParamValue = reader.GetString(2);
						 }
						 if(!reader.IsDBNull(3))
						 {
							item.Remark = reader.GetString(3);
						 }
						 						list.Add(item);
					}
				}
				return list;
			}

        }
        
}