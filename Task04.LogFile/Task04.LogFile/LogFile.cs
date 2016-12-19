using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task04.LogFile
{
    public class LogFile: IDisposable
    {
        private StreamWriter streamWriter;

        public LogFile(string pathToFile)
        {
            streamWriter = new StreamWriter(pathToFile, true);
        }

        public void Dispose()
        {
            streamWriter.Close();
        }

        public void Write(string str)
        {
            String resultString = string.Format("{0} {1} {2}", DateTime.Now, Thread.CurrentThread.ManagedThreadId, str);
            streamWriter.WriteLine(resultString);
        }
    }
}
