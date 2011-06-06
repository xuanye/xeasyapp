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

       #region 属性
        private RoleInfoRepository _roleRepository;
        private DepartmentRepository _deptRepository;
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
            get {
                if (_roleRepository == null)
                {
                    _roleRepository = new RoleInfoRepository();
                }
                return _roleRepository; 
            }
        }
        protected DepartmentRepository deptRepository
        {
            get
            {
                if (_deptRepository == null)
                {
                    _deptRepository = new DepartmentRepository();
                }
                return _deptRepository;
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
        public List<RoleInfo> QueryRoleList()
        {
            return roleRepository.QueryAll();
        }

        public void SaveRoleInfo(RoleInfo ri)
        {
            if (ri.IsNew)
            {
               bool IsValid =  roleRepository.ValidRoleCode(ri.RoleCode);
               if (!IsValid)
               {
                  throw new BizException("角色代码必须唯一");
               }
            }
            roleRepository.Save(ri);
        }
        public RoleInfo GetRoleInfo(string roleCode)
        {
           return roleRepository.Get(roleCode);
        }
       
        public int DeleteRoleInfo(string roleCode)
        {
            RoleInfo ri = roleRepository.Get(roleCode);
            if (ri == null)
            {
                return 0;
            }
            if (ri.IsSystem.HasValue && ri.IsSystem.Value)
            {
                throw new BizException("系统角色不允许被删除");
            }
            return roleRepository.Delete(roleCode);
        }


        public bool ValidRoleCode(string roleCode)
        {
            return roleRepository.ValidRoleCode(roleCode);
        }
        #endregion

       #region 部门管理
        public List<Department> QueryDepartmentList()
        {
           return deptRepository.QueryAll();
        }

        public Department GetDeptInfo(string deptCode)
        {
            Department d= deptRepository.GetDepartment(deptCode);
            if (d.ParentCode == AppConfig.RootDeptCode)
            {
                d.ParentName = AppConfig.RootDeptName;
            }
            return d;
        }
        public Department GetRootDepartment()
        {
            Department dept = new Department();
            dept.DeptCode = AppConfig.RootDeptCode;
            dept.DeptName = AppConfig.RootDeptName;
            return dept;
        }

        public List<Department> GetChildDeptsByParentCode(string parentCode)
        {
            return deptRepository.GetChildDeptsByParentCode(parentCode);
        }

        public void SaveDeptInfo(Department department)
        {
            deptRepository.SaveDeptInfo(department);
        }

        public bool ValidDeptCode(string deptCode)
        {
            return deptRepository.ValidDeptCode(deptCode);
        }
        public PagedList<UserInfo> QueryDeptUserList(PageView view, string deptCode)
        { 
            return deptRepository.QueryDeptUserList(view,deptCode);
        }
        public int DeleteDeptInfo(string id)
        {
            int ret = -1;
            try
            {              
               ret = deptRepository.DeleteDeptInfo(id);
              
            }
            catch (Exception ex)
            {
                throw new BizException(ex.Message, ex);
            }
            return ret;

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
            return ret;
        }

        public void SaveUserInfo(UserInfo user)
        {
            userRepository.Save(user);
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
            return false;
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
        }

        /// <summary>
        /// 删除某个权限
        /// </summary>
        /// <param name="privilegeCode">The privilege code.</param>
        /// <returns></returns>
        public int DeletePrivilege(string privilegeCode)
        {
            int ret = -1;
            try
            {
                using(TransactionScope scope =new TransactionScope())
                {
                    ret = privilegeRepository.DeletePrivilege(privilegeCode);
                     scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new BizException(ex.Message, ex);
            }
            return ret;
        }
        public Privilege GetPrivilege(string privilegeCode)
        {
            return privilegeRepository.GetPrivilege(privilegeCode);
        }
        #endregion

       #region 数据字典管理
        public List<DictInfo> GetChildDictInfos(string dictCode)
        {
            switch (dictCode)
            { 
                case Constants.PrivilegeTypeCode:
                    return GetPrivilegeTypeDictList();               
            }
           return dictRepository.GetChildDictInfos(dictCode);
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
       #endregion
    }
}
