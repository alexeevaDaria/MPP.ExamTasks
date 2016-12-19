using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task02.TaskQueue;

namespace ConsoleAppForTaskQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskQueue taskQueue = new TaskQueue(5);
            for(int i = 0; i < 20; i++)
            {
                taskQueue.EnqueueTask(Taskmethod);
            }
            taskQueue.Wait();

        }

        static void Taskmethod()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        }
    }
}
