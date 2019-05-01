using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciHeap
{
    public class HeapNode<TPriority, TItem> where TPriority : IComparable<TPriority>
    {
        //родительский узел
        public HeapNode<TPriority, TItem> Parent { get; set; }
        // дочерние узлы
        public HashSet<HeapNode<TPriority, TItem>> Children { get; set; }
        // пометка показывает терял ли  элемент дочерний узел
        public bool Marked { get; set; }
        // количество дочерних узлов
        public int Rank { get { return Children.Count; } }
        public TPriority Priority { get; internal set; }
        public TItem Value { get; set; }
        // создать новый узел
        public HeapNode(TPriority priority, TItem value)
        {
            Children = new HashSet<HeapNode<TPriority, TItem>>();
            Parent = null;
            Priority = priority;
            Value = value;
        }
        // добавить узел как потомок данного узла
        public void AddChild(HeapNode<TPriority, TItem> node)
        {
            Children.Add(node);
            node.Parent = this;
        }
        // удалить дочерний узел
        public void RemoveChild(HeapNode<TPriority, TItem> child)
        {
            Children.Remove(child);
            child.Parent = null;
        }
        // удалить родительский узел
        public void RemoveParent()
        {
            Parent.Children.Remove(this);
            Parent = null;
        }
    }
}
