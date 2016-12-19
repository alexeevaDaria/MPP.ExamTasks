using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Task10.ExportClassAttribute;

namespace ConsoleApp
{
    class Program
    {
        static bool ExportClassAttrFiler(TypeInfo typeInfo)
        {
            foreach(CustomAttributeData attr in typeInfo.CustomAttributes)
            {
                if (attr.AttributeType == typeof(ExportClass))
                    return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            string pathToAssembly = @"D:\study\exams_sem_5\mpp.exam.tasks\Task10.ExportClassAttribute\ConsoleApp\bin\Debug\ClassesWithAttr.dll"/*args[0]*/;
            Assembly assembly = Assembly.LoadFrom(pathToAssembly);
            List<TypeInfo> typeInfoList = assembly.DefinedTypes.Where<TypeInfo>(ExportClassAttrFiler).ToList<TypeInfo>();
            PrintTypeInfoList(typeInfoList);
            Console.Read();
        }

        static void PrintTypeInfoList(List<TypeInfo> list)
        {
            foreach(TypeInfo typeInfo in list)
            {
                Console.WriteLine(typeInfo);
            }
        }
    }
}
