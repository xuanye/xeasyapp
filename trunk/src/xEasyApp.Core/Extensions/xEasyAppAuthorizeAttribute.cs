using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Security.Principal;
using xEasyApp.Core.Common;
using xEasyApp.Core.Configurations;

namespace xEasyApp.Core.Extensions
{
    public class xEasyAppAuthorizeAttribute : AuthorizeAttribute
    {
        string[] _usersSplit ;
        protected string[] UsersSplit
        {
            get {
                if (_usersSplit == null)
                {
                    _usersSplit = SplitString(base.Users);
                }
                return _usersSplit;
            }
        }
        string[] _rolesSplit;
        protected string[] RolesSplit
        {
            get
            {
                if (_rolesSplit == null)
                {
                    _rolesSplit = SplitString(base.Roles);
                }
                return _rolesSplit;
            }
        }
        private string _privilegeCode;
        public string PagePrivilegeCode
        {
            get {
                return _privilegeCode;
            }
            set {
                _privilegeCode = value;
            }
        }

        protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
        {
           
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }

          
            if (!MyContext.IsIsAuthenticated)
            {               
                return false;
            }

            if (UsersSplit.Length > 0 && !UsersSplit.Contains(MyContext.Identity, StringComparer.OrdinalIgnoreCase))
            {
                return false;
            }

            if (RolesSplit.Length > 0 && !RolesSplit.Any(MyContext.IsInRole))
            {
                return false;
            }
            //验证页面权限
            if (!string.IsNullOrEmpty(_privilegeCode) && !MyContext.HasRight(_privilegeCode))
            {
                return false;
            }
            return true;
        }

        internal static string[] SplitString(string original)
        {
            if (String.IsNullOrEmpty(original))
            {
                return new string[0];
            }

            var split = from piece in original.Split(',')
                        let trimmed = piece.Trim()
                        where !String.IsNullOrEmpty(trimmed)
                        select trimmed;
            return split.ToArray();
        }
    }
}
