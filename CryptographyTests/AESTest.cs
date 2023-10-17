using Cryptography.logic;
using Cryptography.logic.Interfaces;
using System.Security.Cryptography.Xml;
using System.Text;

namespace CryptographyTests
{
    [TestClass]
    public class AESTest
    {
        [TestMethod]
        public void CheckEncryptAndDecryptAES()
        {
            string openText = "test string";
            var a =  new AES().AESEncrypt(openText);
            var b = new AES().AESDecrypt(a.Result.cipherText, a.Result.Key, a.Result.IV);
            Assert.AreEqual(openText, b.Result);
        }
    }
}