using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace FormApplication
{
    public interface ICypher
    {
        string Encrypt(string text);
        string Decrypt(string text);
        string BreakOpen(string text);
    }
}
