using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xEasyApp.Core.Configurations
{
    public class AppConfig
    {
        public static string Get(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings.Get(key);
        }
        public static string MainDbkey
        {
            get
            {
                return "mainDB";
            }
        }

        public static string RootOrgCode
        {
            get {
                string code = Get("RootOrgCode");
                if (string.IsNullOrEmpty(code))
                {
                    return "-1";
                }
                return code;
            }
        }

        public static string RootOrgName
        {
            get
            {
                string name = Get("RootOrgName");
                if (string.IsNullOrEmpty(name))
                {
                    return "xEasyApp";
                }
                return name;
            }
        }


        public static string SuperAdminRoleCode
        {
            get
            {
                return "admin";
            }
        }
    }
}
