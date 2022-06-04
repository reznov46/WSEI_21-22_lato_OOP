using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Linq
{
    internal class User
    {
        internal string Name { get; set; }
        internal Role Role { get; set; }
        internal int Age { get; set; }
        internal int[] Marks { get; set; } // zawsze null gdy ADMIN, MODERATOR lub TEACHER
        internal DateTime CreatedAt { get; set; }
        internal DateTime? RemovedAt { get; set; }

        internal User(string Name, Role Role, int Age, int[] Marks = null)
        {
            this.Name = Name;
            this.Role = Role;
            this.Age = Age;
            this.Marks = this.Role == Role.STUDENT ? Marks : null;
            this.CreatedAt = new DateTime();
            this.RemovedAt = null;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (Marks != null)
                foreach (int mark in Marks)
                    sb.Append($"{mark} ");
            return $"{Name} {Role} {Age} | {sb.ToString()} |";
        }
    }
}
