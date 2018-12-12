using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaRestaurant.Library
{
    public class Product
    {
        public Product()
        {

        }

        public Product(int inputId)
        {
            productID = inputId;
        }

        public int productID { get; set; }

        public string productName { get; set; }

        public int unitPrice { get; set; }

        public ICollection<OrderDetail> orderDetail { get; set; }
    }
}
