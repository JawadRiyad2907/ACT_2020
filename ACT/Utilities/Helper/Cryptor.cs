using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ACT.Utilities.Helper
{
    public  class Cryptor
    {
        private static byte[] key = new byte[0];

        private static byte[] _iv = new byte[] { 18, 52, 86, 120, 144, 171, 205, 239 };

        public static byte[] IV
        {
            get
            {
                byte[] numArray = _iv;
                return numArray;
            }
        }

        public static  string Decrypt(string stringToDecrypt)
        {
            string str;
            byte[] numArray = new byte[stringToDecrypt.Length + 1];
            try
            {
                string str1 = ")^*1@23*&^%$#!II*&@";
                key = Encoding.UTF8.GetBytes(str1.Substring(0, 8));
                DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
                numArray = Convert.FromBase64String(stringToDecrypt);
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                cryptoStream.Write(numArray, 0, (int)numArray.Length);
                cryptoStream.FlushFinalBlock();
                str = Encoding.UTF8.GetString(memoryStream.ToArray());
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;

                str = exception.Message;
            }
            return str;
        }

        public static string Encrypt(string stringToEncrypt)
        {
            string base64String;
            try
            {
                string str = ")^*1@23*&^%$#!II*&@";
               key = Encoding.UTF8.GetBytes(str.Substring(0, 8));
                DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
                byte[] bytes = Encoding.UTF8.GetBytes(stringToEncrypt);
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                cryptoStream.Write(bytes, 0, (int)bytes.Length);
                cryptoStream.FlushFinalBlock();
                base64String = Convert.ToBase64String(memoryStream.ToArray());
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;

                base64String = exception.Message;
            }
            return base64String;
        }

        public static string CreateRandomPassword(int length)
        {
            string valid = "1234567890SCFHSscfhs";
            string res = "";
            Random rnd = new Random();
            while (0 < length--)
                res += valid[rnd.Next(valid.Length)];
            return res;
        }
        public static string CreateRandomPinSMS(int length)
        {
            string valid = "1234567890";
            string res = "";
            Random rnd = new Random();
            while (0 < length--)
                res += valid[rnd.Next(valid.Length)];
            return res;
        }
        public static string CreateRandomPinEmail(int length)
        {
            string valid = "SCFHSscfhs1234567890";
            string res = "";
            Random rnd = new Random();
            while (0 < length--)
                res += valid[rnd.Next(valid.Length)];
            return res;
        }
    }
}