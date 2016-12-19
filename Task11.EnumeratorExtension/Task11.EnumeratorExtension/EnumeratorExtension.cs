using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11.EnumeratorExtension
{
    static class EnumeratorExtension
    {
        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            List<T> result = new List<T>();
            foreach(T t in source)
            {
                if (predicate(t))
                {
                    result.Add(t);
                }
            }
            return result.AsEnumerable();
        }
    }
}
