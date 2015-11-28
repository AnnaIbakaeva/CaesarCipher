
namespace Cryptology
{
    public interface ICypher
    {
        string Encrypt(string text);
        string Decrypt(string text);
        string BreakOpen(string text);
    }
}
