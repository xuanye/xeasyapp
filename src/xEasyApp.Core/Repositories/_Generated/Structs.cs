


using System;
using System.Collections.Generic;
using System.Data;

namespace xEasyApp.Core.Repositories {	
        /// <summary>
        /// Table: ShortCut
        /// Primary Key: ShortCutID
        /// </summary>
        public partial class ShortCut:BaseEntity {  
            
			private int _ShortCutID;
			/// <summary>
			///  ShortCutID
			/// </summary>
            public int ShortCutID{
                get{
					return _ShortCutID;
				}
				set
				{
					_ShortCutID= value;
					OnPropertyChanged("ShortCutID");
				}
            }
			private string _ShortCutName;
			/// <summary>
			///  ShortCutName
			/// </summary>
            public string ShortCutName{
                get{
					return _ShortCutName;
				}
				set
				{
					_ShortCutName= value;
					OnPropertyChanged("ShortCutName");
				}
            }
			private string _Remark;
			/// <summary>
			///  Remark
			/// </summary>
            public string Remark{
                get{
					return _Remark;
				}
				set
				{
					_Remark= value;
					OnPropertyChanged("Remark");
				}
            }
			private string _PrivilegeCode;
			/// <summary>
			///  PrivilegeCode
			/// </summary>
            public string PrivilegeCode{
                get{
					return _PrivilegeCode;
				}
				set
				{
					_PrivilegeCode= value;
					OnPropertyChanged("PrivilegeCode");
				}
            }
			private string _UserUID;
			/// <summary>
			///  UserUID
			/// </summary>
            public string UserUID{
                get{
					return _UserUID;
				}
				set
				{
					_UserUID= value;
					OnPropertyChanged("UserUID");
				}
            }
			private DateTime? _LastModifyTime;
			/// <summary>
			///  LastModifyTime
			/// </summary>
            public DateTime? LastModifyTime{
                get{
					return _LastModifyTime;
				}
				set
				{
					_LastModifyTime= value;
					OnPropertyChanged("LastModifyTime");
				}
            }
			private int? _Sequence;
			/// <summary>
			///  Sequence
			/// </summary>
            public int? Sequence{
                get{
					return _Sequence;
				}
				set
				{
					_Sequence= value;
					OnPropertyChanged("Sequence");
				}
            }
  		      
        }
        
        /// <summary>
        /// Table: DictInfos
        /// Primary Key: DictID
        /// </summary>
        public partial class DictInfo:BaseEntity {  
            
			private int _DictID;
			/// <summary>
			///  DictID
			/// </summary>
            public int DictID{
                get{
					return _DictID;
				}
				set
				{
					_DictID= value;
					OnPropertyChanged("DictID");
				}
            }
			private string _DictName;
			/// <summary>
			///  DictName
			/// </summary>
            public string DictName{
                get{
					return _DictName;
				}
				set
				{
					_DictName= value;
					OnPropertyChanged("DictName");
				}
            }
			private string _DictCode;
			/// <summary>
			///  DictCode
			/// </summary>
            public string DictCode{
                get{
					return _DictCode;
				}
				set
				{
					_DictCode= value;
					OnPropertyChanged("DictCode");
				}
            }
			private byte _DictType;
			/// <summary>
			///  DictType
			/// </summary>
            public byte DictType{
                get{
					return _DictType;
				}
				set
				{
					_DictType= value;
					OnPropertyChanged("DictType");
				}
            }
			private int? _ParentID;
			/// <summary>
			///  ParentID
			/// </summary>
            public int? ParentID{
                get{
					return _ParentID;
				}
				set
				{
					_ParentID= value;
					OnPropertyChanged("ParentID");
				}
            }
			private int? _Sequence;
			/// <summary>
			///  Sequence
			/// </summary>
            public int? Sequence{
                get{
					return _Sequence;
				}
				set
				{
					_Sequence= value;
					OnPropertyChanged("Sequence");
				}
            }
			private string _SQLCMD;
			/// <summary>
			///  SQLCMD
			/// </summary>
            public string SQLCMD{
                get{
					return _SQLCMD;
				}
				set
				{
					_SQLCMD= value;
					OnPropertyChanged("SQLCMD");
				}
            }
			private string _Remark;
			/// <summary>
			///  Remark
			/// </summary>
            public string Remark{
                get{
					return _Remark;
				}
				set
				{
					_Remark= value;
					OnPropertyChanged("Remark");
				}
            }
  		      
        }
        
        /// <summary>
        /// Table: Privileges
        /// Primary Key: PrivilegeCode
        /// </summary>
        public partial class Privilege:BaseEntity {  
            
