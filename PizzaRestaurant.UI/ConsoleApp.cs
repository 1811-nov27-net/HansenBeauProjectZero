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
            AddressRepository addressRepository = new AddressRepository(dbContext);
            StoreRepository storeRepository = new StoreRepository(dbContext);

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
                if (signInFName.ToLower() == "exit" || signInLName.ToLower() == "exit")
                {
                    break;
                }
                // exception handling for not a valid sign in name
                // also include way to exit the console app

                List<User> signedInList = userRepository.GetUsersByName(signInFName, signInLName).ToList();
                User signedIn = signedInList[0];

                bool smallLoop = true;
                while (smallLoop == true)
                {
                    Console.WriteLine("What do you want to do?");
                    Console.WriteLine("o - place an order");
                    Console.WriteLine("u - look up a user");
                    Console.WriteLine("h - display order history");
                    Console.WriteLine("x - go back to login screen");
                    string choice = Console.ReadLine();
                    if (choice == "o")
                    {
                        List<Order> orderSuggestList = orderRepository.DisplayOrderHistoryUser(signedIn.userID).OrderByDescending(o => o.orderDate).ToList();
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

                            // Instantiating new order with default values
                            Order order1 = new Order();
                            order1.orderAddressID = orderSuggest.orderAddressID;
                            order1.userID = signedIn.userID;
                            order1.totalCost = 0;
                            order1.orderDate = DateTime.Now;
                            order1.storeId = orderSuggest.storeId;

                            // displaying available addresses
                            Console.WriteLine("Here are our available addresses.");
                            List<Library.Address> addressList = addressRepository.GetAddresses().ToList();
                            for (int i = 1; i < addressList.Count() + 1; i++)
                            {
                                Library.Address addresslist = addressList[i - 1];
                                string addressIdString = $"{i}: \"{addresslist.addressID}\"";
                                string addressLine1String = $"{i}: \"{addresslist.addressLine1}\"";
                                string addressLine2String = $"{i}: \"{addresslist.addressLine2}\"";
                                string addressCityString = $"{i}: \"{addresslist.city}\"";
                                string addressStateString = $"{i}: \"{addresslist.state}\"";
                                string addressZipCodeString = $"{i}: \"{addresslist.zipCode}\"";
                                Console.Write(addressIdString + " ");
                                Console.Write(addressLine1String + " ");
                                Console.Write(addressLine2String + " ");
                                Console.Write(addressCityString + " ");
                                Console.Write(addressStateString + " ");
                                Console.WriteLine(addressZipCodeString);
                            }
                            // Parsing addressID choice
                            Console.WriteLine("Please type the Address ID of the address you would like the order to be delivered to.");
                            string addressAddChoice = Console.ReadLine();
                            bool parseSuccessAddress = Int32.TryParse(addressAddChoice, out int addressAddInt);
                            while (parseSuccessAddress == false || (parseSuccessAddress == true && addressAddInt > addressList.Count()))
                            {
                                Console.WriteLine("Not a valid choice. Please enter a valid integer.");
                                Console.WriteLine("Please type the Product ID of the product you would like to add to your order.");
                                addressAddChoice = Console.ReadLine();
                                parseSuccessAddress = Int32.TryParse(addressAddChoice, out addressAddInt);
                            }
                            // adding choice to order
                            order1.orderAddressID = addressAddInt;

                            //////////////////////////////////////////////////////////////////////////////////////////
                            // displaying available stores
                            Console.WriteLine("Here are our available stores.");
                            List<Library.Store> storeList = storeRepository.GetStores().ToList();
                            for (int i = 1; i < addressList.Count() + 1; i++)
                            {
                                Library.Store storelist = storeList[i - 1];
                                string storeIDString = $"{i}: \"{storelist.storeID}\"";
                                string storeAddressLine1String = $"{i}: \"{storelist.sAddressLine1}\"";
                                string storeAddressLine2String = $"{i}: \"{storelist.sAddressLine2}\"";
                                string storeCityString = $"{i}: \"{storelist.sCity}\"";
                                string storeStateString = $"{i}: \"{storelist.sState}\"";
                                string storeZipCodeString = $"{i}: \"{storelist.sZipCode}\"";
                                Console.Write(storeIDString + " ");
                                Console.Write(storeAddressLine1String + " ");
                                Console.Write(storeAddressLine2String + " ");
                                Console.Write(storeCityString + " ");
                                Console.Write(storeStateString + " ");
                                Console.WriteLine(storeZipCodeString);
                            }
                            // Parsing storeID choice
                            Console.WriteLine("Please type the Store ID of the store you would like to order from");
                            string storeAddChoice = Console.ReadLine();
                            bool parseSuccessStore = Int32.TryParse(storeAddChoice, out int storeAddInt);
                            while (parseSuccessStore == false || (parseSuccessStore == true && storeAddInt > storeList.Count()))
                            {
                                Console.WriteLine("Not a valid choice. Please enter a valid integer.");
                                Console.WriteLine("Please type the Store ID of the store you would like to order from.");
                                storeAddChoice = Console.ReadLine();
                                parseSuccessStore = Int32.TryParse(storeAddChoice, out storeAddInt);
                            }
                            // adding choice to order
                            order1.storeId = storeAddInt;

                             ////////////////////////////////////////////////////////////////
                            // displaying available products
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

                            // deciding if user wants to add a product to order
                            Console.WriteLine("Would you like to add a product to your order? Type 'yes' or 'no'.");
                            string addAProduct = Console.ReadLine();
                            while (!(addAProduct.ToLower() == "yes" || addAProduct.ToLower() == "no"))
                            {
                                Console.WriteLine("Not an available choice.");
                                Console.WriteLine("Would you like to add a product to your order? Type 'yes' or 'no'.");
                                addAProduct = Console.ReadLine();
                            }

                            // adding product to order
                            if (addAProduct.ToLower() == "yes")
                            {
                                
                                while (addAProduct.ToLower() == "yes")
                                {
                                    // getting user input for which product to add
                                    Console.WriteLine("Please type the Product ID of the product you would like to add to your order.");
                                    string productAddChoice = Console.ReadLine();
                                    bool parseSuccessProduct = Int32.TryParse(productAddChoice, out int productAddInt);
                                    while (parseSuccessProduct == false || (parseSuccessProduct == true && productAddInt > productList.Count()))
                                    {
                                        Console.WriteLine("Not a valid choice. Please enter a valid integer.");
                                        Console.WriteLine("Please type the Product ID of the product you would like to add to your order.");
                                        productAddChoice = Console.ReadLine();
                                        parseSuccessProduct = Int32.TryParse(productAddChoice, out productAddInt);
                                    }
                                    Product productToAdd = productsRepository.GetProductByID(productAddInt);
                                    order1.AddToOrder(productToAdd);

                                    // logic to enable indefinite product adding
                                    Console.WriteLine("Would you like to add another product to your order? Type 'yes' or 'no'.");
                                    addAProduct = Console.ReadLine();
                                    while (!(addAProduct.ToLower() == "yes" || addAProduct.ToLower() == "no"))
                                    {
                                        Console.WriteLine("Not an available choice.");
                                        Console.WriteLine("Would you like to add another product to your order? Type 'yes' or 'no'.");
                                        addAProduct = Console.ReadLine();
                                    }
                                }

                                // Inserting, Saving and displaying order
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
                            //Console.WriteLine("If you only want to search by first name, leave last name blank.");
                            //Console.WriteLine("If you only want to search by last name, leave first name blank.");
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
                        Console.WriteLine("s - sort all");
                        string lookUpChoice = Console.ReadLine();
                        while (!(lookUpChoice.ToLower() == "l" || lookUpChoice.ToLower() == "u" || lookUpChoice.ToLower() == "s"))
                        {
                            Console.WriteLine("Not a valid choice. Please type either 'l', 'u', or 's'.");
                            Console.WriteLine("How do you want to look up orders?");
                            Console.WriteLine("l - location");
                            Console.WriteLine("u - user");
                            Console.WriteLine("s - sort all");
                            lookUpChoice = Console.ReadLine();
                        }
                        if (lookUpChoice.ToLower() == "l")
                        {
                            Console.WriteLine("Please provide store ID");
                            Console.Write("Store ID: ");
                            string storeIdToLookUp = Console.ReadLine();
                            bool parseSuccess = Int32.TryParse(storeIdToLookUp, out int storeIdToLookUpInt);
                            while (parseSuccess == false)
                            {
                                Console.WriteLine("Not a valid choice. Please enter a valid Store ID.");
                                Console.WriteLine("Please provide Store ID");
                                Console.Write("Store ID: ");
                                storeIdToLookUp = Console.ReadLine();
                                parseSuccess = Int32.TryParse(storeIdToLookUp, out storeIdToLookUpInt);
                            }
                            List<Order> orderHistory = orderRepository.DisplayOrderHistoryStore(storeIdToLookUpInt).ToList();
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
                        else if (lookUpChoice.ToLower() == "s")
                        {
                            Console.WriteLine("So you want to look up all users.");
                            Console.WriteLine("How would you like to sort the results?");
                            Console.WriteLine("e - earliest first");
                            Console.WriteLine("l - latest first");
                            Console.WriteLine("c - cheapest first");
                            Console.WriteLine("x - most expensive first");
                            string lookUpSortChoice = Console.ReadLine();
                            while (!(lookUpSortChoice.ToLower() == "e" || lookUpSortChoice.ToLower() == "l" || lookUpSortChoice.ToLower() == "c" || lookUpSortChoice.ToLower() == "x"))
                            {
                                Console.WriteLine("Invalid choice. Please type either 'e', 'l' 'c', or 'x'.");
                                Console.WriteLine("How would you like to sort the results?");
                                Console.WriteLine("e - earliest first");
                                Console.WriteLine("l - latest first");
                                Console.WriteLine("c - cheapest first");
                                Console.WriteLine("x - most expensive first");
                                lookUpSortChoice = Console.ReadLine();
                            }
                            List<Order> collectionOfOrders = orderRepository.DisplayOrderHistory(lookUpSortChoice).ToList();
                            foreach (var item in collectionOfOrders)
                            {
                                Console.Write("Order ID: " + item.orderID + " ");
                                Console.Write("User ID: " + item.userID + " ");
                                Console.Write("Order Address ID: " + item.orderAddressID + " ");
                                Console.Write("Total Cost: " + item.totalCost + " ");
                                Console.Write("Order DateTime: " + item.orderDate + " ");
                                Console.Write("Store ID: " + item.storeId);
                                Console.WriteLine();
                            }
                        }
                    }
                    else if (choice == "x")
                    {
                        smallLoop = false;
                    }
                }
            }
        }
    }
}
