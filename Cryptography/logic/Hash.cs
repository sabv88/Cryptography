using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.logic
{
    public static class Hash
    {
        public static string SHA1(string data)
        {

            StringBuilder hex = new StringBuilder();
            foreach (byte b in System.Security.Cryptography.SHA1.HashData(Encoding.UTF8.GetBytes(data)))
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        public static string SHA256(string data)
        {
            StringBuilder hex = new StringBuilder();
            foreach (byte b in System.Security.Cryptography.SHA256.HashData(Encoding.UTF8.GetBytes(data)))
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        public static string SHA384(string data)
        {
            StringBuilder hex = new StringBuilder();
            foreach (byte b in System.Security.Cryptography.SHA384.HashData(Encoding.UTF8.GetBytes(data)))
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        public static string SHA512(string data)
        {
            StringBuilder hex = new StringBuilder();
            foreach (byte b in System.Security.Cryptography.SHA512.HashData(Encoding.UTF8.GetBytes(data)))
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        public static string MD5(string data)
        {
            StringBuilder hex = new StringBuilder();
            foreach (byte b in System.Security.Cryptography.MD5.HashData(Encoding.UTF8.GetBytes(data)))
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        public static bool CheckFileIntegrity(string path, byte[] data)
        {
            return System.Security.Cryptography.MD5.HashData((File.ReadAllBytes(path))
                ).SequenceEqual(data);
        }
    }

}
