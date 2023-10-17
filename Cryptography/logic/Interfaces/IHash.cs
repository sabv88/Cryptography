using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.logic.Interfaces
{
    public interface IHash
    {
        public Task<string> SHA1(string data);
        public Task<string> SHA256(string data);
        public Task<string> SHA384(string data);
        public Task<string> SHA512(string data);
        public Task<string> MD5(string data);

    }
}
