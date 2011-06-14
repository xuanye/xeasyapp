using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xEasyApp.Core.Common
{
    /// <summary>
    /// 公共的帮助类
    /// </summary>
    public class Utility
    {
        public static string ClearSafeStringParma(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                return input.Replace("--", "").Replace("'", "").Replace(";", "；");
            }
            return "";
        }
    }
}
