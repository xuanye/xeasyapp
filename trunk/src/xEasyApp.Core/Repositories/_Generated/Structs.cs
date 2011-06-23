


//=============================================
// 该代码文件有程序自动生成，
// 生成时间: 2011-06-19 14:10:12
// =============================================
using System;
using System.Collections.Generic;
using System.Data;

namespace xEasyApp.Core.Repositories {	
        /// <summary>
        /// Table: ShortCut
        /// Primary Key: ShortCutID
		/// ShortCut
        /// </summary>
        public partial class ShortCut:BaseEntity {  
            
			private int _ShortCutID;
			/// <summary>
			///  主键ID
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
			///  快捷方式名称
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
			///  备注
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
			///  链接
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
			///  所属用户
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
			///  最后更新时间
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
        /// Table: Logs
        /// Primary Key: Id
		/// Logs
        /// </summary>
        public partial class Log:BaseEntity {  
            
			private int _Id;
			/// <summary>
			///  主键标识
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
			///  标题
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
			///  内容
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
			///  操作标识
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
			///  日志类型
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
			///  操作人员标识
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
			///  操作人员姓名
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
			///  IP
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
			///  操作时间
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
        /// Table: RoleUserRelation
        /// Primary Key: RoleID
		/// RoleUserRelation
        /// </summary>
        public partial class RoleUserRelation:BaseEntity {  
            
			private int _RoleID;
			/// <summary>
			///  角色ID
			/// </summary>
            public int RoleID{
                get{
					return _RoleID;
				}
				set
				{
					_RoleID= value;
					OnPropertyChanged("RoleID");
				}
            }
			private string _UserUID;
			/// <summary>
			///  用户标识
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
			///  最后一次更新用户标识
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
			///  最后一次更新用户姓名
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
			///  最后一次更新时间
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
        /// Table: RoleInfos
        /// Primary Key: RoleID
		/// RoleInfos
        /// </summary>
        public partial class RoleInfo:BaseEntity {  
            
			private int _RoleID;
			/// <summary>
			///  角色ID
			/// </summary>
            public int RoleID{
                get{
					return _RoleID;
				}
				set
				{
					_RoleID= value;
					OnPropertyChanged("RoleID");
				}
            }
			private string _RoleCode;
			/// <summary>
			///  角色标识
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
			///  角色名称
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
			private string _Remark;
			/// <summary>
			///   角色说明
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
			private int? _ParentID;
			/// <summary>
			///  父角色ID
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
			private bool _IsSystem;
			/// <summary>
			///  是否系统角色
			/// </summary>
            public bool IsSystem{
                get{
					return _IsSystem;
				}
				set
				{
					_IsSystem= value;
					OnPropertyChanged("IsSystem");
				}
            }
			private string _RolePath;
			/// <summary>
			///  角色路径
			/// </summary>
            public string RolePath{
                get{
					return _RolePath;
				}
				set
				{
					_RolePath= value;
					OnPropertyChanged("RolePath");
				}
            }
			private string _LastUpdateUserUID;
			/// <summary>
			///  最后一次更新用户标识
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
			///  最后一次更新用户姓名
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
			///  最后一次更新时间
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
        /// Table: RolePrivilegeRelation
        /// Primary Key: PrivilegeCode
		/// RolePrivilegeRelation
        /// </summary>
        public partial class RolePrivilegeRelation:BaseEntity {  
            
			private int _RoleID;
			/// <summary>
			///  角色ID
			/// </summary>
            public int RoleID{
                get{
					return _RoleID;
				}
				set
				{
					_RoleID= value;
					OnPropertyChanged("RoleID");
				}
            }
			private string _PrivilegeCode;
			/// <summary>
			///  权限标识
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
			///  最后一次更新用户标识
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
			///  最后一次更新用户姓名
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
			///  最后一次更新时间
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
        /// Table: Organizations
        /// Primary Key: OrgCode
		/// Organizations
        /// </summary>
        public partial class Organization:BaseEntity {  
            
