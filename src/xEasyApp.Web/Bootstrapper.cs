using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;

namespace xEasyApp.Web
{
    public static class Bootstrapper
    {
        public static void ConfigureStructureMap()
        {
            ObjectFactory.Initialize(x => { 
                x.AddRegistry(new Core.ServiceRegistry()); 
            });         
        }
    }
}
