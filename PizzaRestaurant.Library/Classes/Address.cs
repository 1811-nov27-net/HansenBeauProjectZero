using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaRestaurant.Library
{
    public class Address
    {
        private int _addressID;
        public int addressID { get; set; }

        private int _userID;
        public int userID { get; set; }

        private string _addressLine1;
        public string addressLine1 { get; set; }

        private string _addressLine2;
        public string addressLine2 { get; set; }

        private string _city;
        public string city { get; set; }

        private string _state;
        public string state { get; set; }

        private int _zipCode;
        public int zipCode { get; set; }
    }
}
