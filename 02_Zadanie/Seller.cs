using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Zadanie
{
    internal class Seller : Person
    {
        internal Seller(string name, int age) : base(name, age)
        {

        }
        internal override string Print(string prefix = "\t")
        {
            return $"{prefix} Seller: {base.Print("")}";
        }
    }
}
