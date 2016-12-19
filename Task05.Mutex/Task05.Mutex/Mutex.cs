using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task05.Mutex
{
    public class Mutex
    {
        private int locked = 0;

        public void Lock()
        {
            while (Interlocked.CompareExchange(ref locked, 1, 0) != 0)
            {
                Thread.Sleep(10);
            }
        }

        public void Unlock()
        {
            Interlocked.Exchange(ref locked, 0);
        }
    }
}
