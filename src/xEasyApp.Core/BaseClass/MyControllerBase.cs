using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using xEasyApp.Core.Configurations;
using System.Web.Security;
using xEasyApp.Core.Interfaces;
using StructureMap;
using xEasyApp.Core.Entities;
using xEasyApp.Core.Common;

namespace xEasyApp.Core.BaseClass
{
    /// <summary>
    /// Controller 基类，包装一些同样的方法和属性
    /// </summary>
    public class MyControllerBase : Controller
    {       

        /// <summary>
        /// 获取当前登录用户标识
        /// </summary>
        /// <value>The user ID.</value>
        protected virtual string UserId
        {
            get
            {
                return MyContext.Identity;
            }
        }

        /// <summary>
        /// 当前登录用户信息
        /// </summary>
        /// <value>The current user.</value>
        protected virtual IUser CurrentUser
        {
            get
            {
               return MyContext.CurrentUser;
            }
        }

        /// <summary>
        /// 判断用户是否拥有某个权限
        /// </summary>
        /// <param name="rightCode">权限标识</param>
        /// <returns>
        /// 	<c>true</c> 是否拥有指定权限<c>false</c>.
        /// </returns>
        protected virtual bool HasRight(string rightCode)
        {
            return MyContext.HasRight(rightCode);
        }       

        /// <summary>
        /// 判断用户是否属于某个角色
        /// </summary>
        /// <param name="roleCode">角色标识</param>
        /// <returns>
        /// 	<c>true</c> 是否属于某个角色 <c>false</c>.
        /// </returns>
        protected virtual bool IsInRole(string roleCode)
        {
            return MyContext.IsInRole(roleCode);
        }
    }
}
