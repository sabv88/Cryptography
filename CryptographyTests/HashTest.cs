using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Cryptography.logic;


namespace CryptographyTests
{
    [TestClass]
    public class HashTest
    {
        //сайт с которым сверял хеши https://10015.io/tools/md5-encrypt-decrypt
        [TestMethod]
        [DataRow("test")]
        public void Sha1Test(string value)
        {
            Assert.AreEqual("a94a8fe5ccb19ba61c4c0873d391e987982fbbd3", Hash.SHA1(value));
        }

        [TestMethod]
        [DataRow("test")]
        public void Sha256Test(string value)
        {
            Assert.AreEqual("9f86d081884c7d659a2feaa0c55ad015a3bf4f1b2b0b822cd15d6c15b0f00a08", Hash.SHA256(value));
        }

        [TestMethod]
        [DataRow("test")]
        public void Sha384Test(string value)
        {
            Assert.AreEqual("768412320f7b0aa5812fce428dc4706b3cae50e02a64caa16a782249bfe8efc4b7ef1ccb126255d196047dfedf17a0a9", Hash.SHA384(value));
        }

        [TestMethod]
        [DataRow("test")]
        public void Sha512Test(string value)
        {
            Assert.AreEqual("ee26b0dd4af7e749aa1a8ee3c10ae9923f618980772e473f8819a5d4940e0db27ac185f8a0e1d5f84f88bc887fd67b143732c304cc5fa9ad8e6f57f50028a8ff", Hash.SHA512(value));
        }

        [TestMethod]
        [DataRow("test")]
        public void MD5Test(string value)
        {
            Assert.AreEqual("098f6bcd4621d373cade4e832627b4f6", Hash.MD5(value));
        }

        [TestMethod]
        [DataRow(@"D:\Cryptography\CryptographyTests\test.txt")]
        public void CheckFileIntegrityTestTrue(string value)
        {
            Assert.AreEqual(true, Hash.CheckFileIntegrity(value, System.Security.Cryptography.MD5.HashData(File.ReadAllBytes(value))));
        }

        [TestMethod]
        [DataRow(@"D:\Cryptography\CryptographyTests\test.txt")]
        public void CheckFileIntegrityTestFalse(string value)
        {
            var hash = File.ReadAllBytes(value);
            File.AppendAllText(value, "aaaaa");
            Assert.AreEqual(false, Hash.CheckFileIntegrity(value, hash));
        }
    }
}
