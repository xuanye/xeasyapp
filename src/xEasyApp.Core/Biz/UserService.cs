using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xEasyApp.Core.Interfaces;
using xEasyApp.Core.Entities;
using xEasyApp.Core.Repositories;
using xEasyApp.Core.Common;
using xEasyApp.Core.Configurations;

namespace xEasyApp.Core.Biz
{
    public class UserService : IUserService
    {
       
        private UserInfoRepository _userRepository;
        protected UserInfoRepository userRepository
        {
            get {
                if (_userRepository == null)
                {
                    _userRepository = new UserInfoRepository();
                }
                return _userRepository;
            }
        }
        public string GetSSOUserUid()
        {
            return "";
        }

        public IUser GetUserInfo(string UserId)
        {
            return userRepository.GetUserInfo(UserId);
        }

        public bool HasRight(string UserId, string privilegeCode)
        {
            bool IsAdminRole = IsInRole(UserId, AppConfig.SuperAdminRoleCode);
            if (IsAdminRole) //如果是管理员角色
            {
                return true;
            }
            string hasright = UserCache.GetItem(UserId, "HasRight_" + privilegeCode);
            if (hasright == null)
            {
                bool hr = userRepository.CheckUserRight(UserId, privilegeCode);
                UserCache.AddItem("HasRight_" + privilegeCode, hr ? "true" : "false");
                return hr;
            }
            else
            {
                return hasright.ToLower() == "true";
            }
        }

        public bool IsInRole(string UserId, string roleCode)
        {
            string userrols = UserCache.GetItem(UserId, "UserRoles");
            if (!string.IsNullOrEmpty(userrols))
            {
                return userrols.IndexOf("," + roleCode + ",") >= 0;
            }
            else
            {
                List<string> roles = userRepository.GetUserRoleCodes(UserId);
                UserCache.AddItem(UserId, "UserRoles", "," + string.Join(",", roles.ToArray()) + ",");
                return roles.Contains(roleCode);
            }
        }
    }
}
