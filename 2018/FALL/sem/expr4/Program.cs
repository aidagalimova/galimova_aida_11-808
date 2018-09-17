// Найти количество чисел меньших N, которые имеют простые делители X или Y.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace expr44
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 30;
            int x = 3;
            int y = 7;
            int c = 0;
            for (int i =0; i<N; i++)
            if (i % x == 0 || i % y == 0)
                c++;
            Console.WriteLine(c);
            Console.Read();
        }
    }
}
