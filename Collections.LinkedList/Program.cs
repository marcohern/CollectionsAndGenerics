using Collections.Business;
using System;
using System.Collections.Generic;

namespace Collections.LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            User[] userArray = User.GetUserArray();

            // O(1)
            User slavoyZizek = userArray[3];

            LinkedList<User> users = new LinkedList<User>();
            foreach (var user in userArray)
            {
                // O(1)
                users.AddFirst(user);
            }

            User newUser = new User { Name = "Dawn Joe", Age = 32, Gender = Gender.Female };

            // O(N)
            LinkedListNode<User> userFound = users.Find(slavoyZizek);

            // O(1)
            users.AddBefore(userFound, newUser);

            Console.WriteLine("USER LIST:");
            foreach (var user in users)
            {
                Console.WriteLine(string.Format("| {0,20} | {1,6} | {2,2} |", user.Name, user.Gender, user.Age));
            }
            Console.WriteLine();
            Console.WriteLine("LOOPING USING NEXT:");
            for (var node=users.First; node != null; node = node.Next)
            {
                Console.WriteLine(string.Format("| {0,20} | {1,6} | {2,2} |", node.Value.Name, node.Value.Gender, node.Value.Age));
            }
            Console.Read();
        }
    }
}