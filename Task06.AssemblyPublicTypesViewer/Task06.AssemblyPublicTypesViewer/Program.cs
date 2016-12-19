using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Task06.AssemblyPublicTypesViewer
{
    class TypeComparator : IComparer<TypeInfo>
    {
        public int Compare(TypeInfo x, TypeInfo y)
        {
            int result =  string.Compare(x.Namespace, y.Namespace);
            if (result != 0)
                return result;
            result = string.Compare(x.Name, y.Name);
            return result;
        }
    }

    class Program
    {

        static bool FilterMethod(TypeInfo typeInfo)
        {
            return typeInfo.IsPublic;
        }

        static void Main(string[] args)
        {
            string pathToAssembly = args[0];
            Console.WriteLine(pathToAssembly);
            Assembly assembly = Assembly.LoadFrom(pathToAssembly);
            List<TypeInfo> typeInfoList = assembly.DefinedTypes.Where(FilterMethod).ToList<TypeInfo>();
            typeInfoList.Sort(new TypeComparator());
            PrintTypeInfoList(typeInfoList);
            Console.Read();
        }

        static void PrintTypeInfoList(List<TypeInfo> typeInfoList)
        {
            foreach(TypeInfo typeInfo in typeInfoList)
            {
                Console.WriteLine(typeInfo);
            }
        }
    }
}
