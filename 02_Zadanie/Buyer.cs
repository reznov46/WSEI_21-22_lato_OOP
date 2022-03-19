using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Zadanie
{
    internal class Buyer : Person
    {
        protected List<Product> tasks;
        internal Buyer(string name, int age) : base(name, age)
        {
            tasks = new List<Product>();
        }
        internal void AddProduct(Product product)
            => tasks.Add(product);
        internal void RemoveProduct(int index)
            => tasks.RemoveAt(index);
        internal override string Print(string prefix)
        {
            return $"{prefix} Buyer: {base.Print("")}";
        }
    }
}
