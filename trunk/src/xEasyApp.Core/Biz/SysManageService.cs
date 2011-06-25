using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xEasyApp.Core.Interfaces;
using xEasyApp.Core.Repositories;
using xEasyApp.Core.Exceptions;
using xEasyApp.Core.Configurations;
using xEasyApp.Core.Entities;
using System.Transactions;
using xEasyApp.Core.Common;

namespace xEasyApp.Core.Biz
{
    public class SysManageService : ISysManageService
    {
        public SysManageService(ILogService logservice)
        {
            _LogService = logservice;
        }

        private ILogService _LogService;

        #region 属性
        private RoleInfoRepository _roleRepository;
        private OrganizationRepository _orgRepository;
        private UserInfoRepository _userRepository;
        private PrivilegeRepository _privilegeRepository;

        private DictInfoRepository _dictRepository;

        protected DictInfoRepository dictRepository
        {
            get
            {
                if (_dictRepository == null)
                {
                    _dictRepository = new DictInfoRepository();
                }
                return _dictRepository;
            }
        }

        protected RoleInfoRepository roleRepository
        {
            get
            {
                if (_roleRepository == null)
                {
                    _roleRepository = new RoleInfoRepository();
                }
                return _roleRepository;
            }
        }
        protected OrganizationRepository orgRepository
        {
            get
            {
                if (_orgRepository == null)
                {
                    _orgRepository = new OrganizationRepository();
                }
                return _orgRepository;
            }
        }

