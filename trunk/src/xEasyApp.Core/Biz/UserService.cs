using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xEasyApp.Core.Interfaces;
using xEasyApp.Core.Entities;
using xEasyApp.Core.Repositories;

namespace xEasyApp.Core.Biz
{
    public class UserService : IUserService
    {
        public UserService()
        {
            _userRepository = new UserInfoRepository();
        }
        private UserInfoRepository _userRepository;
        public string GetSSOUserUid()
        {
            return "";
        }

        public IUser GetUserInfo(string UserId)
        {
            return _userRepository.Get(UserId);
        }

        public bool HasRight(string UserId, string rightCode)
        {
            return false;
        }

        public bool IsInRole(string UserId, string roleCode)
        {
            return true;
        }
    }
}
