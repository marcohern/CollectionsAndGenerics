using Collections.Business;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;

namespace Collections.SortedList
{
    class Program
    {
        static void Main(string[] args)
        {
            User[] userArray = User.GetUserArray();
            SortedList<string, User> users = new SortedList<string, User>();
            
            foreach(var user in userArray)
            {
                users[user.Name] = user;
            }

            foreach (var u in users)
            {
                Console.WriteLine(string.Format("| {0,20} | {1,6} | {2,2} |", u.Value.Name, u.Value.Gender, u.Value.Age));
            }

            Console.Read();
        }
    }
}