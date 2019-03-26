using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linqKR
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static IEnumerable<int> Get(IEnumerable<int> a)
        {
            int i = 0;
            return a
                .Select(x => { i++; return x * i; })
                .Where(x => { return x > 9 && x < 100; })
                .Reverse();
        }
    }

    public static class EnumerableExtensions
    {
        public static  IEnumerable<TItem> Add<TItem>(this IEnumerable<TItem> c, TItem a, TItem b)
        {
            
        }

        public IEnumerable<TItem> e<TItem>(int a)
        {
           
        }
    }
}
