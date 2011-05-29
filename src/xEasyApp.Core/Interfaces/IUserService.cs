using System;
using xEasyApp.Core.Entities;


namespace xEasyApp.Core.Interfaces
{
    public interface IUserService 
    {
        string GetSSOUserUid();

        /// <summary>
        /// 根据用户标示 获取标准用户信息
        /// </summary>
        /// <param name="UserId">The user id.</param>
        /// <returns></returns>
        IUser GetUserInfo(string UserId);

        bool HasRight(string UserId, string rightCode);

        bool IsInRole(string UserId, string roleCode);
    }
}
