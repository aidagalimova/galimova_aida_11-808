using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciHeap
{
    public class Bucket<TItem>
    {
        //получить или установить элемент по индексу
        public TItem this[int index]
        {
            get
            {
                if (!bucket.ContainsKey(index))
                    bucket.Add(index, default(TItem));
                return bucket[index];
            }

            set
            {
                if (!bucket.ContainsKey(index))
                    bucket.Add(index, value);
                else
                    bucket[index] = value;
            }
        }

        private Dictionary<int, TItem> bucket;
        // пустая корзина
        public Bucket()
        {
            bucket = new Dictionary<int, TItem>();
        }
    }
}
