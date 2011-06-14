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

       
    }
}
