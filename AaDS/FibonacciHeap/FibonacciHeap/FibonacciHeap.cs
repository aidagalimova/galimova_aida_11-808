using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciHeap
{
    public class FibonacciHeap<TPriority, TItem> where TPriority : IComparable<TPriority>
    {
       // деревья в куче
        public LinkedList<HeapNode<TPriority, TItem>> Trees { get; private set; }
        // минимальный узел
        public HeapNode<TPriority, TItem> Minimum { get { return minimumTreesNode.Value; } }
        // количество элементов в куче
        public int Count { get; private set; }

        private LinkedListNode<HeapNode<TPriority, TItem>> minimumTreesNode;
        // пустая куча
        public FibonacciHeap()
        {
            Trees = new LinkedList<HeapNode<TPriority, TItem>>();
            Count = 0;
            minimumTreesNode = null;
        }
        // извлечь минимум
        public HeapNode<TPriority,TItem> ExtractMin()
        {
            var min = Minimum;
            DeleteMin();
            return min;
        }
        // доваить элемент в кучу
        public HeapNode<TPriority, TItem> Insert(TPriority priority, TItem value)
        {
            // добавить дерево с данным элементов
            HeapNode<TPriority, TItem> node = new HeapNode<TPriority, TItem>(priority, value);
            Trees.AddFirst(node);
            //обновить минимум. 
            // Элемент минимум если он единственный в куче или его приритет меньше приоритета min
            if (Count == 0 ||                                      
                node.Priority.CompareTo(Minimum.Priority) < 0)     
                minimumTreesNode = Trees.First;
            Count++;
            return node;
        }
        
        public void DeleteMin()
        {
            // удалить минимум
            RemoveMinimum();
            // произвести уплотнение кучи
            ConsolidateTrees();
            // найти новый минимум
            FindMinimum();
        }
        // изменить приоритет
        public void DecreasePriority(HeapNode<TPriority, TItem> node, TPriority priority)
        {
            // если св-во кочи сохраняются
            if (node.Priority.CompareTo(priority) < 0)
                throw new ArgumentException();
            // изменить приоритет
            node.Priority = priority;
            // если node корневвой узел и его приоритет меньше приритета min - он минимум
            if (node.Parent == null &&
                priority.CompareTo(Minimum.Priority) < 0)
                minimumTreesNode = Trees.Find(node);      
            // если порядок кучи нарушен
            if (node.Parent != null &&
                node.Priority.CompareTo(node.Parent.Priority) < 0)
            {
                // поместить node в корневой список
                HeapNode<TPriority, TItem> parent = MoveToRoot(node);
                if (priority.CompareTo(Minimum.Priority) < 0)
                    minimumTreesNode = Trees.First;
                // отметить родителя если еще не отмечен
                if (!parent.Marked)
                    parent.Marked = true;
                // если уже отмечен то сделать вырезание и для родителей которые уже отмечены
                else 
                {
                    while (parent != null &&
                           parent.Marked)
                        parent = MoveToRoot(parent); 
                }
            }
        }
        // вырезание узла
        private HeapNode<TPriority, TItem> MoveToRoot(HeapNode<TPriority, TItem> node)
        {
            // запомнить родителя
            HeapNode<TPriority, TItem> parent = node.Parent;
            // удалить родителя, добавить в корневой список, снять пометку
            node.RemoveParent();
            Trees.AddFirst(node);
            node.Marked = false;
            return parent;
        }
        // удалить минимум
        private void RemoveMinimum()
        {
           // все дочерние узлы поместить в корневой список и удалить их родителя
            foreach (HeapNode<TPriority, TItem> child in minimumTreesNode.Value.Children)
            {
                child.Parent = null;
                Trees.AddFirst(child);
            }
            // удалить дерево с мин. элементом
            Trees.Remove(minimumTreesNode);
            Count--;
        }
        // найти новый минимум
        private void FindMinimum()
        {
            if (Count > 0)
            {
                minimumTreesNode = Trees.First;
                // рассмотреть кроневой элемент каждого дерева
                LinkedListNode<HeapNode<TPriority, TItem>> walker = Trees.First.Next;
                while (walker != null)
                {
                    // если приореитет текущего меньше приоритета min, обновить min
                    if (walker.Value.Priority.CompareTo(minimumTreesNode.Value.Priority) < 0)
                        minimumTreesNode = walker;
                    walker = walker.Next;
                }
            }
            else
                minimumTreesNode = null;
        }
        //объединить деревья одинакового размера
        private void ConsolidateTrees()
        {
            if (Count > 1)
            {
                // индекс корзины соответствует размеру элемента
                var rankBucket = new Bucket<LinkedListNode<HeapNode<TPriority, TItem>>>();
                // рассмотреть все корневые деревья
                var walker = Trees.First;
                while (walker != null)
                {
                    var next = walker.Next;
                    // размер текущего
                    int rank = walker.Value.Rank;
                    // объединить деревья с таким же размером
                    while (rankBucket[rank] != null)
                    {
                        walker = Consolidate(walker, rankBucket[rank]);     
                        rankBucket[rank] = null;                         
                        rank = walker.Value.Rank;                          
                    }
                    rankBucket[rank] = walker;
                    walker = next;
                }
            }
        }
        // объединить два дерева
        private LinkedListNode<HeapNode<TPriority, TItem>> Consolidate(LinkedListNode<HeapNode<TPriority, TItem>> node1,
                                                                       LinkedListNode<HeapNode<TPriority, TItem>> node2)
        {
            // получить узел с наименьшим приоритетом
            var root = node1;
            var child = node2;
            if (node2.Value.Priority.CompareTo(node1.Value.Priority) < 0)
            {
                root = node2;
                child = node1;
            }
            // сделать дерево с большим приоритетом потомком другой кучи
            Trees.Remove(child);
            root.Value.AddChild(child.Value);
            // вернуть объединенную кучу
            return root;
        }
    }
}