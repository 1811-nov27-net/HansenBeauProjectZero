using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaRestaurant.Library
{
    public class Order
    {

        // constructor sets name of order recipient and delivery address 
        // to the user's first name + last name and user's location,
        // respectively
        public Order()
        {
           
        }

        public Order(string inputName, string inputLoc1, string inputLoc2, string inputLoc3)
        {
            _deliveryName = inputName;
            _location1 = inputLoc1;
            _location2 = inputLoc2;
            _location3 = inputLoc3;
        }

        List<string> OrderList = new List<string>();

        private string _deliveryName = "";
        public string deliveryName
        {
            get => _deliveryName;
            set
            {
                if (value != null)
                {
                    _deliveryName = value;
                }
                else
                {
                    Console.WriteLine("Cannot have a null Delivery Name");
                }
            }
        }

        private string _deliveryLocation = "";
        public string deliveryLocation
        {
            get => _deliveryLocation;
            set
            {
                if (value != null)
                {
                    _deliveryLocation = value;
                }
                else
                {
                    Console.WriteLine("Cannot have a null Delivery Location");
                }
            }
        }

        private string _defaultFName;
        public string defaultFName
        {
            get => _defaultFName;
            set
            {
                if (value != "" && value != null)
                {
                    _defaultFName = value;
                };
            }
        }

        private string _defaultLName;
        public string defaultLName
        {
            get => _defaultLName;
            set
            {
                if (value != "" && value != null)
                {
                    _defaultLName = value;
                };
            }
        }

        private string _location1;
        public string location1
        {
            get => _location1;
            set
            {
                if (value != null)
                {
                    _location1 = value;
                }
                else
                {
                    _location1 = "";
                };
            }
        }

        private string _location2;
        public string location2
        {
            get => _location2;
            set
            {
                if (value != null)
                {
                    _location2 = value;
                }
                else
                {
                    _location2 = "";
                };
            }
        }
        private string _location3;
        public string location3
        {
            get => _location3;
            set
            {
                if (value != null)
                {
                    _location3 = value;
                }
                else
                {
                    _location3 = "";
                };
            }
        }

        public readonly DateTime orderTime = new DateTime();

        /// <summary>
        /// This method should 
        /// First: finalize the order by verifying that all required fields
        ///     filled. It should also check to make sure all requested
        ///     menu items and ingredients are in stock. Probably 
        ///     should try to place a hold on them so that near-
        ///     simultaneuos order submissions cannot cause us to run out
        ///     of ingredients.
        /// Second: If any more work needs to be done, this method 
        ///     should do it, whether it be asking User to fillin
        ///     missing data.
        /// Third: Set orderTime to presetn time.
        ///        Send the information to a database to be fulfilled and stored
        /// 
        /// Consider building separate methods to implement into SubmitOrder()
        /// in order to have cleaner code (SOLID)
        /// </summary>
        public void SubmitOrder()
        {
            this.CheckDelName();
            this.CheckDelLocation();

        }

        /// <summary>
        /// Method used to check if there is a valid Delivery Name for the
        /// order, display what it is, and change it if need be.
        /// </summary>
        public void CheckDelName()
        {
            if (_deliveryName.Length > 0)
            {
                Console.WriteLine("We have {0} as the name for the delivery. Is this okay? 'Yes' or 'No'", _deliveryName);
                string choice = Console.ReadLine();
                while (!(choice.ToLower().Equals("yes") || choice.ToLower().Equals("no")))
                {
                    Console.WriteLine("Not a valid choice. Please type either 'Yes' or 'No'");
                    Console.WriteLine("We have {0} as the name for the delivery. Is this okay? 'Yes' or 'No'", _deliveryName);
                    choice = Console.ReadLine();
                }
                if (choice.ToLower().Equals("no"))
                {
                    Console.WriteLine("What name should we use as delivery name?");
                    _deliveryName = Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("We do not have a Delivery Name for this order.");
                Console.WriteLine("Which name should we put on the order?");
                string choice = Console.ReadLine();
                while (choice == null)
                {
                    Console.WriteLine("Not a valid choice. Please type a name for the order.");
                    choice = Console.ReadLine();
                }
                Console.WriteLine("What name should we use as delivery name?");
                _deliveryName = Console.ReadLine();
            }
        }

        /// <summary>
        /// Method used to check if there is a valid Delivery Name for the
        /// order, display what it is, and change it if need be.
        /// </summary>
        public void CheckDelLocation()
        {
            if (_deliveryLocation.Length > 0)
            {
                Console.WriteLine("We have {0} as the address for the delivery. Is this okay? 'Yes' or 'No'", _deliveryName);
                string choice = Console.ReadLine();
                while (!(choice.ToLower().Equals("yes") || choice.ToLower().Equals("no")))
                {
                    Console.WriteLine("Not a valid choice. Please type either 'Yes' or 'No'");
                    Console.WriteLine("We have {0} as the name for the delivery. Is this okay? 'Yes' or 'No'", _deliveryName);
                    choice = Console.ReadLine();
                }
                if (choice.ToLower().Equals("no"))
                {
                    Console.WriteLine("What address should we deliver to?");
                    Console.WriteLine("Address line 1");
                    Console.WriteLine("Example: 1111 Street Name Lane");
                    string inputAddress1 = Console.ReadLine();
                    Console.WriteLine("Address line 2");
                    Console.WriteLine("Example: Arlington, TX 76019");
                    string inputAddress2 = Console.ReadLine();
                    _deliveryLocation = inputAddress1 + inputAddress2;

                }
            }
            else
            {
                Console.WriteLine("We do not have a Delivery Name for this order.");
                Console.WriteLine("Which name should we put on the order?");
                string choice = Console.ReadLine();
                while (choice == null)
                {
                    Console.WriteLine("Not a valid choice. Please type a name for the order.");
                    choice = Console.ReadLine();
                }
                Console.WriteLine("What name should we use as delivery name?");
                _deliveryName = Console.ReadLine();
            }
        }

        public void AddItem(string itemToAdd)
        {

        }
        
        public void AddPizza()
        {

        }

        public void AddItem()
        {
            Console.WriteLine("Here are the availible items to add {0}");
            Console.WriteLine("Would you like to add an item to your order? Type 'Yes' or 'No'.");
            string choice = Console.ReadLine();
            while (!(choice.ToLower().Equals("yes") || choice.ToLower().Equals("no")))
            {
                Console.WriteLine("Not a valid choice. Please type either 'Yes' or 'No'");
                Console.WriteLine("Here are the availible items to add {0}");
                Console.WriteLine("Would you like to add an item to your order? Type 'Yes' or 'No'.");
                choice = Console.ReadLine();
            }
            if (choice.ToLower().Equals("yes"))
            {
                Console.WriteLine("Which item would you like to add?");
                string menuItem = Console.ReadLine();

            }
        }


    }
}
