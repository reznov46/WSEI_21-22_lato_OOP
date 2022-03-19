using System;

namespace _02_Project
{
    class Person: IEquatable<Person>
    {
        protected string name;
        protected int age;
        public string Name { get => name; }
        public int Age { get => age; }

        public Person(string _name, int _age)
        {
            name = _name;
            age = _age;
        }

        public override string ToString()
        {
            return $"{name} {age}";
        }

        public bool Equals(Person other)
        {
            if (other == null)
                return false;
            if (other == this)
                return true;
            if (other.Name.Equals(name) && other.Age.Equals(age))
                return true;
            return false;

        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Person);
        }
    }
}
