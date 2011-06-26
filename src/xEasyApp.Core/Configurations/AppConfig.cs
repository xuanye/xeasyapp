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
        public static string PasswordFormat
        {
            get
            {
                string format = Get("PasswordFormat");
                if (string.IsNullOrEmpty(format))
                {
                    return "md5";
                }
                return format;
            }
        }
        public static int SuperAdminRoleID
        {
            get {
                string id = Get("SuperAdminRoleID");
                if (string.IsNullOrEmpty(id))
                {
                    return 1;
                }
                return Convert.ToInt32(id);
            }
        }
        public static string SuperAdminRoleCode
        {
            get
            {
                return "admin";
            }
        }

        /// <summary>
        /// 判断是否允许记录操作日志，默认为真
        /// </summary>
        /// <value><c>true</c> if [enable op log]; otherwise, <c>false</c>.</value>
        public static bool EnableOpLog
        {
            get {
                string enable = Get("EnableOpLog");
                if (!string.IsNullOrEmpty(enable))
                {
                    return enable.ToLower() == "true";
                }
                return true;
            }
        }

        public static string LogoTitle {

            get
            {
                string title = Get("LogoTitle");
                if (string.IsNullOrEmpty(title))
                {
                    return "xEasyApp Demo";
                }
                return title;
            }
        }
    }
}
