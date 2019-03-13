using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КМП_алгоритм.Properties
{
    class KMPonArray
    {
        public static int iteration = 0;
        public static int[] GetPrefixFunсtion(string pattern)
        {
            var prefixFunction = new int[pattern.Length];
            prefixFunction[0] = 0;
            var j = 0;
            var i = 1;
            while (i < pattern.Length)
            {
                iteration++;
                if (pattern[i] == pattern[j])
                {
                    prefixFunction[i] = j + 1;
                    j++;
                    i++;
                }
                else
                {
                    if (j == 0)
                    {
                        prefixFunction[i] = 0;
                        i++;
                    }
                    if (j != 0) j = prefixFunction[j - 1];
                }
            }
            return prefixFunction;
        }

        public static int KMPsearch(string text, string pattern)
        {
            var i = 0;
            var j = 0;
            int[] prefixFunction = GetPrefixFunсtion(pattern);
            while(i<text.Length)
            {
                iteration++;
                if(text[i] == pattern[j])
                {
                    i++;
                    j++;
                    if(j == pattern.Length) return j;
                }
                else
                {
                    if(j==0)
                    {
                        i++;
                        if(i==text.Length) return -1;
                    }
                    else j = prefixFunction[j - 1];
                }
            }
            return -1;
        }
    }
}
