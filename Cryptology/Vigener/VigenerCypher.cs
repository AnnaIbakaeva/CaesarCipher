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

        private CaesarCypher _caesarCypher;
        public VigenerCypher(string keyWord)
        {
            KeyWord = keyWord;
            _alphabet = Data.GetAlphabets()[AlphabetType.Russian];
            _caesarCypher = new CaesarCypher(0);
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
            int keyWordLength = FindKeyWordLength(text);
            var breakText = new char[text.Length];
            
            for (int j = 0; j < keyWordLength; j++)
            {
                var sameShiftString = "";
                for (int i = j; i < text.Length; i += keyWordLength)
                {
                    sameShiftString += text[i];
                }
                var breakOpenStr = _caesarCypher.BreakOpen(sameShiftString);
                int k = 0;
                for (int i = j; i < text.Length; i += keyWordLength)
                {
                    breakText[i] = breakOpenStr[k];
                    k++;
                }
            }

            string keyWord = "";
            var resultString = new String(breakText);
            for (int i = 0; i < keyWordLength; i++)
            {
                keyWord += GetKeyChar(resultString.ElementAt(i), text.ElementAt(i));
            }
           
            resultString += " \n Ключевое слово: " + keyWord;
            return resultString;
        }

        private char GetKeyChar(char columnSymb, char value)
        {
            int columnNumber = 0;
            for (int i = 0; i < Data.vigenerTable[0].Count; i++)
            {
                if (Data.vigenerTable[0][i] == columnSymb)
                {
                    columnNumber = i;
                    break;
                }
            }

            foreach (var row in Data.vigenerTable)
            {
                if (row[columnNumber] == value)
                    return Data.GetAlphabets()[AlphabetType.Russian].Letters[Data.vigenerTable.IndexOf(row)];
            }
            return ' ';
        }

        private int FindKeyWordLength(string text)
        {
            var text2 = text;
            
            List<int> distances = new List<int>();
            for (int i = 0; i < text.Length-2; i++)
            {                
                for (int j = i+1; j < text2.Length - 2; j++)
                {
                    if (text[i] == text2[j] && text[i + 1] == text2[j + 1] && text[i + 2] == text2[j + 2])
                    {
                        distances.Add(j - i);
                    }
                }
            }
            return FindNOD(distances);
        }

        private double FindD(List<int> shiftDistances)
        {
            var notNullDistances = shiftDistances.FindAll((dist) => dist != 0);
            return notNullDistances.Max() - notNullDistances.Average();
        }

        private int FindMaxCountDistances(List<int> shiftDistances)
        {
            var max = shiftDistances.Max();
            int d;
            if (max > 2)
                d = 1;
            else
                d = 0;
            List<int> savedM = new List<int>();
            var dict = new List<int>();
            dict.Add(0);
            for (int i = 0; i < shiftDistances.Count; i++)
            {
                if (i > 0)
                {
                    if (i < shiftDistances.Count - 1)
                    {
                        if (shiftDistances[i] - shiftDistances[i - 1] > d  &&
                            shiftDistances[i + 1] == shiftDistances[i])
                        {
                            int k = i + 2;
                            while (shiftDistances[k] == shiftDistances[i])
                                k++;

                            if (shiftDistances[i] - shiftDistances[k] > d )
                                dict.Add(i+1);
                        }

                        else if (shiftDistances[i] - shiftDistances[i - 1] > d &&
                            shiftDistances[i] - shiftDistances[i + 1] > d)
                            dict.Add(i + 1);
                    }
                    else
                    {
                        if (shiftDistances[i] - shiftDistances[i - 1] > d)
                            dict.Add(i + 1);
                    }
                }
                else
                {
                    if (shiftDistances[i] - shiftDistances[i + 1] > d)
                        dict.Add(i + 1);
                }
            }
            var deltaLocalMaxList = new List<int>();
            for (int i = 1; i < dict.Count; i++)
            {
                int delta = dict[i] - dict[i - 1];
                if (delta > 3)
                    deltaLocalMaxList.Add(delta);
            }
            deltaLocalMaxList.Sort();


            var deltaCountDict = new Dictionary<int, int>();
            foreach (var delta in deltaLocalMaxList)
            {
                if (!deltaCountDict.ContainsKey(delta))
                    deltaCountDict.Add(delta, 1);
                else
                    deltaCountDict[delta] += 1;
            }

            var maxCount = 0;
            int maxDelta = 0;
            foreach (var delta in deltaCountDict.Keys)
            {
                if (deltaCountDict[delta] > maxCount)
                {
                    maxCount = deltaCountDict[delta];
                    maxDelta = delta;
                }
            }
            return maxDelta;
        }

        private int FindNOD(IEnumerable<int> numbers)
        {
            List<int> dividers = new List<int>();
            for (int i = 0; i < numbers.Count(); i++)
            {
                for (int j = i + 1; j < numbers.Count(); j++)
                {
                    int divider = numbers.ElementAt(j);
                    int dividend = numbers.ElementAt(i);
                    while (true)
                    {
                        int residue = dividend % divider;
                        if (residue == 0)
                        {
                            if (divider > 3)
                                dividers.Add(divider);
                            break;
                        }
                        else
                        {
                            dividend = divider;
                            divider = residue;
                        }
                    }
                }
            }

            dividers.Sort();

            var dividerCountDict = new Dictionary<int, int>();
            foreach (var divider in dividers)
            {
                if (!dividerCountDict.ContainsKey(divider))
                    dividerCountDict.Add(divider, 1);
                else
                    dividerCountDict[divider] += 1;
            }

            var maxCount = 0;
            int maxDivider = 0;
            foreach (var divider in dividerCountDict.Keys)
            {
                if (dividerCountDict[divider] > maxCount)
                {
                    maxCount = dividerCountDict[divider];
                    maxDivider = divider;
                }
            }
            return maxDivider;
            
            //int maxDivider = 0;
            //foreach (int divider in dividers)
            //{
            //    var isDiv = true;
            //    foreach (int number in numbers)
            //    {
            //        if (number % divider != 0)
            //        {
            //            isDiv = false;
            //            break;
            //        }
            //    }
            //    if (isDiv && divider > maxDivider)
            //        maxDivider = divider;
            //}

            //return maxDivider;
        }
    }
}
