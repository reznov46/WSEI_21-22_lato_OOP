using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Project
{
    class Classroom
    {
        private string name;
        private Person[] persons;
        public string Name { get => name; }
        public Classroom(string name, Person[] persons)
        {
            this.name = name;
            this.persons = persons;
        }

        public override string ToString()
        {
            string s = $"Classroom: {name} \n ";
                foreach (Person p in persons)
                {
                    s += $"{p}";
                }
            return s;
        }
    }
}
