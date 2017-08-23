using Collections.Business;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Collections.QueueAndStack
{
    class Program
    {
        static void Main(string[] args)
        {
            User u;
            int i;
            User[] userArray = User.GetUserArray();

            Console.WriteLine("ORIGINAL LIST:");
            i = 0;
            foreach (var user in userArray)
            {
                Console.WriteLine(string.Format("| {0,2} | {1,20} | {2,6} | {3,2} |", i, user.Name, user.Gender, user.Age));
                i++;
            }
            Console.WriteLine();

            Console.WriteLine("STACK:");
            Stack<User> userS = new Stack<User>();
            foreach (var user in userArray)
            {
                // O(1)
                userS.Push(user);
            }
            Console.WriteLine("First one available in Stack:");

            // O(1)
            u = userS.Pop();
            Console.WriteLine(string.Format("| {0,20} | {1,6} | {2,2} |", u.Name, u.Gender, u.Age));

            Console.WriteLine("Next one in Stack:");

            // O(1)
            u = userS.Pop();
            Console.WriteLine(string.Format("| {0,20} | {1,6} | {2,2} |", u.Name, u.Gender, u.Age));

            Console.WriteLine();

            Console.WriteLine("QUEUE:");

            Queue<User> userQ = new Queue<User>();
            foreach(var user in userArray)
            {
                // O(1)
                userQ.Enqueue(user);
            }
            Console.WriteLine();

            Console.WriteLine("First in Line:");

            // O(1)
            u = userQ.Dequeue();
            Console.WriteLine(string.Format("| {0,20} | {1,6} | {2,2} |", u.Name, u.Gender, u.Age));

            Console.WriteLine("Next in Line:");

            // O(1)
            u = userQ.Dequeue();
            Console.WriteLine(string.Format("| {0,20} | {1,6} | {2,2} |", u.Name, u.Gender, u.Age));

            Console.WriteLine();

            // CAUTION: If you need to filter a Queue<T> or Stack<T>, consider using a List<T> or Array instead

            // O(N)
            User robert = userQ.Single(x => x.Name.StartsWith("Robert") );

            // O(N)
            User marco = userS.Single(x => x.Name.StartsWith("Marco"));

            Console.WriteLine("Users Filtered with LINQ:");
            Console.WriteLine(string.Format("| {0,20} | {1,6} | {2,2} |", robert.Name, robert.Gender, robert.Age));
            Console.WriteLine(string.Format("| {0,20} | {1,6} | {2,2} |", marco.Name, marco.Gender, marco.Age));

            Console.Read();
        }
    }
}