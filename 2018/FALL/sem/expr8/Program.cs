/*Expr8.Дана прямая L и точка A.
Найти точку пересечения прямой L с перпендикулярной ей прямой P, проходящей через точку A.
Можете считать, что прямая задана либо двумя точками, либо коэффициентами уравнения прямой*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expr7
{
    class Program
    {
        static void Main(string[] args)
        {
            // y=kx+b уравнение прямой L
            // -1/k+d уравнение перпендикулярной ей прямой
            // x1, y1 координаты т. А
            // x2, y2 координаты т. B
            double k, b, x1, y1, x2, y2;
            k = double.Parse(Console.ReadLine());
            b = double.Parse(Console.ReadLine());
            x1 = double.Parse(Console.ReadLine());
            y1 = double.Parse(Console.ReadLine());
            x2 = (k * y1 - k * b + x1) / (k * k + 1);
            y2 = (k * k + k * x1 + b) / (k * k + 1);
            Console.WriteLine(x2);
            Console.WriteLine("B = ({0}, {1})", x2, y2);
            Console.Read();
        }
    }
}