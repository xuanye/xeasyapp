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
    }
}
