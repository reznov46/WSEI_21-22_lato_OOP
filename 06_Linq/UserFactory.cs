using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Linq
{
    internal class UserFactory
    {
        internal static List<User> GenerateUsers(int count)
        {
            List<User> users = new List<User>();
            for (int i = 0; i < count; i++)
            {
                int[] Marks = null;
                Role role = RandomRole();
                if (role == Role.STUDENT)
                {
                    Marks = RandomMarks();
                }
                users.Add(new User(RandomName(), role, RandomAge(), Marks));
            }
            return users;
        }

        private static string RandomName()
        {
            Random random = new Random();
            string[] names = new string[] { "Liam", "Olivia", "Noah", "Emma", "Oliver", "Charlotte", "Elijah", "Amelia", "James", "Ava", "William", "Sophia", "Benjamin", "Isabella", "Lucas", "Mia", "Henry", "Evelyn", "Theodore", "Harper" };
            return names[random.Next(19)];
        }

        private static Role RandomRole()
        {
            Random random = new Random();
            Type type = typeof(Role);
            Array values = type.GetEnumValues();
            return (Role)values.GetValue(random.Next(values.Length));
        }

        private static int RandomAge()
        {
            Random random = new Random();

            return random.Next(1, 69);
        }
        private static int[] RandomMarks()
        {
            Random random = new Random();
            int amount = random.Next(10);
            int[] marks = new int[amount];
            for (int i = 0; i < amount; i++)
            {
                marks[i] = random.Next(1, 6);
            }
            return marks;
        }
    }
}
