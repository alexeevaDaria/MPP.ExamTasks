using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MutexTest
{
    class Program
    {
        private static Task05.Mutex.Mutex mutex;
        private static int number = 0;

        static void Main(string[] args)
        {
            mutex = new Task05.Mutex.Mutex();

            Thread threadDec = new Thread(RunDec);
            Thread threadInc = new Thread(RunInc);
            threadDec.Start();
            threadInc.Start();
            threadDec.Join();
            threadInc.Join();
            Console.WriteLine(number);
            Console.Read();
        }

        static void RunDec()
        {
            for(int i = 0; i < 100000000; i++)
            {
                mutex.Lock();
                number -= 1;
                mutex.Unlock();
            }
        }

        static void RunInc()
        {
            for (int i = 0; i < 100000000; i++)
            {
                mutex.Lock();
                number += 1;
                mutex.Unlock();
            }
        }
    }
}
