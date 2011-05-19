using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xEasyApp.Core.Interfaces;
using xEasyApp.Core.Repositories;

namespace xEasyApp.Core.Biz
{
    public class SysManageService : ISysManageService
    {
        public List<Repositories.RoleInfo> QueryRoleList()
        {
           return RoleInfo.All().ToList();
        }
    }
}
