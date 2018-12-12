using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaRestaurant.Library
{
    public class Address
    {
        public int addressID { get; set; }

        public int userID { get; set; }

        public string addressLine1 { get; set; }

        public string addressLine2 { get; set; }

        public string city { get; set; }

        public string state { get; set; }

        public int zipCode { get; set; }
    }
}
