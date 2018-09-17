using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace expr1
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 5;
            int y = 1;
            int z;
            z = x;
            x = y;
            y = z;
            Console.WriteLine(x);
            Console.WriteLine(y);
        }
    }
}
