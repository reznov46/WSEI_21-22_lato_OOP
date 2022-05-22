using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Files
{
    internal class Class1
    {
        readonly string[] Columns = { "[count]", "[total size]", "[avg size]", "[min size]", "[max size]" };
        internal Dictionary<string, Dictionary<string, FileInfo>> rows;
        internal Class1(Dictionary<string, Dictionary<string, FileInfo>> dicts)
        {
            rows = dicts;
        }
    }
}
