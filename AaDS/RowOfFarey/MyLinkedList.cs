using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ряд_Фарея.Properties
{
    class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }

    }
    class MyLinkedList<T> : IEnumerable<T>
    {
        public Node<T> head { get; private set; }
        Node<T> tail;
        int count;
        public void Add(T el)
        {

            if (head == null)
            {
                head = new Node<T> { Value = el, Next = null };
                tail = head;
            }
            else
            {
                Node<T> node = new Node<T> { Value = el, Next = null };
                tail.Next = node;
                tail = node;
                count++;
            }
        }
        public void AddAfter(Node<T> node, T value)
        {
            Node<T> t = new Node<T> { Value = value, Next = node.Next };
            node.Next = t;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = head;
            while(current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
