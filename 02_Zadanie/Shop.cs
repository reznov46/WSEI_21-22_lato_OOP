using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Zadanie
{
    internal class Shop : IThing
    {
        private string name;
        private Person[] people;
        private Product[] products;
        public string Name { get { return name; } }
        internal Shop(string name, Person[] people, Product[] products)
        {
            this.name = name;
            this.people = people;
            this.products = products;
        }
        internal void Print()
        {
            string s = $"Shop: {name}\n";
            s += "-- People: --\n";
            foreach(Person p in people)
                s += $"{p.Print("\t")}\n";
            s += "-- Products: --\n";
            foreach (Product p in products)
                s += $"{p.Print("\t\t")}\n";
            Console.Write(s);
        }
    }
}
