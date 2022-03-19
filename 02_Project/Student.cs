using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Project
{
    internal class Student : Person, IEquatable<Student>
    {
        protected string group;
        protected List<Task> tasks;
        internal string Group { get => group; }
        internal List<Task> Tasks { get => tasks; }

        internal Student(string name, int age, string group) : base(name, age)
        { 
            this.group = group;
            this.tasks = new List<Task>();
        }
        internal Student(string name, int age, string group, List<Task> tasks) : base(name, age)
        {
            this.group = group;
            this.tasks = tasks;
        }
        internal void AddTask(string taskName, TaskStatus taskStatus)
        {
            tasks.Add(new Task(taskName, taskStatus));
        }
        internal void RemoveTask(int index) { }
        internal void UpdateTask(int index, TaskStatus taskStatus) { }
        internal string RenderTasks(string prefix = "\t")
        {
            string s = "";
            int i = 1; 
            foreach(Task t in tasks)
            {
                s += $"{prefix}{i}. {t}\n";
            }
            return s;
        }
        public override string ToString()
        {
            return $"Student: {name} ({age} y.o.) \n Group: {group} \n {RenderTasks()}\n";
        }

        internal bool Equals(Student other)
        {
            if (other == null)
                return false;
            if (base.Equals(other))
            {
                if (group.Equals(other.Group) && SequenceEqual<Task>(tasks, other.Tasks))
                    return true;
            }
            return false;
        }

        private static bool SequenceEqual<T>(List<T> a, List<T> b)
        {
            if (a == null && b == null)
                return false;
            return a.SequenceEqual(b);
        }

    }
}
