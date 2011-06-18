using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xEasyApp.Core.Entities;

namespace xEasyApp.Core.Repositories
{
    public partial class UserInfo:IUser
    {
        string IUser.UserUId
        {
            get
            {
                return this.UserUID;
            }
            set
            {
                this.UserUID = value;
            }
        }

        string IUser.FullName
        {
            get
            {
                return this.FullName;
            }
            set
            {
                this.FullName = value;
            }
        }

        string IUser.OrgCode
        {
            get
            {
                return this.OrgCode;
            }
            set
            {
                this.OrgCode = value;
                
            }
        }

        string IUser.OrgName
        {
            get
            {
                return this.OrgName;
            }
            set
            {
                this.OrgName = value;
            }
        }
        string IUser.UnitCode
        {
            get {
                return this.UnitCode;
            }
            set {
                this.UnitCode = value;
            }
        }
        string IUser.UnitName
        {
            get {
                return this.UnitName;
            }
            set {
                this.UnitName = value;
            }
        }
        
        private Dictionary<string, string> _UserExtendProperties;
        Dictionary<string, string> IUser.ExtendProperties
        {
            get { 
                if(_UserExtendProperties ==null)
                {
                    _UserExtendProperties =new Dictionary<string,string>();
                }
                return _UserExtendProperties;
            }
        }
        /// <summary>
        /// 所属单位Code
        /// </summary>
        /// <value>The unit code.</value>
        public string UnitCode
        {
            get;
            set;
        }
        /// <summary>
        /// 所属单位的名称
        /// </summary>
        /// <value>The name of the unit.</value>
        public string UnitName
        {
            get;
            set;
        }
    }
}