			private string _PrivilegeCode;
			/// <summary>
			///  PrivilegeCode
			/// </summary>
            public string PrivilegeCode{
                get{
					return _PrivilegeCode;
				}
				set
				{
					_PrivilegeCode= value;
					OnPropertyChanged("PrivilegeCode");
				}
            }
			private string _PrivilegeName;
			/// <summary>
			///  PrivilegeName
			/// </summary>
            public string PrivilegeName{
                get{
					return _PrivilegeName;
				}
				set
				{
					_PrivilegeName= value;
					OnPropertyChanged("PrivilegeName");
				}
            }
			private byte _PrivilegeType;
			/// <summary>
			///  PrivilegeType
			/// </summary>
            public byte PrivilegeType{
                get{
					return _PrivilegeType;
				}
				set
				{
					_PrivilegeType= value;
					OnPropertyChanged("PrivilegeType");
				}
            }
			private string _ParentID;
			/// <summary>
			///  ParentID
			/// </summary>
            public string ParentID{
                get{
					return _ParentID;
				}
				set
				{
					_ParentID= value;
					OnPropertyChanged("ParentID");
				}
            }
			private string _Uri;
			/// <summary>
			///  Uri
			/// </summary>
            public string Uri{
                get{
					return _Uri;
				}
				set
				{
					_Uri= value;
					OnPropertyChanged("Uri");
				}
            }
			private int? _Sequence;
			/// <summary>
			///  Sequence
			/// </summary>
            public int? Sequence{
                get{
					return _Sequence;
				}
				set
				{
					_Sequence= value;
					OnPropertyChanged("Sequence");
				}
            }
			private string _LastUpdateUserUID;
			/// <summary>
			///  LastUpdateUserUID
			/// </summary>
            public string LastUpdateUserUID{
                get{
					return _LastUpdateUserUID;
				}
				set
				{
					_LastUpdateUserUID= value;
					OnPropertyChanged("LastUpdateUserUID");
				}
            }
			private string _LastUpdateUserName;
			/// <summary>
			///  LastUpdateUserName
			/// </summary>
            public string LastUpdateUserName{
                get{
					return _LastUpdateUserName;
				}
				set
				{
					_LastUpdateUserName= value;
					OnPropertyChanged("LastUpdateUserName");
				}
            }
			private DateTime _LastUpdateTime;
			/// <summary>
			///  LastUpdateTime
			/// </summary>
            public DateTime LastUpdateTime{
                get{
					return _LastUpdateTime;
				}
				set
				{
					_LastUpdateTime= value;
					OnPropertyChanged("LastUpdateTime");
				}
            }
  		      
        }
        
        /// <summary>
        /// Table: Logs
        /// Primary Key: Id
        /// </summary>
        public partial class Log:BaseEntity {  
            
			private int _Id;
			/// <summary>
			///  Id
			/// </summary>
            public int Id{
                get{
					return _Id;
				}
				set
				{
					_Id= value;
					OnPropertyChanged("Id");
				}
            }
			private string _Topic;
			/// <summary>
			///  Topic
			/// </summary>
            public string Topic{
                get{
					return _Topic;
				}
				set
				{
					_Topic= value;
					OnPropertyChanged("Topic");
				}
            }
			private string _Content;
			/// <summary>
			///  Content
			/// </summary>
            public string Content{
                get{
					return _Content;
				}
				set
				{
					_Content= value;
					OnPropertyChanged("Content");
				}
            }
			private string _OperateCode;
			/// <summary>
			///  OperateCode
			/// </summary>
            public string OperateCode{
                get{
					return _OperateCode;
				}
				set
				{
					_OperateCode= value;
					OnPropertyChanged("OperateCode");
				}
            }
			private byte _LogType;
			/// <summary>
			///  LogType
			/// </summary>
            public byte LogType{
                get{
					return _LogType;
				}
				set
				{
					_LogType= value;
					OnPropertyChanged("LogType");
				}
            }
			private string _OperateUID;
			/// <summary>
			///  OperateUID
			/// </summary>
            public string OperateUID{
                get{
					return _OperateUID;
				}
				set
				{
					_OperateUID= value;
					OnPropertyChanged("OperateUID");
				}
            }
			private string _OperateName;
			/// <summary>
			///  OperateName
			/// </summary>
            public string OperateName{
                get{
					return _OperateName;
				}
				set
				{
					_OperateName= value;
					OnPropertyChanged("OperateName");
				}
            }
			private string _IPAddress;
			/// <summary>
			///  IPAddress
			/// </summary>
            public string IPAddress{
                get{
					return _IPAddress;
				}
				set
				{
					_IPAddress= value;
					OnPropertyChanged("IPAddress");
				}
            }
			private DateTime _OperateTime;
			/// <summary>
			///  OperateTime
			/// </summary>
            public DateTime OperateTime{
                get{
					return _OperateTime;
				}
				set
				{
					_OperateTime= value;
					OnPropertyChanged("OperateTime");
				}
            }
  		      
        }
        
