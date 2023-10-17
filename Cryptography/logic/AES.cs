using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Threading.Tasks;
using Cryptography.logic.Interfaces;

namespace Cryptography.logic
{
    public class AES : IAES
    {
        public async Task<(string cipherText, string Key, string IV)> AESEncrypt(string openText)
        {
            byte[] encrypted;
            byte[] iv;
            byte[] key;

            using (Aes myAes = Aes.Create())
            {
                key = myAes.Key;
                iv = myAes.IV;
                ICryptoTransform encryptor = myAes.CreateEncryptor(key, iv);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(openText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            StringBuilder stringBuilderEncoding = new StringBuilder();
            foreach (byte b in encrypted)
            {
                stringBuilderEncoding.Append(b).Append(" ");
            }

            StringBuilder stringBuilderKey = new StringBuilder();
            foreach (byte b in key)
            {
                stringBuilderKey.Append(b).Append(" ");
            }

            StringBuilder stringBuilderIV = new StringBuilder();
            foreach (byte b in iv)
            {
                stringBuilderIV.Append(b).Append(" ");
            }

            var cipherText = stringBuilderEncoding.ToString().TrimEnd();
            var Key = stringBuilderKey.ToString().TrimEnd();
            var IV = stringBuilderIV.ToString().TrimEnd();

            return (cipherText, Key, IV);

        }


        public async Task<string> AESDecrypt(string cipherText, string Key, string IV)
        {
            string plaintext = string.Empty;
         
                var iv = Array.ConvertAll(IV.Split(" "), Byte.Parse);
                var key = Array.ConvertAll(Key.Split(" "), Byte.Parse);

                using (Aes myAes = Aes.Create())
                {
                    myAes.Key = key;
                    myAes.IV = iv;
                    ICryptoTransform decryptor = myAes.CreateDecryptor(key, iv);
                    using (MemoryStream msDecrypt = new MemoryStream(Array.ConvertAll(cipherText.Split(" "), Byte.Parse)))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {
                                plaintext = srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }

                return plaintext;
        }
    }
}

