using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Zadanie
{
    internal class Product: IThing
    {
        private string name;
        public string Name { get => name; }
        public Product(string name)
        {
            this.name = name;
        }
        internal virtual string Print(string prefix)
        {
            return $"{prefix} {name}";
        }
    }
}
