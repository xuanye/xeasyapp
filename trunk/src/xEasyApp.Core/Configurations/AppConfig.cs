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

        public static string RootDeptCode
        {
            get {
                string code = Get("RootDeptCode");
                if (string.IsNullOrEmpty(code))
                {
                    return "-1";
                }
                return code;
            }
        }

        public static string RootDeptName
        {
            get
            {
                string name = Get("RootDeptName");
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
