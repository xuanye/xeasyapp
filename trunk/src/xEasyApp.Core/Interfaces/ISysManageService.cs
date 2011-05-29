using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xEasyApp.Core.Repositories;

namespace xEasyApp.Core.Interfaces
{
    public interface ISysManageService
    {
        List<RoleInfo> QueryRoleList();

        void SaveRoleInfo(RoleInfo ri);

        RoleInfo GetRoleInfo(string roleCode);

        int DeleteRoleInfo(string roleCode);

        bool ValidRoleCode(string RoleCode);

        List<Department> QueryDepartmentList();

        Department GetDeptInfo(string deptCode);

        Department GetRootDepartment();

        List<Department> GetChildDeptsByParentCode(string parentCode);

        void SaveDeptInfo(Department department);

        bool ValidDeptCode(string deptCode);
    }
}
