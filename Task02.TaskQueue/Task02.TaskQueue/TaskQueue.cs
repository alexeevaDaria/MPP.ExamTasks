using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task02.TaskQueue
{
    public class TaskQueue : IDisposable
    {
        public delegate void TaskDelegate();
        private ConcurrentQueue<TaskDelegate> tasks; 

        private List<Thread> threads;
        private bool work = true;


        public TaskQueue(int threadCount)
        {
            threads = new List<Thread>();
            tasks = new ConcurrentQueue<TaskDelegate>();
            Thread thread;
            for(int i = 0; i < threadCount; i++)
            {
                thread = new Thread(new ThreadStart(Run));
                threads.Add(thread);
            }
            for(int i = 0; i < threadCount; i++)
            {
                threads[i].Start();
            }
        }

        public void EnqueueTask(TaskDelegate taskDelegate)
        {
            tasks.Enqueue(taskDelegate);
        }


        private void Run()
        {
            while (work)
            {
                try
                {
                    GetTask()();
                }
                catch(Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }       
        }

        private TaskDelegate GetTask()
        {
            TaskDelegate taskDelegate;
            while (!tasks.TryDequeue(out taskDelegate))
                Thread.Sleep(100);
            return taskDelegate;
        }

        public void Dispose()
        {
            foreach(Thread thread in threads)
            {
                thread.Interrupt();
            }
        }

        public void Wait()
        {
            foreach(Thread thread in threads)
            {
                thread.Join();
            }
        }
    }
}
