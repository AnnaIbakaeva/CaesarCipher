using System;
using System.Collections.Generic;
using System.Globalization;
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

        public CaesarCypher(int m, AlphabetType alphabetType)
        {
            CurrentAlphabet = Data.GetAlphabets()[alphabetType];
            if (m < 0)
                m += CurrentAlphabet.Letters.Count;
            var d = m / CurrentAlphabet.Letters.Count;
            m -= CurrentAlphabet.Letters.Count * d;
            M = m;
            ChangeAlphabets(alphabetType);
        }

        public void ChangeAlphabets(AlphabetType alphabetType)
        {
            CurrentAlphabet = Data.GetAlphabets()[alphabetType];
            shiftAlphabet = new Alphabet();
            for (var i = M; i < CurrentAlphabet.Letters.Count + M; i++)
            {
                var j = i;
                if (j >= CurrentAlphabet.Letters.Count)
                    j -= CurrentAlphabet.Letters.Count;
                shiftAlphabet.Letters.Add(CurrentAlphabet.Letters[j]);
            }
        }

        public string Encrypt(string text, AlphabetType alphabetType)
        {
            ChangeAlphabets(alphabetType);
            var encryptedText = "";
            var symbolsCounter = 0;
            foreach (var symbol in text)
            {
                var index = CurrentAlphabet.Letters.IndexOf(symbol);
                var shiftIndex = index + M;
                if (shiftIndex >= shiftAlphabet.Letters.Count)
                    shiftIndex -= shiftAlphabet.Letters.Count;
                if (symbolsCounter == 5)
                {
                    encryptedText += " ";
                    symbolsCounter = 0;
                }
                encryptedText += shiftAlphabet.Letters[shiftIndex];
                symbolsCounter++;
            }
            return encryptedText;
        }

        public string Decrypt(string text, AlphabetType alphabetType)
        {
            ChangeAlphabets(alphabetType);
            var decodedText = "";
            var symbolsCounter = 0;
            foreach (var symbol in text)
            {
                var index = shiftAlphabet.Letters.IndexOf(symbol);
                var unshiftIndex = index - M;
                if (unshiftIndex < 0)
                    unshiftIndex += shiftAlphabet.Letters.Count;
                if (symbolsCounter == 5)
                {
                    decodedText += " ";
                    symbolsCounter = 0;
                }
                decodedText += CurrentAlphabet.Letters[unshiftIndex];
                symbolsCounter++;
            }
            return decodedText;
        }

        public string BreakOpen(string text, AlphabetType alphabetType)
        {
            throw new NotImplementedException();
        }
    }
}
