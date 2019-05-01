using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FibonacciHeap
{
    public class Dijkstra
    {

        public static Dictionary<Node, double> shortestPaths(DirectedGraph<Node> graph, Node source)
        {
            // фибоначчиевая куча которая будет хранить расстояния до узлов
            var pq = new FibonacciHeap<double, Node>();
            // словарь для соответствия узла в куче и узла в графе
            var entries = new Dictionary<Node, HeapNode<double, Node>>();
            //  узел и итоговое расстояние до него
            var result = new Dictionary<Node, double>();

            // добавить все узлы в фибоначчиеву кучу
            foreach (var node in graph)
                entries.Add(node, pq.Insert(double.PositiveInfinity, node));
            pq.DecreasePriority(entries[source], 0.0);
            // пока куча не пуста
            while (pq.Count != 0)
            {
                // извлечь минимум
                var curr = pq.ExtractMin();
                // доавить в список результатов
                result.Add(curr.Value, curr.Priority);
                // рассмотреть все исходящие ребра для минимума 
                foreach (var arc in graph.edgesFrom(curr.Value))
                {
                    // если уже записано в результат продолжить
                    if (result.ContainsKey(arc.Key)) continue;
                    // инче прибавить пройденый путь к пути от curr до acr
                    double pathCost = curr.Priority + arc.Value;
                    // обновить самый короткий если текущий меньше
                    var dest = entries[arc.Key];
                    if (pathCost < dest.Priority)
                        pq.DecreasePriority(dest, pathCost);
                }
            }
            return result;
        }

        public static void Main(string[] args)
        {
        }
    }
}
