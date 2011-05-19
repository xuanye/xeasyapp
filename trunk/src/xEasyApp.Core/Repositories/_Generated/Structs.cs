


using System;
using SubSonic.Schema;
using System.Collections.Generic;
using SubSonic.DataProviders;
using System.Data;

namespace xEasyApp.Core.Repositories {
	
        /// <summary>
        /// Table: ShortCut
        /// Primary Key: ShortCutID
        /// </summary>

        public class ShortCutTable: DatabaseTable {
            
            public ShortCutTable(IDataProvider provider):base("ShortCut",provider){
                ClassName = "ShortCut";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("ShortCutID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ShortCutName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("Remark", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1000
                });

                Columns.Add(new DatabaseColumn("PrivilegeCode", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2000
                });

                Columns.Add(new DatabaseColumn("UserUID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("LastModifyTime", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Sequence", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn ShortCutID{
                get{
                    return this.GetColumn("ShortCutID");
                }
            }
				
   			public static string ShortCutIDColumn{
			      get{
        			return "ShortCutID";
      			}
		    }
            
            public IColumn ShortCutName{
                get{
                    return this.GetColumn("ShortCutName");
                }
            }
				
   			public static string ShortCutNameColumn{
			      get{
        			return "ShortCutName";
      			}
		    }
            
            public IColumn Remark{
                get{
                    return this.GetColumn("Remark");
                }
            }
				
   			public static string RemarkColumn{
			      get{
        			return "Remark";
      			}
		    }
            
            public IColumn PrivilegeCode{
                get{
                    return this.GetColumn("PrivilegeCode");
                }
            }
				
   			public static string PrivilegeCodeColumn{
			      get{
        			return "PrivilegeCode";
      			}
		    }
            
            public IColumn UserUID{
                get{
                    return this.GetColumn("UserUID");
                }
            }
				
   			public static string UserUIDColumn{
			      get{
        			return "UserUID";
      			}
		    }
            
            public IColumn LastModifyTime{
                get{
                    return this.GetColumn("LastModifyTime");
                }
            }
				
   			public static string LastModifyTimeColumn{
			      get{
        			return "LastModifyTime";
      			}
		    }
            
            public IColumn Sequence{
                get{
                    return this.GetColumn("Sequence");
                }
            }
				
   			public static string SequenceColumn{
			      get{
        			return "Sequence";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: DictInfos
        /// Primary Key: DictID
        /// </summary>

        public class DictInfosTable: DatabaseTable {
            
            public DictInfosTable(IDataProvider provider):base("DictInfos",provider){
                ClassName = "DictInfo";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("DictID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("DictName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("DictCode", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("DictType", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ParentID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Sequence", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("SQLCMD", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 4000
                });

                Columns.Add(new DatabaseColumn("Remark", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 200
                });
                    
                
                
            }
            
            public IColumn DictID{
                get{
                    return this.GetColumn("DictID");
                }
            }
				
   			public static string DictIDColumn{
			      get{
        			return "DictID";
      			}
		    }
            
            public IColumn DictName{
                get{
                    return this.GetColumn("DictName");
                }
            }
				
   			public static string DictNameColumn{
			      get{
        			return "DictName";
      			}
		    }
            
            public IColumn DictCode{
                get{
                    return this.GetColumn("DictCode");
                }
            }
				
   			public static string DictCodeColumn{
			      get{
        			return "DictCode";
      			}
		    }
            
            public IColumn DictType{
                get{
                    return this.GetColumn("DictType");
                }
            }
				
   			public static string DictTypeColumn{
			      get{
        			return "DictType";
      			}
		    }
            
            public IColumn ParentID{
                get{
                    return this.GetColumn("ParentID");
                }
            }
				
   			public static string ParentIDColumn{
			      get{
        			return "ParentID";
      			}
		    }
            
            public IColumn Sequence{
                get{
                    return this.GetColumn("Sequence");
                }
            }
				
   			public static string SequenceColumn{
			      get{
        			return "Sequence";
      			}
		    }
            
            public IColumn SQLCMD{
                get{
                    return this.GetColumn("SQLCMD");
                }
            }
				
   			public static string SQLCMDColumn{
			      get{
        			return "SQLCMD";
      			}
		    }
            
            public IColumn Remark{
                get{
                    return this.GetColumn("Remark");
                }
            }
				
   			public static string RemarkColumn{
			      get{
        			return "Remark";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: Departments
        /// Primary Key: DeptID
        /// </summary>

        public class DepartmentsTable: DatabaseTable {
            
            public DepartmentsTable(IDataProvider provider):base("Departments",provider){
                ClassName = "Department";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("DeptID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("DeptCode", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("DeptName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 200
                });

                Columns.Add(new DatabaseColumn("ParentID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Path", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1000
                });

                Columns.Add(new DatabaseColumn("Manager", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 500
                });

                Columns.Add(new DatabaseColumn("Remark", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2000
                });

                Columns.Add(new DatabaseColumn("Sequence", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("LastUpdateUserUID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("LastUpdateUserName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("LastUpdateTime", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn DeptID{
                get{
                    return this.GetColumn("DeptID");
                }
            }
				
   			public static string DeptIDColumn{
			      get{
        			return "DeptID";
      			}
		    }
            
            public IColumn DeptCode{
                get{
                    return this.GetColumn("DeptCode");
                }
            }
				
   			public static string DeptCodeColumn{
			      get{
        			return "DeptCode";
      			}
		    }
            
            public IColumn DeptName{
                get{
                    return this.GetColumn("DeptName");
                }
            }
				
   			public static string DeptNameColumn{
			      get{
        			return "DeptName";
      			}
		    }
            
            public IColumn ParentID{
                get{
                    return this.GetColumn("ParentID");
                }
            }
				
   			public static string ParentIDColumn{
			      get{
        			return "ParentID";
      			}
		    }
            
            public IColumn Path{
                get{
                    return this.GetColumn("Path");
                }
            }
				
   			public static string PathColumn{
			      get{
        			return "Path";
      			}
		    }
            
            public IColumn Manager{
                get{
                    return this.GetColumn("Manager");
                }
            }
				
   			public static string ManagerColumn{
			      get{
        			return "Manager";
      			}
		    }
            
            public IColumn Remark{
                get{
                    return this.GetColumn("Remark");
                }
            }
				
   			public static string RemarkColumn{
			      get{
        			return "Remark";
      			}
		    }
            
            public IColumn Sequence{
                get{
                    return this.GetColumn("Sequence");
                }
            }
				
   			public static string SequenceColumn{
			      get{
        			return "Sequence";
      			}
		    }
            
            public IColumn LastUpdateUserUID{
                get{
                    return this.GetColumn("LastUpdateUserUID");
                }
            }
				
   			public static string LastUpdateUserUIDColumn{
			      get{
        			return "LastUpdateUserUID";
      			}
		    }
            
            public IColumn LastUpdateUserName{
                get{
                    return this.GetColumn("LastUpdateUserName");
                }
            }
				
   			public static string LastUpdateUserNameColumn{
			      get{
        			return "LastUpdateUserName";
      			}
		    }
            
            public IColumn LastUpdateTime{
                get{
                    return this.GetColumn("LastUpdateTime");
                }
            }
				
   			public static string LastUpdateTimeColumn{
			      get{
        			return "LastUpdateTime";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: Privileges
        /// Primary Key: PrivilegeCode
        /// </summary>

        public class PrivilegesTable: DatabaseTable {
            
            public PrivilegesTable(IDataProvider provider):base("Privileges",provider){
                ClassName = "Privilege";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("PrivilegeCode", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("PrivilegeName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("PrivilegeType", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ParentID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Uri", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2000
                });

                Columns.Add(new DatabaseColumn("Sequence", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("LastUpdateUserUID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("LastUpdateUserName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("LastUpdateTime", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn PrivilegeCode{
                get{
                    return this.GetColumn("PrivilegeCode");
                }
            }
				
   			public static string PrivilegeCodeColumn{
			      get{
        			return "PrivilegeCode";
      			}
		    }
            
            public IColumn PrivilegeName{
                get{
                    return this.GetColumn("PrivilegeName");
                }
            }
				
   			public static string PrivilegeNameColumn{
			      get{
        			return "PrivilegeName";
      			}
		    }
            
            public IColumn PrivilegeType{
                get{
                    return this.GetColumn("PrivilegeType");
                }
            }
				
   			public static string PrivilegeTypeColumn{
			      get{
        			return "PrivilegeType";
      			}
		    }
            
            public IColumn ParentID{
                get{
                    return this.GetColumn("ParentID");
                }
            }
				
   			public static string ParentIDColumn{
			      get{
        			return "ParentID";
      			}
		    }
            
            public IColumn Uri{
                get{
                    return this.GetColumn("Uri");
                }
            }
				
   			public static string UriColumn{
			      get{
        			return "Uri";
      			}
		    }
            
            public IColumn Sequence{
                get{
                    return this.GetColumn("Sequence");
                }
            }
				
   			public static string SequenceColumn{
			      get{
        			return "Sequence";
      			}
		    }
            
            public IColumn LastUpdateUserUID{
                get{
                    return this.GetColumn("LastUpdateUserUID");
                }
            }
				
   			public static string LastUpdateUserUIDColumn{
			      get{
        			return "LastUpdateUserUID";
      			}
		    }
            
            public IColumn LastUpdateUserName{
                get{
                    return this.GetColumn("LastUpdateUserName");
                }
            }
				
   			public static string LastUpdateUserNameColumn{
			      get{
        			return "LastUpdateUserName";
      			}
		    }
            
            public IColumn LastUpdateTime{
                get{
                    return this.GetColumn("LastUpdateTime");
                }
            }
				
   			public static string LastUpdateTimeColumn{
			      get{
        			return "LastUpdateTime";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: Logs
        /// Primary Key: Id
        /// </summary>

        public class LogsTable: DatabaseTable {
            
            public LogsTable(IDataProvider provider):base("Logs",provider){
                ClassName = "Log";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Topic", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 200
                });

                Columns.Add(new DatabaseColumn("Content", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = -1
                });

                Columns.Add(new DatabaseColumn("OperateCode", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("LogType", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("OperateUID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("OperateName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 200
                });

                Columns.Add(new DatabaseColumn("IPAddress", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 15
                });

                Columns.Add(new DatabaseColumn("OperateTime", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
   			public static string IdColumn{
			      get{
        			return "Id";
      			}
		    }
            
            public IColumn Topic{
                get{
                    return this.GetColumn("Topic");
                }
            }
				
   			public static string TopicColumn{
			      get{
        			return "Topic";
      			}
		    }
            
            public IColumn Content{
                get{
                    return this.GetColumn("Content");
                }
            }
				
   			public static string ContentColumn{
			      get{
        			return "Content";
      			}
		    }
            
            public IColumn OperateCode{
                get{
                    return this.GetColumn("OperateCode");
                }
            }
				
   			public static string OperateCodeColumn{
			      get{
        			return "OperateCode";
      			}
		    }
            
            public IColumn LogType{
                get{
                    return this.GetColumn("LogType");
                }
            }
				
   			public static string LogTypeColumn{
			      get{
        			return "LogType";
      			}
		    }
            
            public IColumn OperateUID{
                get{
                    return this.GetColumn("OperateUID");
                }
            }
				
   			public static string OperateUIDColumn{
			      get{
        			return "OperateUID";
      			}
		    }
            
            public IColumn OperateName{
                get{
                    return this.GetColumn("OperateName");
                }
            }
				
   			public static string OperateNameColumn{
			      get{
        			return "OperateName";
      			}
		    }
            
            public IColumn IPAddress{
                get{
                    return this.GetColumn("IPAddress");
                }
            }
				
   			public static string IPAddressColumn{
			      get{
        			return "IPAddress";
      			}
		    }
            
            public IColumn OperateTime{
                get{
                    return this.GetColumn("OperateTime");
                }
            }
				
   			public static string OperateTimeColumn{
			      get{
        			return "OperateTime";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: RolePrivilegeRelation
        /// Primary Key: PrivilegeCode
        /// </summary>

        public class RolePrivilegeRelationTable: DatabaseTable {
            
            public RolePrivilegeRelationTable(IDataProvider provider):base("RolePrivilegeRelation",provider){
                ClassName = "RolePrivilegeRelation";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("RoleCode", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("PrivilegeCode", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("LastUpdateUserUID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("LastUpdateUserName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("LastUpdateTime", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn RoleCode{
                get{
                    return this.GetColumn("RoleCode");
                }
            }
				
   			public static string RoleCodeColumn{
			      get{
        			return "RoleCode";
      			}
		    }
            
            public IColumn PrivilegeCode{
                get{
                    return this.GetColumn("PrivilegeCode");
                }
            }
				
   			public static string PrivilegeCodeColumn{
			      get{
        			return "PrivilegeCode";
      			}
		    }
            
            public IColumn LastUpdateUserUID{
                get{
                    return this.GetColumn("LastUpdateUserUID");
                }
            }
				
   			public static string LastUpdateUserUIDColumn{
			      get{
        			return "LastUpdateUserUID";
      			}
		    }
            
            public IColumn LastUpdateUserName{
                get{
                    return this.GetColumn("LastUpdateUserName");
                }
            }
				
   			public static string LastUpdateUserNameColumn{
			      get{
        			return "LastUpdateUserName";
      			}
		    }
            
            public IColumn LastUpdateTime{
                get{
                    return this.GetColumn("LastUpdateTime");
                }
            }
				
   			public static string LastUpdateTimeColumn{
			      get{
        			return "LastUpdateTime";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: UserInfos
        /// Primary Key: UserUID
        /// </summary>

        public class UserInfosTable: DatabaseTable {
            
            public UserInfosTable(IDataProvider provider):base("UserInfos",provider){
                ClassName = "UserInfo";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("UserUID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("FullName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 200
                });

                Columns.Add(new DatabaseColumn("UsedName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 200
                });

                Columns.Add(new DatabaseColumn("Password", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("UserNO", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("UserType", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("DeptID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Gender", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Birthplace", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("National", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("IDCard", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 18
                });

                Columns.Add(new DatabaseColumn("Birthday", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Email", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 200
                });

                Columns.Add(new DatabaseColumn("EmailBacker", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 200
                });

                Columns.Add(new DatabaseColumn("OfficePhone", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 500
                });

                Columns.Add(new DatabaseColumn("HomePhone", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 500
                });

                Columns.Add(new DatabaseColumn("MobilePhone", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("QQ", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("MSN", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 200
                });

                Columns.Add(new DatabaseColumn("Sequence", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("CreateUserUID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("CreateUserName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("CreateTime", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("LastUpdateUserUID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("LastUpdateUserName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("LastUpdateTime", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("AccountState", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn UserUID{
                get{
                    return this.GetColumn("UserUID");
                }
            }
				
   			public static string UserUIDColumn{
			      get{
        			return "UserUID";
      			}
		    }
            
            public IColumn FullName{
                get{
                    return this.GetColumn("FullName");
                }
            }
				
   			public static string FullNameColumn{
			      get{
        			return "FullName";
      			}
		    }
            
            public IColumn UsedName{
                get{
                    return this.GetColumn("UsedName");
                }
            }
				
   			public static string UsedNameColumn{
			      get{
        			return "UsedName";
      			}
		    }
            
            public IColumn Password{
                get{
                    return this.GetColumn("Password");
                }
            }
				
   			public static string PasswordColumn{
			      get{
        			return "Password";
      			}
		    }
            
            public IColumn UserNO{
                get{
                    return this.GetColumn("UserNO");
                }
            }
				
   			public static string UserNOColumn{
			      get{
        			return "UserNO";
      			}
		    }
            
            public IColumn UserType{
                get{
                    return this.GetColumn("UserType");
                }
            }
				
   			public static string UserTypeColumn{
			      get{
        			return "UserType";
      			}
		    }
            
            public IColumn DeptID{
                get{
                    return this.GetColumn("DeptID");
                }
            }
				
   			public static string DeptIDColumn{
			      get{
        			return "DeptID";
      			}
		    }
            
            public IColumn Gender{
                get{
                    return this.GetColumn("Gender");
                }
            }
				
   			public static string GenderColumn{
			      get{
        			return "Gender";
      			}
		    }
            
            public IColumn Birthplace{
                get{
                    return this.GetColumn("Birthplace");
                }
            }
				
   			public static string BirthplaceColumn{
			      get{
        			return "Birthplace";
      			}
		    }
            
            public IColumn National{
                get{
                    return this.GetColumn("National");
                }
            }
				
   			public static string NationalColumn{
			      get{
        			return "National";
      			}
		    }
            
            public IColumn IDCard{
                get{
                    return this.GetColumn("IDCard");
                }
            }
				
   			public static string IDCardColumn{
			      get{
        			return "IDCard";
      			}
		    }
            
            public IColumn Birthday{
                get{
                    return this.GetColumn("Birthday");
                }
            }
				
   			public static string BirthdayColumn{
			      get{
        			return "Birthday";
      			}
		    }
            
            public IColumn Email{
                get{
                    return this.GetColumn("Email");
                }
            }
				
   			public static string EmailColumn{
			      get{
        			return "Email";
      			}
		    }
            
            public IColumn EmailBacker{
                get{
                    return this.GetColumn("EmailBacker");
                }
            }
				
   			public static string EmailBackerColumn{
			      get{
        			return "EmailBacker";
      			}
		    }
            
            public IColumn OfficePhone{
                get{
                    return this.GetColumn("OfficePhone");
                }
            }
				
   			public static string OfficePhoneColumn{
			      get{
        			return "OfficePhone";
      			}
		    }
            
            public IColumn HomePhone{
                get{
                    return this.GetColumn("HomePhone");
                }
            }
				
   			public static string HomePhoneColumn{
			      get{
        			return "HomePhone";
      			}
		    }
            
            public IColumn MobilePhone{
                get{
                    return this.GetColumn("MobilePhone");
                }
            }
				
   			public static string MobilePhoneColumn{
			      get{
        			return "MobilePhone";
      			}
		    }
            
            public IColumn QQ{
                get{
                    return this.GetColumn("QQ");
                }
            }
				
   			public static string QQColumn{
			      get{
        			return "QQ";
      			}
		    }
            
            public IColumn MSN{
                get{
                    return this.GetColumn("MSN");
                }
            }
				
   			public static string MSNColumn{
			      get{
        			return "MSN";
      			}
		    }
            
            public IColumn Sequence{
                get{
                    return this.GetColumn("Sequence");
                }
            }
				
   			public static string SequenceColumn{
			      get{
        			return "Sequence";
      			}
		    }
            
            public IColumn CreateUserUID{
                get{
                    return this.GetColumn("CreateUserUID");
                }
            }
				
   			public static string CreateUserUIDColumn{
			      get{
        			return "CreateUserUID";
      			}
		    }
            
            public IColumn CreateUserName{
                get{
                    return this.GetColumn("CreateUserName");
                }
            }
				
   			public static string CreateUserNameColumn{
			      get{
        			return "CreateUserName";
      			}
		    }
            
            public IColumn CreateTime{
                get{
                    return this.GetColumn("CreateTime");
                }
            }
				
   			public static string CreateTimeColumn{
			      get{
        			return "CreateTime";
      			}
		    }
            
            public IColumn LastUpdateUserUID{
                get{
                    return this.GetColumn("LastUpdateUserUID");
                }
            }
				
   			public static string LastUpdateUserUIDColumn{
			      get{
        			return "LastUpdateUserUID";
      			}
		    }
            
            public IColumn LastUpdateUserName{
                get{
                    return this.GetColumn("LastUpdateUserName");
                }
            }
				
   			public static string LastUpdateUserNameColumn{
			      get{
        			return "LastUpdateUserName";
      			}
		    }
            
            public IColumn LastUpdateTime{
                get{
                    return this.GetColumn("LastUpdateTime");
                }
            }
				
   			public static string LastUpdateTimeColumn{
			      get{
        			return "LastUpdateTime";
      			}
		    }
            
            public IColumn AccountState{
                get{
                    return this.GetColumn("AccountState");
                }
            }
				
   			public static string AccountStateColumn{
			      get{
        			return "AccountState";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: RoleUserRelation
        /// Primary Key: RoleCode
        /// </summary>

        public class RoleUserRelationTable: DatabaseTable {
            
            public RoleUserRelationTable(IDataProvider provider):base("RoleUserRelation",provider){
                ClassName = "RoleUserRelation";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("RoleCode", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("UserUID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("LastUpdateUserUID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("LastUpdateUserName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("LastUpdateTime", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn RoleCode{
                get{
                    return this.GetColumn("RoleCode");
                }
            }
				
   			public static string RoleCodeColumn{
			      get{
        			return "RoleCode";
      			}
		    }
            
            public IColumn UserUID{
                get{
                    return this.GetColumn("UserUID");
                }
            }
				
   			public static string UserUIDColumn{
			      get{
        			return "UserUID";
      			}
		    }
            
            public IColumn LastUpdateUserUID{
                get{
                    return this.GetColumn("LastUpdateUserUID");
                }
            }
				
   			public static string LastUpdateUserUIDColumn{
			      get{
        			return "LastUpdateUserUID";
      			}
		    }
            
            public IColumn LastUpdateUserName{
                get{
                    return this.GetColumn("LastUpdateUserName");
                }
            }
				
   			public static string LastUpdateUserNameColumn{
			      get{
        			return "LastUpdateUserName";
      			}
		    }
            
            public IColumn LastUpdateTime{
                get{
                    return this.GetColumn("LastUpdateTime");
                }
            }
				
   			public static string LastUpdateTimeColumn{
			      get{
        			return "LastUpdateTime";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: RoleInfos
        /// Primary Key: RoleCode
        /// </summary>

        public class RoleInfosTable: DatabaseTable {
            
            public RoleInfosTable(IDataProvider provider):base("RoleInfos",provider){
                ClassName = "RoleInfo";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("RoleCode", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("RoleName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("LastUpdateUserUID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("LastUpdateUserName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("LastUpdateTime", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("IsSystem", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn RoleCode{
                get{
                    return this.GetColumn("RoleCode");
                }
            }
				
   			public static string RoleCodeColumn{
			      get{
        			return "RoleCode";
      			}
		    }
            
            public IColumn RoleName{
                get{
                    return this.GetColumn("RoleName");
                }
            }
				
   			public static string RoleNameColumn{
			      get{
        			return "RoleName";
      			}
		    }
            
            public IColumn LastUpdateUserUID{
                get{
                    return this.GetColumn("LastUpdateUserUID");
                }
            }
				
   			public static string LastUpdateUserUIDColumn{
			      get{
        			return "LastUpdateUserUID";
      			}
		    }
            
            public IColumn LastUpdateUserName{
                get{
                    return this.GetColumn("LastUpdateUserName");
                }
            }
				
   			public static string LastUpdateUserNameColumn{
			      get{
        			return "LastUpdateUserName";
      			}
		    }
            
            public IColumn LastUpdateTime{
                get{
                    return this.GetColumn("LastUpdateTime");
                }
            }
				
   			public static string LastUpdateTimeColumn{
			      get{
        			return "LastUpdateTime";
      			}
		    }
            
            public IColumn IsSystem{
                get{
                    return this.GetColumn("IsSystem");
                }
            }
				
   			public static string IsSystemColumn{
			      get{
        			return "IsSystem";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: SysParams
        /// Primary Key: ParamCode
        /// </summary>

        public class SysParamsTable: DatabaseTable {
            
            public SysParamsTable(IDataProvider provider):base("SysParams",provider){
                ClassName = "SysParam";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("ParamCode", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 200
                });

                Columns.Add(new DatabaseColumn("ParamName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 200
                });

                Columns.Add(new DatabaseColumn("ParamValue", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1000
                });

                Columns.Add(new DatabaseColumn("Remark", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1000
                });
                    
                
                
            }
            
            public IColumn ParamCode{
                get{
                    return this.GetColumn("ParamCode");
                }
            }
				
   			public static string ParamCodeColumn{
			      get{
        			return "ParamCode";
      			}
		    }
            
            public IColumn ParamName{
                get{
                    return this.GetColumn("ParamName");
                }
            }
				
   			public static string ParamNameColumn{
			      get{
        			return "ParamName";
      			}
		    }
            
            public IColumn ParamValue{
                get{
                    return this.GetColumn("ParamValue");
                }
            }
				
   			public static string ParamValueColumn{
			      get{
        			return "ParamValue";
      			}
		    }
            
            public IColumn Remark{
                get{
                    return this.GetColumn("Remark");
                }
            }
				
   			public static string RemarkColumn{
			      get{
        			return "Remark";
      			}
		    }
            
                    
        }
        
}