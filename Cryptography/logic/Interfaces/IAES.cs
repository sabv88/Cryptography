using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.logic.Interfaces
{
    public interface IAES
    {
        public Task<(string cipherText, string Key, string IV)> AESEncrypt(string openText);
        public Task<string> AESDecrypt(string cipherText, string Key, string IV);
    }
}
