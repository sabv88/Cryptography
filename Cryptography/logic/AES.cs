using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;


namespace Cryptography.logic
{
    public static class AES
    {
        public static void AESEncrypt(string openText, out string cipherText, out string Key, out string IV)
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

            cipherText = stringBuilderEncoding.ToString().TrimEnd();
            Key = stringBuilderKey.ToString().TrimEnd();
            IV = stringBuilderIV.ToString().TrimEnd();
        }


        public static string AESDecrypt(string cipherText, string Key, string IV)
        {

            string plaintext;
         
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
            
           

            return string.Empty;
        }
    }
}

