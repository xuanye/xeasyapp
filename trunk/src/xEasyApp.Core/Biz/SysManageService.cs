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

namespace xEasyApp.Core.Biz
{
    public class SysManageService : ISysManageService
    {
        public SysManageService()
        {
            _roleRepository=new RoleInfoRepository();
            _deptRepository =new DepartmentRepository();
            _userRepository = new UserInfoRepository();
            _privilegeDao = new PrivilegeRepository();
        }
        private RoleInfoRepository _roleRepository;
        private DepartmentRepository _deptRepository;
        private UserInfoRepository _userRepository;
        private PrivilegeRepository _privilegeDao;
        public List<RoleInfo> QueryRoleList()
        {
            return _roleRepository.QueryAll();
        }

        public void SaveRoleInfo(RoleInfo ri)
        {
            if (ri.IsNew)
            {
               bool IsValid =  _roleRepository.ValidRoleCode(ri.RoleCode);
               if (!IsValid)
               {
                  throw new BizException("角色代码必须唯一");
               }
            }
            _roleRepository.Save(ri);
        }
        public RoleInfo GetRoleInfo(string roleCode)
        {
           return _roleRepository.Get(roleCode);
        }
       
        public int DeleteRoleInfo(string roleCode)
        {
            RoleInfo ri = _roleRepository.Get(roleCode);
            if (ri == null)
            {
                return 0;
            }
            if (ri.IsSystem.HasValue && ri.IsSystem.Value)
            {
                throw new BizException("系统角色不允许被删除");
            }
            return _roleRepository.Delete(roleCode);
        }


        public bool ValidRoleCode(string roleCode)
        {
            return _roleRepository.ValidRoleCode(roleCode);
        }


        public List<Department> QueryDepartmentList()
        {
           return _deptRepository.QueryAll();
        }

        public Department GetDeptInfo(string deptCode)
        {
            Department d= _deptRepository.GetDepartment(deptCode);
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
            return _deptRepository.GetChildDeptsByParentCode(parentCode);
        }

        public void SaveDeptInfo(Department department)
        {
            _deptRepository.SaveDeptInfo(department);
        }

        public bool ValidDeptCode(string deptCode)
        {
            return _deptRepository.ValidDeptCode(deptCode);
        }
        public PagedList<UserInfo> QueryDeptUserList(PageView view, string deptCode)
        { 
            return _deptRepository.QueryDeptUserList(view,deptCode);
        }
        public int DeleteDeptInfo(string id)
        {
            int ret = -1;
            try
            {              
               ret = _deptRepository.DeleteDeptInfo(id);
              
            }
            catch (Exception ex)
            {
                throw new BizException(ex.Message, ex);
            }
            return ret;

        }
        public UserInfo GetUserInfo(string UserUID)
        {
            return _userRepository.Get(UserUID);
        }

        public bool ValidUserUID(string UserUID)
        {
            return _userRepository.ValidUserUID(UserUID);
        }

        public int DeleteUserInfo(string id)
        {
            int ret = -1;
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    ret = _userRepository.DeleteUserInfo(id);
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
            _userRepository.Save(user);
        }

        #region 权限相关

        /// <summary>
        /// 验证权限代码是否存在
        /// </summary>
        /// <param name="privilegeCode">The privilege code.</param>
        /// <returns></returns>
        public bool ValidPrivilegeCode(string privilegeCode)
        {
            return _privilegeDao.ValidPrivilegeCode(privilegeCode);
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
            if (parentCode == null)
            {
                return _privilegeDao.GetTopLevelPrivileges();
            }
            else
            {
                return _privilegeDao.GetChildPrivileges(parentCode);
            }
        }

        /// <summary>
        /// 根据父权限表示获取子权限列表 ，用于列表
        /// </summary>
        /// <param name="parentCode">The parent code.</param>
        /// <returns></returns>
        public List<Privilege> QueryPrivilegeListByParentCode(string parentCode)
        {
            if (parentCode == null)
            {
                return _privilegeDao.QueryTopLevelPrivilegeList();
            }
            else
            {
                return _privilegeDao.QueryPrivilegeListByParentCode(parentCode);
            }
        }

        /// <summary>
        ///保存对权限的修改
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns></returns>
        public void SavePrivilege(Privilege p)
        {
            _privilegeDao.Save(p);
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
                     ret =_privilegeDao.DeletePrivilege(privilegeCode);
                     scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new BizException(ex.Message, ex);
            }
            return ret;
        }

        #endregion
    }
}
