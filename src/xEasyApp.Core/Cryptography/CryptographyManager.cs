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
        /// ������ܷ������ṩMD5��SHA1�����㷨
        /// </summary>
        /// <param name="encryptingString">�����ܵ��ַ���</param>
        /// <param name="encryptFormat">�����㷨����"md5"��"sha1"��"clear"�����ģ��������ܣ���</param>
        /// <returns>���ܺ���ַ���</returns>
        /// <remarks>
        /// ������<paramref name="encryptFormat" />��Ϊ"md5"��"sha1"��"clear"ʱ��ֱ�ӷ��ز���<paramref name="encryptingString" />
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