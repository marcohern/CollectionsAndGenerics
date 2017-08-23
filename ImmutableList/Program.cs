using Collections.Business;
using System;
using System.Linq;
using System.Collections.Immutable;
namespace Collections
{
    namespace ImmutableList
    {
        class Program
        {
            static ImmutableList<User> users;

            static void Main(string[] args)
            {
                var userArray = User.GetUserArray();

                users = userArray.ToImmutableList();

                //Add is available but does not work
                users.Add(new User { Name = "John Key", Gender = Gender.Male, Age = 45 });

                foreach (var user in users)
                {
                    Console.WriteLine(string.Format("| {0,20} | {1,6} | {2,2} |", user.Name, user.Gender, user.Age));
                }

                Console.Read();
            }
        }
    }
}