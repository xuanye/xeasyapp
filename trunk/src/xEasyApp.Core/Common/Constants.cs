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
    }
}