        /// <summary>
        /// Table: RolePrivilegeRelation
        /// Primary Key: PrivilegeCode
        /// </summary>
        public partial class RolePrivilegeRelation:BaseEntity {  
            
			private string _RoleCode;
			/// <summary>
			///  RoleCode
			/// </summary>
            public string RoleCode{
                get{
					return _RoleCode;
				}
				set
				{
					_RoleCode= value;
					OnPropertyChanged("RoleCode");
				}
            }
			private string _PrivilegeCode;
			/// <summary>
			///  PrivilegeCode
			/// </summary>
            public string PrivilegeCode{
                get{
					return _PrivilegeCode;
				}
				set
				{
					_PrivilegeCode= value;
					OnPropertyChanged("PrivilegeCode");
				}
            }
			private string _LastUpdateUserUID;
			/// <summary>
			///  LastUpdateUserUID
			/// </summary>
            public string LastUpdateUserUID{
                get{
					return _LastUpdateUserUID;
				}
				set
				{
					_LastUpdateUserUID= value;
					OnPropertyChanged("LastUpdateUserUID");
				}
            }
			private string _LastUpdateUserName;
			/// <summary>
			///  LastUpdateUserName
			/// </summary>
            public string LastUpdateUserName{
                get{
					return _LastUpdateUserName;
				}
				set
				{
					_LastUpdateUserName= value;
					OnPropertyChanged("LastUpdateUserName");
				}
            }
			private DateTime _LastUpdateTime;
			/// <summary>
			///  LastUpdateTime
			/// </summary>
            public DateTime LastUpdateTime{
                get{
					return _LastUpdateTime;
				}
				set
				{
					_LastUpdateTime= value;
					OnPropertyChanged("LastUpdateTime");
				}
            }
  		      
        }
        
        /// <summary>
        /// Table: RoleUserRelation
        /// Primary Key: RoleCode
        /// </summary>
        public partial class RoleUserRelation:BaseEntity {  
            
			private string _RoleCode;
			/// <summary>
			///  RoleCode
			/// </summary>
            public string RoleCode{
                get{
					return _RoleCode;
				}
				set
				{
					_RoleCode= value;
					OnPropertyChanged("RoleCode");
				}
            }
			private string _UserUID;
			/// <summary>
			///  UserUID
			/// </summary>
            public string UserUID{
                get{
					return _UserUID;
				}
				set
				{
					_UserUID= value;
					OnPropertyChanged("UserUID");
				}
            }
			private string _LastUpdateUserUID;
			/// <summary>
			///  LastUpdateUserUID
			/// </summary>
            public string LastUpdateUserUID{
                get{
					return _LastUpdateUserUID;
				}
				set
				{
					_LastUpdateUserUID= value;
					OnPropertyChanged("LastUpdateUserUID");
				}
            }
			private string _LastUpdateUserName;
			/// <summary>
			///  LastUpdateUserName
			/// </summary>
            public string LastUpdateUserName{
                get{
					return _LastUpdateUserName;
				}
				set
				{
					_LastUpdateUserName= value;
					OnPropertyChanged("LastUpdateUserName");
				}
            }
			private DateTime _LastUpdateTime;
			/// <summary>
			///  LastUpdateTime
			/// </summary>
            public DateTime LastUpdateTime{
                get{
					return _LastUpdateTime;
				}
				set
				{
					_LastUpdateTime= value;
					OnPropertyChanged("LastUpdateTime");
				}
            }
  		      
        }
        
        /// <summary>
        /// Table: Departments
        /// Primary Key: DeptCode
        /// </summary>
        public partial class Department:BaseEntity {  
            
