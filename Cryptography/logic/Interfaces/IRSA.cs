using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.logic.Interfaces
{
    public interface IRSA
    {
        public Task<(string cipherText, string PublicKey, string PrivateKey)> RSAEncrypt(string openText, bool DoOAEPPadding);

        public Task<string> RSADecrypt(string DataToDecrypt, string privateKey, bool DoOAEPPadding);
    }
}
