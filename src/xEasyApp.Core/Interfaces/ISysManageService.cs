using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xEasyApp.Core.Repositories;
using xEasyApp.Core.Entities;

namespace xEasyApp.Core.Interfaces
{
    public interface ISysManageService
    {
       #region 角色相关
        List<RoleInfo> GetRoles(int? parentId, string userCode);

        List<RoleInfo> QueryRoleList(int? parentId, string userCode);

        void SaveRoleInfo(RoleInfo ri);

        RoleInfo GetRoleInfo(int roleid);

        int DeleteRoleInfo(int roleId);

        bool ValidRoleCode(string RoleCode);

        #endregion 

       #region 部门相关
        List<Department> QueryDepartmentList();

        Department GetDeptInfo(string deptCode);

        Department GetRootDepartment();

        List<Department> GetChildDeptsByParentCode(string parentCode);

        void SaveDeptInfo(Department department);

        bool ValidDeptCode(string deptCode);

        PagedList<UserInfo> QueryDeptUserList(Entities.PageView view, string DeptCode);
        int DeleteDeptInfo(string id);

       #endregion

       #region 用户相关
        UserInfo GetUserInfo(string UserUID);

        bool ValidUserUID(string UserUID);

        int DeleteUserInfo(string id);

        void SaveUserInfo(UserInfo user);
        #endregion

       #region 权限相关

        /// <summary>
        /// 验证权限代码是否存在
        /// </summary>
        /// <param name="privilegeCode">The privilege code.</param>
        /// <returns></returns>
        bool ValidPrivilegeCode(string privilegeCode);

        /// <summary>
        /// 判断用户是否拥有某个权限
        /// </summary>
        /// <param name="userUid">The user uid.</param>
        /// <param name="privilegeCode">The privilege code.</param>
        /// <returns>
        /// 	<c>true</c> if the specified user uid has right; otherwise, <c>false</c>.
        /// </returns>
        bool HasRight(string userUid, string privilegeCode);

        /// <summary>
        /// 根据父权限表示获取子权限列表 ，用于树状结构，返回的字段不同
        /// </summary>
        /// <param name="parentCode">The parent code.</param>
        /// <returns></returns>
        List<Privilege> GetChildPrivileges(string parentCode);

        /// <summary>
        /// 根据父权限表示获取子权限列表 ，用于列表
        /// </summary>
        /// <param name="parentCode">The parent code.</param>
        /// <returns></returns>
        List<Privilege> QueryPrivilegeListByParentCode(string parentCode);
        /// <summary>
        ///保存对权限的修改
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns></returns>
        void SavePrivilege(Privilege p);

        /// <summary>
        /// 删除某个权限
        /// </summary>
        /// <param name="privilegeCode">The privilege code.</param>
        /// <returns></returns>
        int DeletePrivilege(string privilegeCode);

        /// <summary>
        /// 获取权限信息
        /// </summary>
        /// <param name="privilegeCode">The privilege code.</param>
        /// <returns></returns>
        Privilege GetPrivilege(string privilegeCode);
       #endregion

       #region 数据字典相关
        /// <summary>
        /// 根据数据字典想获取
        /// </summary>
        /// <param name="dictCode">The dict code.</param>
        /// <returns></returns>
        List<DictInfo> GetChildDictInfos(string dictCode);

       #endregion
    }
}
