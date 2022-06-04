using System;
using System.Collections.Generic;
using System.Linq;
namespace _06_Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<User> Users = UserFactory.GenerateUsers(20);
            int amount = Users.Count;
            var names = Users.Select(x => x.Name).ToList();
            //PrintList(Users);
            //PrintList(names);
            var sortedByName = Users.OrderBy(x => x.Name);
            var roles = Users.Select(x => x.Role).Distinct().ToList();
            //PrintList(roles);
            var groupedByRoles = Users.GroupBy(x => x.Role).ToList();
            var withMarks = Users.Where(x => x.Role == Role.STUDENT).Where(x => x.Marks != null && x.Marks.Length > 0).Count();
            var sum = Users.Where(s => s.Role == Role.STUDENT).Sum(x => x.Marks.Sum());
            // 7 ???
             
            //var lol = Users.Select(x => x.Marks).Sum(); ??
            //var s = Users.Where(x => x.Role == Role.STUDENT).SelectMany(y => y);
            //Console.WriteLine(s);
            var bestMark = Users.Where(x => x.Role == Role.STUDENT).Select(x => x.Marks?.Max()).Max();
            Console.WriteLine(bestMark);
            var WorstMark = Users.Where(x => x.Role == Role.STUDENT).Select(x => x.Marks?.Min()).Min();
            Console.WriteLine(WorstMark);
            // 10 wymaganie nie jasne, co to znaczy najlepszy student?
            var studentsWithLeastMarks = Users.Where(x => x.Role == Role.STUDENT).OrderBy(u => u.Marks.Length).Take(1);
            var studentsWithMostMarks = Users.Where(x => x.Role == Role.STUDENT).OrderByDescending(u => u.Marks.Length).Take(1);
            var nameNAverage = Users.Where(x => x.Role == Role.STUDENT).Select(u => new { u.Name, average = u.Marks.Average() });
            // definicja nalepszego studenta
            var averageOfAll = Users.Average(u => u.Marks?.Average());
            var groupedByMonths = Users.GroupBy(x => x.CreatedAt.ToString("yyyy-MM")).ToList();
            PrintList<IGrouping<string, User>>(groupedByMonths);
            var notDeleted = Users.Select(x => x.RemovedAt == null);
            var newest = Users.Where(x => x.Role == Role.STUDENT).OrderBy(d => d.CreatedAt).Take(1);





        }

        static void PrintList<T>(List<T> list)
        {
            foreach (T elem in list)
            {
                Console.WriteLine();


                Console.WriteLine(elem);
            }
            Console.WriteLine("======");

        }

    }


}