			private string _DeptCode;
			/// <summary>
			///  DeptCode
			/// </summary>
            public string DeptCode{
                get{
					return _DeptCode;
				}
				set
				{
					_DeptCode= value;
					OnPropertyChanged("DeptCode");
				}
            }
			private string _DeptName;
			/// <summary>
			///  DeptName
			/// </summary>
            public string DeptName{
                get{
					return _DeptName;
				}
				set
				{
					_DeptName= value;
					OnPropertyChanged("DeptName");
				}
            }
			private string _ParentCode;
			/// <summary>
			///  ParentCode
			/// </summary>
            public string ParentCode{
                get{
					return _ParentCode;
				}
				set
				{
					_ParentCode= value;
					OnPropertyChanged("ParentCode");
				}
            }
			private string _Path;
			/// <summary>
			///  Path
			/// </summary>
            public string Path{
                get{
					return _Path;
				}
				set
				{
					_Path= value;
					OnPropertyChanged("Path");
				}
            }
			private string _Remark;
			/// <summary>
			///  Remark
			/// </summary>
            public string Remark{
                get{
					return _Remark;
				}
				set
				{
					_Remark= value;
					OnPropertyChanged("Remark");
				}
            }
			private int _Sequence;
			/// <summary>
			///  Sequence
			/// </summary>
            public int Sequence{
                get{
					return _Sequence;
				}
				set
				{
					_Sequence= value;
					OnPropertyChanged("Sequence");
				}
            }
			private string _LastUpdateUserUID;
			/// <summary>
			///  LastUpdateUserUID
			/// </summary>
            public string LastUpdateUserUID{
                get{
					return _LastUpdateUserUID;
				}
				set
				{
					_LastUpdateUserUID= value;
					OnPropertyChanged("LastUpdateUserUID");
				}
            }
			private string _LastUpdateUserName;
			/// <summary>
			///  LastUpdateUserName
			/// </summary>
            public string LastUpdateUserName{
                get{
					return _LastUpdateUserName;
				}
				set
				{
					_LastUpdateUserName= value;
					OnPropertyChanged("LastUpdateUserName");
				}
            }
			private DateTime _LastUpdateTime;
			/// <summary>
			///  LastUpdateTime
			/// </summary>
            public DateTime LastUpdateTime{
                get{
					return _LastUpdateTime;
				}
				set
				{
					_LastUpdateTime= value;
					OnPropertyChanged("LastUpdateTime");
				}
            }
  		      
        }
        
        /// <summary>
        /// Table: UserInfos
        /// Primary Key: UserUID
        /// </summary>
        public partial class UserInfo:BaseEntity {  
            
			private string _UserUID;
			/// <summary>
			///  UserUID
			/// </summary>
            public string UserUID{
                get{
					return _UserUID;
				}
				set
				{
					_UserUID= value;
					OnPropertyChanged("UserUID");
				}
            }
			private string _FullName;
			/// <summary>
			///  FullName
			/// </summary>
            public string FullName{
                get{
					return _FullName;
				}
				set
				{
					_FullName= value;
					OnPropertyChanged("FullName");
				}
            }
			private string _Password;
			/// <summary>
			///  Password
			/// </summary>
            public string Password{
                get{
					return _Password;
				}
				set
				{
					_Password= value;
					OnPropertyChanged("Password");
				}
            }
			private string _DeptCode;
			/// <summary>
			///  DeptCode
			/// </summary>
            public string DeptCode{
                get{
					return _DeptCode;
				}
				set
				{
					_DeptCode= value;
					OnPropertyChanged("DeptCode");
				}
            }
			private string _DeptName;
			/// <summary>
			///  DeptName
			/// </summary>
            public string DeptName{
                get{
					return _DeptName;
				}
				set
				{
					_DeptName= value;
					OnPropertyChanged("DeptName");
				}
            }
			private int _Sequence;
			/// <summary>
			///  Sequence
			/// </summary>
            public int Sequence{
                get{
					return _Sequence;
				}
				set
				{
					_Sequence= value;
					OnPropertyChanged("Sequence");
				}
            }
			private byte _AccountState;
			/// <summary>
			///  AccountState
			/// </summary>
            public byte AccountState{
                get{
					return _AccountState;
				}
				set
				{
					_AccountState= value;
					OnPropertyChanged("AccountState");
				}
            }
			private string _LastUpdateUserUID;
			/// <summary>
			///  LastUpdateUserUID
			/// </summary>
            public string LastUpdateUserUID{
                get{
					return _LastUpdateUserUID;
				}
				set
				{
					_LastUpdateUserUID= value;
					OnPropertyChanged("LastUpdateUserUID");
				}
            }
			private string _LastUpdateUserName;
			/// <summary>
			///  LastUpdateUserName
			/// </summary>
            public string LastUpdateUserName{
                get{
					return _LastUpdateUserName;
				}
				set
				{
					_LastUpdateUserName= value;
					OnPropertyChanged("LastUpdateUserName");
				}
            }
			private DateTime _LastUpdateTime;
			/// <summary>
			///  LastUpdateTime
			/// </summary>
            public DateTime LastUpdateTime{
                get{
					return _LastUpdateTime;
				}
				set
				{
					_LastUpdateTime= value;
					OnPropertyChanged("LastUpdateTime");
				}
            }
  		      
        }
        
