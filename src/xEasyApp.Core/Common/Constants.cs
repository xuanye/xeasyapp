using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xEasyApp.Core.Common
{
    public class Constants
    {
        /// <summary>
        /// 权限类型对应的数据字典Code
        /// </summary>
        public const string PrivilegeTypeCode = "PrivilegeType";
        public const string OrgTypeCode = "OrgType";
        public const string OperateCode = "OperateCode";
        public const string LogType = "LogType";


        public static readonly string OpType_SysManage_UserManage = "用户管理";
        public static readonly string OpType_SysManage_GroupManage = "组织管理";
        public static readonly string OpType_SysManage_PerimissionManage = "权限管理";
        public static readonly string OpType_SysManage_RoleManage = "角色管理";
        public static readonly string OpType_SysManage_Authorization = "授权管理";


        public const string SystemManage_User_PagePrivilegeCode = "10010";
        public const string SystemManage_Role_PagePrivilegeCode = "10030";
        public const string SystemManage_Privilege_PagePrivilegeCode = "10040";
        public const string SystemManage_Authorization_PagePrivilegeCode = "10050";
        public const string SystemManage_Org_PagePrivilegeCode = "10020";
        public const string SystemManage_Dict_PagePrivilegeCode = "10060";
        public const string SystemManage_LogManage_PagePrivilegeCode = "10070";

    }
}
