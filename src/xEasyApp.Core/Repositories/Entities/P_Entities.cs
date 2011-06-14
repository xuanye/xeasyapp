using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xEasyApp.Core.Repositories
{
    public partial class Organization
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

    public partial class RoleInfo
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance has child.
        /// </summary>
        /// <value><c>true</c> if this instance has child; otherwise, <c>false</c>.</value>
        public bool HasChild
        {
            get;
            set;
        }
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
        public bool IsChecked
        {
            get;
            set;
        }
    }
}
