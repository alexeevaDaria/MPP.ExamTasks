using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace task01.parallelFileCopier
{
    class CopyInfo
    {
        public string DirectoryName { get; set; }
        public string Filename { get; set; }
        public string SourceFilename { get; set; }
        public string SourceDirectoryName { get; set; }

        public string Destination
        {
            get
            {
                return Path.Combine(DirectoryName, Filename);
            }
        }
        public string Source
        {
            get
            {
                return Path.Combine(SourceDirectoryName, SourceFilename);
            }
        }
    }

    class Program
    {
        private static int copiedFilesCount = 0;
        private static string destinationDirectory;
        private static string sourceDirectory;
        private static ConcurrentBag<Task<bool>> tasks = new ConcurrentBag<Task<bool>>(); 

        static void Main(string[] args)
        {
            sourceDirectory = @"D:\study\exams_sem_5\mpp.exam.tasks\task01.parallelFileCopier\task01.parallelFileCopier\task01.parallelFileCopier\bin\Debug\sourceDir"/*args[0]*/;
            destinationDirectory = @"D:\study\exams_sem_5\mpp.exam.tasks\task01.parallelFileCopier\task01.parallelFileCopier\task01.parallelFileCopier\bin\Debug\destDir"/*args[1]*/;
            CopyInfo copyInfo = new CopyInfo()
            {
                DirectoryName = destinationDirectory,
                Filename = string.Empty,
                SourceFilename = string.Empty,
                SourceDirectoryName = sourceDirectory
            };

            if (Directory.Exists(copyInfo.Source)){
                CreateDestinationDirectory(copyInfo.DirectoryName);
                RunTask(Copy, copyInfo);
            }
            Thread.Sleep(5000);
            Console.WriteLine("Copied files: " + copiedFilesCount);
        }

        private static void CreateDestinationDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private static bool IsDirectory(string path)
        { 
            return Directory.Exists(path);
        }

        private static bool Copy(object state)
        {
            CopyInfo copyInfo = state as CopyInfo;
            if (IsDirectory(copyInfo.Destination))
            {
                RunTask(CopyDirectory, copyInfo);
            }
            else
            {
                RunTask(CopyFile, copyInfo);
            }
            return true;
        }

        private static bool CopyDirectory(object state)
        {
            CopyInfo copyInfo = state as CopyInfo;
            CreateDestinationDirectory(copyInfo.Destination);
            foreach(string dir in Directory.GetDirectories(copyInfo.Source))
            {
                string d = dir.Replace(copyInfo.SourceDirectoryName, string.Empty);
                d = d.Substring(1);
                CopyInfo newCopyInfo = new CopyInfo()
                {
                    DirectoryName = copyInfo.Destination,
                    Filename = d,
                    SourceFilename = string.Empty,
                    SourceDirectoryName = dir
                };
                RunTask(CopyDirectory, newCopyInfo);
            }
            foreach(string file in Directory.GetFiles(copyInfo.Source))
            {
                string f = file.Replace(copyInfo.SourceDirectoryName, string.Empty);
                f = f.Substring(1);
                CopyInfo newCopyInfo = new CopyInfo()
                {
                    DirectoryName = copyInfo.Destination,
                    Filename = f,
                    SourceFilename = f,
                    SourceDirectoryName = copyInfo.SourceDirectoryName
                };
                newCopyInfo.SourceFilename = newCopyInfo.Filename;
                RunTask(Copy, newCopyInfo);
            }
            return true;
        }

        private static bool CopyFile(object state)
        {
            CopyInfo copyInfo = state as CopyInfo;
            File.Copy(copyInfo.Source, copyInfo.Destination);
            Interlocked.Increment(ref copiedFilesCount);
            return true;
        }

        private static void RunTask(Func<object, bool> func, object param)
        { 
            Task<bool> task = new Task<bool>(func, param);
            task.Start();
            tasks.Add(task);
        }
    }
}
