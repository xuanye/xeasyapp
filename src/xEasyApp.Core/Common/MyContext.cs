using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

using StructureMap;
using xEasyApp.Core.Configurations;
using xEasyApp.Core.Exceptions;
using System.Web.Security;
using xEasyApp.Core.Interfaces;
using xEasyApp.Core.Repositories;
using xEasyApp.Core.Entities;

namespace xEasyApp.Core.Common
{
    public class MyContext
    {

        /// <summary>
        /// 当前登录账户的标识
        /// </summary>
        /// <value>The identity.</value>
        public static string Identity
        {
            get
            {
                xEasyAppConfig config = xEasyAppConfig.Instance();
                //如果是调试模式则获取配置的测试账号
                if (config.RuntimeInfo.Mode == RunMode.Debug)
                {
                    string userid = config.RuntimeInfo.UserId;
                    if (!HttpContext.Current.User.Identity.IsAuthenticated)
                    {
                        FormsAuthentication.SetAuthCookie(userid, false);
                    }
                    return userid;
                }
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    string fuid = HttpContext.Current.User.Identity.Name;
                    return fuid.IndexOf("\\") > 0 ? fuid.Split('\\')[1] : fuid;
                }
                string ssoUid = UserService.GetSSOUserUid();
                if (!string.IsNullOrEmpty(ssoUid))
                {
                    FormsAuthentication.SetAuthCookie(ssoUid, false);
                    return ssoUid;
                }
                throw new UnauthorizedAccessException("登录超时!");
            }
        }

        /// <summary>
        /// 判断是否经过认证
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is is authenticated; otherwise, <c>false</c>.
        /// </value>
        public static bool IsIsAuthenticated
        {
            get {
                xEasyAppConfig config = xEasyAppConfig.Instance();
                if (config.RuntimeInfo.Mode == RunMode.Debug)
                {
                    string userid = config.RuntimeInfo.UserId;
                    if (!HttpContext.Current.User.Identity.IsAuthenticated)
                    {
                        FormsAuthentication.SetAuthCookie(userid, false);
                    }
                    return true;
                }
                else
                {
                    return HttpContext.Current.User.Identity.IsAuthenticated;
                }
            }
        }

        /// <summary>
        /// 当前登录账户的完整信息
        /// </summary>
        /// <value>The current user.</value>
        public static IUser CurrentUser
        {
            get
            {

                if (HttpContext.Current.Session["UseInfo"] != null)
                {
                    IUser user= HttpContext.Current.Session["UseInfo"] as IUser;
                    return user;
                }
                else
                {
                    IUser u = UserService.GetUserInfo(Identity);
                    HttpContext.Current.Session["UseInfo"] = u;
                    return u;
                }
            }
        }

        /// <summary>
        /// 获取用户的IP
        /// </summary>
        /// <value>The user IP.</value>
        public static string UserIP
        {
            get
            {
                return HttpContext.Current.Request.UserHostAddress;
            }
        }
        /// <summary>
        /// 判断当前用户是否在某个角色内
        /// </summary>
        /// <param name="roleCode">角色代码</param>
        /// <returns>
        /// 	<c>true</c> if [is in role] [the specified role code]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsInRole(string roleCode)
        {
            return UserService.IsInRole(Identity, roleCode);
        }
        /// <summary>
        /// 判断是否有权限
        /// </summary>
        /// <param name="rightCode">权限代码</param>
        /// <returns>
        /// 	<c>true</c> if the specified right code has right; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasRight(string rightCode)
        {
            return UserService.HasRight(Identity, rightCode);
        }

        private static IUserService _IUserService;
        private static IUserService UserService
        {
            get
            {
                if (_IUserService == null)
                {
                    _IUserService = ObjectFactory.GetInstance<IUserService>();
                }
                return _IUserService;
            }
        }

        /// <summary>
        /// 将object类型转换成指定类型，吞掉转换异常等情况
        /// </summary>
        /// <typeparam name="T">需要转换成的类型</typeparam>
        /// <param name="o">需要转换的对象</param>
        /// <returns></returns>
        private static T ObjectToStrongType<T>(object o) where T : class, new()
        {
            T t = null;
            if (o != null)
            {
                t = o as T;
            }
            return t;
        }
    }
}
