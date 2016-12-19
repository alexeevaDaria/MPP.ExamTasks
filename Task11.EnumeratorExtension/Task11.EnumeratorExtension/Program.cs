using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11.EnumeratorExtension
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 3, 4, 5, 6, 2, 7, 10, 50, 50, 38, 58 };
            PrintList<int>(list);
            IEnumerable<int> result = list.Where(x => x < 10);
            PrintList<int>(result);
            Console.Read();
        }

        static void PrintList<T>(IEnumerable<T> list)
        {
            foreach(T t in list)
            {
                Console.Write(t + " ");
            }
            Console.WriteLine();
        }
    }
}
