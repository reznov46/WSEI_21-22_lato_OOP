﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Project
{
    class Task: IEquatable<Task>
    {
        private string name;
        private TaskStatus status;
        public string Name { get => name; }
        public TaskStatus Status { get => status; }
        public Task(string name, TaskStatus status)
        {
            this.name = name;
            this.status = status;
        }
        public override string ToString()
        {
            return $"{name} [{status}]";
        }

        public bool Equals(Task other)
        {
            if (other == null)
                return false;
            if (other.Name.Equals(name) && other.Status.Equals(status))
                return true;
            return false;
        }
    }
}
