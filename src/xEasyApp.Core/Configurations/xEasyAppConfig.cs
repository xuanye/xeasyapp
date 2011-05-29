using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace xEasyApp.Core.Configurations
{
    /// <summary>
    /// 配置文件类
    /// </summary>
    public class xEasyAppConfig : ConfigurationSection
    {      
        /// <summary>
        /// 运行时信息
        /// </summary>
        /// <value>The runtime.</value>
        [ConfigurationProperty("Runtime")]
        public RuntimeInfo RuntimeInfo
        {
            get
            {
                RuntimeInfo runtimeinfo = this["Runtime"] as RuntimeInfo;
                if(runtimeinfo ==null)
                {
                    runtimeinfo = new RuntimeInfo();
                    runtimeinfo.Mode = RunMode.Normal;
                    runtimeinfo.UserId = "";
                }
                return runtimeinfo;
            }
            set
            {
                this["Runtime"] = value;
            }
        }

        private static xEasyAppConfig _config;

        /// <summary>
        /// 实例化
        /// </summary>
        /// <returns></returns>
        public static xEasyAppConfig Instance()
        {
            if (_config == null)
            {
                _config = ConfigurationManager.GetSection("xEasyAppConfig") as xEasyAppConfig;
            }
            return _config;
        }
    }
    public enum RunMode
    {
        Debug,
        Normal,
        Release
    }
    public class RuntimeInfo : ConfigurationElement
    {
        [ConfigurationProperty("mode")]
        public RunMode Mode
        {
            get
            {
                string mode = this["mode"] !=null? this["mode"].ToString():"";

                if (string.IsNullOrEmpty(mode))
                {
                    return RunMode.Normal;
                }
                else
                {
                    return (RunMode)Enum.Parse(typeof(RunMode), mode);
                }
                
            }
            set { this["mode"] = value; }
        }
        [ConfigurationProperty("userid")]
        public string UserId
        {
            get { return this["userid"] as string; }
            set { this["userid"] = value; }
        }
    }
   
}
