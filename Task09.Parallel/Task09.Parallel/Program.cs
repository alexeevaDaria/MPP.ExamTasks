using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task09.Parallel
{
    class Program
    {
        static void Main(string[] args)
        {
            Parallel.WaitAll(new Func<bool>[] { Do, Do, Do, Do, Do, Do, Do, Do, Do, Do, Do, Do, Do, Do, Do });
            Console.WriteLine("End");
            Console.Read();
        }

        static bool Do()
        {
            Console.WriteLine("Do start");
            Thread.Sleep(1000);
            Console.WriteLine("Do end");
            return true;
        }
    }
}
