using System;
using System.Collections.Generic;
using System.Text;

namespace Collections.Business
{
    public class User : 
        //Sorting Interface
        IComparable<User>, IComparable
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public int CompareTo(object obj)
        {
            return this.CompareTo((User)obj);
        }

        public int CompareTo(User other)
        {
            int c = Name.CompareTo(other.Name);
            if (c==0)
            {
                c = Age.CompareTo(other.Age);
                if (c==0)
                {
                    c = Gender.CompareTo(other.Gender);
                }
            }
            return c;
        }

        public static User[] GetUserArray()
        {
            return new User[] {
                new User{ Name="Marco Hernandez", Age=37, Gender=Gender.Male },
                new User{ Name="Ken Oathcairn", Age=42, Gender=Gender.Male },
                new User{ Name="Christine La'Guard", Age=55, Gender=Gender.Female },
                new User{ Name="Slavoy Zizek", Age=62, Gender=Gender.Male },
                new User{ Name="Robert Foster", Age=32, Gender=Gender.Male },
            };
        }
    }
}
