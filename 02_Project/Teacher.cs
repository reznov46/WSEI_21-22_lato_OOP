namespace _02_Project
{
    class Teacher : Person
    {
        public Teacher(string _name, int _age) : base(_name, _age)
        { }
        public override string ToString()
        {
            return $"Teacher: {base.name} ({base.age} y.o.)";
        }
    }
}
