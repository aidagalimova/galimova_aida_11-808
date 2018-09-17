// Галимова Аида 11-808
// Посчитать расстояние от точки до прямой, заданной двумя разными точками.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            /* (x1; y1), (x2; y2) координаты точек прямой. (x0; y0) координаты точки.
            p-расстояние между точками прямой. 
            s2-  удвоенная площадь треугольника с вершинами (x0,y0), (x1,y1), (x2, y2) */
            double x1, x2, x0, y1, y2, y0, p, s2;
            x1 = double.Parse(Console.ReadLine());
            y1 = double.Parse(Console.ReadLine());
            x2 = double.Parse(Console.ReadLine());
            y2 = double.Parse(Console.ReadLine());
            x0 = double.Parse(Console.ReadLine());
            y0 = double.Parse(Console.ReadLine());
            p = Math.Abs((y2 - y1) * x0 - (x2 - x1) * y0 + x2 * y1 - y2 * x1);
            s2 = Math.Sqrt((y2 - y1) * (y2 - y1) + (x2 - x1) * (x2 - x1));
            Console.WriteLine(p/s2);
            Console.Read();
        }
    }
}
