using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FibonacciHeap
{
    public class DirectedGraph<T> : IEnumerable<T>
    {
        private Dictionary<T, Dictionary<T, double>> mGraph = new Dictionary<T, Dictionary<T, Double>>();
        // доавить вершины
        public bool addNode(T node)
        {
            if (mGraph.ContainsKey(node))
                return false;
            mGraph.Add(node, new Dictionary<T, double>());
            return true;
        }
        // добавить грань от исходящий от start входящий в dest, с весом length
        public void addEdge(T start, T dest, double length)
        {
            if (!mGraph.ContainsKey(start) || !mGraph.ContainsKey(dest))
                throw new NotImplementedException();
            mGraph[start].Add(dest, length);
        }
        // удалить грань
        public void removeEdge(T start, T dest)
        {
            if (!mGraph.ContainsKey(start) || !mGraph.ContainsKey(dest))
                throw new NotImplementedException();

            mGraph[start].Remove(dest);
        }
        // исходящие ребра
        public Dictionary<T, double> edgesFrom(T node)
        {
            Dictionary<T, Double> arcs = mGraph[node];
            if (arcs == null)
                throw new NotImplementedException("Source node does not exist.");
            return arcs;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return mGraph.Keys.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class Node
    {
        public readonly int NodeNumber;

        public Node(int number)
        {
            NodeNumber = number;
        }
    }
}