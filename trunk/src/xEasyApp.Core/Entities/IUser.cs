using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace xEasyApp.Core.Entities
{
    /// <summary>
    /// 用户基本信息
    /// </summary>
  
    public interface IUser 
    {
        /// <summary>
        /// 用户标识，一般为登录账号
        /// </summary>
        /// <value>The user id.</value>
        string UserUId { get; set; }
        /// <summary>
        /// 用户全名
        /// </summary>
        /// <value>The full name.</value>
        string FullName { get; set; }
        /// <summary>
        /// 所属机构代码,一般为部门Code
        /// </summary>
        /// <value>The org code.</value>
        string OrgCode { get; set; }
        /// <summary>
        /// 所属机构名称,一般为部门名称
        /// </summary>
        /// <value>The name of the org.</value>
        string OrgName { get; set; }  

        /// <summary>
        /// 扩展信息
        /// </summary>
        /// <value>The extend properties.</value>
        Dictionary<string, string> ExtendProperties { get; }

    }
    public class BaseUser : IUser
    {
        public string UserUId
        {
            get;
            set;
        }

        public string FullName
        {
            get;
            set;
        }

        public string OrgCode
        {
            get;
            set;
        }

        public string OrgName
        {
            get;
            set;
        }

        private Dictionary<string, string> _ExtendProperties;
        public Dictionary<string, string> ExtendProperties
        {
            get {
                if (_ExtendProperties == null)
                {
                    _ExtendProperties = new Dictionary<string, string>();
                }
                return _ExtendProperties;
            }
        }      
    }
}
