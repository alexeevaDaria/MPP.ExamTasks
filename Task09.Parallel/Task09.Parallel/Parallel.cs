using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task09.Parallel
{
    class Parallel
    {
        public static void WaitAll(Func<bool>[] funcs)
        {
            List<Task<bool>> tasks = new List<Task<bool>>();
            Task<bool> task;
            foreach(Func<bool> func in funcs)
            {
                task = new Task<bool>(func);
                tasks.Add(task);
                task.Start();
            }
            Task.WaitAll(tasks.ToArray());
        }
    }
}
