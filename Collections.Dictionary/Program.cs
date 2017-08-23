using Collections.Business;
using System;
using System.Collections.Generic;

namespace Collections.Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var userArray = User.GetUserArray();

            Dictionary<string, User> users = new Dictionary<string, User>();
            foreach(var user in userArray)
            {
                users[user.Name] = user;
                //users.Add(user.Name, user);
            }

            // O(1)
            users["Ken Oathcairn"].Age = 50;

            // O(1)
            users.Remove("Robert Foster");

            //Find
            
            foreach(var user in users)
            {
                Console.WriteLine(string.Format("{0,20} ==> | {1,20} | {2,6} | {3,2} |", user.Key, user.Value.Name, user.Value.Gender, user.Value.Age));
            }

            Console.Read();
        }
    }
}