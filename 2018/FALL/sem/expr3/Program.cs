/*Expr3. Задано время Н часов (ровно). 
 *Вычислить угол в градусах между часовой и минутной стрелками. 
 *Например, 5 часов -> 150 градусов, 20 часов -> 120 градусов. Не использовать циклы.*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expr3
{
    class Program
    {
        static void Main(string[] args)
        {
            int h = 17;
            int c;
            h %= 12;
            c = h * 30;
            Console.Write(c);
        }
    }
}
