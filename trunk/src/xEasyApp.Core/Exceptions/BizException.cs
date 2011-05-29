using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xEasyApp.Core.Exceptions
{
    public class BizException : Exception
    {
        public BizException(string msg)
            : base(msg)
        { 
        }
        public BizException(string msg,Exception inner)
            : base(msg, inner)
        {
        }
    }
}
