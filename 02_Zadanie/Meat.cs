using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Zadanie
{
    internal class Meat : Product
    {
        private double weight;
        internal double Weight { get => weight; }
        internal Meat(string name, double weight): base(name)
        {
            this.weight = weight;
        }
        internal override string Print(string prefix)
        {
            return $"{base.Print(prefix)} ({weight} kg)";
        }
    }
}
