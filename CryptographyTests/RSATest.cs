using Cryptography.logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Security.Policy;
using System.Windows.Markup;
using Cryptography.logic.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace CryptographyTests
{
    [TestClass]
    public class RSATest
    {
        [TestMethod]
        public void CheckEncryptAndDecryptRSA()
        {
            string openText = "test string";
            string encryptedData, decryptedData;
            var a  =  new Cryptography.logic.RSA().RSAEncrypt(openText, false).Result;
            string PublicKey = a.PublicKey;
            string PrivateKey = a.PrivateKey;
            string CipherText = a.cipherText;
            decryptedData = new Cryptography.logic.RSA().RSADecrypt(CipherText, PrivateKey, false).Result;
              
            Assert.AreEqual(openText, decryptedData);
        }

        [TestMethod]
        public void CheckSignatureRSATrue()
        {
            string openText = "test string"; 
            byte[] data = Encoding.ASCII.GetBytes(openText);
            using SHA256 alg = SHA256.Create();
            byte[] hash = alg.ComputeHash(data);
            RSAParameters sharedParameters;
            byte[] signedHash = Cryptography.logic.RSA.RSACreateSignature(openText, out sharedParameters);
            Assert.IsTrue(Cryptography.logic.RSA.RSAVerifySignature(hash, sharedParameters, signedHash));
        }

        [TestMethod]
        public void CheckSignatureRSAFalse()
        {
            string openText = "test string";
            RSAParameters sharedParameters;
            byte[] signedHash = Cryptography.logic.RSA.RSACreateSignature(openText, out sharedParameters);
            byte[] hash = Encoding.ASCII.GetBytes(openText+"ggg");
            Assert.IsFalse(Cryptography.logic.RSA.RSAVerifySignature(hash, sharedParameters, signedHash));
        }
    }
}
