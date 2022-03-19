using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Zadanie
{
    internal class Person : IThing
    {
        private string name;
        private int age;
        public string Name { get => name; }
        internal int Age { get => age; }

        internal Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        internal virtual string Print(string prefix)
        {
            return $"{prefix} {name} ({age} y.o.)";
        }
    }
}
