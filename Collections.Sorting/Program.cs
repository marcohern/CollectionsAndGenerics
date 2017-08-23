using Collections.Business;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Collections.Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            User[] userArray = User.GetUserArray();

            List<User> users = new List<User>();
            foreach (var user in userArray)
            {
                users.Add(user);
            }
            
            Console.WriteLine("BEFORE SORTING:");
            foreach(var user in users)
            {
                Console.WriteLine(string.Format("| {0,20} | {1,6} | {2,2} |", user.Name, user.Gender, user.Age));
            }
            Console.WriteLine();

            // Traditional Sort O(NlogN)
            users.Sort();

            Console.WriteLine("AFTER SORTING:");
            foreach (var user in users)
            {
                Console.WriteLine(string.Format("| {0,20} | {1,6} | {2,2} |", user.Name, user.Gender, user.Age));
            }
            Console.WriteLine();

            // LINQ O(NlogN)
            users = users.OrderBy(x => x.Age).ToList();

            Console.WriteLine("AFTER AGE SORTING:");
            foreach (var user in users)
            {
                Console.WriteLine(string.Format("| {0,20} | {1,6} | {2,2} |", user.Name, user.Gender, user.Age));
            }

            Console.Read();
        }
    }
}