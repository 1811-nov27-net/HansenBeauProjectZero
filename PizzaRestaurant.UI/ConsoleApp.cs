using Microsoft.EntityFrameworkCore;
using PizzaRestaurant.Library;
using PizzaRestaurant.DataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PizzaRestaurant.UI
{
    public static class ConsoleApp
    {
        public static void Main()
        {
            var optionsBuilder = new DbContextOptionsBuilder<PizzaOrdersContext>();
            optionsBuilder.UseSqlServer(SecretConfiguration.ConnectionString);
            var options = optionsBuilder.Options;

            var dbContext = new PizzaOrdersContext(options);
            UserRepository userRepository = new UserRepository(dbContext);
            OrderRepository orderRepository = new OrderRepository(dbContext);

            Console.WriteLine("Welcome to Ita D'Pizza!");
            List<Order> orderAddressList = orderRepository.DisplayOrderHistoryAddress(1).ToList();
            Console.WriteLine(orderAddressList);
            List<User> userList = userRepository.GetUsers().ToList();

            bool bigLoop = true;
            while (bigLoop == true)
            {
                for (int i = 1; i < userList.Count(); i++)
                {
                    User userlist = userList[i - 1];
                    string userString = $"{i}: \"{userlist.firstName}\"";
                    Console.WriteLine(userlist);
                }

                Console.WriteLine("Please sign in.");
                Console.Write("First Name: ");
                string signInFName = Console.ReadLine();
                Console.Write("Last Name: ");
                string signInLName = Console.ReadLine();
                List<User> signedInList = userRepository.GetUsersByName(signInFName, signInLName).ToList();
                User signedIn = signedInList[0];

                while (true)
                {
                    Console.WriteLine("What do you want to do?");
                    Console.WriteLine("o - place an order");
                    Console.WriteLine("u - look up a user");
                    Console.WriteLine("h - display order history");
                    Console.WriteLine("s - save to disk");
                    Console.WriteLine("l - load from disk");
                    Console.WriteLine("x - exit the console application");
                    string choice = Console.ReadLine();
                    if (choice == "o")
                    {
                        List<Order> orderSuggestList = orderRepository.DisplayOrderHistoryUser(signedIn.userID).ToList();
                        Order orderSuggest = orderSuggestList[0];
                        Console.WriteLine("So you want to place an order?");
                        Console.WriteLine("Your most recent order on record is ");
                        Console.WriteLine(orderSuggest);
                        Console.WriteLine("Would you like to resubmit this order? Type 'yes' or 'no'.");
                        string resubmit = Console.ReadLine();
                        while (resubmit.ToLower() == "yes" || resubmit.ToLower() == "no")
                        {
                            if (resubmit.ToLower() == "yes")
                            {
                                Order order1 = new Order();
                                for (int i = 0; i < orderSuggest.orderProducts.Count(); i++)
                                {
                                    Product productToAdd = orderSuggest.orderProducts[i];
                                    order1.AddToOrder(productToAdd);
                                }
                            }
                            else if (resubmit.ToLower() == "no")
                            {
                                Console.WriteLine("Okay, we will buuild a new order for you.");
                                Console.WriteLine("Here are our available products.");

                            }
                            else
                            {
                                Console.WriteLine("Not an available choice.");
                                Console.WriteLine("Would you like to resubmit this order? Type 'yes' or 'no'.");
                                resubmit = Console.ReadLine();
                            }
                        }
                        

                    }
                    else if (choice == "u")
                    {

                    }
                    else if (choice == "h")
                    {

                    }
                    else if (choice == "s")
                    {

                    }
                    else if (choice == "l")
                    {

                    }
                    else if (choice == "x")
                    {
                        break;
                    }

                    //string signInfName = dbContext.Users.Where(u => u.FirstName == signInfName)
                }
            }
        }
    }
}
