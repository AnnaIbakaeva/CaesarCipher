using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Cryptology
{
    public interface ICypher
    {
        string Encrypt(string text, AlphabetType alphabetType);
        string Decrypt(string text, AlphabetType alphabetType);
        string BreakOpen(string text, AlphabetType alphabetType);
    }
}