        protected UserInfoRepository userRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserInfoRepository();
                }
                return _userRepository;
            }
        }

        protected PrivilegeRepository privilegeRepository
        {
            get
            {
                if (_privilegeRepository == null)
                {
                    _privilegeRepository = new PrivilegeRepository();
                }
                return _privilegeRepository;
            }
        }

        #endregion

        #region 角色管理

        public bool IsInRole(string roleCode, string userCode)
        {
            string userrols = UserCache.GetItem(userCode,"UserRoles");
            if (!string.IsNullOrEmpty(userrols))
            {
                return userrols.IndexOf("," + roleCode + ",") >= 0;
            }
            else
            {
                List<string> roles = userRepository.GetUserRoleCodes(userCode);
                UserCache.AddItem(userCode,"UserRoles", "," + string.Join(",", roles.ToArray()) + ",");
                return roles.Contains(roleCode);
            }
        }

        public List<RoleInfo> GetUserTopRoles(string userCode)
        {
            bool IsAdminRole = IsInRole(userCode, AppConfig.SuperAdminRoleCode);
            if (IsAdminRole)
            {
                return roleRepository.GetTopRoles();
            }
            else
            {
                List<RoleInfo> list = roleRepository.GetTopUserRoles(userCode);
                List<RoleInfo> listcopy = new List<RoleInfo>();
                foreach (RoleInfo r in list) //过滤已有权限，并拥有下级权限，此处只获取顶级
                {
                    if (r.IsSystem) //系统角色过滤掉
                    {
                        continue;
                    }
                    bool exists = list.Exists(x => x.RoleID != r.RoleID && x.RolePath != r.RolePath && r.RolePath.IndexOf(x.RolePath) >= 0);
                    if (!exists)
                    {
                        listcopy.Add(r);
                    }
                }

                return listcopy;
            }
        }
        public List<RoleInfo> GetRoles(int? parentId, string userCode)
        {
            if (!parentId.HasValue)
            {
                return GetUserTopRoles(userCode);
            }
            else
            {
                return roleRepository.GetRolesByParentID(parentId.Value);
            }
        }
        public List<RoleInfo> QueryRoleList(int? parentId, string userCode)
        {
            if (!parentId.HasValue)
            {
                return QueryTopRoleList(userCode);
            }
            else
            {
                return roleRepository.QueryRoleList(parentId.Value);
            }
        }
        public List<RoleInfo> QueryTopRoleList(string userCode)
        {
            bool IsAdminRole = IsInRole(userCode, AppConfig.SuperAdminRoleCode);
            if (IsAdminRole)
            {
                return roleRepository.QueryTopRoleList();
            }
            else
            {
                List<RoleInfo> list = roleRepository.QueryTopUserRolesList(userCode);
                List<RoleInfo> listcopy = new List<RoleInfo>();
                foreach (RoleInfo r in list) //过滤已有权限，并拥有下级权限，此处只获取顶级
                {
                    if (r.IsSystem) //系统角色过滤掉
                    {
                        continue;
                    }
                    bool exists = list.Exists(x => x.RoleID != r.RoleID && x.RolePath != r.RolePath && r.RolePath.IndexOf(x.RolePath) >= 0);
                    if (!exists)
                    {
                        listcopy.Add(r);
                    }
                }

                return listcopy;
            }
        }

        public void SaveRoleInfo(RoleInfo ri)
        {
            try
            {
                if (ri.IsNew)
                {
                    bool IsValid = roleRepository.ValidRoleCode(ri.RoleCode);
                    if (!IsValid)
                    {
                        throw new BizException("角色代码必须唯一");
                    }
                }
                roleRepository.SaveRoleInfo(ri);
            }
            catch (Exception ex)
            {
                throw new BizException(ex.Message, ex);
            }
            string op = ri.IsNew ? "新增" : "修改";
            //记录操作日志
            _LogService.Trace(Constants.OpType_SysManage_RoleManage, string.Format("{0}角色 ，权限标识[{1}],权限名称[{2}]", op, ri.RoleCode, ri.RoleName));
        }
        public RoleInfo GetRoleInfo(int roleId)
        {
            RoleInfo ri = roleRepository.GetRoleInfo(roleId);
            if (!ri.ParentID.HasValue)
            {
                ri.ParentName = "根角色";
            }
            return ri;

        }

        /// <summary>
        /// Deletes the role info.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        public int DeleteRoleInfo(int roleId)
        {
            RoleInfo ri = roleRepository.Get(roleId);
            if (ri == null)
            {
                return 0;
            }
            if (ri.IsSystem)
            {
                throw new BizException("系统角色不允许被删除");
            }
            int ret = roleRepository.Delete(roleId);

            //记录操作日志
            _LogService.Trace(Constants.OpType_SysManage_RoleManage, string.Format("删除角色，角色代码[{0}],角色名称[{1}]", ri.RoleCode, ri.RoleName));
            return ret;
        }


        public bool ValidRoleCode(string roleCode)
        {
            return roleRepository.ValidRoleCode(roleCode);
        }

        public PagedList<UserInfo> QueryRoletUserList(PageView view, int roleId, string qtext)
        {
            return roleRepository.QueryRoletUserList(view, roleId, qtext);
        }

        public void AddRoleUser(int roleid, string userids, string opUserID, string opUserName)
        {
			 try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    roleRepository.AddRoleUser(roleid, userids,opUserID,opUserName);
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new BizException(ex.Message, ex);
            }
            _LogService.Trace(Constants.OpType_SysManage_RoleManage, string.Format("添加角色用户 ，角色ID[{0}],用户ID列表[{1}]", roleid, userids));
          
        }

        public void DeleteRoleUser(int roleid, string userids)
        {
			 try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                   roleRepository.DeleteRoleUser(roleid, userids);
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new BizException(ex.Message, ex);
            }
            _LogService.Trace(Constants.OpType_SysManage_RoleManage, string.Format("删除角色用户 ，角色ID[{0}],用户ID列表[{1}]", roleid, userids));
           
        }

       public  List<Privilege> GetRoleAuthorizationPermissions(int roleid, string userId, string parentId)
       {
           bool IsAdminRole = IsInRole(userId, AppConfig.SuperAdminRoleCode);
           List<Privilege> uplist = null;
           if (IsAdminRole)
           {
               if (string.IsNullOrEmpty(parentId))
               {
                   uplist = privilegeRepository.GetTopLevelPrivileges();
               }
               else
               {
                   uplist = privilegeRepository.GetChildPrivileges(parentId);
               }
           }
           else
           {
               uplist = roleRepository.GetUserPermissions(userId, parentId);
           }

           List<Privilege> rplist = roleRepository.GetRolePermissions(roleid, parentId);
           foreach (Privilege p in uplist)
           {
               p.IsChecked = rplist.Exists(x => x.PrivilegeCode == p.PrivilegeCode);
           }
           return uplist;
       }
        #endregion

        #region 部门管理
        public List<Organization> QueryOrganizationList()
        {
            return orgRepository.QueryAll();
        }

        public Organization GetOrgInfo(string orgCode)
        {
            Organization d = orgRepository.GetOrganization(orgCode);
            if (d.ParentCode == AppConfig.RootOrgCode)
            {
                d.ParentName = AppConfig.RootOrgName;
            }
            return d;
        }
        public Organization GetRootOrganization()
        {
            bool Isadmin = MyContext.IsInRole(AppConfig.SuperAdminRoleCode);
            Organization org = null;
            if (Isadmin)
            {
                org = new Organization();
                org.OrgCode = AppConfig.RootOrgCode;
                org.OrgName = AppConfig.RootOrgName;
              
            }
            else
            {
                org = GetOrgInfo(MyContext.CurrentUser.UnitCode);  
            }
            return org;
        }

        public List<Organization> GetChildOrgsByParentCode(string parentCode)
        {
            return orgRepository.GetChildOrgsByParentCode(parentCode);
        }

        public void SaveOrgInfo(Organization Organization)
        {
            orgRepository.SaveOrgInfo(Organization);

            string op = Organization.IsNew ? "新增" : "修改";
            _LogService.Trace(Constants.OpType_SysManage_GroupManage, string.Format("{0}组织，组织代码[{1}],组织名称[{2}]", op,Organization.OrgCode, Organization.OrgName));
        }

        public bool ValidOrgCode(string orgCode)
        {
            return orgRepository.ValidOrgCode(orgCode);
        }
        public PagedList<UserInfo> QueryOrgUserList(PageView view, string orgCode)
        {
            return orgRepository.QueryOrgUserList(view, orgCode);
        }
        public int DeleteOrgInfo(string id)
        {
            Organization org = orgRepository.GetOrganization(id);
            if (org != null)
            {
                int ret = -1;
                try
                {
                    ret = orgRepository.DeleteOrgInfo(id);

                }
                catch (Exception ex)
                {
                    throw new BizException(ex.Message, ex);
                }

                _LogService.Trace(Constants.OpType_SysManage_GroupManage, string.Format("删除组织，组织代码[{1}],组织名称[{2}]", org.OrgCode, org.OrgName));
                return ret;
            }
            else
            {
                throw new BizException("删除失败,该组标识不存在");
            }
        }

        #endregion

        #region 用户管理

        public UserInfo GetUserInfo(string UserUID)
        {
            return userRepository.Get(UserUID);
        }

        public bool ValidUserUID(string UserUID)
        {
            return userRepository.ValidUserUID(UserUID);
        }

        public int DeleteUserInfo(string id)
        {
            int ret = -1;
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    ret = userRepository.DeleteUserInfo(id);
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new BizException(ex.Message, ex);
            }
            _LogService.Trace(Constants.OpType_SysManage_UserManage, string.Format("删除用户，用户编码[{0}]", id));
            return ret;
        }

        public void SaveUserInfo(UserInfo user)
        {
            userRepository.Save(user);
            string op = user.IsNew ? "新增" : "修改";
            _LogService.Trace(Constants.OpType_SysManage_UserManage, string.Format("{0}用户，用户编码[{1}],用户名称[{2}]", op, user.UserUID, user.FullName));
        }

        public List<UserInfo> GetUserListByOrgCode(string orgCode)
        {
            return userRepository.GetUserListByOrgCode(orgCode);
        }
        public List<UserInfo> QueryUserList(string userCode)
        {
            userCode = Utility.ClearSafeStringParma(userCode);
            return userRepository.QueryTopUserList(userCode);
        }
        #endregion

        #region 权限相关

        /// <summary>
        /// 验证权限代码是否存在
        /// </summary>
        /// <param name="privilegeCode">The privilege code.</param>
        /// <returns></returns>
        public bool ValidPrivilegeCode(string privilegeCode)
        {
            return privilegeRepository.ValidPrivilegeCode(privilegeCode);
        }

        /// <summary>
        /// 判断用户是否拥有某个权限
        /// </summary>
        /// <param name="userUid">The user uid.</param>
        /// <param name="privilegeCode">The privilege code.</param>
        /// <returns>
        /// 	<c>true</c> if the specified user uid has right; otherwise, <c>false</c>.
        /// </returns>
        public bool HasRight(string userUid, string privilegeCode)
        {
            bool IsAdminRole = IsInRole(userUid, AppConfig.SuperAdminRoleCode);
            if (IsAdminRole) //如果是管理员角色
            {
                return true;
            }
            string hasright = UserCache.GetItem(userUid, "HasRight_" + privilegeCode);
            if (hasright == null)
            {
                bool hr = userRepository.CheckUserRight(userUid, privilegeCode);
                UserCache.AddItem("HasRight_" + privilegeCode, hr ? "true" : "false");
                return hr;
            }
            else
            {
                return hasright.ToLower() == "true";
            }
        }

        /// <summary>
        ///  根据父权限表示获取子权限列表 ，用于树状结构，返回的字段不同
        /// </summary>
        /// <param name="parentCode">The parent code.</param>
        /// <returns></returns>
        public List<Privilege> GetChildPrivileges(string parentCode)
        {
            if (string.IsNullOrEmpty(parentCode))
            {
                return privilegeRepository.GetTopLevelPrivileges();
            }
            else
            {
                return privilegeRepository.GetChildPrivileges(parentCode);
            }
        }

        /// <summary>
        /// 根据父权限表示获取子权限列表 ，用于列表
        /// </summary>
        /// <param name="parentCode">The parent code.</param>
        /// <returns></returns>
        public List<Privilege> QueryPrivilegeListByParentCode(string parentCode)
        {
            if (string.IsNullOrEmpty(parentCode))
            {
                return privilegeRepository.QueryTopLevelPrivilegeList();
            }
            else
            {
                return privilegeRepository.QueryPrivilegeListByParentCode(parentCode);
            }
        }

        /// <summary>
        ///保存对权限的修改
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns></returns>
        public void SavePrivilege(Privilege p)
        {
            privilegeRepository.Save(p);
            string op = p.IsNew ? "新增" : "修改";
            _LogService.Trace(Constants.OpType_SysManage_PerimissionManage, string.Format("{0} 权限 ，权限标识[{1}],权限名称[{2}]", op, p.PrivilegeCode,p.PrivilegeName));
        }

        /// <summary>
        /// 删除某个权限
        /// </summary>
        /// <param name="privilegeCode">The privilege code.</param>
        /// <returns></returns>
        public int DeletePrivilege(string privilegeCode)
        {
            Privilege p = privilegeRepository.GetPrivilege(privilegeCode);
            if (p != null)
            {
                int ret = -1;
                try
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        ret = privilegeRepository.DeletePrivilege(privilegeCode);
                        scope.Complete();
                    }
                }
                catch (Exception ex)
                {
                    throw new BizException(ex.Message, ex);
                }
                //记录操作日志
                _LogService.Trace(Constants.OpType_SysManage_PerimissionManage, string.Format("删除权限 ，权限标识[{0}],权限名称[{1}]", privilegeCode, p.PrivilegeName));
                return ret;
            }
            else
            {
                throw new BizException("删除权限失败，权限标识不存在");
            }
        }
        public Privilege GetPrivilege(string privilegeCode)
        {
            return privilegeRepository.GetPrivilege(privilegeCode);
        }

        public bool CheckUserAuthorizationRight(int RoleID, string userid)
        {
            bool IsAdminRole = IsInRole(userid, AppConfig.SuperAdminRoleCode);
            if (IsAdminRole) //如果是超级管理员
            {
                return true;
            }
            else
            {
                bool isHasRigth = roleRepository.CheckUserAuthorizationRight(RoleID, userid);
                return isHasRigth;
            }
        }

        public void SetRolePrivilege(int roleid, string addids, string minusids,string userid,string username)
        { 
            bool hasright = CheckUserAuthorizationRight(roleid,userid);
           
            
            if (!hasright)
            {
                throw new BizException("你没有对角色授权的权利");
            }
            else
            {
                RoleInfo role = roleRepository.GetRoleInfo(roleid);
                if (role != null)
                {
                    try
                    {
                        roleRepository.SetRolePrivilege(roleid, addids, minusids, userid, username);
                    }
                    catch (Exception ex)
                    {
                        throw new BizException(ex.Message, ex);
                    }
                    _LogService.Trace(Constants.OpType_SysManage_Authorization, string.Format("角色授权,角色[{0},{1}],新增的权限列表[{2}],删除的权限列表[{3}]", role.RoleCode, role.RoleName, addids, minusids));
                }
                else
                {
                    throw new BizException("角色不存在");
                }
             }
        }

        /// <summary>
        /// 获取用户的权限树
        /// </summary>
        /// <param name="usercode">用户标识</param>
        /// <param name="parentId">父ID</param>
        /// <returns></returns>
        public List<Privilege> GetUserPrivilegesByParentID(string usercode, string parentId)
        {
            bool IsAdminRole = IsInRole(usercode, AppConfig.SuperAdminRoleCode);
            if (IsAdminRole) //如果是超级管理员
            {
               return GetChildPrivileges(parentId);
            }
            else
            {
                return roleRepository.GetUserPermissions(usercode, parentId);
               
            }
        }
        public List<RoleInfo> QueryUserPrivilegeRoles(string usercode, string pcode)
        {
            List<RoleInfo> rlist = roleRepository.QueryUserPrivilegeRoles(usercode, pcode);
            bool IsAdminRole = IsInRole(usercode, AppConfig.SuperAdminRoleCode);
            if (IsAdminRole)
            {
                bool hasadmin = rlist.Exists(x => x.RoleCode == AppConfig.SuperAdminRoleCode);
                if (!hasadmin)
                {
                    RoleInfo adminrole = new RoleInfo();
                    adminrole.RoleID =   AppConfig.SuperAdminRoleID;
                    adminrole.RoleCode = AppConfig.SuperAdminRoleCode;
                    adminrole.RoleName = "超级管理员";
                    adminrole.IsSystem = true;
                    rlist.Insert(0, adminrole);
                }
            }
            return rlist;
            
        }
        #endregion

        #region 数据字典管理
        public List<DictInfo> GetChildDictInfos(string dictCode)
        {
            switch (dictCode)
            {
                case Constants.PrivilegeTypeCode:
                    return GetPrivilegeTypeDictList();
                case Constants.OrgTypeCode:
                    return GetOrgTypeDictList();
                case Constants.OperateCode:
                    return GetOperateCode();
                case Constants.LogType:
                    return GetLogType();
            }
            return dictRepository.GetChildDictInfos(dictCode);
        }

        private List<DictInfo> GetLogType()
        {
            List<DictInfo> list = new List<DictInfo>();
            DictInfo dict1 = new DictInfo();
            dict1.DictCode = "";
            dict1.DictName = "全部";

            DictInfo dict2 = new DictInfo();
            dict2.DictCode = "0";
            dict2.DictName = "调试";
            DictInfo dict3 = new DictInfo();
            dict3.DictCode = "1";
            dict3.DictName = "跟踪";

            DictInfo dict4 = new DictInfo();
            dict4.DictCode = "2";
            dict4.DictName = "错误";

            list.Add(dict1);
            list.Add(dict2);
            list.Add(dict3);
            list.Add(dict4);
            return list;
        }

        private List<DictInfo> GetOperateCode()
        {
            List<DictInfo> list = new List<DictInfo>();
            string[] ops = new[] { Constants.OpType_SysManage_Authorization, Constants.OpType_SysManage_GroupManage, Constants.OpType_SysManage_PerimissionManage, Constants.OpType_SysManage_RoleManage, Constants.OpType_SysManage_UserManage };
            list.Add(new DictInfo { DictCode = "", DictName = "全部" });
            foreach (string c in ops)
            {
                list.Add(new DictInfo { DictCode = c, DictName = c });
            }
            return list;
        }
        private List<DictInfo> GetOrgTypeDictList()
        {
            List<DictInfo> list = new List<DictInfo>();
            DictInfo dict1 = new DictInfo();
            dict1.DictCode = "0";
            dict1.DictName = "单位";

            DictInfo dict2 = new DictInfo();
            dict2.DictCode = "1";
            dict2.DictName = "部门";
            DictInfo dict3 = new DictInfo();
            dict3.DictCode = "2";
            dict3.DictName = "组";
            list.Add(dict1);
            list.Add(dict2);
            list.Add(dict3);
            return list;
        }
        private List<DictInfo> GetPrivilegeTypeDictList()
        {
            List<DictInfo> list = new List<DictInfo>();
            DictInfo dict1 = new DictInfo();
            dict1.DictCode = "1";
            dict1.DictName = "普通权限";

            DictInfo dict2 = new DictInfo();
            dict2.DictCode = "2";
            dict2.DictName = "菜单权限";
            list.Add(dict1);
            list.Add(dict2);
            return list;
        }


        /// <summary>
        /// 根据父节点获取子数据字典列表 用于Grid
        /// </summary>
        /// <param name="parentId">父ID.</param>
        /// <returns></returns>
        public List<DictInfo> QueryDictInfoList(int parentId)
        {
            return dictRepository.QueryDictInfoList(parentId);
        }
        /// <summary>
        /// 根据父节点获取子数据字典项 用于Tree
        /// </summary>
        /// <param name="parentId">父ID.</param>
        /// <returns></returns>
        public List<DictInfo> GetDictInfoTree(int parentId)
        {
            return dictRepository.GetDictInfoTree(parentId);
        }

        /// <summary>
        /// 根据主键获取数据字典
        /// </summary>
        /// <param name="dictId">The dict id.</param>
        /// <returns></returns>
        public DictInfo GetDictInfo(int dictId)
        {
            return dictRepository.GetDictInfo(dictId);
        }

        /// <summary>
        /// 根据主键删除数据字典
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public int DeleteDictInfo(int id)
        { 
            //校验是否能删除
            bool checkret= dictRepository.CheckDictIsSystemOrHasChild(id);
            if (checkret)
            {
                throw new BizException("数据字典为系统字典或者包含子项不能被删除");
            }
            else
            {
                return dictRepository.Delete(id);
            }
        }
        /// <summary>
        /// 保存数据字典信息
        /// </summary>
        /// <param name="di">The di.</param>
        public void SaveDictInfo(DictInfo di)
        {
            dictRepository.Save(di);
        }
        #endregion
    }
}
