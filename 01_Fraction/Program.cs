using System;
using System.Collections.Generic;

namespace Project
{
    internal class Program
    {
        static void Main()
        {
            Fraction a = new(12, 3);
            Fraction b = new(2, 4);
            Fraction c = new(8, 4);
            Fraction d = new(4, 5);
            Fraction e = a + c;
            Fraction f = new(-1, 2);
            Fraction g = new(2, 8);
            Fraction g2 = new(2, 8);
            Fraction k = g + g2;
            List<Fraction> list = new();
            list.Add(a);
            list.Add(b);
            list.Add(c);
            list.Add(d);
            list.Add(e);
            list.Add(f);
            list.Add(g);
            list.Add(g2);
            list.Add(k);
            Console.WriteLine(k == b);
            List<Fraction> list2 = new(list);
            list.Sort();
            for (int i = 0; i < list2.Count; ++i)
            {
                Console.WriteLine(list2[i].ToString() + " " + list[i].ToString());

            }
        }
    }
}
