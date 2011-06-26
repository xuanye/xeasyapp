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

        PagedList<UserInfo> QueryRoletUserList(PageView view, int roleId, string qtext);

        void AddRoleUser(int roleid, string userids,string opUserID,string opUserName);

        void DeleteRoleUser(int roleid, string userids);

        List<Privilege> GetRoleAuthorizationPermissions(int roleid, string userId, string parentId);
        #endregion

        #region 部门相关
        List<Organization> QueryOrganizationList();

        Organization GetOrgInfo(string OrgCode);

        Organization GetRootOrganization();
        
        List<Organization> GetChildOrgsByParentCode(string parentCode);

        void SaveOrgInfo(Organization Organization);

        bool ValidOrgCode(string OrgCode);

        PagedList<UserInfo> QueryOrgUserList(Entities.PageView view, string OrgCode);
        int DeleteOrgInfo(string id);

        #endregion

        #region 用户相关
        UserInfo GetUserInfo(string UserUID);

        bool ValidUserUID(string UserUID);

        int DeleteUserInfo(string id);

        void SaveUserInfo(UserInfo user);

        List<UserInfo> GetUserListByOrgCode(string OrgCode);

        List<UserInfo> QueryUserList(string userCode);

        /// <summary>
        /// 登录认证
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="pwd">The PWD.</param>
        /// <returns></returns>
        bool Authentication(string userid, string pwd);
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

        /// <summary>
        /// 判断某用户是否可以对某角色授权
        /// </summary>
        /// <param name="RoleID"></param>
        /// <param name="useId"></param>
        /// <returns></returns>
        bool CheckUserAuthorizationRight(int RoleID, string useId);

        /// <summary>
        /// 设置角色权限
        /// </summary>
        /// <param name="roleid">The roleid.</param>
        /// <param name="addids">The addids.</param>
        /// <param name="minusids">The minusids.</param>
        /// <param name="userid">The userid.</param>
        void SetRolePrivilege(int roleid, string addids, string minusids, string userid, string username);

        /// <summary>
        /// 获取用户的权限树
        /// </summary>
        /// <param name="usercode">用户标识</param>
        /// <param name="parentId">父ID</param>
        /// <returns></returns>
        List<Privilege> GetUserPrivilegesByParentID(string usercode, string parentId);

        /// <summary>
        /// 获取权限的角色
        /// </summary>
        /// <param name="usercode">The usercode.</param>
        /// <param name="pcode">The pcode.</param>
        /// <returns></returns>
        List<RoleInfo> QueryUserPrivilegeRoles(string usercode, string pcode);

        /// <summary>
        ///获取所有菜单
        /// </summary>
        /// <returns></returns>
        List<Privilege> GetAllMenu();

        /// <summary>
        /// 获取用户的菜单IDs
        /// </summary>
        /// <returns></returns>
        List<string> GetUserMenuIds(string userid);
       #endregion

        #region 数据字典相关
        /// <summary>
        /// 根据数据字典想获取
        /// </summary>
        /// <param name="dictCode">The dict code.</param>
        /// <returns></returns>
        List<DictInfo> GetChildDictInfos(string dictCode);

        /// <summary>
        /// 根据父节点获取子数据字典列表 用于Grid
        /// </summary>
        /// <param name="parentId">父ID.</param>
        /// <returns></returns>
        List<DictInfo> QueryDictInfoList(int parentId);
        /// <summary>
        /// 根据父节点获取子数据字典项 用于Tree
        /// </summary>
        /// <param name="parentId">父ID.</param>
        /// <returns></returns>
        List<DictInfo> GetDictInfoTree(int parentId);

        /// <summary>
        /// 根据主键获取数据字典
        /// </summary>
        /// <param name="dictId">The dict id.</param>
        /// <returns></returns>
        DictInfo GetDictInfo(int dictId);

        /// <summary>
        /// 根据主键删除数据字典
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        int DeleteDictInfo(int id);

        /// <summary>
        /// 保存数据字典信息
        /// </summary>
        /// <param name="di">The di.</param>
        void SaveDictInfo(DictInfo di);
       #endregion

      
    }
}
