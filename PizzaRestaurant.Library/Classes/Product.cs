using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaRestaurant.Library
{
    public class Product
    {
        private int _productID;
        public int productID { get; set; }

        private string _productName;
        public string productName { get; set; }

        private int _unitPrice;
        public int unitPrice { get; set; }
    }
}
