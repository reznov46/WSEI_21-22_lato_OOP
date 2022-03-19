using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project;
using System.Collections.Generic;

namespace _01_FractionTest
{
    [TestClass]
    public class FractionTest
    {
        [TestMethod]
        public void AddingTwoFractions()
        {
            Fraction expected = new(1,2);
            Fraction tryFraction = new(-1, 2);
            Assert.AreEqual(expected, -tryFraction);
        }
        [TestMethod]
        public void FractionMinusToString()
        {
            string expected = "1/2";
            Fraction tryFraction = new(-1, 2);
            Fraction newFraction = -tryFraction;
            string reversed = newFraction.ToString();
            Assert.AreEqual(expected, reversed);
        }
        [TestMethod]
        public void TestOverloadOfPlus()
        {
            // test for one overload, not for everyone
            Fraction expected = new(3, 4);
            Fraction tryFraction = new(1, 4);
            Fraction tryFraction2 = new(2, 4);
            Fraction addition = tryFraction + tryFraction2;
            Assert.AreEqual(expected, addition);
        }

        [TestMethod]
        public void TestSimplificationMultiplication()
        {
            Fraction expected = new(1, 2);
            Fraction a = new(2, 16);
            Fraction b = new(4, 1);
            Fraction multiplied = a * b;
            Assert.AreEqual(expected, multiplied);
            Assert.IsTrue(expected != b);
        }
        [TestMethod]
        public void Sort()
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
            list.Sort();
            List<Fraction> list2 = new();
            list2.Add(f);
            list2.Add(g);
            list2.Add(g2);
            list2.Add(b);
            list2.Add(k);
            list2.Add(d);
            list2.Add(c);
            list2.Add(a);
            list2.Add(e);
            Assert.AreEqual(list.ToString(), list2.ToString());
        }
    }
}