        /// <summary>
        /// Table: UserDeptRelation
        /// Primary Key: UDRID
        /// </summary>
        public partial class UserDeptRelation:BaseEntity {  
            
			private int _UDRID;
			/// <summary>
			///  UDRID
			/// </summary>
            public int UDRID{
                get{
					return _UDRID;
				}
				set
				{
					_UDRID= value;
					OnPropertyChanged("UDRID");
				}
            }
			private string _UserUID;
			/// <summary>
			///  UserUID
			/// </summary>
            public string UserUID{
                get{
					return _UserUID;
				}
				set
				{
					_UserUID= value;
					OnPropertyChanged("UserUID");
				}
            }
			private string _DeptCode;
			/// <summary>
			///  DeptCode
			/// </summary>
            public string DeptCode{
                get{
					return _DeptCode;
				}
				set
				{
					_DeptCode= value;
					OnPropertyChanged("DeptCode");
				}
            }
			private bool _IsPrimary;
			/// <summary>
			///  IsPrimary
			/// </summary>
            public bool IsPrimary{
                get{
					return _IsPrimary;
				}
				set
				{
					_IsPrimary= value;
					OnPropertyChanged("IsPrimary");
				}
            }
  		      
        }
        
        /// <summary>
        /// Table: RoleInfos
        /// Primary Key: RoleCode
        /// </summary>
        public partial class RoleInfo:BaseEntity {  
            
			private string _RoleCode;
			/// <summary>
			///  RoleCode
			/// </summary>
            public string RoleCode{
                get{
					return _RoleCode;
				}
				set
				{
					_RoleCode= value;
					OnPropertyChanged("RoleCode");
				}
            }
			private string _RoleName;
			/// <summary>
			///  RoleName
			/// </summary>
            public string RoleName{
                get{
					return _RoleName;
				}
				set
				{
					_RoleName= value;
					OnPropertyChanged("RoleName");
				}
            }
			private string _LastUpdateUserUID;
			/// <summary>
			///  LastUpdateUserUID
			/// </summary>
            public string LastUpdateUserUID{
                get{
					return _LastUpdateUserUID;
				}
				set
				{
					_LastUpdateUserUID= value;
					OnPropertyChanged("LastUpdateUserUID");
				}
            }
			private string _LastUpdateUserName;
			/// <summary>
			///  LastUpdateUserName
			/// </summary>
            public string LastUpdateUserName{
                get{
					return _LastUpdateUserName;
				}
				set
				{
					_LastUpdateUserName= value;
					OnPropertyChanged("LastUpdateUserName");
				}
            }
			private DateTime _LastUpdateTime;
			/// <summary>
			///  LastUpdateTime
			/// </summary>
            public DateTime LastUpdateTime{
                get{
					return _LastUpdateTime;
				}
				set
				{
					_LastUpdateTime= value;
					OnPropertyChanged("LastUpdateTime");
				}
            }
			private bool? _IsSystem;
			/// <summary>
			///  IsSystem
			/// </summary>
            public bool? IsSystem{
                get{
					return _IsSystem;
				}
				set
				{
					_IsSystem= value;
					OnPropertyChanged("IsSystem");
				}
            }
  		      
        }
        
        /// <summary>
        /// Table: SysParams
        /// Primary Key: ParamCode
        /// </summary>
        public partial class SysParam:BaseEntity {  
            
			private string _ParamCode;
			/// <summary>
			///  ParamCode
			/// </summary>
            public string ParamCode{
                get{
					return _ParamCode;
				}
				set
				{
					_ParamCode= value;
					OnPropertyChanged("ParamCode");
				}
            }
			private string _ParamName;
			/// <summary>
			///  ParamName
			/// </summary>
            public string ParamName{
                get{
					return _ParamName;
				}
				set
				{
					_ParamName= value;
					OnPropertyChanged("ParamName");
				}
            }
			private string _ParamValue;
			/// <summary>
			///  ParamValue
			/// </summary>
            public string ParamValue{
                get{
					return _ParamValue;
				}
				set
				{
					_ParamValue= value;
					OnPropertyChanged("ParamValue");
				}
            }
			private string _Remark;
			/// <summary>
			///  Remark
			/// </summary>
            public string Remark{
                get{
					return _Remark;
				}
				set
				{
					_Remark= value;
					OnPropertyChanged("Remark");
				}
            }
  		      
        }
        
}