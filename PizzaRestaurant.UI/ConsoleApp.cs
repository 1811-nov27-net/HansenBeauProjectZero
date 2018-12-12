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
            ProductsRepository productsRepository = new ProductsRepository(dbContext);

            Console.WriteLine("Welcome to Ita D'Pizza!");
            List<Order> orderAddressList = orderRepository.DisplayOrderHistoryAddress(1).ToList();
            Console.WriteLine(orderAddressList);
            List<User> userList = userRepository.GetUsers().ToList();

            bool bigLoop = true;
            while (bigLoop == true)
            {
                for (int i = 1; i < userList.Count() + 1; i++)
                {
                    User userlist = userList[i - 1];
                    string userFirstNameString = $"{i}: \"{userlist.firstName}\"";
                    string userLastNameString = $"\"{userlist.lastName}\"";
                    Console.Write(userFirstNameString + " ");
                    Console.Write(userLastNameString);
                    Console.WriteLine();
                }

                Console.WriteLine("Please sign in.");
                Console.WriteLine("To exit, type 'exit' as either a first name or a last name");
                Console.Write("First Name: ");
                string signInFName = Console.ReadLine();
                Console.Write("Last Name: ");
                string signInLName = Console.ReadLine();
                // exception handling for not a valid sign in name
                // also include way to exit the console app
                List<User> signedInList = userRepository.GetUsersByName(signInFName, signInLName).ToList();
                User signedIn = signedInList[0];

                while (true)
                {
                    Console.WriteLine("What do you want to do?");
                    Console.WriteLine("o - place an order");
                    Console.WriteLine("u - look up a user");
                    Console.WriteLine("h - display order history");
                    Console.WriteLine("s - save to database");
                    Console.WriteLine("l - load from database");
                    Console.WriteLine("x - exit the console application");
                    string choice = Console.ReadLine();
                    if (choice == "o")
                    {
                        List<Order> orderSuggestList = orderRepository.DisplayOrderHistoryUser(signedIn.userID).ToList();
                        Order orderSuggest = orderSuggestList[0];
                        Console.WriteLine("So you want to place an order?");
                        Console.WriteLine("Your most recent order on record is ");
                        string orderSuggestID = $"\"{"Order ID: " + orderSuggest.orderID}\"";

                        string orderSuggestTotalCost = $"\"{"Total Cost: " + orderSuggest.totalCost}\"";
                        string orderSuggestStoreID = $"\"{"Store ID: " + orderSuggest.storeId}\"";
                        Console.WriteLine(orderSuggestID);
                        Console.Write("Products ");
                        // what is there is no previous order? simple loop/conditional
                        // still need to figure out how to populate orderProducts from OrderHeader
                        List<Product> productListToPrint = orderRepository.GetProductsOfOrderByID(orderSuggest.orderID).ToList();
                        foreach (var item in productListToPrint)
                        {
                            Console.Write(item.productName + " ");
                        }
                        Console.WriteLine(orderSuggestTotalCost);
                        Console.WriteLine(orderSuggestStoreID);
                        Console.WriteLine("Would you like to resubmit this order? Type 'yes' or 'no'.");
                        string resubmit = Console.ReadLine();
                        while (!(resubmit.ToLower() == "yes" || resubmit.ToLower() == "no"))
                        {
                            Console.WriteLine("Not an available choice.");
                            Console.WriteLine("Would you like to resubmit this order? Type 'yes' or 'no'.");
                            resubmit = Console.ReadLine();
                        }
                        if (resubmit.ToLower() == "yes")
                        {
                            Order order1 = new Order();
                            order1.orderAddressID = orderSuggest.orderAddressID;
                            order1.userID = signedIn.userID;
                            order1.totalCost = 0;
                            order1.orderDate = DateTime.Now;
                            order1.storeId = orderSuggest.storeId;
                            List<Product> listOfProductsToAdd = orderRepository.GetProductsOfOrderByID(orderSuggest.orderID).ToList();
                            foreach (var item in listOfProductsToAdd)
                            {
                                order1.AddToOrder(item);
                            }
                            Console.WriteLine("Successfully recreated the order");
                            Console.WriteLine("Your order details");
                            orderRepository.InsertOrder(order1);
                            orderRepository.Save();
                            orderRepository.DisplayOrderDetailsByOrderID(orderRepository.getLastId());
                        }
                        else if (resubmit.ToLower() == "no")
                        {
                            Console.WriteLine("Okay, we will build a new order for you.");
                            Order order1 = new Order();

                            order1.orderAddressID = orderSuggest.orderAddressID;
                            order1.userID = signedIn.userID;
                            order1.totalCost = 0;
                            order1.orderDate = DateTime.Now;
                            order1.storeId = orderSuggest.storeId;
                            Console.WriteLine("Here are our available products.");
                            List<Product> productList = productsRepository.GetProducts().ToList();
                            for (int i = 1; i < productList.Count() + 1; i++)
                            {
                                Product productlist = productList[i - 1];
                                string productIdString = $"{i}: \"{productlist.productName}\"";
                                string productNameString = $"{i}: \"{productlist.productName}\"";
                                Console.Write(productIdString + " ");
                                Console.WriteLine(productNameString);
                            }
                            Console.WriteLine("Would you like to add a product to your order? Type 'yes' or 'no'.");
                            string addAProduct = Console.ReadLine();
                            while (!(addAProduct.ToLower() == "yes" || addAProduct.ToLower() == "no"))
                            {
                                Console.WriteLine("Not an available choice.");
                                Console.WriteLine("Would you like to add a product to your order? Type 'yes' or 'no'.");
                                addAProduct = Console.ReadLine();
                            }
                            if (addAProduct.ToLower() == "yes")
                            {
                                
                                while (addAProduct.ToLower() == "yes")
                                {
                                    Console.WriteLine("Please type the Product ID of the product you would like to add to your order.");
                                    string productAddChoice = Console.ReadLine();
                                    bool parseSuccess = Int32.TryParse(productAddChoice, out int productAddInt);
                                    while (parseSuccess == false || (parseSuccess == true && productAddInt > productList.Count()))
                                    {
                                        Console.WriteLine("Not a valid choice. Please enter a valid integer.");
                                        Console.WriteLine("Please type the Product ID of the product you would like to add to your order.");
                                        productAddChoice = Console.ReadLine();
                                        parseSuccess = Int32.TryParse(productAddChoice, out productAddInt);
                                    }
                                    Product productToAdd = productsRepository.GetProductByID(productAddInt);
                                    order1.AddToOrder(productToAdd);
                                    Console.WriteLine("Would you like to add another product to your order? Type 'yes' or 'no'.");
                                    addAProduct = Console.ReadLine();
                                    while (!(addAProduct.ToLower() == "yes" || addAProduct.ToLower() == "no"))
                                    {
                                        Console.WriteLine("Not an available choice.");
                                        Console.WriteLine("Would you like to add another product to your order? Type 'yes' or 'no'.");
                                        addAProduct = Console.ReadLine();
                                    }
                                }
                                orderRepository.InsertOrder(order1);
                                orderRepository.Save();
                                orderRepository.DisplayOrderDetailsByOrderID(orderRepository.getLastId());
                            }
                        }
                    }
                    else if (choice == "u")
                    {
                        Console.WriteLine("So you want to look up a user?");
                        Console.WriteLine("How do you want to look up?");
                        Console.WriteLine("n - Look up by name");
                        Console.WriteLine("i - Look up by user ID");
                        string lookUpChoice = Console.ReadLine();
                        while (!(lookUpChoice.ToLower() == "n" || lookUpChoice.ToLower() == "i"))
                        {
                            Console.WriteLine("Invalid choice. Please select either 'n' or 'i'.");
                            Console.WriteLine("How do you want to look up?");
                            Console.WriteLine("n - Look up by name");
                            Console.WriteLine("i - Look up by user ID");
                            lookUpChoice = Console.ReadLine();
                        }
                        if (lookUpChoice.ToLower() == "n")
                        {
                            Console.WriteLine("To look up by name, type the first name and last name.");
                            Console.WriteLine("If you only want to search by first name, leave last name blank.");
                            Console.WriteLine("If you only want to search by last name, leave first name blank.");
                            Console.Write("First Name: ");
                            string inputFirstNameSearch = Console.ReadLine();
                            Console.Write("Last Name: ");
                            string inputLastNameSearch = Console.ReadLine();
                            List<User> returnedUsers = userRepository.GetUsersByName(inputFirstNameSearch, inputLastNameSearch).ToList();
                            for (int i = 1; i < returnedUsers.Count() + 1; i++)
                            {
                                int displayUserID = returnedUsers[i - 1].userID;
                                string displayUserFirstName = returnedUsers[i - 1].firstName;
                                string displayUserLastName = returnedUsers[i - 1].lastName;
                                Console.WriteLine(displayUserID + " " + displayUserFirstName + " " + displayUserLastName);
                            }
                        }
                        //else if (lookUpChoice.ToLower() == "i")
                        //{
                        //    Console.WriteLine("To look up by user ID, type the user ID");
                        //    Console.Write("User ID: ");
                        //    string inputUserIDSearch = Console.ReadLine();
                        //    bool parseSuccess = Int32.TryParse(inputUserIDSearch, out int userIdSearchInt);
                        //    while (parseSuccess == false)
                        //    {
                        //        Console.WriteLine("Not a valid choice. Please enter a valid integer.");
                        //        Console.WriteLine("To look up by user ID, type the user ID");
                        //        Console.Write("User ID: ");
                        //        inputUserIDSearch = Console.ReadLine();
                        //        parseSuccess = Int32.TryParse(inputUserIDSearch, out userIdSearchInt);
                        //    }
                        //}
                    }
                    else if (choice == "h")
                    {
                        Console.WriteLine("So you want to look up order history.");
                        Console.WriteLine("How do you want to look up orders?");
                        Console.WriteLine("l - location");
                        Console.WriteLine("u - user");
                        string lookUpChoice = Console.ReadLine();
                        while (!(lookUpChoice.ToLower() == "l" || lookUpChoice.ToLower() == "u"))
                        {
                            Console.WriteLine("Not a valid choice. Please type either 'l' or 'u'.");
                            Console.WriteLine("How do you want to look up orders?");
                            Console.WriteLine("l - location");
                            Console.WriteLine("u - user");
                            lookUpChoice = Console.ReadLine();
                        }
                        if (lookUpChoice.ToLower() == "l")
                        {

                        }
                        else if (lookUpChoice.ToLower() == "u")
                        {
                            Console.WriteLine("Please provide User ID");
                            Console.Write("User ID: ");
                            string userIdToLookUp = Console.ReadLine();
                            bool parseSuccess = Int32.TryParse(userIdToLookUp, out int userIdToLookUpInt);
                            while (parseSuccess == false)
                            {
                                Console.WriteLine("Not a valid choice. Please enter a valid User ID.");
                                Console.WriteLine("Please provide User ID");
                                Console.Write("User ID: ");
                                userIdToLookUp = Console.ReadLine();
                                parseSuccess = Int32.TryParse(userIdToLookUp, out userIdToLookUpInt);
                            }
                            List<Order> orderHistory = orderRepository.DisplayOrderHistoryUser(userIdToLookUpInt).ToList();
                            Console.Write("(Order ID) ");
                            Console.Write("(Order Address ID) ");
                            Console.Write("(Total Cost) ");
                            Console.Write("(Order DateTime) ");
                            Console.Write("(Order Store ID) ");
                            Console.WriteLine();
                            for (int i = 1; i < orderHistory.Count() + 1; i++)
                            {
                                Order orderhistory = orderHistory[i - 1];
                                string orderIdString = $"{i}: \"{orderhistory.orderID}\"";
                                string orderAddressIdString = $"\"{orderhistory.orderAddressID}\"";
                                string orderTotalCostString = $"\"{orderhistory.totalCost}\"";
                                string orderDateTimeString = $"\"{orderhistory.orderDate}\"";
                                string orderStoreIdString = $"\"{orderhistory.storeId}\"";
                                Console.Write(orderIdString + " ");
                                Console.Write(orderAddressIdString + " ");
                                Console.Write(orderTotalCostString + " ");
                                Console.Write(orderDateTimeString + " ");
                                Console.Write(orderStoreIdString + " ");
                                Console.WriteLine();
                            }
                        }
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
