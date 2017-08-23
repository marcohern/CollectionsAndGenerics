using Collections.Business;
using System;
using System.Collections.Generic;

namespace Collections.List
{
    class Program
    {
        static void Main(string[] args)
        {
            User[] userArray = User.GetUserArray();

            List<User> usersDefCap = new List<User>();
            Console.WriteLine(string.Format("Default Capacity BEF:{0}", usersDefCap.Capacity));
            usersDefCap.Add(userArray[0]);
            Console.WriteLine(string.Format("Default Capacity AFT:{0}", usersDefCap.Capacity));

            List<User> users = new List<User>(3);
            Console.WriteLine(string.Format("Capacity Before:{0}", users.Capacity));
            // all these are O(1)
            users.Add(userArray[0]);
            Console.WriteLine(string.Format("Added! Capacity:{0}, Count: {1}", users.Capacity, users.Count));
            users.Add(userArray[1]);
            Console.WriteLine(string.Format("Added! Capacity:{0}, Count: {1}", users.Capacity, users.Count));
            users.Add(userArray[2]);
            Console.WriteLine(string.Format("Added! Capacity:{0}, Count: {1}", users.Capacity, users.Count));

            //This one is O(N)
            users.Add(userArray[3]);
            Console.WriteLine(string.Format("Added! Capacity:{0}, Count: {1}", users.Capacity, users.Count));

            //Back to O(1)
            users.Add(userArray[4]);
            Console.WriteLine(string.Format("Added! Capacity:{0}, Count: {1}", users.Capacity, users.Count));

            users.Add(null);
            Console.WriteLine(string.Format("Added! Capacity:{0}, Count: {1}", users.Capacity, users.Count));

            Console.WriteLine("USER LIST:");

            // Insert O(N)
            users.Insert(1, new User { Name = "Jim Raynor", Gender = Gender.Male, Age = 39 });

            // Remove O(N)
            var ken = users[2];
            users.Remove(ken);
            //users.RemoveAt(2);
                
            //Update O(1)
            //users[4] = new User { Name = "Pixies", Age = 44, Gender = Gender.Female };
            foreach (var user in users)
            {
                if (user==null)
                {
                    Console.WriteLine(string.Format("| {0,20} | {1,6} | {2,2} |", "NULL", Gender.None, 0));
                } else
                {
                    Console.WriteLine(string.Format("| {0,20} | {1,6} | {2,2} |", user.Name, user.Gender, user.Age));
                }
                
            }
            Console.Read();
        }
    }
}