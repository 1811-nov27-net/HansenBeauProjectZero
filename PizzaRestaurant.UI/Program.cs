using System;
using PizzaRestaurant.Library;
using System.Collections.Generic;
using PizzaRestaurant.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Xml.Serialization;

namespace PizzaRestaurant.UI
{
    public static class Program
    {
        public static void Main()
        {
            DbContextOptionsBuilder<PizzaOrdersContext> optionsBuilder = new DbContextOptionsBuilder<PizzaOrdersContext>();
            optionsBuilder.UseSqlServer(SecretConfiguration.ConnectionString);
            DbContextOptions<PizzaOrdersContext> options = optionsBuilder.Options;

            PizzaOrdersContext dbContext = new PizzaOrdersContext(options);
            UsersRepository userRepo = new UsersRepository(dbContext);
            //XmlSerializer serializer = new XmlSerializer(typeof(List<Users>));

            Console.WriteLine("Welcome to the user interface for 'Pizza Store'");

            Console.WriteLine("Please sign in");
            Console.Write("First Name: ");
            string fName = Console.ReadLine();
            Console.Write("Last Name: ");
            string lName = Console.ReadLine();
            string userName = fName + lName;
            //Users prevUser = dbContext.Users.Find();

            User newUser = new User(fName, lName);
            userRepo.AddUser(newUser);
            Console.WriteLine("{0}, {1} add as a new user, fName, lName");

            Console.WriteLine("What do you want to do?");
            Console.WriteLine("o - place an order");
            Console.WriteLine("u - look up a user");
            Console.WriteLine("h - display order history");
            Console.WriteLine("s - save to disk");
            Console.WriteLine("l - load from disk");
            string choice = Console.ReadLine();

            while (true)
            {
                if (choice.ToLower().Equals("o"))
                {
                    //purpose of if conditional here is to allow us treat new
                    //users differently than we treat old users.
                    //for example, we can offer to a new user a previous order
                    //if (prevUser == false)
                    //    {
                    //        Order ord = new Order(userName, userLocation1, userLocation2, userLocation3);
                    //        orderData.Add(ord);
                    //    }
                    //    else if (prevUser == true)
                    //    {
                    //        Console.WriteLine("You have placed an order with us before.");
                    //        Console.WriteLine("Would you like ");
                    //    }
                }
                else if (choice.ToLower().Equals("u"))
                {

                    //List<User> dispUsers = userRepo.GetUsers();
                    //foreach (var item in dispUsers)
                    //{
                    //    Console.WriteLine("{0}",item);
                    //}
                }
                else if (choice.ToLower().Equals("h"))
                {

                }
                else if (choice.ToLower().Equals("s"))
                {

                }
                else if (choice.ToLower().Equals("l"))
                {

                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
            }

        }

        
    }
}
