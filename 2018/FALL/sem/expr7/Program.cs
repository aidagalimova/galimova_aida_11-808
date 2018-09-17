/* Expr7.Найти вектор, параллельный прямой.Перпендикулярный прямой.Прямая задана коэффициентами уравнения прямой.*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace expr77
{
    class Program
    {
        static void Main(string[] args)
        {
            // y=kx+b уравнение прямой
            // n- вектор перпендикулярной прямой
            // p- вектор параллельной прямой
            double k, b, z;
            k = double.Parse(Console.ReadLine());
            b = double.Parse(Console.ReadLine());
            z = -1 / k;
            Console.WriteLine("p = (1;{0})", k);
            Console.WriteLine("n = (1;{0})", z);
            Console.ReadLine();
        }
    }
}

