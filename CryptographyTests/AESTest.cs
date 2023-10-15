using Cryptography.logic;
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
            string cipherText;
            string Key;
            string IV;
            AES.AESEncrypt(openText, out cipherText, out Key, out IV);
            Assert.AreEqual(openText, AES.AESDecrypt(cipherText, Key, IV));
        }
    }
}