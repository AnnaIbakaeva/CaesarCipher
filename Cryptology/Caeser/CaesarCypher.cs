using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptology
{
    public class CaesarCypher : ICypher
    {
        public int M { get; set; }
        
        public Alphabet CurrentAlphabet { get; set; }

        private Alphabet shiftAlphabet;

        public CaesarCypher(int m)
        {
            M = m;
            ChangeShiftAlphabet();
        }

        public void ChangeShiftAlphabet()
        {
            shiftAlphabet = new Alphabet();
            for (var i = M; i < CurrentAlphabet.Letters.Count + M; i++)
            {
                shiftAlphabet.Letters.Add(CurrentAlphabet.Letters[i]);
            }
        }

        public string Encrypt(string text, AlphabetType alphabetType)
        {
            var encryptedText = "";
            foreach (var symbol in text)
            {
                var index = CurrentAlphabet.Letters.IndexOf(symbol);
                var shiftIndex = index + M;
                if (shiftIndex >= shiftAlphabet.Letters.Count)
                    shiftIndex -= shiftAlphabet.Letters.Count;
                encryptedText += shiftAlphabet.Letters[shiftIndex];
            }
            return encryptedText;
        }

        public string Decrypt(string text, AlphabetType alphabetType)
        {
            throw new NotImplementedException();
        }

        public string BreakOpen(string text, AlphabetType alphabetType)
        {
            throw new NotImplementedException();
        }
    }
}
