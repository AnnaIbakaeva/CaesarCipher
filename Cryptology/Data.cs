using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptology
{
    public static class Data
    {
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
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w',
                'x', 'y', 'z'
            }
            });
            return alphabets;
        }
    }
}
