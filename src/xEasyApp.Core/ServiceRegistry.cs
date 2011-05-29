using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap.Configuration.DSL;
using xEasyApp.Core.Interfaces;
using xEasyApp.Core.Biz;


namespace xEasyApp.Core
{
    public class ServiceRegistry : Registry
    {
        public ServiceRegistry()
        {
            For<ISysManageService>().Use<SysManageService>();
            For<IUserService>().Use<UserService>();
        }
       
    }
}
