using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Zadanie
{
    internal class Fruit : Product
    {
        private int count;
        internal int Count { get => count; }
        internal Fruit(string name, int count): base(name)
        {
            this.count = count;
        }
        internal override string Print(string prefix)
        {
            return $"{base.Print(prefix)} ({count} fruits)";
        }
    }
}
