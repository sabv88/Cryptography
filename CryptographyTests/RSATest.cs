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
    }
}
