using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КМП_алгоритм.Properties
{
    public class Generate
    {
        static Random random = new Random();
        // генерировать строки используя рандомные символы из алфавита
        static string GenerateString(int length)
        {
            var alphabet = "qwertyuiop[]asdfghjkl;'zxcvbnm,.1234567890йцукенгшщзхъфывапролдячсмить";
            StringBuilder sb = new StringBuilder();
            int position = 0;
            for (int i = 0; i < length; i++)
            {
                position = random.Next(0, alphabet.Length - 1);
                sb.Append(alphabet[position]);
            }

            return sb.ToString();
        }
        // 50 строк длины от 100 до 9900
       public static void GenerateText()
        {
            var strings = new StringBuilder();
            for (int i = 100; i <= 9900; i += 200)
            {
                strings.Append(GenerateString(i) + "\n");
            }
            strings.Remove(strings.Length - 1, 1);
            File.WriteAllText("Text.TXT", strings.ToString());
        }

       public static void GeneratePattern()
        {
            var strings = new StringBuilder();
            for (int i = 100; i <= 10000; i += 100)
            {
                strings.Append(GenerateString(random.Next(1, i)) + "\n");
            }
            strings.Remove(strings.Length - 1, 1);
            File.WriteAllText("Patterns.TXT", strings.ToString());
        }
    }
}
