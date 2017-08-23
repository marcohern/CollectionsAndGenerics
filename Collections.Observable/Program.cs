using Collections.Business;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Collections.Observable
{
    class Program
    {
        static void Main(string[] args)
        {
            var userArray = User.GetUserArray();
            ObservableCollection<User> users = new ObservableCollection<User>();

            foreach (var user in userArray)
            {
                users.Add(user);
            }
            users.CollectionChanged += Users_CollectionChanged;
            

            Console.WriteLine("ORIGINAL LIST:");
            foreach (var user in users)
            {
                Console.WriteLine(string.Format("| {0,20} | {1,6} | {2,2} |", user.Name, user.Gender, user.Age));
            }
            Console.WriteLine();

            Console.WriteLine("Adding new user Steam Boy");
            users.Add(new User { Name = "Steam Boy", Gender = Gender.Male, Age = 11 });

            Console.WriteLine("Removing existing user Ken Oathcairn");
            User kenOathkairn = users.Single(x => x.Name == "Ken Oathcairn");
            users.Remove(kenOathkairn);


            Console.WriteLine("Inserting Hewy Duck");
            users.Insert(2, new User { Name = "Hewy Duck", Gender = Gender.Male, Age = 12 });

            Console.WriteLine("Updating Hewy Duck to Dewey Duck");
            users[2] = new User { Name = "Dewey Duck", Gender = Gender.Male, Age = 13 };

            Console.WriteLine("Updating Dewey Duck's name to Louie Duck (Nothing happens)");
            users[2].Name = "Louie Duck";

            //Move
            Console.WriteLine("Moving object in Index 0 to Index 3.");
            users.Move(0, 3);

            Console.WriteLine("FINAL LIST:");
            foreach (var user in users)
            {
                Console.WriteLine(string.Format("| {0,20} | {1,6} | {2,2} |", user.Name, user.Gender, user.Age));
            }

            Console.WriteLine();
            Console.WriteLine("Clearing");
            users.Clear();

            Console.Read();
        }

        private static void Users_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch(e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Console.WriteLine("----Add");
                    foreach (User u in e.NewItems)
                    {
                        Console.WriteLine("----Index: " + e.NewStartingIndex);
                        Console.WriteLine(string.Format("----| {0,20} | {1,6} | {2,2} |", u.Name, u.Gender, u.Age));
                    }
                    break;
                case NotifyCollectionChangedAction.Move:
                    Console.WriteLine("----Move");
                    Console.WriteLine("----From: " + e.OldStartingIndex);
                    Console.WriteLine("------To: " + e.NewStartingIndex);
                    foreach (User u in e.NewItems)
                    {
                        Console.WriteLine(string.Format("----| {0,20} | {1,6} | {2,2} |", u.Name, u.Gender, u.Age));
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine("----Remove");
                    Console.WriteLine("----Index: " + e.OldStartingIndex);
                    foreach (User u in e.OldItems)
                    {
                        Console.WriteLine(string.Format("----| {0,20} | {1,6} | {2,2} |", u.Name, u.Gender, u.Age));
                    }
                    break;
                case NotifyCollectionChangedAction.Replace:
                    Console.WriteLine("----Replace");
                    Console.WriteLine("----Index: " + e.OldStartingIndex);
                    foreach (User u in e.OldItems)
                    {
                        Console.WriteLine(string.Format("----from:| {0,20} | {1,6} | {2,2} |", u.Name, u.Gender, u.Age));
                    }
                    foreach (User u in e.NewItems)
                    {
                        Console.WriteLine(string.Format("----to  :| {0,20} | {1,6} | {2,2} |", u.Name, u.Gender, u.Age));
                    }
                    break;
                case NotifyCollectionChangedAction.Reset:
                    Console.WriteLine("----Reset");
                    break;
                default:
                    Console.WriteLine("----What the???");
                    break;
            }
        }
    }
}