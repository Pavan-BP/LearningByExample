using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{

    /* 
    Reference - https://stackoverflow.com/questions/2019402/when-why-to-use-delegates

    Explanation 1 - A delegate can be seen as a placeholder for a/some method(s).
    By defining a delegate, you are saying to the user of your class, "Please feel free to assign, any method that matches this signature, 
    to the delegate and it will be called each time my delegate is called".
    Typical use is of course events. All the OnEventX delegate to the methods the user defines.
    Delegates are useful to offer to the user of your objects some ability to customize their behavior. Most of the time, you can use other ways to 
    achieve the same purpose and I do not believe you can ever be forced to create delegates. It is just the easiest way in some situations to get the thing done.

    Explanation 2 - A delegate is a reference to a method. Whereas objects can easily be sent as parameters into methods, constructor or whatever, 
    methods are a bit more tricky. But every once in a while you might feel the need to send a method as a parameter to another method, 
    and that's when you'll need delegates. 
    
    */


    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class Example1
    {
        private delegate bool FilerByDelegate(Person p);

        public static void Start(Notify notificationDelegate)
        {
            Person p1 = new Person() { Name = "John", Age = 41 };
            Person p2 = new Person() { Name = "Jane", Age = 69 };
            Person p3 = new Person() { Name = "Jake", Age = 12 };
            Person p4 = new Person() { Name = "Jessie", Age = 25 };
            List<Person> people = new List<Person>() { p1, p2, p3, p4 };

            DisplayPeople("Children", people, IsChild);
            DisplayPeople("Adults", people, IsAdult);
            DisplayPeople("Seniors", people, IsSenior);

            Console.Read();
            notificationDelegate.Invoke("Example1 executed!");
        }

        private static void DisplayPeople(string title, List<Person> people, FilerByDelegate filter)
        {
            Console.WriteLine("{0}:", title);

            foreach (Person p in people)
            {
                if (filter(p))
                {
                    Console.WriteLine("{0}, {1} years old", p.Name, p.Age);
                }
            }

            Console.Write("\n\n");
        }

        static bool IsChild(Person p)
        {
            return p.Age < 18;
        }

        static bool IsAdult(Person p)
        {
            return p.Age >= 18;
        }

        static bool IsSenior(Person p)
        {
            return p.Age >= 65;
        }
    }
}
