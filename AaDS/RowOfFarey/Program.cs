using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Ряд_Фарея.Properties;

namespace Ряд_Фарея
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static MyLinkedList<Fraction> GetRowOfFarey(int n)
        {
            var rowOfFarey = new MyLinkedList<Fraction>();
            rowOfFarey.Add(new Fraction(0, 1));
            rowOfFarey.Add(new Fraction(1, 1));
            int c = 1;
            while (c < n)
            {
                Node<Fraction> currentNode = rowOfFarey.head;
                while (currentNode.Next != null)
                {
                    if (currentNode.Value.denominator + currentNode.Next.Value.denominator < c + 2)
                    {
                        rowOfFarey.AddAfter(currentNode, currentNode.Value + currentNode.Next.Value);
                    }
                    currentNode = currentNode.Next;
                }
                c++;
            }
            return rowOfFarey;
        }
    }
}