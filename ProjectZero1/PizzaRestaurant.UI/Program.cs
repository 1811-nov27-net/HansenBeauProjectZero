using System;
using PizzaRestaurant.Library;

namespace PizzaRestaurant.UI
{
    class Program
    {
        static void Main()
        {
            User sut = new User("Beau");
            Console.WriteLine("Constructed First Name for sut is " + sut.fName + "more text here");
        }
    }
}
