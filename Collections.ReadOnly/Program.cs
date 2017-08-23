using Collections.Business;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Collections.ReadOnly
{
    class Program
    {
        static void Main(string[] args)
        {
            User[] userArray = User.GetUserArray();

            List<User> users = userArray.ToList();

            ReadOnlyCollection<User> rusers = new ReadOnlyCollection<User>(users);

            Console.WriteLine("READ ONLY:");
            foreach (var u in rusers)
            {
                Console.WriteLine(string.Format("| {0,20} | {1,6} | {2,2} |", u.Name, u.Gender, u.Age));
            }
            Console.WriteLine();

            users.Add(new User { Name = "Uma Thurman", Gender = Gender.Female, Age = 39 });

            Console.WriteLine("READ ONLY AFTER INSERTING:");
            foreach (var u in rusers)
            {
                Console.WriteLine(string.Format("| {0,20} | {1,6} | {2,2} |", u.Name, u.Gender, u.Age));
            }
            Console.WriteLine();

            Console.Read();
        }
    }
}