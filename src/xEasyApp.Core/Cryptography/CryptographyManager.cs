using System;
using System.Data;
using System.IO;
using System.Text;
using System.Configuration;
using System.Security;
using System.Security.Cryptography;
using System.Web.Security;

namespace xEasyApp.Core.Cryptography
{
    /// <summary>
    /// Common CryptographyManager
    /// </summary>
    public class CryptographyManager
    {
        //private readonly string _defaultLegalIV = "E4ghj*Ghg7!rNIfb&95GUY86GfghUb#er57HBh(u%g6HJ($jhWk7&!hg4ui%$hjk";



        /// <summary>
        /// Initializes a new instance of the <see cref="CryptographyManager"/> class.
        /// </summary>
        public CryptographyManager()
        {
        }
        //public const string DEFAULT_KEY = "aslkjkljlsajsuaggasfklrjuisdhaie";



        /// <summary>
        /// 单向加密方法，提供MD5、SHA1加密算法
        /// </summary>
        /// <param name="encryptingString">被加密的字符串</param>
        /// <param name="encryptFormat">加密算法，有"md5"、"sha1"、"clear"（明文，即不加密）等</param>
        /// <returns>加密后的字符串</returns>
        /// <remarks>
        /// 当参数<paramref name="encryptFormat" />不为"md5"、"sha1"、"clear"时，直接返回参数<paramref name="encryptingString" />
        /// </remarks>
        public static string Encrypt(string encryptingString, string encryptFormat)
        {
            if (string.Compare(encryptFormat, "md5", true) == 0 || string.Compare(encryptFormat, "sha1", true) == 0)
            {
                return FormsAuthentication.HashPasswordForStoringInConfigFile(encryptingString, encryptFormat);
            }
            return encryptingString;
        }
   
    }
}