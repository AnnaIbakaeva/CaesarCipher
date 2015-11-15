using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApplication
{
    public static class Data
    {
        public static Dictionary<char, float> GetTableFrequencies()
        {
            var frequencies = new Dictionary<char, float>();

            frequencies.Add('а', 0.062f);
            frequencies.Add('б', 0.014f);
            frequencies.Add('в', 0.038f);
            frequencies.Add('г', 0.013f);

            frequencies.Add('д', 0.025f);
            frequencies.Add('е', 0.072f);
            frequencies.Add('ё', 0.072f);
            frequencies.Add('ж', 0.007f);

            frequencies.Add('з', 0.016f);
            frequencies.Add('и', 0.062f);
            frequencies.Add('й', 0.010f);
            frequencies.Add('к', 0.028f);

            frequencies.Add('л', 0.035f);
            frequencies.Add('м', 0.026f);
            frequencies.Add('н', 0.053f);
            frequencies.Add('о', 0.090f);

            frequencies.Add('п', 0.023f);
            frequencies.Add('р', 0.040f);
            frequencies.Add('с', 0.045f);
            frequencies.Add('т', 0.053f);

            frequencies.Add('у', 0.021f);
            frequencies.Add('ф', 0.002f);
            frequencies.Add('х', 0.009f);
            frequencies.Add('ц', 0.003f);

            frequencies.Add('ч', 0.012f);
            frequencies.Add('ш', 0.006f);
            frequencies.Add('щ', 0.003f);
            frequencies.Add('ъ', 0.014f);

            frequencies.Add('ы', 0.016f);
            frequencies.Add('ь', 0.014f);
            frequencies.Add('э', 0.003f);
            frequencies.Add('ю', 0.006f);
            frequencies.Add('я', 0.018f);

            return frequencies;
        }
        public static Dictionary<AlphabetType, Alphabet> GetAlphabets()
        {
            var alphabets = new Dictionary<AlphabetType, Alphabet>();
            alphabets.Add(AlphabetType.Russian, new Alphabet()
            {
                Letters = new List<char>()
            {
                'а', 'б', 'в', 'г', 'д', 'е', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х',
                'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я'
            } });
            alphabets.Add(AlphabetType.English, new Alphabet()
            {
                Letters = new List<char>()
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w',
                'x', 'y', 'z'
            }
            });
            return alphabets;
        }
    }
}
