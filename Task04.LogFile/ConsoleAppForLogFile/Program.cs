using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task04.LogFile;

namespace ConsoleAppForLogFile
{
    class Program
    {
        static void Main(string[] args)
        {
            LogFile log = new LogFile("log.txt");
            for(int i = 0; i < 10; i++)
            {
                log.Write(string.Format("Current number is {0}", i));
            }
            Console.WriteLine("Всё записано. Ентер чтобы закрыть логгер");
            Console.Read();
            log.Dispose();
        }
    }
}
