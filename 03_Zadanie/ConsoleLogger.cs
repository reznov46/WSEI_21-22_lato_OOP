using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Zadanie
{
    internal class ConsoleLogger : WritterLogger
    {
        public ConsoleLogger()
        {
            writer = Console.Out;
        }
        public override void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
