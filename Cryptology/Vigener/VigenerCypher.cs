using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptology;

namespace Cryptology.Vigener
{
    public class VigenerCypher : ICypher
    {
        public string KeyWord { get; set; }

        private Alphabet _alphabet;
        public VigenerCypher(string keyWord)
        {
            KeyWord = keyWord;
            _alphabet = Data.GetAlphabets()[AlphabetType.Russian];
        }
        public string Encrypt(string text)
        {
            var textFromKeyWord = CreateTextFromKeyWord(text.Length);
            var encryptedText = "";
            for (int i = 0; i < text.Length; i++)
            {
                encryptedText += GetEncryptedChar(textFromKeyWord[i], text[i]);

                if (encryptedText.Length > 4 && encryptedText.Length % 6 == 0)
                    encryptedText += " ";
            }
            return encryptedText;
        }

        private char GetEncryptedChar(char key, char srcSymb)
        {
            var row = _alphabet.Letters.IndexOf(key);
            var column = _alphabet.Letters.IndexOf(srcSymb);
            return Data.vigenerTable[row][column];
        }

        private string CreateTextFromKeyWord(int count)
        {
            var result = "";
            for (int i = 0; i < count; i++)
            {
                var j = i;
                while (j >= KeyWord.Length)
                    j -= KeyWord.Length;
                result += KeyWord[j];
            }
            return result;
        }

        public string Decrypt(string text)
        {
            var textFromKeyWord = CreateTextFromKeyWord(text.Length);
            var decryptedText = "";
            for (int i = 0; i < text.Length; i++)
            {
                decryptedText += GetSourceSymbol(textFromKeyWord[i], text[i]);
                if (decryptedText.Length > 4 && decryptedText.Length % 6 == 0)
                    decryptedText += " ";
            }
            return decryptedText;
        }

        private char GetSourceSymbol(char key, char encrSymb)
        {
            var row = _alphabet.Letters.IndexOf(key);
            var index = Data.vigenerTable[row].IndexOf(encrSymb);
            return _alphabet.Letters[index];
        }

        public string BreakOpen(string text)
        {
            return null;
        }
    }
}
