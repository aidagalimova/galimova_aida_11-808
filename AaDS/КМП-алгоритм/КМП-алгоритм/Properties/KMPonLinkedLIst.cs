using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КМП_алгоритм.Properties
{
    class KMPonLinkedLIst
    {
        public static int iteration = 0;
        public static int[] GetPrefixFunсtionList(LinkedList<char> pattern)
        {
            var prefixFunction = new int[pattern.Count];
            prefixFunction[0] = 0;
            var j = 0;
            var i = 1;
            while (i < pattern.Count)
            {
                iteration++;
                if (pattern.ElementAt(i) == pattern.ElementAt(j))
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

        public static int KMPsearchList(LinkedList<char> text, LinkedList<char> pattern)
        {
            var i = 0;
            var j = 0;
            int[] prefixFunction = GetPrefixFunсtionList(pattern);
            while (i < text.Count) 
            {
                iteration++;
                if (text.ElementAt(i) == pattern.ElementAt(j))
                {
                    i++;
                    j++;
                    if (j == pattern.Count) return j;
                }
                else
                {
                    if (j == 0)
                    {
                        i++;
                        if (i == text.Count) return -1;
                    }
                    else j = prefixFunction[j - 1];
                }
            }
            return -1;
        }
    }
}
