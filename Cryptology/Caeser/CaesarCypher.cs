using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApplication
{
    public class CaesarCypher : ICypher
    {
        public int M { get; set; }

        private List<Alphabet> _alphabets;

        public CaesarCypher(int m)
        {
            _alphabets = new List<Alphabet>(Data.GetAlphabets().Values);
            M = m;
        }

        public string Encrypt(string text)
        {
            var encryptedText = "";
            foreach (var symbol in text)
            {
                foreach (var alphabet in _alphabets)
                {
                    var index = alphabet.Letters.IndexOf(symbol);
                    if (index != -1)
                    {
                        if (encryptedText.Length > 4 && encryptedText.Length % 6 == 0)
                        {
                            encryptedText += " ";
                        }
                        var shiftIndex = index + M;
                        while (shiftIndex >= alphabet.Letters.Count)
                            shiftIndex -= alphabet.Letters.Count;
                        while (shiftIndex < 0)
                            shiftIndex += alphabet.Letters.Count;
                        encryptedText += alphabet.Letters[shiftIndex];
                        break;
                    }
                }
            }
            return encryptedText;
        }

        public string Decrypt(string text)
        {
            var decodedText = "";
            foreach (var symbol in text)
            {
                foreach (var alphabet in _alphabets)
                {
                    var index = alphabet.Letters.IndexOf(symbol);
                    if (index != -1)
                    {
                        if (decodedText.Length > 4 && decodedText.Length % 6 == 0)
                        {
                            decodedText += " ";
                        }
                        var shiftIndex = index - M;
                        while (shiftIndex >= alphabet.Letters.Count)
                            shiftIndex -= alphabet.Letters.Count;
                        while (shiftIndex < 0)
                            shiftIndex += alphabet.Letters.Count;
                        decodedText += alphabet.Letters[shiftIndex];
                        break;
                    }
                }
            }
            return decodedText;
        }

        private Dictionary<char, float> EvaluateActualFrequency(string text)
        {
            var frequencies = new Dictionary<char, float>();
            var symbolsCounter = new Dictionary<char, int>();

            foreach (var symbol in text)
            {
                if (!symbolsCounter.ContainsKey(symbol))
                    symbolsCounter.Add(symbol, 0);
                symbolsCounter[symbol] += 1;
            }

            foreach (var key in symbolsCounter.Keys)
            {
                var symbFrequency = symbolsCounter[key] / symbolsCounter.Count;
                frequencies.Add(key, symbFrequency);
            }

            return frequencies;
        }

        public string BreakOpen(string text)
        {
            var savedM = M;
            text = text.Replace(" ", "");
            var tableFrequincies = Data.GetTableFrequencies();

            var minSumSquares = double.MaxValue;
            var resultText = "";
            var minM = 0;
            for (int i = 0; i < 32; i++)
            {
                M = i;
                var decryptedText = Decrypt(text).Replace(" ", "");
                var actualFrequencies = EvaluateActualFrequency(decryptedText);

                double sumSquares = 0;
                foreach (var key in actualFrequencies.Keys)
                {
                    if (!tableFrequincies.ContainsKey(key))
                        throw new Exception(String.Format("Отсутствует табличная частота для символа '{0}'", key));
                    else
                    {
                        sumSquares += Math.Pow((actualFrequencies[key] - tableFrequincies[key]), 2);
                    }
                }
                if (sumSquares < minSumSquares)
                {
                    minSumSquares = sumSquares;
                    resultText = "";
                    for (int j = 0; j < decryptedText.Length; j++)
                    {
                        resultText += decryptedText[j];
                        if (resultText.Length > 4 && resultText.Length % 6 == 0)
                        {
                            resultText += " ";
                        }
                    }
                    minM = M;
                }
            }
            resultText += " \n m = " + minM;
            M = savedM;

            return resultText;
        }
    }
}