			private string _OrgCode;
			/// <summary>
			///  组织标识
			/// </summary>
            public string OrgCode{
                get{
					return _OrgCode;
				}
				set
				{
					_OrgCode= value;
					OnPropertyChanged("OrgCode");
				}
            }
			private string _OrgName;
			/// <summary>
			///  组织名称
			/// </summary>
            public string OrgName{
                get{
					return _OrgName;
				}
				set
				{
					_OrgName= value;
					OnPropertyChanged("OrgName");
				}
            }
			private string _ParentCode;
			/// <summary>
			///  上属部门ID
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
			///  组织机构路径
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
			///  备注
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
			///  排序
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
			private byte _OrgType;
			/// <summary>
			///  组织类型
			/// </summary>
            public byte OrgType{
                get{
					return _OrgType;
				}
				set
				{
					_OrgType= value;
					OnPropertyChanged("OrgType");
				}
            }
			private string _UnitName;
			/// <summary>
			///  单位标识
			/// </summary>
            public string UnitName{
                get{
					return _UnitName;
				}
				set
				{
					_UnitName= value;
					OnPropertyChanged("UnitName");
				}
            }
			private string _UnitCode;
			/// <summary>
			///  单位名称
			/// </summary>
            public string UnitCode{
                get{
					return _UnitCode;
				}
				set
				{
					_UnitCode= value;
					OnPropertyChanged("UnitCode");
				}
            }
			private string _LastUpdateUserUID;
			/// <summary>
			///  最后一次更新用户标识
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
			///  最后一次更新用户姓名
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
			///  最后一次更新时间
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
        /// Table: DictInfos
        /// Primary Key: DictID
		/// DictInfos
        /// </summary>
        public partial class DictInfo:BaseEntity {  
            
			private int _DictID;
			/// <summary>
			///  数据字典目录ID
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
			///  目录名称
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
			///  目录代码
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
			private bool _IsSystem;
			/// <summary>
			///  是否系统字典
			/// </summary>
            public bool IsSystem{
                get{
					return _IsSystem;
				}
				set
				{
					_IsSystem= value;
					OnPropertyChanged("IsSystem");
				}
            }
			private int? _ParentID;
			/// <summary>
			///  父ID
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
			///  排序字段
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
			private string _Remark;
			/// <summary>
			///  备注
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
        /// Table: UserInfos
        /// Primary Key: UserUID
		/// UserInfos
        /// </summary>
        public partial class UserInfo:BaseEntity {  
            
			private string _UserUID;
			/// <summary>
			///  用户标识
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
			///  用户姓名
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
			///  登录密码
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
			private string _OrgCode;
			/// <summary>
			///  所属部门
			/// </summary>
            public string OrgCode{
                get{
					return _OrgCode;
				}
				set
				{
					_OrgCode= value;
					OnPropertyChanged("OrgCode");
				}
            }
			private string _OrgName;
			/// <summary>
			///  部门名称
			/// </summary>
            public string OrgName{
                get{
					return _OrgName;
				}
				set
				{
					_OrgName= value;
					OnPropertyChanged("OrgName");
				}
            }
			private bool _IsManager;
			/// <summary>
			///  是否组长
			/// </summary>
            public bool IsManager{
                get{
					return _IsManager;
				}
				set
				{
					_IsManager= value;
					OnPropertyChanged("IsManager");
				}
            }
			private bool _IsSystem;
			/// <summary>
			///  IsSystem
			/// </summary>
            public bool IsSystem{
                get{
					return _IsSystem;
				}
				set
				{
					_IsSystem= value;
					OnPropertyChanged("IsSystem");
				}
            }
			private int _Sequence;
			/// <summary>
			///  排序号
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
			///  账号状态
            ///   0	正常
            ///   1	停用
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
			///  最后一次更新用户标识
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
			///  最后一次更新用户姓名
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
			///  最后一次更新时间
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
        /// Table: Privileges
        /// Primary Key: PrivilegeCode
		/// Privileges
        /// </summary>
        public partial class Privilege:BaseEntity {  
            
			private string _PrivilegeCode;
			/// <summary>
			///  权限标识
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
			///  权限名称
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
			///  权限类型
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
			private string _ParentID;
			/// <summary>
			///  父权限标识
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
			///  菜单权限对应的链接地址
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
			private int _Sequence;
			/// <summary>
			///  排序号
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
			///  最后一次更新用户标识
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
			///  最后一次更新用户姓名
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
			///  最后一次更新时间
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
        /// Table: SysParams
        /// Primary Key: ParamCode
		/// SysParams
        /// </summary>
        public partial class SysParam:BaseEntity {  
            
			private string _ParamCode;
			/// <summary>
			///  参数代码
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
			///  参数名
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
			///  参数值
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
			///  备注
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