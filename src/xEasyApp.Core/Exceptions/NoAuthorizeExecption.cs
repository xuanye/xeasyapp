﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xEasyApp.Core.Exceptions
{
    /// <summary>
    /// 没有登录的异常
    /// </summary>
    public class NoAuthorizeExecption:Exception
    {
        public NoAuthorizeExecption()
            : base("你没有登录，该页面必须登录后访问！")
        {
           
        }             
    }
}
