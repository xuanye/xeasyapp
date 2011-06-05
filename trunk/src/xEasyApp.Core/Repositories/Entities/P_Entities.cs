using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xEasyApp.Core.Repositories
{
    public partial class Department
    {
        /// <summary>
        /// 父部门名称
        /// </summary>
        /// <value>The name of the parent.</value>
        public string ParentName
        {
            get;
            set;
        }
    }

    public partial class Privilege
    {
        public string ParentName
        { get; set; }

        public bool HasChild
        {
            get;
            set;
        }
    }
}
