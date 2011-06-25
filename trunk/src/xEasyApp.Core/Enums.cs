using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xEasyApp.Core
{
    public enum Theme
    { 
        Default,
        Share
    }
    public enum DictValueType
    { 
        DictID,
        DictCode,
        DictName
    }

    /// <summary>
    /// 日志类型
    /// </summary>
    public enum LogType
    {
        None=99,
        /// <summary>
        /// 调试
        /// </summary>
        Debug = 0,
        /// <summary>
        /// 跟踪
        /// </summary>
        Trace = 1,
        /// <summary>
        /// 错误
        /// </summary>
        Error = 2
    }

}
