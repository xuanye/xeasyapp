using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using xEasyApp.Core.Configurations;


namespace xEasyApp.Core.Common
{
    /// <summary>
    /// 用户缓存。可针对每个用户
    /// </summary>
    public class UserCache
    {

        private static Dictionary<string, Dictionary<string, string>> _cacheDict = new Dictionary<string, Dictionary<string, string>>();
        private static object _lockobject = new object();
        private static string GetUserId()
        {
            return MyContext.Identity;
        }
        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public static void AddItem(string key, string value)
        {

            string uid = GetUserId();
            AddItem(uid, key, value);
        }
        private static bool ContainUser(string userId)
        {
            return _cacheDict.ContainsKey(userId);
        }


        /// <summary>
        /// 判断是否用用
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static bool ContainKey(string key)
        {
            string uid = GetUserId();
            return ContainKey(uid, key);
        }
        public static string GetItem(string key)
        {
            string uid = GetUserId();
            return GetItem(uid, key);
        }
        public static void RemoveItem(string key)
        {
            string uid = GetUserId();
            RemoveItem(uid, key);
        }


        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public static void AddItem(string userId, string key, string value)
        {

            string uid = userId;
            lock (_lockobject)
            {
                if (ContainUser(uid))
                {
                    if (_cacheDict[uid].ContainsKey(key))
                    {
                        _cacheDict[uid][key] = value;
                    }
                    else
                    {
                        _cacheDict[uid].Add(key, value);
                    }
                }
                else
                {
                    Dictionary<string, string> dict = new Dictionary<string, string>();
                    dict.Add(key, value);
                    _cacheDict.Add(uid, dict);
                }
            }
        }

        /// <summary>
        /// 判断是否用用
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static bool ContainKey(string userId, string key)
        {
            string uid = userId;
            if (ContainUser(uid))
            {
                return _cacheDict[uid].ContainsKey(key);
            }
            return false;
        }
        public static string GetItem(string userId, string key)
        {
            string uid = userId;
            lock (_lockobject)
            {
                if (ContainKey(uid, key))
                {
                    return _cacheDict[uid][key];
                }
                else
                {
                    return null;
                }
            }
        }
        public static void RemoveItem(string userId, string key)
        {
            string uid = userId;
            lock (_lockobject)
            {

                if (ContainKey(uid, key))
                {
                    _cacheDict[uid].Remove(key);
                }

            }
        }

        /// <summary>
        /// 清空某个用户的缓存
        /// </summary>
        /// <param name="userId">如果没有传，这默认为当前用户</param>
        public static void RemoveUser(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                userId = GetUserId();
            }
            lock (_lockobject)
            {
                if (ContainUser(userId))
                {

                    _cacheDict.Remove(userId);
                }
            }
        }
        /// <summary>
        /// 清空缓存
        /// </summary>
        public static void Clear()
        {
            lock (_lockobject)
            {
                _cacheDict.Clear();
            }
        }
    }
}