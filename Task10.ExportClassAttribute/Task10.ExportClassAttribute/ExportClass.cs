using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10.ExportClassAttribute
{
    public class ExportClass: Attribute
    {
        public string SomeText { get; set; }

        public ExportClass() { }

        public ExportClass(string someText)
        {
            SomeText = someText;
        }
    }
}
