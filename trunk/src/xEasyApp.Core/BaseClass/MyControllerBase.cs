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
        public MyControllerBase()
        {
            _service = ObjectFactory.GetInstance<IUserService>();
        }
        private readonly IUserService _service;

        /// <summary>
        /// 获取当前登录用户标识
        /// </summary>
        /// <value>The user ID.</value>
        protected virtual string UserId
        {
            get
            {
                xEasyAppConfig config = xEasyAppConfig.Instance();
                //如果是调试模式则获取配置的测试账号
                if (config.RuntimeInfo.Mode == RunMode.Debug)
                {
                    return config.RuntimeInfo.UserId;
                }
                if (User.Identity.IsAuthenticated)
                {
                    string fuid = User.Identity.Name;
                    return fuid.IndexOf("\\") > 0 ? fuid.Split('\\')[1] : fuid;
                }
                string ssoUid = _service.GetSSOUserUid();
                if (!string.IsNullOrEmpty(ssoUid))
                {
                    FormsAuthentication.SetAuthCookie(ssoUid, false);
                    return ssoUid;
                }
                throw new UnauthorizedAccessException("登录超时!");
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
                IUser user = null;               
                
                if (Session["CurrentUser"] != null)
                {
                    user = Session["CurrentUser"] as IUser;
                }
                if (user == null)
                {
                    user = _service.GetUserInfo(UserId);
                    Session.Add("CurrentUser", user);
                }
                return user;
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
            if (string.IsNullOrEmpty(rightCode))
            {
                return false;
            }

            string hasRightCacheKey = "HasRight_" + rightCode;
            if (UserCache.ContainKey(hasRightCacheKey))
            {
                return UserCache.GetItem(hasRightCacheKey) == "true";
            }
            bool hasRight = _service.HasRight(UserId, rightCode);
            UserCache.AddItem(hasRightCacheKey, hasRight?"true":"false");
            return hasRight;
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
            if (string.IsNullOrEmpty(roleCode))
            {
                return false;
            }
            string isInRoleCacheKey = "IsInRole_" + roleCode;
            if (UserCache.ContainKey(isInRoleCacheKey))
            {
                return UserCache.GetItem(isInRoleCacheKey) == "true";
            }
            bool isInRole = _service.IsInRole(UserId, roleCode);
            UserCache.AddItem(isInRoleCacheKey, isInRole?"true":"false");
            return isInRole;
        }
    }
}
