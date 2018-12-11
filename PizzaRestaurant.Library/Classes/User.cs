using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaRestaurant.Library
{
    public class User
    {
        private int _userID;
        public int userID { get; set; }

        private string _firstName;
        public string firstName { get; set; }

        private string _lastName;
        public string lastName { get; set; }

        private int _defaultAddressID;
        public int defaultAddressID { get; set; }
    }
}
