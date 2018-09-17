/* Галимова Аида 11-808
 * Expr2. Задается натуральное трехзначное число (гарантируется, что трехзначное).
 * Развернуть его, т.е. получить трехзначное число, записанное теми же цифрами в обратном порядке.*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace expr2
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 678;
            int y;
            int z;
            while (x > 0)
            {
                z = x;
                z %= 10;
                y = z;
                x /= 10;
                z = x;
                Console.Write(y);
            }
    }
}
