using Cryptography.logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.logic
{
    public class RSA : IRSA
    {
        public async Task<(string cipherText, string PublicKey, string PrivateKey)> RSAEncrypt(string openText, bool DoOAEPPadding)
        {
            string publicKey, privateKey;
            byte[] toEncryptData = Encoding.Unicode.GetBytes(openText);
            List<byte> encrypted = new List<byte>();
            using (RSACryptoServiceProvider RSA = new(1024))
            {
                publicKey = RSA.ToXmlString(false);
                privateKey = RSA.ToXmlString(true);

                int encryptedDataIndex = 0;
                for (int i = 117, j = 0; encryptedDataIndex < toEncryptData.Length - 128; i += 117)
                {
                    encrypted.AddRange(RSA.Encrypt(toEncryptData[j..i], DoOAEPPadding));
                    encryptedDataIndex += 128;
                    j = i;
                }
                encrypted.AddRange(RSA.Encrypt(toEncryptData[encryptedDataIndex..], DoOAEPPadding));
            }

            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in encrypted)
            {
                stringBuilder.Append(b).Append(" ");
            }

            return ( stringBuilder.ToString().TrimEnd(), publicKey, privateKey);
        }

        public async Task<string> RSADecrypt(string DataToDecrypt, string privateKey, bool DoOAEPPadding)
        {

            byte[] bytes = Array.ConvertAll(DataToDecrypt.Split(" "), Byte.Parse);
            List<byte> decrypted = new List<byte>();

            using (RSACryptoServiceProvider RSA = new(1024))
            {
                RSA.FromXmlString(privateKey);
                int decryptedDataIndex = 0;

                for (int i = 128, j = 0; i < bytes.Length; i += 128)
                {
                    decrypted.AddRange(RSA.Decrypt(bytes[j..i], DoOAEPPadding));
                    j = i;
                    decryptedDataIndex += 117;
                }
                decrypted.AddRange(RSA.Decrypt(bytes[decryptedDataIndex..], DoOAEPPadding));
            }

            return Encoding.Unicode.GetString(decrypted.ToArray());

        }

        // TODO: RSACreateSignature
        public static byte[] RSACreateSignature(string DataToDecrypt, out RSAParameters sharedParameters)
        {
            using SHA256 alg = SHA256.Create();

            byte[] data = Encoding.ASCII.GetBytes(DataToDecrypt);
            byte[] hash = alg.ComputeHash(data);

            byte[] signedHash;

            using (System.Security.Cryptography.RSA rsa = System.Security.Cryptography.RSA.Create())
            {
                sharedParameters = rsa.ExportParameters(false);

                RSAPKCS1SignatureFormatter rsaFormatter = new(rsa);
                rsaFormatter.SetHashAlgorithm(nameof(SHA256));

                signedHash = rsaFormatter.CreateSignature(hash);
            }

            return signedHash;
        }

        public static bool RSAVerifySignature(byte[] hash, RSAParameters sharedParameters, byte[] signedHash)
        {
            using (System.Security.Cryptography.RSA rsa = System.Security.Cryptography.RSA.Create())
            {
                rsa.ImportParameters(sharedParameters);

                RSAPKCS1SignatureDeformatter rsaDeformatter = new(rsa);
                rsaDeformatter.SetHashAlgorithm(nameof(SHA256));

                return rsaDeformatter.VerifySignature(hash, signedHash);
            }
        }
    }
}
