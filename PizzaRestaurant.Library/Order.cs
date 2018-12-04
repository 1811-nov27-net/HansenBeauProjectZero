using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaRestaurant.Library
{
    public class Order
    {
        // I want the only way to instantiate Order to be the 
        // User.StartOrder method

        // constructor sets name of order recipient and delivery address 
        // to the user's first name + last name and user's location,
        // respectively
        public Order()
        {
            string _deliveryName = _defaultFName + " " + _defaultLName;
            string _deliveryAddress = _defaultLocation;
        }

        // constructor sets name 
        public Order(string inputLocation)
        {
            string _deliveryAddress = inputLocation;
        }

        public Order(string inputFName, string inputLName)
        {
            string _deliveryName = inputFName + " " + inputLName;
        }

        public Order(string inputFName, string inputLName, string inputLocation)
        {
            string _deliveryName = inputFName + " " + inputLName;
            string _deliveryAddress = inputLocation;
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

        private string _defaultLocation;
        public string defaultLocation
        {
            get => _defaultLocation;
            set
            {
                if (value != "" && value != null)
                {
                    _defaultLocation = value;
                };
            }
        }
    }
}
