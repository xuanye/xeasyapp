using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace xEasyApp.Core.Common
{
    public class StringKeyValueCache
    {
        private static Dictionary<string, string> _cacheDict = new Dictionary<string, string>();
        private static object _lockobject = new object();
        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public static void AddItem(string key, string value)
        {
            lock (_lockobject)
            {
                if (ContainKey(key))
                {
                    _cacheDict[key] = value;
                }
                else
                {
                    _cacheDict.Add(key, value);
                }
            }
        }
        /// <summary>
        /// 判断是否用用
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static bool ContainKey(string key)
        {
            return _cacheDict.ContainsKey(key);
        }
        public static string GetItem(string key)
        {
            lock (_lockobject)
            {
                if (ContainKey(key))
                {
                    return _cacheDict[key];
                }
                else
                {
                    return null;
                }
            }
        }
        public static void RemoveItem(string key)
        {
            lock (_lockobject)
            {

                if (ContainKey(key))
                {
                    _cacheDict.Remove(key);
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
