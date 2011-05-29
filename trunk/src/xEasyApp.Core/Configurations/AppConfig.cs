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
    }
}
