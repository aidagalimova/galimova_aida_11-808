// Галимова Аида 11-808
// Expr5.Найти количество високосных лет на отрезке[a, b] не используя циклы.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace expr5
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            int b;
            a = 1901;
            b = 2020;
            int c = 0;
            int z;
            if (((a % 100 == 0) & (a % 400 == 0)) | ((a % 100 != 0) & (a % 4 == 0)))
                c++;
            if (((b % 100 == 0) & (b % 400 == 0)) | ((b % 100 != 0) & (b % 4 == 0)))
                c++;
            z = (b - a) / 4;
            c += z;
            Console.WriteLine(c);
            Console.ReadLine();
        }
    }
}
